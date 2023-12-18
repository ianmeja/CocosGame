using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    [SerializeField] Text infoText;    
    private bool info = false;

    private void Start()
    {
        if(!PlayerPrefs.HasKey("info"))
        {
            PlayerPrefs.SetInt("info",0);
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
        if(info == false)
        {
            infoText.enabled = false;
        }
        else
        {
            infoText.enabled = true;
        }
    }

    public void OnButtonPress()
    {
        if(info == false)
        {
            info = true;
            
        }
        else
        {
            info = false;
        }
        Save();
        UpdateText();
    }

    private void Load()
    {
        info = PlayerPrefs.GetInt("info") == 1 ;
    }
    private void Save()
    {
        PlayerPrefs.SetInt("info",info ? 1 : 0);
    }
    
}
