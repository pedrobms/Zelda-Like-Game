using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver{

    public float runtimeValue;
    public float defaultValue;

    public void OnAfterDeserialize(){
      runtimeValue = defaultValue;
    }

    public void OnBeforeSerialize(){

    }
}
