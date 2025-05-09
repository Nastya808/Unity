using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatesScript : MonoBehaviour
{
    public static bool isOpen = false;
    private GameObject content;

    private float openingTime = 5.0f; // Час повного відкриття
    private float openSize = 1.0f;    // Наскільки далеко відкривається

    private float openedAmount = 0f;

    private void Start()
    {
        content = transform.Find("Content").gameObject;
        GameEvents.Subscribe(OnGameEvent);
    }

    private void Update()
    {
        if (isOpen)
        {
            // Поки ворота ще не відкриті повністю
            if (openedAmount < openSize)
            {
                float step = (openSize / openingTime) * Time.deltaTime;
                content.transform.Translate(step, 0f, 0f);
                openedAmount += step;
            }
            else
            {
                // Ворота відкриті повністю — знищуємо об'єкт
                Destroy(gameObject);
            }
        }
    }


    private void OnGameEvent(GameEvent e)
    {
        if (e.name == "Key1")
        {
            isOpen = true;
        }
    }

    private void OnDestroy()
    {
        GameEvents.UnSubscribe(OnGameEvent);
    }
}
