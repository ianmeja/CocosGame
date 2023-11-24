using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnimationController : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private bool _openChestParameter;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _openChestParameter = false;
    }

    private void OnTriggerEnter(Collider other) 
    {
        SetParameterFlags(true);
    }

    private void SetParameterFlags(bool doGateOpen)
    {
        _openChestParameter = doGateOpen;
        _animator.SetBool("Open_flag",_openChestParameter);
    }
}
