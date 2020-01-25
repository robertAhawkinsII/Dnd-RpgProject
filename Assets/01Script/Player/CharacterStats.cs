using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CharacterStats : MonoBehaviour
{
    public Sprite CharacterPortrait;

    public InventoryObject inventory, equipment;

    public Attribute[] attributes;

    [SerializeField]
    private FloatValue characterStomach, characterThirst;

    public int characterWeight;

    [SerializeField]
    private IntValue characterHealth;

    [SerializeField]
    private GameObject damageTextPrefab;

    [SerializeField]
    private GameObject statusTextPrefab;

    [SerializeField]
    private Vector3 damageTextPosition;

    public bool isAlive = true;

    public IntValue characterLevel, playerMaxHealth;
    public FloatValue experienceAmassed;
    public FloatValue experience;
    public FloatValue experienceNeeded;


    public int MaxSpeed;
    public float speed;
    public int actionsTaken;
    public int MaxactionsTakable;

    public string CharacterName;

    public PlayerClass characterClass;
    public PlayerJobs characterJobs;

    public int strMod;
    public int dexMod;
    public int conMod;
    public int intMod;
    public int wisMod;
    public int chrMod;

    public bool inBattle;

    private void Start()
    {
        for (int i = 0; i < attributes.Length; i++)
        {
            attributes[i].SetParent(this);
        }
        for (int i = 0; i < equipment.GetSlots.Length; i++)
        {
            equipment.GetSlots[i].OnBeforeUpdate += OnBeforSlotUpdate;
            equipment.GetSlots[i].OnAfterUpdate += OnAfterSlotUpdate;
        }

        CalculateCharacter();
    }

   
    public virtual void CalculateCharacter()
    {
        experienceNeeded.RuntimeValue = experienceNeeded.initialValue;
        for (int i = 0; i < equipment.GetSlots.Length; i++)
        {
            equipment.GetSlots[i].SetCharacterClass(characterClass);
        }
    }

    public void OnBeforSlotUpdate(InventorySlot _slot)
    {
        if (_slot.item != null)
            return;
        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:
                break;
            case InterfaceType.Equipment:

                for (int i = 0; i < _slot.item.buffs.Length; i++)
                {
                    for (int j = 0; j < attributes.Length; j++)
                    {
                        if (attributes[j].type == _slot.item.buffs[i].atributes)
                            attributes[j].value.RemoveModifier(_slot.item.buffs[i]);
                    }
                }
                break;
            case InterfaceType.Chest:
                break;
            default:
                break;
        }
    }
    public void OnAfterSlotUpdate(InventorySlot _slot)
    {
        if (_slot.item != null)
            return;
        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:
                break;
            case InterfaceType.Equipment:

                for (int i = 0; i < _slot.item.buffs.Length; i++)
                {
                    for (int j = 0; j < attributes.Length; j++)
                    {
                        if (attributes[j].type == _slot.item.buffs[i].atributes)
                            attributes[j].value.AddModifier(_slot.item.buffs[i]);
                    }
                }
                break;
            case InterfaceType.Chest:
                break;
            default:
                break;
        }
    }

    public void GainExperience(float expValue)
    {
        experience.RuntimeValue += expValue;
        if (experience.RuntimeValue >= experienceNeeded.RuntimeValue)
        {
            EXPEvaluation();
        }
    }

    void EXPEvaluation()
    {

        experienceAmassed.RuntimeValue += 1;
        characterLevel.RuntimeValue += 1;
        //characterLevel.initialValue += 1; ad this to the save function
        if (experienceAmassed.RuntimeValue < 5)
        {
            PlayerMenuSetUp.Instance.LevelUpSkillsOnly();
            experience.RuntimeValue = experience.initialValue;
            //levelSplashScreen.GetComponent<LevelUpSplashScreenDisplay>().LevelUPSplashUP();
        }
        else if (experienceAmassed.RuntimeValue >= 5)
        {
            PlayerMenuSetUp.Instance.LevelUpStatsandSkills();
            experienceAmassed.RuntimeValue = experienceAmassed.initialValue;
            experience.RuntimeValue = experience.initialValue;
            //levelSplashScreen.GetComponent<LevelUpSplashScreenDisplay>().LevelUPSplashUP();
        }
        experienceNeeded.initialValue = experienceNeeded.initialValue * 3;
        experienceNeeded.RuntimeValue = experienceNeeded.initialValue;
    }

    public void ReceiveDamage(int attack)
    {
        if (attack <= 0)
        {
            attack = 0;
        }
        //anim.TakeDamage
        characterHealth.RuntimeValue -= attack;

        GameObject playerHud = GameObject.Find("BattleGameCanvas");
        GameObject damageText = Instantiate(damageTextPrefab, playerHud.transform);
        damageText.GetComponent<TextMeshProUGUI>().text = "" + Mathf.FloorToInt(attack);
        damageText.transform.localPosition = damageTextPosition;
        damageText.transform.localScale = Vector2.one;
        Destroy(damageText.gameObject, 1f);

        if(characterHealth.RuntimeValue <= 0)
        {
            //KnockOut
            if(characterHealth.RuntimeValue <= -10)
            {
                isAlive = false;
                //deathFunction
            }
        }
    }

    public void Missattack()
    {
        GameObject playerHud = GameObject.Find("BattleGameCanvas");
        GameObject damageText = Instantiate(damageTextPrefab, playerHud.transform);
        damageText.GetComponent<TextMeshProUGUI>().text = "MISS";
        damageText.transform.localPosition = damageTextPosition;
        damageText.transform.localScale = Vector2.one;
        Destroy(damageText.gameObject, 1f);

    }

    private void OnApplicationQuit()
    {
        inventory.Clear();
        equipment.Clear();
    }

    private int inishitiveRoll;

    public int InishitiveRoll { get => inishitiveRoll; set => inishitiveRoll = value; }


    public void RollInishitive(int diceValue)
    {
        inishitiveRoll = diceValue;
        //battleInfo.NotPlayersTurn();
    }

    public void Knockout()
    {

    }

    public void DeathFunction()
    {

    }

    public void DisplaySavingDice()
    {

    }
    public void AttributeModified(Attribute attribute)
    {
        
    }

    [SerializeField]
    private PlayerBattleInfo battleInfo;
    [SerializeField]
    private GameObject BattleUI;

    public void TurnStart()
    {
        MaxSpeed = 30 + (dexMod * 5);
        MaxactionsTakable = 2;
        actionsTaken = MaxactionsTakable;
        speed = MaxSpeed;
        BattleUI.SetActive(true);

        battleInfo.TurnStart();
    }

    public void TurnOver()
    {
        BattleUI.SetActive(false);
    }

}

[System.Serializable]
public class Attribute
{
    [System.NonSerialized]
    public CharacterStats character;
    public Atributes type;
    public ModifiableInt value;

    public void SetParent(CharacterStats _parent)
    {
        character = _parent;
        value = new ModifiableInt(AttributeModified);
    }
    public void AttributeModified()
    {
        character.AttributeModified(this);
    }
}