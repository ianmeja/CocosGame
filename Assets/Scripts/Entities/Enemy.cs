using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    private int _routine;
    private float _chronometer;
    [SerializeField] private Animator _ani;
    private Quaternion _angle;
    private float _degree;

    [SerializeField] private GameObject _target;
    [SerializeField] private bool _attack = false;

    [SerializeField] private RangeEnemy _range;

    [SerializeField] private NavMeshAgent _enemy;


    // Start is called before the first frame update
    void Start()
    {
        _ani = GetComponent<Animator>();
        _target = GameObject.Find("TT_demo_police");
        _enemy = GetComponent<NavMeshAgent>();
    }

    public RangeEnemy GetRange()
    {
        return _range;
    }
    
    public Animator GetAni()
    {
        return _ani;
    }

    public bool GetAttack()
    {
        return _attack;
    }

    public void SetAttack(bool value)
    {
        _attack = value;
    }

    void behaviour_enemy()
    {
        if (_target == null)
        {
            Debug.LogError("La variable 'target' no ha sido asignada en el Inspector.");
            return; // Sale de la función para evitar errores adicionales.
        }
        if(_attack){
            return;
        }

        var lookPos = _target.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        
        if (Vector3.Distance(transform.position, _target.transform.position) > 1 && !_attack){
            
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
            _ani.SetBool("walk", false);
            _ani.SetBool("run", true);
            //transform.Translate(Vector3.forward * 2 * Time.deltaTime);
            _ani.SetBool("attack", false);
        }
        else{
            
            if (!_attack){
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                _ani.SetBool("walk", false);
                _ani.SetBool("run", false);
            }

        }
    }


    // Update is called once per frame
    void Update()
    {
        //behaviour_enemy();
        //enemy.SetDestination(target.transform.position);

        behaviour_enemy();
        if(!_attack){
            _enemy.SetDestination(_target.transform.position);
        }
    }
    
}
