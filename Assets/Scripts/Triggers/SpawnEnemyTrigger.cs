using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("TT_demo_police")) 
            Instantiate(
                _enemyPrefab, 
                transform.position + Random.insideUnitSphere * 3 + Vector3.up * 2 , 
                transform.rotation);
    }
}
