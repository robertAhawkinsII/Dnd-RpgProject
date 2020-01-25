using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InishitiveRoll : MonoBehaviour
{
    [SerializeField]
    private CharacterStats playerInishitive;

    [Header("Dice images")]
    #region DiceComponents
    public Sprite Dice1;
    public Sprite Dice2;
    public Sprite Dice3;
    public Sprite Dice4;
    public Sprite Dice5;
    public Sprite Dice6;
    public Sprite Dice7;
    public Sprite Dice8;
    public Sprite Dice9;
    public Sprite Dice10;
    public Sprite Dice11;
    public Sprite Dice12;
    public Sprite Dice13;
    public Sprite Dice14;
    public Sprite Dice15;
    public Sprite Dice16;
    public Sprite Dice17;
    public Sprite Dice18;
    public Sprite Dice19;
    public Sprite Dice20;

    public Image diceOBJ;
    public int diceValue;
    #endregion

    private void Awake()
    {
        playerInishitive = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
    }

    public void DiceRoleEvent()
    {
        diceValue = Random.Range(1, 21);
        #region ImageSwitching
        if (diceValue == 1)
        {
            diceOBJ.sprite = Dice1;
        }
        if (diceValue == 2)
        {
            diceOBJ.sprite = Dice2;
        }
        if (diceValue == 3)
        {
            diceOBJ.sprite = Dice3;
        }
        if (diceValue == 4)
        {
            diceOBJ.sprite = Dice4;
        }
        if (diceValue == 5)
        {
            diceOBJ.sprite = Dice5;
        }
        if (diceValue == 6)
        {
            diceOBJ.sprite = Dice6;
        }
        if (diceValue == 7)
        {
            diceOBJ.sprite = Dice7;
        }
        if (diceValue == 8)
        {
            diceOBJ.sprite = Dice8;
        }
        if (diceValue == 9)
        {
            diceOBJ.sprite = Dice9;
        }
        if (diceValue == 10)
        {
            diceOBJ.sprite = Dice10;
        }
        if (diceValue == 11)
        {
            diceOBJ.sprite = Dice11;
        }
        if (diceValue == 12)
        {
            diceOBJ.sprite = Dice12;
        }
        if (diceValue == 13)
        {
            diceOBJ.sprite = Dice13;
        }
        if (diceValue == 14)
        {
            diceOBJ.sprite = Dice14;
        }
        if (diceValue == 15)
        {
            diceOBJ.sprite = Dice15;
        }
        if (diceValue == 16)
        {
            diceOBJ.sprite = Dice16;
        }
        if (diceValue == 17)
        {
            diceOBJ.sprite = Dice17;
        }
        if (diceValue == 18)
        {
            diceOBJ.sprite = Dice18;
        }
        if (diceValue == 19)
        {
            diceOBJ.sprite = Dice19;
        }
        if (diceValue == 20)
        {
            diceOBJ.sprite = Dice20;
        }
        #endregion
        playerInishitive.RollInishitive(diceValue);
    }


}
