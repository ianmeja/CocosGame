using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    public Enemy enemy;
    RangeEnemy range;

    void Start(){
        range = GetComponent<RangeEnemy>();
    }

    void Final_Ani(){
        print("Entre");
        Animator animator = enemy.GetAni();
        if (animator != null)
        {
            animator.SetBool("attack", false);
        }

        enemy.SetAttack(false);
        enemy.GetRange().GetComponent<CapsuleCollider>().enabled = true; 
    }

    void OnTriggerEnter(Collider coll){

        if (!enemy.GetAttack())
        {
            Animator animator = enemy.GetAni();

            // Verifica que el objeto Animator no sea nulo antes de usarlo
            if (animator != null)
            {
                // Llama a SetBool en el objeto Animator
                animator.SetBool("attack", true);
                animator.SetBool("walk", false);
                animator.SetBool("run", false);
            }
            // Realiza la lógica de ataque aquí
            // Puedes agregar sonidos, efectos, etc.
            // También puedes restar puntos de vida al objetivo, por ejemplo.
            enemy.SetAttack(true);
            print("Daño");
            enemy.GetRange().GetComponent<CapsuleCollider>().enabled = false;

            // Puedes agregar un temporizador para detener la animación de ataque después de un tiempo
            Invoke("Final_Ani", 2.0f);
            
        }
    }

}