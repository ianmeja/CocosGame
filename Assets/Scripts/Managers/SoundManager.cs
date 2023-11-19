using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _victory;
    [SerializeField] private AudioClip _defeat;
    [SerializeField] private AudioClip _wave;

    private AudioSource _audioSource;

    #region UNITY_EVENT
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        EventsManager.instance.OnGameOver += OnGameOver;
        EventsManager.instance.OnOleadaActivada += OnOleadaActivada;
    }
    #endregion

    #region EVENTS
    private void OnGameOver(bool isVictory)
    {
        _audioSource.PlayOneShot(isVictory ? _victory : _defeat);
    }
    private void OnOleadaActivada()
    {
        Debug.Log("Sonido de oleada activado");
        // Llamar al método PlayOnShot al activar una oleada
        _audioSource.PlayOneShot(_wave);
    }
    #endregion
}
