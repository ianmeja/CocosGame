using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun
{
    GameObject BulletPrefab {get ;}
    Transform BulletContainer {get;}
    int Damage {get;}
    int AmmoCapacity {get;}
    void Shoot();
    void Reload();
}
