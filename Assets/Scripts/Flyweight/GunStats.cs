using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunStats", menuName = "Stats/GunStats", order = 0)]
public class GunStats : ScriptableObject
{
    [SerializeField] private GunStatValues _gunStats;
    public GameObject BulletPrefab => _gunStats.BulletPrefab;
    public int Damage => _gunStats.Damage;
    public int AmmoCapacity => _gunStats.AmmoCapacity;

}
[System.Serializable]
public struct GunStatValues
{
    public GameObject BulletPrefab;
    public int Damage;
    public int AmmoCapacity;
}
