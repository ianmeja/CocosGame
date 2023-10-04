using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBell : MonoBehaviour, IListener
{
    #region PUBLIC_PROPERTIES
    public AudioClip AudioClip => _audioClip;
    public AudioSource AudioSource => throw new System.NotImplementedException();
    #endregion

    #region PRIVATE_PROPERTIES
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioSource _audioSource;
    #endregion

    public void InitAudioSource(){
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _audioClip;
    }

    public void Play(){
        _audioSource.Play();
    }

    public void PlayOnShot(){
        _audioSource.PlayOneShot(_audioClip);
    }

    public void Stop(){
        _audioSource.Stop();
    }

    // Start is called before the first frame update
    void Start(){
        InitAudioSource();
    }
    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Alpha1)) PlayOnShot();
        if (Input.GetKeyDown(KeyCode.Alpha2)) Play();
        if (Input.GetKeyDown(KeyCode.Alpha3)) Stop();
    }

}
