using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Value/Float")]
[System.Serializable]
public class FloatValue : Value
{
    public float initialValue;

    public float RuntimeValue;

}
