using System;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents
{
    private static List<Action<GameEvent>> subscribers = new List<Action<GameEvent>>();

    // Метод для подписки на событие
    public static void Subscribe(Action<GameEvent> action)
    {
        if (action != null && !subscribers.Contains(action))
        {
            subscribers.Add(action);
        }
    }

    public static void UnSubscribe(Action<GameEvent> action)
    {
        if (action != null && !subscribers.Contains(action))
        {
            subscribers.Remove(action);
        }
    }

    // Метод для вызова события
    public static void EmitEvent(GameEvent e)
    {
        foreach (var action in subscribers)
        {
            action.Invoke(e);
        }
    }
}