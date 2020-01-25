using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    [SerializeField]
    private IntValue playerAC;

    public IntValue Maxcarryweight;
    public FloatValue carryWeight;

    public override void CalculateCharacter()
    {
        CharacterName = GameInfo.PlayerName;

        strMod = GameInfo.strMod;
        dexMod = GameInfo.dexMod;
        conMod = GameInfo.conMod;
        intMod = GameInfo.intMod;
        wisMod = GameInfo.wisMod;
        chrMod = GameInfo.chrMod;

        characterClass = GameInfo.setClass;
        characterJobs = GameInfo.setJobs;
        HealthSetup();
        ACSetUp();
        Maxcarryweight.initialValue = (GameInfo.Strength * 15);
        Maxcarryweight.RuntimeValue = (GameInfo.Strength * 15);

        characterLevel.initialValue = GameInfo.PlayerLevel;
        characterLevel.RuntimeValue = GameInfo.PlayerLevel;
        experienceNeeded.RuntimeValue = experienceNeeded.initialValue;

        characterWeight = GameInfo.characterWeight;

        for (int i = 0; i < attributes.Length; i++)
        {
            switch (attributes[i].type)
            {
                default:
                case Atributes.MaxHP:
                    attributes[i].value.BaseValue = playerMaxHealth.initialValue;
                    
                    break;
                case Atributes.AC:
                    attributes[i].value.BaseValue = playerAC.initialValue;
                    break;
                case Atributes.Strength:
                    attributes[i].value.BaseValue = GameInfo.Strength;
                    break;
                case Atributes.Dexterity:
                    attributes[i].value.BaseValue = GameInfo.Dexterity;
                    break;
                case Atributes.Constitution:
                    attributes[i].value.BaseValue = GameInfo.Constitution;
                    break;
                case Atributes.Intelligence:
                    attributes[i].value.BaseValue = GameInfo.Intelligence;
                    break;
                case Atributes.Wisdon:
                    attributes[i].value.BaseValue = GameInfo.Wisdom;
                    break;
                case Atributes.Charisma:
                    attributes[i].value.BaseValue = GameInfo.Charisma;
                    break;
                case Atributes.Acrobatics:
                    attributes[i].value.BaseValue = GameInfo.Acrobatics + GameInfo.dexMod;
                    break;
                case Atributes.AnimalHandeling:
                    attributes[i].value.BaseValue = GameInfo.AnimaHandling + GameInfo.wisMod;
                    break;
                case Atributes.Arcana:
                    attributes[i].value.BaseValue = GameInfo.Arcana + GameInfo.intMod;
                    break;
                case Atributes.Athletics:
                    attributes[i].value.BaseValue = GameInfo.Athletics + GameInfo.strMod;
                    break;
                case Atributes.Deception:
                    attributes[i].value.BaseValue = GameInfo.Deception + GameInfo.chrMod;
                    break;
                case Atributes.History:
                    attributes[i].value.BaseValue = GameInfo.History + GameInfo.intMod;
                    break;
                case Atributes.Insight:
                    attributes[i].value.BaseValue = GameInfo.Insight + GameInfo.wisMod;
                    break;
                case Atributes.Intimidation:
                    attributes[i].value.BaseValue = GameInfo.Intimidation + GameInfo.chrMod;
                    break;
                case Atributes.Investigation:
                    attributes[i].value.BaseValue = GameInfo.Investigation + GameInfo.intMod;
                    break;
                case Atributes.Medicine:
                    attributes[i].value.BaseValue = GameInfo.Medicine + GameInfo.wisMod;
                    break;
                case Atributes.Nature:
                    attributes[i].value.BaseValue = GameInfo.Nature + GameInfo.intMod;
                    break;
                case Atributes.Perception:
                    attributes[i].value.BaseValue = GameInfo.Perception + GameInfo.wisMod;
                    break;
                case Atributes.Performence:
                    attributes[i].value.BaseValue = GameInfo.Performance + GameInfo.chrMod;
                    break;
                case Atributes.Persuasion:
                    attributes[i].value.BaseValue = GameInfo.Persuasion + GameInfo.chrMod;
                    break;
                case Atributes.Religion:
                    attributes[i].value.BaseValue = GameInfo.Religion + GameInfo.intMod;
                    break;
                case Atributes.SlightOfHand:
                    attributes[i].value.BaseValue = GameInfo.SlightOfHand + GameInfo.dexMod;
                    break;
                case Atributes.Stealth:
                    attributes[i].value.BaseValue = GameInfo.Stealth + GameInfo.dexMod;
                    break;
                case Atributes.Survival:
                    attributes[i].value.BaseValue = GameInfo.Survival + GameInfo.wisMod;
                    break;
            }

        }
        for (int i = 0; i < equipment.GetSlots.Length; i++)
        {
            equipment.GetSlots[i].SetCharacterClass(characterClass);
        }
    }

    void HealthSetup()
    {
        switch (GameInfo.setClass)
        {
            case (PlayerClass.Barbarian):
                playerMaxHealth.initialValue = 12 + GameInfo.conMod;
                break;
            case (PlayerClass.Bard):
                playerMaxHealth.initialValue = 8 + GameInfo.conMod;
                break;
            case (PlayerClass.Cleric):
                playerMaxHealth.initialValue = 8 + GameInfo.conMod;
                break;
            case (PlayerClass.Druid):
                playerMaxHealth.initialValue = 8 + GameInfo.conMod;
                break;
            case (PlayerClass.Fighter):
                playerMaxHealth.initialValue = 10 + GameInfo.conMod;
                break;
            case (PlayerClass.Monk):
                playerMaxHealth.initialValue = 8 + GameInfo.conMod;
                break;
            case (PlayerClass.Palidin):
                playerMaxHealth.initialValue = 10 + GameInfo.conMod;
                break;
            case (PlayerClass.Ranger):
                playerMaxHealth.initialValue = 10 + GameInfo.conMod;
                break;
            case (PlayerClass.Rouge):
                playerMaxHealth.initialValue = 8 + GameInfo.conMod;
                break;
            case (PlayerClass.Scorcerer):
                playerMaxHealth.initialValue = 6 + GameInfo.conMod;
                break;
            case (PlayerClass.Warlock):
                playerMaxHealth.initialValue = 8 + GameInfo.conMod;
                break;
            case (PlayerClass.Wizard):
                playerMaxHealth.initialValue = 6 + GameInfo.conMod;
                break;
        }
    }

    void ACSetUp()
    {
        playerAC.initialValue = 10 + GameInfo.dexMod;
    }
}
