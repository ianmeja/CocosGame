using UnityEngine;
using UnityEngine.SceneManagement;
using static Enums;

public class NextLevel : MonoBehaviour
{
    private BoxCollider _col;

    void Start(){
        _col = gameObject.GetComponent<BoxCollider>();
        _col.enabled = false;
        EventsManager.instance.OnLevelChange += OnLevelChange;
    }

    private void OnLevelChange(){
        _col.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegurate de que el jugador tenga un tag "Player" asignado.
        {
            // Carga la escena de "End Game" al encontrar la puerta.
            SceneManager.LoadScene((int)Levels.Level_2);
        }
    }
}
