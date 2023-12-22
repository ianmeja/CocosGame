using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyBox : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    private bool _nextLevel;

    void Start(){
        _nextLevel = false;
        EventsManager.instance.OnOleadaActivada += OnOleadaActivada;
    }

    private void OnOleadaActivada(int oleada)
    {
        //if(!_nextLevel && transform.position.y < 1) StartCoroutine(GenerarZombiesEnCaja(oleada));
        if(!_nextLevel && transform.position.y < 1) GenerarZombiesEnCaja(oleada);
    }

    // Función para activar la generación de zombies
    private void GenerarZombiesEnCaja(int oleada)
    {
        for (int i = 0; i < oleada & !_nextLevel; i++)
        {
            GameObject clone = Instantiate(
                _enemyPrefab,
                transform.position + Random.insideUnitSphere,
                Quaternion.Euler(0, Random.Range(0,360), 0)
            );
            //yield return new WaitForSeconds(2);
        }
    }
}

