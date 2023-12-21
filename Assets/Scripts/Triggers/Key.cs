using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public static bool _hasKey = false;

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            _hasKey = true;
            EventsManager.instance.EventGetKey();
            
            Destroy(gameObject);
        }
    }
}
