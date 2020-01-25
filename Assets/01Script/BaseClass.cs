using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClass 
{
    private int strength;
    private int dexterity;
    private int constitution;
    private int intelligence;
    private int wisdom;
    private int charisma;

    public int Strength
    {
        get { return strength; }
        set { strength = value; }
    }

    public int Dexterity
    {
        get { return dexterity; }
        set { dexterity = value; }
    }

    public int Constitution { get => constitution; set => constitution = value; }
    public int Intelligence { get => intelligence; set => intelligence = value; }
    public int Wisdom { get => wisdom; set => wisdom = value; }
    public int Charisma { get => charisma; set => charisma = value; }
}
