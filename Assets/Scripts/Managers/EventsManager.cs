using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

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
    public event Action<int> OnOleadaActivada;
    public void EventOleada(int oleada)
    {
        if (OnOleadaActivada != null) OnOleadaActivada(oleada);
    }
    public event Action OnLevelChange;
    public void EventNewLevel()
    {
        Debug.Log("New Level Achieved!");
        if (OnLevelChange != null) OnLevelChange();
    }
    public event Action OnGetKey;
    public void EventGetKey()
    {
        Debug.Log("Key collected!");
        if (OnGetKey != null) OnGetKey();
    }
    #endregion

    #region UI_ELEMENTS_Update
    // LIFE BAR
    public event Action<int,int,int> OnCharacterLifeChange;

    public void CharacterLifeChange(int currentLife, int maxLife, int sound)
    {
        if(OnCharacterLifeChange != null) OnCharacterLifeChange(currentLife, maxLife, sound);
    }
    // WEAPONS & BULLETS
    public event Action<Weapon> OnWeaponChange;
    public event Action<int,int> OnBulletCountChange;

    public void WeaponChange(Weapon id)
    {
        if (OnWeaponChange != null) OnWeaponChange(id);
    }

    public void BulletCountChange(int bulletCount, int maxBullet)
    {
        if (OnBulletCountChange !=null) OnBulletCountChange(bulletCount,maxBullet);

    }

    // AVATAR 
    public event Action<AvatarFace> OnAvatarChange;
    
    public void AvatarChange(AvatarFace id)
    {
        if (OnAvatarChange !=null) OnAvatarChange(id);

    }
    #endregion

    #region ZOMBIE
    public event Action OnZombieDie;
    public void ZombieDie(){
        if(OnZombieDie != null) OnZombieDie();
    }
    public event Action OnZombieAttack;
    public void ZombieAttack(){
        if(OnZombieAttack != null) OnZombieAttack();
    }
    #endregion
}
