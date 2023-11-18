using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBox : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _initDrag = 15f; // Caida suave "con paracaidas"
    [SerializeField] private float _deploymentDrag = 3f; // Caida fuerte "sin paracaidas"
    [SerializeField] private float _minHeightDetection = 5f;
    [SerializeField] private bool _parachuteDeployed;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.drag = _initDrag;
    }

    void Update()
    {
        // Guardar toda la info de las colisiones detectadas
        RaycastHit hitInfo;
        // Ray es la info basica del rayo a disparar
        Ray ray = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.localPosition, Vector3.down * _minHeightDetection, Color.red);
        // Pregunta si se detectan colisiones
        if (!_parachuteDeployed && Physics.Raycast(ray, out hitInfo, _minHeightDetection))
        {
            if(hitInfo.collider.tag.Equals("Ground"))
            {
                DeployParachute();
            }
        }
    }

    private void DeployParachute()
    {
        _parachuteDeployed = true;
        _rigidbody.drag = _deploymentDrag;

        //Instalar objeto paracaidas
        // Llamar animacion de despliegue del paracaidas
    }
}
