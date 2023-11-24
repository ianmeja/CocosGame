using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    private CapsuleCollider _col;

    // Start is called before the first frame update
    void Start()
    {
        _col = GetComponent<CapsuleCollider>();
    }

    #region ATTACK
    private void EnableCollider(){
        _col.enabled = true; 
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            _col.enabled = false;
            EventsManager.instance.ZombieAttack(other);
            Invoke("EnableCollider", 2.0f);
        }
    }
    #endregion
}
