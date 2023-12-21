using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int _health = 20;

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            if(other.gameObject.GetComponent<Actor>() != null)
                other.gameObject.GetComponent<Actor>().GainHealth(_health);
        
            Destroy(gameObject);
        }
    }
}
