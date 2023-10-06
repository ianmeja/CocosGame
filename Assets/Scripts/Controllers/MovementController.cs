using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour, IMoveable
{
    public float MovementSpeed => _movementSpeed;
    [SerializeField] private float _movementSpeed = 15f;
    public float RotationSpeed => _rotationSpeed;
    [SerializeField] private float _rotationSpeed = 100f;

    public void Move(Vector3 direction) => transform.Translate(direction * Time.deltaTime * MovementSpeed);
    public void Turn(Vector3 direction) => transform.Rotate(direction * Time.deltaTime * _rotationSpeed, Space.Self);

}
