using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyBox : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;

    // Función para activar la generación de zombies
    public void GenerarZombiesEnCaja()
    {
        Instantiate(
            _enemyPrefab, 
            transform.position + Random.insideUnitSphere * 3 + Vector3.up * 2, 
            transform.rotation);
    }
}

