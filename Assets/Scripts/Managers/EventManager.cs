using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EVENT_TYPE { WEATHER_UPDATED }

public class EventManager : MonoBehaviour
{
    private static EventManager _instance = null;

    public static EventManager Instance
    {
        get
        {
            return _instance;
        }
        private set
        {
        }
    }

    // Тип делегата, обрабатывающего события
    public delegate void OnEvent(EVENT_TYPE eventType, Component sender, object param = null);

    // Получатели
    private Dictionary<EVENT_TYPE, List<OnEvent>> _allListeners = new Dictionary<EVENT_TYPE, List<OnEvent>>();

    void Awake()      
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }

        SceneManager.sceneLoaded += this.OnLeveLoadCallback;     // подписка на встроенное событие sceneLoaded 
    }
    /// <summary>
    /// Подписывает слушателя на событие
    /// </summary>
    /// <param name="eventType">Ожидаемое событие</param>
    /// <param name="listener">Объект-слушатель</param>
    public void AddListener(EVENT_TYPE eventType, OnEvent listener)
    {
        // список получателей для данного события
        List<OnEvent> eventListeners = null;       // ListenList

        // Если событие существует, добавить слушателя в список
        if (_allListeners.TryGetValue(eventType, out eventListeners))
        {
            eventListeners.Add(listener);
            return;
        }

        // или создать новое события
        eventListeners = new List<OnEvent>();
        eventListeners.Add(listener);
        _allListeners.Add(eventType, eventListeners);
    }
  
    /// <summary>
    /// Посылает события получателям
    /// </summary>
    /// <param name="eventType">Событие для вызова</param>
    /// <param name="sender">Вызываемый объект</param>
    /// <param name="param">Необязательный аргумент</param>
   public void PostNotification(EVENT_TYPE eventType, Component sender, object param = null)
    {
        //Список слушателей данного события
        List<OnEvent> eventListeners = null;

        // Если получателей нет - выйти
        if(!_allListeners.TryGetValue(eventType, out eventListeners))
        {
            Debug.LogWarning("No listeners event: " + eventType);
            return;
        }

        // Если получатели есть, послать им событие

        foreach (var listener in eventListeners)           // возможна ошибка
        {
            listener(eventType, sender, param);
        }   
    }

    // Удаляет событие из словаря, включая всех получателей
    public void RemoveEvent(EVENT_TYPE eventType)
    {
        // Удалить запись из словаря
        _allListeners.Remove(eventType);
    }

    public void RemoveRedundancies()
    {
        // Инициализировать новый словарь
        var tmpListeners = new Dictionary<EVENT_TYPE, List<OnEvent>>();

        // Обойти все записи в словаре
        foreach (KeyValuePair<EVENT_TYPE, List<OnEvent>> item in _allListeners)
        {
            for (int i = item.Value.Count - 1; i >= 0; i--)
            {
                // Если ссылка пустая, удалить элемент
                if(item.Value[i].Equals(null))
                {
                    item.Value.RemoveAt(i);
                }
            }

            //Если в списке остались элементы (слушатели), добавить их в словарь tmp
            if(item.Value.Count > 0)
            {
                tmpListeners.Add(item.Key, item.Value);
            }
        }

        _allListeners = tmpListeners;
    }

    // Вызывается автоматически при смене сцены. Очищает словарь
    private void OnLeveLoadCallback(Scene scene, LoadSceneMode sceneMode)
    {
        RemoveRedundancies();
    }
}
