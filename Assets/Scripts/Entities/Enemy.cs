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


    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void behaviour_enemy()
    {
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
                transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        behaviour_enemy();
    }
}
