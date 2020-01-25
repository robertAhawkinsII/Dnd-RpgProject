using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerClass 
{

    private string playerName;
    private int playerAge;
    private int playerHight;
    private int playerWeight;
    private int playerLevel;

    private BaseClass playerClass;
    private BaseJob playerJob;
    private BaseRace playerRace;

    public int strMod;
    public int dexMod;
    public int conMod;
    public int intMod;
    public int wisMod;
    public int chrMod;

    public int strClassbounes;
    public int strRacebounes;
    public int dexClassbounes;
    public int dexRacebounes;
    public int conClassbounes;
    public int conRacebounes;
    public int intClassbounes;
    public int intRacebounes;
    public int wisClassbounes;
    public int wisRacebounes;
    public int chrClassbounes;
    public int chrRacebounes;

    #region Attributes
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


    #endregion

    #region Skills
    private int acrobatics;
    private int animaHandling;
    private int arcana;
    private int athletics;
    private int deception;
    private int history;
    private int insight;
    private int intimidation;
    private int investigation;
    private int medicine;
    private int nature;
    private int perception;
    private int performance;
    private int persuasion;
    private int religion;
    private int slightOfHand;
    private int stealth;
    private int survival;

    public int Acrobatics { get => acrobatics; set => acrobatics = value; }
    public int AnimaHandling { get => animaHandling; set => animaHandling = value; }
    public int Arcana { get => arcana; set => arcana = value; }
    public int Athletics { get => athletics; set => athletics = value; }
    public int Deception { get => deception; set => deception = value; }
    public int History { get => history; set => history = value; }
    public int Insight { get => insight; set => insight = value; }
    public int Intimidation { get => intimidation; set => intimidation = value; }
    public int Investigation { get => investigation; set => investigation = value; }
    public int Medicine { get => medicine; set => medicine = value; }
    public int Nature { get => nature; set => nature = value; }
    public int Perception { get => perception; set => perception = value; }
    public int Performance { get => performance; set => performance = value; }
    public int Persuasion { get => persuasion; set => persuasion = value; }
    public int Religion { get => religion; set => religion = value; }
    public int SlightOfHand { get => slightOfHand; set => slightOfHand = value; }
    public int Stealth { get => stealth; set => stealth = value; }
    public int Survival { get => survival; set => survival = value; }

    #endregion

    public string PlayerName { get => playerName; set => playerName = value; }
    public int PlayerLevel { get => playerLevel; set => playerLevel = value; }
    public BaseClass PlayerClass { get => playerClass; set => playerClass = value; }
    public BaseJob PlayerJob { get => playerJob; set => playerJob = value; }
    public BaseRace PlayerRace { get => playerRace; set => playerRace = value; }
    public int PlayerAge { get => playerAge; set => playerAge = value; }
    public int PlayerHight { get => playerHight; set => playerHight = value; }
    public int PlayerWeight { get => playerWeight; set => playerWeight = value; }
}
