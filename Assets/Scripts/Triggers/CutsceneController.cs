using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneController : MonoBehaviour
{
    private PlayableDirector _director;
    [SerializeField] private GameObject _canva; 
    
    // Start is called before the first frame update
    void Start()
    {
        _director = GetComponent<PlayableDirector>();
        EventsManager.instance.OnLevelChange += OnLevelChange;
    }

    void OnLevelChange(){
        _director.Play();
        _canva.SetActive(false);
    }
}
