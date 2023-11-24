using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyBox : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    private List<GameObject> _zombies;
    private bool _nextLevel;

    void Start(){
        _zombies = new List<GameObject>();
        _nextLevel = false;
        EventsManager.instance.OnOleadaActivada += OnOleadaActivada;
        EventsManager.instance.OnLevelChange += OnLevelChange;
    }

    private void OnLevelChange()
    {
        _nextLevel = true;
        foreach (GameObject zombie in _zombies)
        {
            if(zombie != null)  Destroy(zombie);
        }
        _zombies.Clear();
    }

    private void OnOleadaActivada(int oleada)
    {
        if(!_nextLevel) StartCoroutine(GenerarZombiesEnCaja(oleada));
    }

    // Función para activar la generación de zombies
    private IEnumerator GenerarZombiesEnCaja(int oleada)
    {
        for (int i = 0; i < 2*oleada & !_nextLevel; i++)
        {
            GameObject clone = Instantiate(
                _enemyPrefab,
                transform.position + Random.insideUnitSphere,
                Quaternion.Euler(0, Random.Range(0,360), 0)
            );
            if (clone != null)  _zombies.Add(clone);
            yield return new WaitForSeconds(1);
        }
    }
}

