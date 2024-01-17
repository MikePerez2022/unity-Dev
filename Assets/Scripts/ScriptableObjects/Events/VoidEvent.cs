using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Event")]
public class VoidEvent : ScriptableObjectBase
{
    public UnityAction onEventRaised;

    public void RaisedEvent()
    {
        onEventRaised?.Invoke();
    }

    public void Subscribe(UnityAction function)
    {
        onEventRaised += function;
    }

    public void Unsubscribe(UnityAction function)
    {
        onEventRaised -= function;
    }
}
