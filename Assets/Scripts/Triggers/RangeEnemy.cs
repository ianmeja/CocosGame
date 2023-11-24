using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    public Enemy _enemy;
    RangeEnemy _range;

    void Start(){
        _range = GetComponent<RangeEnemy>();
    }

    void Final_Ani(){
        Animator _animator = _enemy.GetAni();
        if (_animator != null)
        {
            _animator.SetBool("attack", false);
        }

        _enemy.SetAttack(false);
        _enemy.GetRange().GetComponent<CapsuleCollider>().enabled = true; 
    }

    void OnTriggerEnter(Collider coll){

        if (!_enemy.GetAttack())
        {
            Animator _animator = _enemy.GetAni();

            // Verifica que el objeto Animator no sea nulo antes de usarlo
            if (_animator != null)
            {
                // Llama a SetBool en el objeto Animator
                _animator.SetBool("attack", true);
                _animator.SetBool("walk", false);
                _animator.SetBool("run", false);
            }
            _enemy.SetAttack(true);
            //print("Daño");
            Actor _actor = coll.gameObject.GetComponent<Actor>();

            if (_actor != null) {
                // Llamada al método TakeDamage en el script Actor
                _actor.TakeDamage(10);
            }

            _enemy.GetRange().GetComponent<CapsuleCollider>().enabled = false;

            // Puedes agregar un temporizador para detener la animación de ataque después de un tiempo
            Invoke("Final_Ani", 2.0f);
            
        }
    }

}