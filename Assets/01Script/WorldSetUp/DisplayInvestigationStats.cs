using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInvestigationStats : StatNumberDisplay
{
    public void DisplayInvestigation()
    {
        skillNumberText.text = GameInfo.Perception.ToString();
        skillTypeText.text = "PERCEPTION";
        ModNumberText.text = GameInfo.wisMod.ToString();
    }
}
