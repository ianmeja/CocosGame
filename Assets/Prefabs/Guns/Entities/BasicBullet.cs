using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider),typeof(Rigidbody))]
public class BasicBullet : MonoBehaviour, IBullet
{
    #region IBULLET_PROPERTIES
    public float Speed => _speed;
    public float Lifetime => _lifetime;
    public Collider Collider => _collider;
    public Rigidbody Rb => _rigidbody;
    public IGun Owner => _owner;
    #endregion

    #region PRIVATE_PROPERTIES
    [SerializeField] private float _speed = 30f;
    [SerializeField] private float _lifetime = 3f;
    private Collider _collider;
    private Rigidbody _rigidbody;
    IGun _owner;
    [SerializeField] private LayerMask _hittableMask;
    #endregion

    #region UNITY_EVENTS
    private void Start()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();

        Init();
    }
    void Update()
    {
        Travel();

        _lifetime -= Time.deltaTime;
        if(_lifetime <= 0) Die(); 
    }
    private void OnDestroy() 
    {
        // Debug.Log("Bullet has died!!!");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(((1<<other.gameObject.layer) & _hittableMask)!= 0)
        {
            // other.GetComponent<Actor>()?.TakeDamage(_owner.Damage);
        
            if(other.GetComponent<IDamageable>() != null)
            {
                EventQueueManager.instance.AddCommand(
                    new CmdApplyDamage(other.GetComponent<IDamageable>(),_owner.Damage));
            }

            // Die();
        }
    }
    #endregion

    #region IBULLET_METHODS
    public void Init()
    {
        _collider.isTrigger = true;
        _rigidbody.isKinematic = true;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

    }
    public void Travel() => transform.Translate(Vector3.forward * Time.deltaTime * _speed);
    public void Die() => Destroy(gameObject);
    public void SetOwner(IGun owner) => _owner = owner;
    #endregion
    
 
}
