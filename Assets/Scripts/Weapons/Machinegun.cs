using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machinegun : Gun
{
    [SerializeField] private int _bulletPerShot = 5;
    
    public override void Shoot(){

        if (_currentBulletCount <= 0)
            return;
        

        for (int i = 0; i < _bulletPerShot; i++)
        {    
            GameObject bullet = Instantiate(
                BulletPrefab, 
                transform.position + Vector3.forward * i * .2f, 
                transform.rotation, 
                BulletContainer);
            bullet.GetComponent<BasicBullet>().SetOwner(this);

            UpdateBulletCount();

        }
        
    }
}
