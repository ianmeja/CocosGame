using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Stats/EnemyStats", order = 0)]
public class EnemyStats : EntitieStats
{
    [SerializeField] private EnemyStatsValues _EnemyStats;
    public int Damage => _EnemyStats.Damage;

}
[System.Serializable] 
public struct EnemyStatsValues
{
    public int Damage;
}
