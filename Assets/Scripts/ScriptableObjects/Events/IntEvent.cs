using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="Events/Int Event")]
public class IntEvent : ScriptableObjectBase
{
    public UnityAction<int> onEventRaised;

    public void RaisedEvent(int value)
    {
        onEventRaised?.Invoke(value);
    }

    public void Subscribe(UnityAction<int> function)
    {
        onEventRaised += function;
    }

    public void Unsubscribe(UnityAction<int> function)
    {
        onEventRaised -= function;
    }
}
