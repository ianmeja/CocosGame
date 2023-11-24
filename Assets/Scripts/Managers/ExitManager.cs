using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Enums;
using UnityEngine.SceneManagement;


public class ExitManager : MonoBehaviour
{
    public GameObject optionsMenu;

    void Start()
    {

    }

    void Update(){
        if (Input.GetKeyDown("escape"))
        {
            // SceneManager.LoadScene((int)Levels.MainMenu);
            optionsMenu.gameObject.SetActive(!optionsMenu.gameObject.activeSelf);
        }
    }

    public void OnButtonPressYes()
    {
        SceneManager.LoadScene((int)Levels.MainMenu);
    }
    public void OnButtonPressNo()
    {
        optionsMenu.gameObject.SetActive(!optionsMenu.gameObject.activeSelf);
    }
    
}
