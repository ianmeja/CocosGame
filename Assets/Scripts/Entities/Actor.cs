using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour, IDamageable
{
    #region IDAMAGEABLE_PROPERTIES
    public int MaxLife => stats.MaxLife;
    public int Life => _life;
    #endregion

    #region PRIVATE_PROPERTIES
    
    public EntitieStats Stats => stats;
    [SerializeField] protected EntitieStats stats;
    [SerializeField] private int _life; //currentLife
    #endregion

    #region UNITY_EVENTS
    protected void Start() 
    {
        _life = MaxLife;
        EventsManager.instance.CharacterLifeChange(Life,MaxLife);
    }
    #endregion

    #region IDAMAGEABLE_METHODS
    public void TakeDamage(int damage)
    {
        _life -= damage; 
        EventsManager.instance.CharacterLifeChange(Life,MaxLife);
        Debug.Log($"{name} Hit -> Life {_life}!");
        if(_life <= 0) Die();
    }
    public void Die()
    {
        Debug.Log($"{name} Died!!!!");
        
        if(name.Equals("Character")) EventsManager.instance.EventGameOver(false);
        else Destroy(gameObject);
    }
    #endregion
}
