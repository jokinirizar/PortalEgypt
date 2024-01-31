using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLidDown : MonoBehaviour
{
    // Start is called before the first frame update
    public float percentageOfHeightPerFrame;
    void Start()
    {
        Transform lid = transform.Find("Lid");
        lid.gameObject.GetComponent<Animator>().enabled = true;
    }

}
