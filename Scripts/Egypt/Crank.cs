using Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crank : MonoBehaviour
{
    public Animator anim;
    public SecretCodeResolve resolve;
    //Evento al script "SecretCodeResolve"
    //public delegate void EventHandler();
    //public static event EventHandler CrankEvent;
    //public void asdfmovie() 
    //{
    //    Debug.Log("asdf");
    //    CrankEvent();
    //}
    public void activatePuzzle()
    {
        resolve.enabled = true;
    }
}