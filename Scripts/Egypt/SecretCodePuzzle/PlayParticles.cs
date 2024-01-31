using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayParticles : MonoBehaviour
{
    public List<ParticleSystem> particles = new List<ParticleSystem>();
    //public GameObject particleContainer;
    public float duration;

    public delegate void EventHandler(bool correct);

    // Declare the event of type MyEventHandler
    public static event EventHandler OnParticlesStop;
    public MaterialLerp script;
    private void Start()
    {
        CodeLineScript.OnStart += StartPlayingParticles;
    }
    private void StartPlayingParticles(string lineName)
    {
        if(transform.parent.transform.parent.gameObject.name == lineName)
        {
            script.enabled = true;
            foreach (ParticleSystem particle in particles)
            {
                particle.Play();
            }
            Invoke("StopEmitter", duration); // Call method after 5 seconds
                                             //Invoke("StopEmitter", duration); // Call method after 5 seconds
        }

    }
    private void StopEmitter()
    {

        foreach (ParticleSystem particle in particles)
        {
            particle.Stop();
        }

      foreach (var child in transform)
        {
        }
    }
}
