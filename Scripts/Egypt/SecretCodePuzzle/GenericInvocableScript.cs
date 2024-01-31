using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GenericInvocableScript
{
    public bool _enabled = true;
    public bool enabled
    {
        get
        {
            return _enabled;
        }
        set
        {
            _enabled = value;
        }
    }
    private Transform _target;
    public GenericInvocableScript(Transform transform)
    {
        _target = transform;
    }

    public void Update()
    {
        _target.position = _target.position + Vector3.forward * Time.deltaTime;
    }
}