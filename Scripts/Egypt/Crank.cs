using Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crank : InteractableObject
{
    public Animator anim;
    //Evento al script "SecretCodeResolve"
    public delegate void EventHandler();
    public static event EventHandler CrankEvent;

    protected override void OnActivate()
    {
        //anim.Play();
    }
}