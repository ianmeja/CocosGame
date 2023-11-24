using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageable
{
    private Animator _ani;
    private GameObject _target;
    [SerializeField] private NavMeshAgent _enemy;

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
        _ani = GetComponent<Animator>();
        _enemy = GetComponent<NavMeshAgent>();
        _target = GameObject.Find("TT_demo_police");
        EventsManager.instance.OnZombieAttack += OnZombieAttack;
        _ani.SetBool("walk", true);
    }

    private void OnZombieAttack(Collider other)
    {
        _ani.SetBool("attack", true);
        _ani.SetBool("walk", false);
        other.gameObject.GetComponent<Actor>().TakeDamage(Damage);
        Invoke("EndAnimation", 2f);
    }

    private void EndAnimation(){
        _ani.SetBool("attack", false);
        _ani.SetBool("walk", true);
    }

    // Update is called once per frame
    void Update()
    {
        _enemy.SetDestination(_target.transform.position);
    }

    #region IDAMAGEABLE_METHODS
    public void TakeDamage(int damage)
    {
        _life -= damage;
        Debug.Log($"{name} Hit -> Life {_life}!");
        if(_life <= 0) Die();
    }

    public void Die()
    {
        Debug.Log($"{name} Died!!!!");
        Destroy(gameObject);
    }
    #endregion
}
