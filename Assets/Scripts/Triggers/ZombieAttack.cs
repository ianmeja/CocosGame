using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;

public class ZombieAttack : MonoBehaviour
{
    private CapsuleCollider _col;
    private Animator _ani;
    public EnemyStats Stats => stats;
    [SerializeField] protected EnemyStats stats;
    [SerializeField] protected Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        _col = GetComponent<CapsuleCollider>();
        _ani = GetComponentInParent<Animator>();
    }

    #region ATTACK
    private void EndAnimation(){
        _col.enabled = true;
        _ani.SetBool("attack", false);
        _ani.SetBool("walk", true);
    }

    private void OnTriggerEnter(Collider other){
        if(enemy._dead) return;

        if(other.CompareTag("Player")){
            _col.enabled = false;

            _ani.SetBool("attack", true);
            _ani.SetBool("walk", false);
            EventsManager.instance.ZombieAttack();

            other.gameObject.GetComponent<Actor>().TakeDamage(stats.Damage);

            Invoke("EndAnimation", 1.8f);
        }
    }
    #endregion
}
