using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdMovement : ICommand
{
    // private IMoveable _moveable; 
    private Transform _transform;
    private Vector3 _direction;
    private float _speed;

    public CmdMovement(Transform transform, Vector3 direction, float speed)
    {
        _transform = transform;
        _direction = direction;
        _speed = speed;

    }
    public void Do() => _transform.Translate(_direction * Time.deltaTime * _speed);
}
