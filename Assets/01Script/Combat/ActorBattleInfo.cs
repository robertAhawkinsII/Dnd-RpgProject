using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorBattleInfo : MonoBehaviour
{

    public enum BattleCondition
    {
        Normal,
        Casting,

        Blinded,
        Charmed,
        Deafened,
        Frightened,
        Grapple,
        Incapacitated,
        Invisible,
        Paralized,
        Petrified,
        Poisned,
        Prone,
        Restrained,
        Stunned,
        Unconscious
    }

    public BattleCondition Charactercondition;

}
