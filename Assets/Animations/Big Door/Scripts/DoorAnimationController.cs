using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationController : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private bool _openDoorParameter;
    [SerializeField] private bool _closedDoorParameter;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _openDoorParameter = false;
        _closedDoorParameter = false;
    }

    private void OnTriggerEnter(Collider other) 
    {
        SetParameterFlags(true);
    }

    private void OnTriggerExit(Collider other) 
    {
        SetParameterFlags(false);
    }

    private void SetParameterFlags(bool doGateOpen) //Open door => true // Close door => false //
    {
        _openDoorParameter = doGateOpen;
        _closedDoorParameter = !doGateOpen;

        _animator.SetBool("Open_Flag",_openDoorParameter);
        _animator.SetBool("Close_Flag",_closedDoorParameter);
    }
}
