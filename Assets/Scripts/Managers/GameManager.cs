using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Enums;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isGameOver = false;
    [SerializeField] private bool _isVictory = false;
    [SerializeField] private Text _gameOverMessage;
    [SerializeField] private SpawnEnemyBox _spawnCaja; // Asigna tu caja de spawn en el Inspector
    public float tiempoHastaSiguienteOleada = 30f;
    public int totalOleadas = 4; // Ajusta esto al número total de oleadas que desees
    private int oleadasActivadas = 0;
    private float tiempoRestanteParaSiguienteOleada;

    #region UNITY_EVENTS
    void Start()
    {
        EventsManager.instance.OnGameOver += OnGameOver;
        _gameOverMessage.text = string.Empty;
        tiempoRestanteParaSiguienteOleada = tiempoHastaSiguienteOleada;
    }
    #endregion

    #region UPDATE
    void Update()
    {

        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene((int)Levels.MainMenu);
        }
        
        if (!_isGameOver)
        {
            tiempoRestanteParaSiguienteOleada -= Time.deltaTime;

            if (tiempoRestanteParaSiguienteOleada <= 0f)
            {
                OnOleadaActivada();
                tiempoRestanteParaSiguienteOleada = tiempoHastaSiguienteOleada;
            }
        }
    }
    #endregion

    #region ACTIONS
    private void OnOleadaActivada()
    {
        Debug.Log("¡Oleada de zombies activada!");
        EventsManager.instance.EventOleada();

        // Llama a la función de generación de zombies en la caja
        if (_spawnCaja != null)
        {
            Debug.Log("Spawnear zombie");
            _spawnCaja.GenerarZombiesEnCaja();
        }

        oleadasActivadas++;

        if (oleadasActivadas >= totalOleadas)
        {
            OnGameOver(true);
        }
    }

    private void OnGameOver(bool isVictory)
    {
        _isGameOver = true;
        _isVictory = isVictory;

        _gameOverMessage.text = isVictory ? "VICTORIA!" : "Derrota total";
        _gameOverMessage.color = isVictory ? Color.cyan : Color.red;

        // Cambiar de escena
        Invoke("LoadCreditsScene", 3);
    }

    private void LoadCreditsScene()
    {
        SceneManager.LoadScene(_isGameOver && _isVictory ? (int)Levels.Victory : (int)Levels.Defeat);
    }
    #endregion
}
