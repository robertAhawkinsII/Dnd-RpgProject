using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Dialogue/StatCheckRoll")]
public class RollScript : ScriptableObject
{

    public IntValue rollValue;

    public enum RollType
    {
        Acrobatics, AnimalHanndeling,
        Arcana, Athletics, Deception,
        History, Insight, Intimidation, Investigation,
        Medicine, Nature, Perception,
        Performance, Persuasion, Religion,
        SlightOfHand, Stealth, Survival
    }

    public RollType rollType;

    public void RollCheck()
    {
        switch (rollType)
        {
            case RollType.Acrobatics:
                rollValue.RuntimeValue = (Random.Range(1, 20) + GameInfo.Acrobatics + GameInfo.dexMod);
                rollValue.initialValue = (Random.Range(1, 20) + GameInfo.Acrobatics + GameInfo.dexMod);
                break;
            case RollType.AnimalHanndeling:
                rollValue.RuntimeValue = (Random.Range(1, 20) + GameInfo.AnimaHandling + GameInfo.wisMod);
                rollValue.initialValue = (Random.Range(1, 20) + GameInfo.AnimaHandling + GameInfo.wisMod);
                break;
            case RollType.Arcana:
                rollValue.RuntimeValue = (Random.Range(1, 20) + GameInfo.Arcana + GameInfo.wisMod);
                rollValue.initialValue = (Random.Range(1, 20) + GameInfo.Arcana + GameInfo.wisMod);
                break;
            case RollType.Athletics:
                rollValue.RuntimeValue = (Random.Range(1, 20) + GameInfo.Athletics + GameInfo.strMod);
                rollValue.initialValue = (Random.Range(1, 20) + GameInfo.Athletics + GameInfo.strMod);
                break;
            case RollType.Deception:
                rollValue.RuntimeValue = (Random.Range(1, 20) + GameInfo.Deception + GameInfo.chrMod);
                rollValue.initialValue = (Random.Range(1, 20) + GameInfo.Deception + GameInfo.chrMod);
                break;
            case RollType.History:
                rollValue.RuntimeValue = (Random.Range(1, 20) + GameInfo.History + GameInfo.intMod);
                rollValue.initialValue = (Random.Range(1, 20) + GameInfo.History + GameInfo.intMod);
                break;
            case RollType.Insight:
                rollValue.RuntimeValue = (Random.Range(1, 20) + GameInfo.Insight + GameInfo.wisMod);
                rollValue.initialValue = (Random.Range(1, 20) + GameInfo.Insight + GameInfo.wisMod);
                break;
            case RollType.Intimidation:
                rollValue.RuntimeValue = (Random.Range(1, 20) + GameInfo.Intimidation + GameInfo.chrMod);
                rollValue.initialValue = (Random.Range(1, 20) + GameInfo.Intimidation + GameInfo.chrMod);
                break;
            case RollType.Investigation:
                rollValue.RuntimeValue = (Random.Range(1, 20) + GameInfo.Investigation + GameInfo.intMod);
                rollValue.initialValue = (Random.Range(1, 20) + GameInfo.Investigation + GameInfo.intMod);
                break;
            case RollType.Medicine:
                rollValue.RuntimeValue = (Random.Range(1, 20) + GameInfo.Medicine + GameInfo.wisMod);
                rollValue.initialValue = (Random.Range(1, 20) + GameInfo.Medicine + GameInfo.wisMod);
                break;
            case RollType.Nature:
                rollValue.RuntimeValue = (Random.Range(1, 20) + GameInfo.Nature + GameInfo.intMod);
                rollValue.initialValue = (Random.Range(1, 20) + GameInfo.Nature + GameInfo.intMod);
                break;
            case RollType.Perception:
                rollValue.RuntimeValue = (Random.Range(1, 20) + GameInfo.Perception + GameInfo.wisMod);
                rollValue.initialValue = (Random.Range(1, 20) + GameInfo.Perception + GameInfo.wisMod);
                break;
            case RollType.Performance:
                rollValue.RuntimeValue = (Random.Range(1, 20) + GameInfo.Performance + GameInfo.chrMod);
                rollValue.initialValue = (Random.Range(1, 20) + GameInfo.Performance + GameInfo.chrMod);
                break;
            case RollType.Persuasion:
                rollValue.RuntimeValue = (Random.Range(1, 20) + GameInfo.Persuasion + GameInfo.chrMod);
                rollValue.initialValue = (Random.Range(1, 20) + GameInfo.Persuasion + GameInfo.chrMod);
                break;
            case RollType.Religion:
                rollValue.RuntimeValue = (Random.Range(1, 20) + GameInfo.Religion + GameInfo.intMod);
                rollValue.initialValue = (Random.Range(1, 20) + GameInfo.Religion + GameInfo.intMod);
                break;
            case RollType.SlightOfHand:
                rollValue.RuntimeValue = (Random.Range(1, 20) + GameInfo.SlightOfHand + GameInfo.dexMod);
                rollValue.initialValue = (Random.Range(1, 20) + GameInfo.SlightOfHand + GameInfo.dexMod);
                break;
            case RollType.Stealth:
                rollValue.RuntimeValue = (Random.Range(1, 20) + GameInfo.Stealth + GameInfo.dexMod);
                rollValue.initialValue = (Random.Range(1, 20) + GameInfo.Stealth + GameInfo.dexMod);
                break;
            case RollType.Survival:
                rollValue.RuntimeValue = (Random.Range(1, 20) + GameInfo.Survival + GameInfo.wisMod);
                rollValue.initialValue = (Random.Range(1, 20) + GameInfo.Survival + GameInfo.wisMod);
                break;
        }
    }
}
