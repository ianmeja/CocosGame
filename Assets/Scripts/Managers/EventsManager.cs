using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    static public EventsManager instance;
    
    #region UNITY_EVENTS
    private void Awake()
    {
        if (instance != null) Destroy(this);
        instance = this;
    }
    #endregion

    #region GAME_MANAGER_ACTIONS
    public event Action<bool> OnGameOver;
    public void EventGameOver(bool isVictory)
    {
        if (OnGameOver != null) OnGameOver(isVictory);
    }
    #endregion

    #region UI_ELEMENTS_Update
    public event Action<int,int> OnCharacterLifeChange;

    public void CharacterLifeChange(int currentLife, int maxLife)
    {
        if(OnCharacterLifeChange != null) OnCharacterLifeChange(currentLife, maxLife);
    }
    #endregion
}
