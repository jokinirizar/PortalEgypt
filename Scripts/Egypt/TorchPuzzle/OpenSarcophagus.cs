using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSarcophagus : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Thrust = 200f;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            m_Rigidbody.AddForce(transform.right * m_Thrust);
        }
    }
}
