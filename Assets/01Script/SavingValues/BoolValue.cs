using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Value/Bool")]
[System.Serializable]
public class BoolValue : ScriptableObject
{
    public bool initialValue;

    public bool RuntimeValue;
  
}
