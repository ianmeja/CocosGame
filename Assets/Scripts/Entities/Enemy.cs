using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int routine;
    public float chronometer;
    public Animator ani;
    public Quaternion angle;
    public float degree;

    public GameObject target;
    public bool attack;


    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("TT_demo_police");
    }

    void behaviour_enemy()
    {
        if (target == null)
        {
            Debug.LogError("La variable 'target' no ha sido asignada en el Inspector.");
            return; // Sale de la función para evitar errores adicionales.
        }
        if (Vector3.Distance(transform.position, target.transform.position) > 5){

            ani.SetBool("run", false);
            chronometer += 1 * Time.deltaTime;
            if (chronometer >= 4)
            {
                routine = Random.Range(0, 2);
                chronometer = 0;
            }
            switch (routine)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;
                case 1:
                    degree = Random.Range(0, 360);
                    angle = Quaternion.Euler(0, degree, 0);
                    routine++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f);
                    transform.Translate(Vector3.forward * 0.3f * Time.deltaTime);
                    ani.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 1 && !attack){
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                ani.SetBool("walk", false);
                ani.SetBool("run", true);
                transform.Translate(Vector3.forward * 2 * Time.deltaTime);
                ani.SetBool("attack", false);
            }
            else{
                ani.SetBool("walk", false);
                ani.SetBool("run", false);
                ani.SetBool("attack", true);
                attack = true;
            }
        }
    }

    public void Final_Ani(){
        ani.SetBool("attack", false);
        attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        behaviour_enemy();
    }
}
