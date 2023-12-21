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
    
    public CharacterStats Stats => stats;
    [SerializeField] protected CharacterStats stats;
    [SerializeField] private int _life; //currentLife
    public bool _inmortal = false;
    public float _tiempoInmortal = 1.0f;
    #endregion

    #region UNITY_EVENTS
    protected void Start() 
    {
        _life = MaxLife;
        EventsManager.instance.CharacterLifeChange(Life,MaxLife,0);
        EventsManager.instance.AvatarChange(Enums.AvatarFace.NormalFace);
    }
    #endregion

    #region IDAMAGEABLE_METHODS
    public void TakeDamage(int damage)
    {
        if(_inmortal) return;

        _life -= damage;
        EventsManager.instance.CharacterLifeChange(Life,MaxLife,1);

        if(_life < (MaxLife * 0.25f))
        {
            EventsManager.instance.AvatarChange(Enums.AvatarFace.BloodyFace);
        }

        Debug.Log($"{name} Hit -> Life {_life}!");
        if(_life <= 0) Die();

        StartCoroutine(TiempoInmortal());
    }
    public void Die()
    {
        Debug.Log($"{name} Died!!!!");
        EventsManager.instance.EventGameOver(false);
        Destroy(gameObject);
    }
    #endregion

    public void GainHealth(int health){
        _life += health;
        if(_life > MaxLife)
            _life = MaxLife;
        EventsManager.instance.CharacterLifeChange(Life,MaxLife,2);
    }

    IEnumerator TiempoInmortal(){
        _inmortal = true;
        yield return new WaitForSeconds(_tiempoInmortal);
        _inmortal = false;
    }
}
