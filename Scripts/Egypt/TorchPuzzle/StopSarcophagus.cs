using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSarcophagus : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sarcophagus")
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
