using System;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents
{
    private static List<Action<string>> subscribers = new List<Action<string>>();

    // Метод для подписки на событие
    public static void Subscribe(Action<string> action)
    {
        if (action != null && !subscribers.Contains(action))
        {
            subscribers.Add(action);
        }
    }

    public static void UnSubscribe(Action<string> action)
    {
        if (action != null && !subscribers.Contains(action))
        {
            subscribers.Remove(action);
        }
    }

    // Метод для вызова события
    public static void EmitEvent(string e)
    {
        foreach (var action in subscribers)
        {
            action.Invoke(e);
        }
    }
}