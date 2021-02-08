﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sphere : MonoBehaviour
{
    public float speed = 2.5f;

    [SerializeField] Text speedText;
    [SerializeField] Text timeText;

    private string currentTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        MoverNave();

        //Cambio el texto de la UI, metido en la variable speedText
        //Debe ser una cadena, si quiero`puedo convertir el float en string
        //speedText.text = speed.ToString();
        speedText.text = "Velocidad: " + speed + " Kmts/h";

        // Obtain the current time.
        currentTime = Time.time.ToString("f2");
        currentTime = "Time is: " + currentTime + " sec.";

        timeText.text = currentTime;

    }

    void MoverNave()
    {
        float PosX = transform.position.x;
        float PosY = transform.position.y;
        //print(transform.position.x);
        float desplY = Input.GetAxis("Vertical");
        
        float desplX = Input.GetAxis("Horizontal");

        //Restringir movimiento horizontal
        if (PosX > 0 && PosX < 30)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * desplX, Space.World);
        }
        else if(PosX < 0 && desplX > 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * desplX, Space.World);
        }
        else if (PosX > 30 && desplX < 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * desplX, Space.World);
        }

        //Restringir movimiento vertical
        if (PosY > 0 && PosY < 9)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed * desplY, Space.World);
        }
        else if (PosY < 0 && desplY > 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed * desplY, Space.World);
        }
        else if (PosY > 9 && desplY < 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed * desplY, Space.World);
        }

transform.rotation = Quaternion.Euler(desplY * -10, 0 , desplX * -20);


    }
}
