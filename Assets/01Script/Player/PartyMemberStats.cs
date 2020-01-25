using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMemberStats : CharacterStats
{
    public PlayerJobs characterJobs;


    public override void CalculateCharacter()
    {
        for (int i = 0; i < attributes.Length; i++)
        {
            switch (attributes[i].type)
            {
                case Atributes.MaxHP:
                    switch (characterClass)
                    {
                        case PlayerClass.Barbarian:
                            attributes[i].value.BaseValue = 12 + conMod;
                            break;
                        case PlayerClass.Bard:
                            attributes[i].value.BaseValue = 8 + conMod;
                            break;
                        case PlayerClass.Cleric:
                            attributes[i].value.BaseValue = 8 + conMod;
                            break;
                        case PlayerClass.Druid:
                            attributes[i].value.BaseValue = 8 + conMod;
                            break;
                        case PlayerClass.Fighter:
                            attributes[i].value.BaseValue = 10 + conMod;
                            break;
                        case PlayerClass.Monk:
                            attributes[i].value.BaseValue = 8 + conMod;
                            break;
                        case PlayerClass.Palidin:
                            attributes[i].value.BaseValue = 10 + conMod;
                            break;
                        case PlayerClass.Ranger:
                            attributes[i].value.BaseValue = 10 + conMod;
                            break;
                        case PlayerClass.Rouge:
                            attributes[i].value.BaseValue = 8 + conMod;
                            break;
                        case PlayerClass.Scorcerer:
                            break;
                        case PlayerClass.Warlock:
                            attributes[i].value.BaseValue = 8 + conMod;
                            break;
                        case PlayerClass.Wizard:
                            attributes[i].value.BaseValue = 6 + conMod;
                            break;
                        default:
                            break;
                    }
                    break;
                case Atributes.AC:
                    break;
                default:
                    break;
            }
        }
    }
}
