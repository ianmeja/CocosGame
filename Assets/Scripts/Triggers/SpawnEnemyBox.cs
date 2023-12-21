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
        if(!_nextLevel) StartCoroutine(GenerarZombiesEnCaja(oleada));
    }

    // Función para activar la generación de zombies
    private IEnumerator GenerarZombiesEnCaja(int oleada)
    {
        for (int i = 0; i < oleada & !_nextLevel; i++)
        {
            GameObject clone = Instantiate(
                _enemyPrefab,
                transform.position + Random.insideUnitSphere,
                Quaternion.Euler(0, Random.Range(0,360), 0)
            );
            yield return new WaitForSeconds(2);
        }
    }
}

