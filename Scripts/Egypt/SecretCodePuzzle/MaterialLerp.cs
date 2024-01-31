using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class MaterialLerp : MonoBehaviour
{
    public Material material1;
    public Material material2;
    public float duration = 10.0f;
    public MeshRenderer rend;
    private bool pingpongHasToStop= false;
    public bool TriggerScriptOnFinish = false;
    public MoveLidDown Script;

    void Start()
    {

        rend.material = material1;
        Invoke("StopPingPong", duration);

    }

    void Update()
    {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        if (!pingpongHasToStop)
        {
            rend.material.Lerp(material1, material2, lerp);
        }
        // ping-pong between the materials over the duration

    }
    private void StopPingPong()
    {
        pingpongHasToStop = true;
        rend.material = material2;
        if (TriggerScriptOnFinish)
        {
            Script.enabled = true;
        }
       
    }
}
