using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Value/Int")]
[System.Serializable]
public class IntValue : Value
{
    public int initialValue;

    public int RuntimeValue;

}
