using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageable
{
    private Animator _ani;
    private GameObject _target;
    private NavMeshAgent _enemy;
    public bool _dead;

    #region IDAMAGEABLE_PROPERTIES
    public EnemyStats Stats => stats;
    [SerializeField] protected EnemyStats stats;
    [SerializeField] private int _life;

    public int MaxLife => stats.MaxLife;
    public int Damage => stats.Damage;
    public int Life => _life;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        _life = MaxLife;
        _dead = false;
        _ani = GetComponent<Animator>();
        _enemy = GetComponent<NavMeshAgent>();
        _target = GameObject.Find("TT_demo_police");
        _ani.SetBool("walk", true);
        EventsManager.instance.OnLevelChange += Die;
    }

    // Update is called once per frame
    void Update()
    {
        if(_target != null){
            _enemy.SetDestination(_target.transform.position);
        }
        else{
            _target = GameObject.Find("TT_demo_police");
        }
    }

    #region IDAMAGEABLE_METHODS
    public void TakeDamage(int damage)
    {
        _life -= damage;
        Debug.Log($"Zombie {name} Hit -> Life {_life}!");
        if(_life <= 0) Die();
    }

    public void Die()
    {
        if(_dead) return;

        _dead = true;
        _ani.SetBool("walk", false);
        _ani.SetBool("attack", false);
        _ani.SetBool("die", true);

        Debug.Log($"{name} Died!!!!");
        Invoke("ZDestroy", 1.8f);
    }
    private void ZDestroy(){
        Destroy(gameObject);
    }
    #endregion
}
