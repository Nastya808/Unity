using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Gates1ContentScript : MonoBehaviour
{
    public static bool isOpen = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player" && !isOpen)
        {
            GameEvents.EmitEvent(new GameEvent
            {
                toast = "Closed! Look for key 1"
            });
        }
    }
}
