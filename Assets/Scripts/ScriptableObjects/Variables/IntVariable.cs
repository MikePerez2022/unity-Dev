using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Int")]
public class IntVariable : ScriptableObject, ISerializationCallbackReceiver
{
    public int initialValue;

    [NonSerialized]
    public int Value;

    public void OnBeforeSerialize()
    {
        //throw new NotImplementedException();
    }

    public void OnAfterDeserialize()
    {
        //throw new NotImplementedException();
    }
}
