using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public static bool isFpv;

    void Start()
    {
        isFpv = false;
    }

    void Update()
    {
        // Нажатие на клавишу V переключает режим камеры
        if (Input.GetKeyDown(KeyCode.V))
        {
            isFpv = !isFpv;
        }
    }
}