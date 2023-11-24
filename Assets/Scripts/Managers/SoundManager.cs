using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _victory;
    [SerializeField] private AudioClip _defeat;
    [SerializeField] private AudioClip _wave;

    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    private bool muted = false;

    private AudioSource _audioSource;

    #region UNITY_EVENT
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        EventsManager.instance.OnGameOver += OnGameOver;
        EventsManager.instance.OnOleadaActivada += OnOleadaActivada;

        if(!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted",0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }
    #endregion

    #region EVENTS
    private void OnGameOver(bool isVictory)
    {
        _audioSource.PlayOneShot(isVictory ? _victory : _defeat);
    }
    private void OnOleadaActivada(int oleada)
    {
        _audioSource.PlayOneShot(_wave);
    }
    
    private void UpdateButtonIcon()
    {
        if(muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;

        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }

    public void OnButtonPress()
    {
        if(muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        Save();
        UpdateButtonIcon();
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1 ;
    }
    private void Save()
    {
        PlayerPrefs.SetInt("muted",muted ? 1 : 0);
    }
    
    #endregion
}
