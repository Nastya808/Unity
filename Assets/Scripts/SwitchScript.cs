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
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFpv = !isFpv;
        }
    }
}