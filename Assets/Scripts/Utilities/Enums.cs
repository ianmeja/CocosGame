using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums : MonoBehaviour
{
    #region Singleton
    static public Enums instance;

    private void Awake()
    {
        if (instance !=null) Destroy(this);
        instance = this;
    }
    #endregion

    public enum Weapon
    {
        Pistol,
        Machinegun,
        Shotgun       
    }
    public enum AvatarFace
    {
        NormalFace,
        BloodyFace,
        ActionFace
    }

    public enum Levels
    {
        MainMenu,
        LoadScreen,
        Level_1,
        Level_2,
        Victory,
        Defeat,
        Ranking
    }
}
