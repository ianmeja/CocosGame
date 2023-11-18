using UnityEngine;
using UnityEngine.SceneManagement;
using static Enums;

public class NextLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Aseg�rate de que el jugador tenga un tag "Player" asignado.
        {
            // Carga la escena de "End Game" al encontrar la puerta.
            SceneManager.LoadScene((int)Levels.Level_2);
        }
    }
}
