using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Enums;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Playables;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    #region UNITY_EVENTS
    void Start()
    {
        EventsManager.instance.OnGameOver += OnGameOver;
        EventsManager.instance.OnLevelChange += OnLevelChange;

        _gameOverMessage.text = string.Empty;
        _oleadasActivadas = 0;
        _nextLevelFlag = false;
        _tiempoRestanteParaSiguienteOleada = _tiempoHastaSiguienteOleada;
    }
    #endregion

    #region UPDATE
    [SerializeField] private float _tiempoHastaSiguienteOleada = 30f;
    private int _oleadasActivadas;
    private float _tiempoRestanteParaSiguienteOleada;
    void Update()
    {

        if (!_isGameOver & !_nextLevelFlag)
        {
            _tiempoRestanteParaSiguienteOleada -= Time.deltaTime;

            if (_tiempoRestanteParaSiguienteOleada <= 0f)
            {
                _tiempoRestanteParaSiguienteOleada = _tiempoHastaSiguienteOleada;
                _oleadasActivadas += 1;
                Debug.Log(string.Format("Oleada nº{0}", _oleadasActivadas));
                EventsManager.instance.EventOleada(_oleadasActivadas);
            }
        }
    }
    #endregion

    #region GAME_LEVELS
    private bool _nextLevelFlag;
    [SerializeField] private GameObject _chestPrefab;
    public CinemachineVirtualCamera _cmvc2;
    public CinemachineVirtualCamera _cmvc4;
    private void OnLevelChange()
    {
        _nextLevelFlag = true;
        if(SceneManager.GetActiveScene().buildIndex == (int)Levels.Level_1){
            GameObject finalChest = Instantiate(
                _chestPrefab, 
                _chestPrefab.transform.position, 
                _chestPrefab.transform.rotation
            );
            _cmvc2.m_LookAt = finalChest.transform;
            _cmvc4.m_LookAt = finalChest.transform;
        }
    }
    #endregion

    #region GAME_OVER
    [SerializeField] private bool _isGameOver = false;
    [SerializeField] private bool _isVictory = false;
    [SerializeField] private Text _gameOverMessage;
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
