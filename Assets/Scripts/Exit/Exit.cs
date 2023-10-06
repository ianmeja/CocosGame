using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Aseg�rate de que el jugador tenga un tag "Player" asignado.
        {
            // Carga la escena de "End Game" al encontrar la puerta.
            SceneManager.LoadScene("Victory");
        }
    }
}
