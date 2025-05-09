using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key1Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            GameEvents.EmitEvent(new GameEvent { name = "Key1", toast = "Key 1 Collected. Gates 1 opening" });
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("Key1Script Destroyed");
    }
}
