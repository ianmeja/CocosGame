using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    public Animator ani;
    public Enemy enemy;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            if (!enemy.stuneado){
                ani.SetBool("walk", false);
                ani.SetBool("run", false);
                ani.SetBool("attack", true);
                enemy.attack = true;
                GetComponent<CapsuleCollider>().enabled = false;
            }
        }
    }
}