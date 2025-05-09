using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class KeysScript : MonoBehaviour
{
    private Image Key1Image;
    // Start is called before the first frame update
    void Start()
    {
        Key1Image = transform.Find("Key1Image").GetComponent<Image>();
        Key1Image.enabled = false;
        GameEvents.Subscribe(OnGameEvent);


    }

    private void OnGameEvent(GameEvent e)
    {
        if (e.name == "Key1")
        {
            Key1Image.enabled = true;
        }
    }

    private void OnDestroy()
    {
        GameEvents.UnSubscribe(OnGameEvent);
    }
}
