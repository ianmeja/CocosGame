using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpManager : MonoBehaviour
{
    [SerializeField] Text helpText;    
    private bool help = false;

    private void Start()
    {
        if(!PlayerPrefs.HasKey("help"))
        {
            PlayerPrefs.SetInt("help",0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateText();
    }

    private void UpdateText()
    {
        if(help == false)
        {
            helpText.enabled = false;
        }
        else
        {
            helpText.enabled = true;
        }
    }

    public void OnButtonPress()
    {
        if(help == false)
        {
            help = true;
            
        }
        else
        {
            help = false;
        }
        Save();
        UpdateText();
    }

    private void Load()
    {
        help = PlayerPrefs.GetInt("help") == 1 ;
    }
    private void Save()
    {
        PlayerPrefs.SetInt("help",help ? 1 : 0);
    }
    
}
