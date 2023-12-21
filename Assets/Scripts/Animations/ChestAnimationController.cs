using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnimationController : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private bool _openChestParameter;
    [SerializeField] private GameObject _consumiblePrefab;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _openChestParameter = false;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(_openChestParameter) return;
        if(other.CompareTag("Player")){
            SetParameterFlags(true);
            Invoke("InstanciateConsumable", 1.5f);
        }
    }

    private void InstanciateConsumable(){
        GameObject clone = Instantiate(
                _consumiblePrefab,
                transform.position + transform.forward * 2 + transform.up, transform.rotation
        );
    }

    private void SetParameterFlags(bool doGateOpen)
    {
        _openChestParameter = doGateOpen;
        _animator.SetBool("Open_flag",_openChestParameter);
    }
}
