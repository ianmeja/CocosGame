using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour, IGun
{
    [SerializeField] private GunStats _stats;

    #region IGUN_PROPERTIES
    public GameObject BulletPrefab => _stats.BulletPrefab;
    public int Damage => _stats.Damage;
    public int AmmoCapacity => _stats.AmmoCapacity;
    public Transform BulletContainer => _bulletContainer;
    [SerializeField] protected Transform _bulletContainer;
    #endregion

    #region PRIVATE_PROPERTIES
    protected int _currentBulletCount;
    #endregion

    #region UNITY_EVENTS
    private void Start()
    {
        Reload();
    }
    #endregion

    #region IGUN_MEHTODS
    public void Reload() 
    {
        _currentBulletCount = AmmoCapacity;
        EventsManager.instance.BulletCountChange(_currentBulletCount,AmmoCapacity);
    }
    public virtual void Shoot() => Debug.Log("Shoot!!");

    protected void UpdateBulletCount()
    {
        _currentBulletCount--;
        EventsManager.instance.BulletCountChange(_currentBulletCount,AmmoCapacity);
    }
    #endregion
}