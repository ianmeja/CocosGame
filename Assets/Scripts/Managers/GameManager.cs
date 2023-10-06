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

    #region UNITY_EVENTS
    void Start()
    {
        EventsManager.instance.OnGameOver += OnGameOver;
        _gameOverMessage.text = string.Empty;
    }
    #endregion

    #region ACTIONS
    private void OnGameOver(bool isVictory)
    {
        _isGameOver = true;
        _isVictory = isVictory;

        _gameOverMessage.text = isVictory ? "VICTORIA!" : "Derrota total";
        _gameOverMessage.color = isVictory ? Color.cyan : Color.red;

        //cambio de escena
        Invoke("LoadCreditsScene", 3);
    }

    private void LoadCreditsScene()
    {
        SceneManager.LoadScene(_isGameOver && _isVictory ? (int)Levels.Victory : (int)Levels.Defeat);
    }
    #endregion
}