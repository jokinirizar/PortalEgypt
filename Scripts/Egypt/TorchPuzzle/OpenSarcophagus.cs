using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSarcophagus : MonoBehaviour
{
    //Variables Puerta y Posición Inicial de esta, "Activación" sirve para ejecutar el movmiento de la puerta. Introducir el objeto con este script en "Torch", variable Door
    public GameObject sarcophagus = null;
    private Vector3 StartPoint;
    public bool activation = false;
    public float movementSpeed = 0.01f;
    public float goalPosition = 1.14f;

    void Start()
    {
        Torch.OnComplete += MyEventHandlerMethod;
        if (!sarcophagus)
        {
            sarcophagus = transform.gameObject;

        }
        StartPoint.x = sarcophagus.transform.position.x;
    }

    private void MyEventHandlerMethod()
    {
        activation = true;

    }

    private void Update()
    {
        if (activation)
        {

                sarcophagus.transform.position = new Vector3(sarcophagus.transform.position.x - movementSpeed, sarcophagus.transform.position.y, sarcophagus.transform.position.z);
            


       
        if (sarcophagus.transform.position.x >= StartPoint.x + goalPosition || sarcophagus.transform.position.x <= StartPoint.x - goalPosition)
        {
            activation = false;
        }
        }
    }
}
