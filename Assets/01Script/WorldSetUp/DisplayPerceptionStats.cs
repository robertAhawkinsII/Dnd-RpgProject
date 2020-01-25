using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPerceptionStats : StatNumberDisplay
{
    public void DisplayPerception()
    {
        skillNumberText.text = GameInfo.Investigation.ToString();
        skillTypeText.text = "PERCEPTION";
        ModNumberText.text = GameInfo.intMod.ToString();
    }
}
