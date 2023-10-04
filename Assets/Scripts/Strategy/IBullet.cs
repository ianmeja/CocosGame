using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{
   IGun Owner { get; }
   float Speed { get; }
   float Lifetime { get; }
   Collider Collider { get; }
   Rigidbody Rb { get; }  
   void Init();
   void Travel();
   void Die();
   void SetOwner(IGun owner);
}
