using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Enums;


public class GameLevelManager : MonoBehaviour
{
   public void Load_MainMenu() => SceneManager.LoadScene((int)Levels.MainMenu);
   public void Load_LoadScreen() => SceneManager.LoadScene((int)Levels.LoadScreen);
   public void Load_Level_1() => SceneManager.LoadScene((int)Levels.Level_1);
   public void Load_Victory() => SceneManager.LoadScene((int)Levels.Victory);
   public void Load_Defeat() => SceneManager.LoadScene((int)Levels.Defeat);
   public void Exit() => Application.Quit();

}
