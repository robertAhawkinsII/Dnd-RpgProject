using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UnityEngine.SceneManagement;

public class CreatePlayer : MonoBehaviour
{
    private bool PlayerNameGiven = false;
    private bool PlayerAgeGiven = false;

    private BasePlayerClass newPlayer;
    
    private string playerName = " ";
    private string PlayerAge = " ";

    public GameObject nameInputField;
    public GameObject ageInputField;
    public TextMeshProUGUI NameTextDisplay;
    public TextMeshProUGUI AgeTextDisplay;
    public TextMeshProUGUI RaceTextDisplay;
    public TextMeshProUGUI ClassTextDisplay;
    public TextMeshProUGUI BackgroundTextDisplay;

    public TextMeshProUGUI HeightTextDisplay;
    public TextMeshProUGUI WeightTextDisplay;

    //UI
    [Header ("Class UI")]
    public TextMeshProUGUI strengthText;
    public TextMeshProUGUI dexterityText;
    public TextMeshProUGUI constitutionText;
    public TextMeshProUGUI intelligenceText;
    public TextMeshProUGUI wisdomText;
    public TextMeshProUGUI charismaText;

    private int pointsToSpend = 2;
    public TextMeshProUGUI pointsText;


    private int jobPointstoSpend = 5;
    public TextMeshProUGUI jobPointsText;

    [Header("JobUI")]
    public TextMeshProUGUI acrobaticsText;
    public TextMeshProUGUI animalHandelingText;
    public TextMeshProUGUI arcanaText;
    public TextMeshProUGUI athleticsText;
    public TextMeshProUGUI deceptionText;
    public TextMeshProUGUI historyText;
    public TextMeshProUGUI insightText;
    public TextMeshProUGUI intimidationText;
    public TextMeshProUGUI investigationText;
    public TextMeshProUGUI medicineText;
    public TextMeshProUGUI natureText;
    public TextMeshProUGUI perceptionText;
    public TextMeshProUGUI performanceText;
    public TextMeshProUGUI persuasionText;
    public TextMeshProUGUI religionText;
    public TextMeshProUGUI slightOfHandText;
    public TextMeshProUGUI stealthText;
    public TextMeshProUGUI survivalText;


    public TextMeshProUGUI [] strmodtext;
    public TextMeshProUGUI [] dexmodtext;
    public TextMeshProUGUI [] conmodtext;
    public TextMeshProUGUI [] intmodtext;
    public TextMeshProUGUI [] wismodtext;
    public TextMeshProUGUI [] chrmodtext;
    // Start is called before the first frame update

    void Start()
    {
        newPlayer = new BasePlayerClass();
        UpdateUI();
    }

    public void StoreName()
    {
        PlayerPrefs.DeleteKey("PLAYERNAME");
        playerName = nameInputField.GetComponent<Text>().text;
        NameTextDisplay.text =  playerName;
        PlayerNameGiven = true;
    }

    public void StoreAge()
    {
        if(newPlayer.PlayerRace != null)
        {
            PlayerPrefs.DeleteKey("PLAYERAGE");
            PlayerAge = ageInputField.GetComponent<Text>().text;
            AgeTextDisplay.text = "Age: " + PlayerAge + "yr";
            PlayerAgeGiven = true;
        }
        else
        {
            //for the requiermentinsantiation pop up
        }
    }

    int heightRoll1;
    int heightRoll2;

    int weightRoll1;
    int weightRoll2;

    public void RollHightAndWeightCalculations()
    {       
        
        if (newPlayer.PlayerRace != null )
        {
            switch (GameInfo.setRace)
            {
                case PlayerRace.Human:
                    SetHumanRace();
                    heightRoll1 = Random.Range(1, 10);
                    heightRoll2 = Random.Range(1, 10);

                    weightRoll1 = Random.Range(1, 4);
                    weightRoll2 = Random.Range(1, 4);
                    break;
                case PlayerRace.Dwarf:
                    SetDwarfRace();
                    heightRoll1 = Random.Range(1, 4);
                    heightRoll2 = Random.Range(1, 4);

                    weightRoll1 = Random.Range(1, 6);
                    weightRoll2 = Random.Range(1, 6);
                    break;
                case PlayerRace.HillDwarf:
                    SetHillDwarfRace();
                    heightRoll1 = Random.Range(1, 4);
                    heightRoll2 = Random.Range(1, 4);

                    weightRoll1 = Random.Range(1, 6);
                    weightRoll2 = Random.Range(1, 6);
                    break;
                case PlayerRace.MountainDwarf:
                    SetMountainDwarfRace();
                    heightRoll1 = Random.Range(1, 4);
                    heightRoll2 = Random.Range(1, 4);

                    weightRoll1 = Random.Range(1, 6);
                    weightRoll2 = Random.Range(1, 6);
                    break;
                case PlayerRace.Elf:
                    SetElfRace();
                    heightRoll1 = Random.Range(1, 10);
                    heightRoll2 = Random.Range(1, 10);

                    weightRoll1 = Random.Range(1, 4);
                    weightRoll2 = 0;
                    break;
                case PlayerRace.HighElf:
                    SetHighElfRace();
                    heightRoll1 = Random.Range(1, 10);
                    heightRoll2 = Random.Range(1, 10);

                    weightRoll1 = Random.Range(1, 4);
                    weightRoll2 = 0;
                    break;
                case PlayerRace.WoodElf:
                    SetWoodElfRace();
                    heightRoll1 = Random.Range(1, 10);
                    heightRoll2 = Random.Range(1, 10);

                    weightRoll1 = Random.Range(1, 4);
                    weightRoll2 = 0;
                    break;
                case PlayerRace.DarkElf:
                    SetDarkElfRace();
                    heightRoll1 = Random.Range(1, 6);
                    heightRoll2 = Random.Range(1, 6);

                    weightRoll1 = Random.Range(1, 6);
                    weightRoll2 = 0;
                    break;
                case PlayerRace.Halfling:
                    SetHalflingRace();
                    heightRoll1 = Random.Range(1, 4);
                    heightRoll2 = Random.Range(1, 4);

                    weightRoll1 = 1;
                    weightRoll2 = 0;
                    break;
                case PlayerRace.StoutHalfling:
                    SetStoutHalflingRace();
                    heightRoll1 = Random.Range(1, 4);
                    heightRoll2 = Random.Range(1, 4);

                    weightRoll1 = 1;
                    weightRoll2 = 0;
                    break;
                case PlayerRace.LightFootHalfling:
                    SetLightfootHalflingRace();
                    heightRoll1 = Random.Range(1, 4);
                    heightRoll2 = Random.Range(1, 4);

                    weightRoll1 = 1;
                    weightRoll2 = 0;
                    break;
                case PlayerRace.Dragonborn:
                    SetDragonbornRace();
                    heightRoll1 = Random.Range(1, 8);
                    heightRoll2 = Random.Range(1, 8);

                    weightRoll1 = Random.Range(1, 6);
                    weightRoll2 = Random.Range(1, 6);
                    break;
                case PlayerRace.Gnome:
                    SetGnomeRace();
                    heightRoll1 = Random.Range(1, 4);
                    heightRoll2 = Random.Range(1, 4);

                    weightRoll1 = 1;
                    weightRoll2 = 0;
                    break;
                case PlayerRace.ForestGnome:
                    SetForestGnomeRace();
                    heightRoll1 = Random.Range(1, 4);
                    heightRoll2 = Random.Range(1, 4);

                    weightRoll1 = 1;
                    weightRoll2 = 0;
                    break;
                case PlayerRace.RockGnome:
                    SetRockGnomeRace();
                    heightRoll1 = Random.Range(1, 4);
                    heightRoll2 = Random.Range(1, 4);

                    weightRoll1 = 1;
                    weightRoll2 = 0;
                    break;
                case PlayerRace.HalfElf:
                    SetHalfElfRace();
                    heightRoll1 = Random.Range(1, 8);
                    heightRoll2 = Random.Range(1, 8);

                    weightRoll1 = Random.Range(1, 4);
                    weightRoll2 = Random.Range(1, 4);
                    break;
                case PlayerRace.HalfOrc:
                    SetHalfOrcRace();
                    heightRoll1 = Random.Range(1, 10);
                    heightRoll2 = Random.Range(1, 10);

                    weightRoll1 = Random.Range(1, 6);
                    weightRoll2 = Random.Range(1, 6);
                    break;
                case PlayerRace.Tiefling:
                    SetTieflingRace();
                    heightRoll1 = Random.Range(1, 8);
                    heightRoll2 = Random.Range(1, 8);

                    weightRoll1 = Random.Range(1, 4);
                    weightRoll2 = Random.Range(1, 4);
                    break;
            }

            newPlayer.PlayerHight += (heightRoll1 + heightRoll2) * 3;

            newPlayer.PlayerWeight += ((heightRoll1 + heightRoll2) * (weightRoll1 + weightRoll2));

            HeightTextDisplay.text = "" + newPlayer.PlayerHight;
            WeightTextDisplay.text = "" + newPlayer.PlayerWeight;
            UpdateUI();
        }
    }

    public void CreateNewPlayer()
    {
        StoreName();
        StoreAge();
        newPlayer.PlayerLevel = 1;
        newPlayer.PlayerName = newPlayer.PlayerName;

        GameInfo.PlayerLevel = newPlayer.PlayerLevel;
        GameInfo.characterAge = int.Parse(PlayerAge);
        GameInfo.characterHeight = newPlayer.PlayerHight;
        GameInfo.characterWeight = newPlayer.PlayerWeight;
        GameInfo.PlayerName = playerName;
        GameInfo.PlayerClass = newPlayer.PlayerClass;
        GameInfo.PlayerJob = newPlayer.PlayerJob;
        GameInfo.PlayerRace = newPlayer.PlayerRace;

        GameInfo.Strength = newPlayer.Strength;
        GameInfo.Dexterity = newPlayer.Dexterity;
        GameInfo.Constitution = newPlayer.Constitution;
        GameInfo.Intelligence = newPlayer.Intelligence;
        GameInfo.Wisdom = newPlayer.Wisdom;
        GameInfo.Charisma = newPlayer.Charisma;

        GameInfo.Acrobatics = newPlayer.Acrobatics;
        GameInfo.AnimaHandling = newPlayer.AnimaHandling;
        GameInfo.Arcana = newPlayer.Arcana;
        GameInfo.Athletics = newPlayer.Athletics;
        GameInfo.Deception = newPlayer.Deception;
        GameInfo.History = newPlayer.History;
        GameInfo.Insight = newPlayer.Insight;
        GameInfo.Intimidation = newPlayer.Intimidation;
        GameInfo.Investigation = newPlayer.Investigation;
        GameInfo.Medicine = newPlayer.Medicine;
        GameInfo.Nature = newPlayer.Nature;
        GameInfo.Perception = newPlayer.Perception;
        GameInfo.Persuasion = newPlayer.Persuasion;
        GameInfo.Religion = newPlayer.Religion;
        GameInfo.SlightOfHand = newPlayer.SlightOfHand;
        GameInfo.Stealth = newPlayer.Stealth;
        GameInfo.Survival = newPlayer.Survival;

        GameInfo.strMod = newPlayer.strMod;
        GameInfo.dexMod = newPlayer.dexMod;
        GameInfo.conMod = newPlayer.conMod;
        GameInfo.intMod = newPlayer.intMod;
        GameInfo.wisMod = newPlayer.wisMod;
        GameInfo.chrMod = newPlayer.chrMod;

        SaveInfo.SaveAllInfo();
    }

    //needs a Display RaceselectionNeededPrompt function
    #region StatRoll

    bool StrSet = false;
    bool DexSet = false;
    bool ConSet = false;
    bool IntSet = false;
    bool WisSet = false;
    bool ChaSet = false;

    bool AllStatsSet = false;

    public void StRtRoll()
    {
        if(newPlayer.PlayerRace != null)
        {
            int dieRoll1;
            int dieRoll2;
            int dieRoll3;
            int dieRoll4;

            dieRoll1 = Random.Range(1, 6);
            dieRoll2 = Random.Range(1, 6);
            dieRoll3 = Random.Range(1, 6);
            dieRoll4 = Random.Range(1, 6);

            newPlayer.Strength = (dieRoll1 + dieRoll2 + dieRoll3 + dieRoll4) + newPlayer.strRacebounes;
            #region StatModCalculation
            switch (newPlayer.Strength)
            {
                case 0:
                    newPlayer.strMod = -5;
                    break;
                case 1:
                    newPlayer.strMod = -5;
                    break;
                case 2:
                    newPlayer.strMod = -4;
                    break;
                case 3:
                    newPlayer.strMod = -4;
                    break;
                case 4:
                    newPlayer.strMod = -3;
                    break;
                case 5:
                    newPlayer.strMod = -3;
                    break;
                case 6:
                    newPlayer.strMod = -2;
                    break;
                case 7:
                    newPlayer.strMod = -2;
                    break;
                case 8:
                    newPlayer.strMod = -1;
                    break;
                case 9:
                    newPlayer.strMod = -1;
                    break;
                case 10:
                    newPlayer.strMod = 0;
                    break;
                case 11:
                    newPlayer.strMod = 0;
                    break;
                case 12:
                    newPlayer.strMod = 1;
                    break;
                case 13:
                    newPlayer.strMod = 1;
                    break;
                case 14:
                    newPlayer.strMod = 2;
                    break;
                case 15:
                    newPlayer.strMod = 2;
                    break;
                case 16:
                    newPlayer.strMod = 3;
                    break;
                case 17:
                    newPlayer.strMod = 3;
                    break;
                case 18:
                    newPlayer.strMod = 4;
                    break;
                case 19:
                    newPlayer.strMod = 4;
                    break;
                case 20:
                    newPlayer.strMod = 5;
                    break;
                case 21:
                    newPlayer.strMod = 5;
                    break;
                case 22:
                    newPlayer.strMod = 6;
                    break;
                case 23:
                    newPlayer.strMod = 6;
                    break;
                case 24:
                    newPlayer.strMod = 7;
                    break;
                case 25:
                    newPlayer.strMod = 7;
                    break;
                case 26:
                    newPlayer.strMod = 8;
                    break;
                case 27:
                    newPlayer.strMod = 8;
                    break;
                case 28:
                    newPlayer.strMod = 9;
                    break;
                case 29:
                    newPlayer.strMod = 9;
                    break;
                case 30:
                    newPlayer.strMod = 10;
                    newPlayer.Strength = 30;
                    break;
            }
            #endregion
            UpdateUI();

            StrSet = true;
            for (int i = 0; i < StatRollButtons.Length; i++)
            {
                StatRollButtons[0].SetActive(false);
            }
            if (StrSet == true && DexSet == true && ConSet == true && IntSet == true && WisSet == true && ChaSet == true)
            {
                AllStatsSet = true;
            }
        }
        else
        {

        }
    }

    public void DexRoll()
    {
        if (newPlayer.PlayerRace != null)
        {
            int dieRoll1;
            int dieRoll2;
            int dieRoll3;
            int dieRoll4;

            dieRoll1 = Random.Range(1, 6);
            dieRoll2 = Random.Range(1, 6);
            dieRoll3 = Random.Range(1, 6);
            dieRoll4 = Random.Range(1, 6);

            newPlayer.Dexterity = (dieRoll1 + dieRoll2 + dieRoll3 + dieRoll4) + newPlayer.dexRacebounes;
            #region StatModCalculation
            switch (newPlayer.Dexterity)
            {
                case 0:
                    newPlayer.dexMod = -5;
                    break;
                case 1:
                    newPlayer.dexMod = -5;
                    break;
                case 2:
                    newPlayer.dexMod = -4;
                    break;
                case 3:
                    newPlayer.dexMod = -4;
                    break;
                case 4:
                    newPlayer.dexMod = -3;
                    break;
                case 5:
                    newPlayer.dexMod = -3;
                    break;
                case 6:
                    newPlayer.dexMod = -2;
                    break;
                case 7:
                    newPlayer.dexMod = -2;
                    break;
                case 8:
                    newPlayer.dexMod = -1;
                    break;
                case 9:
                    newPlayer.dexMod = -1;
                    break;
                case 10:
                    newPlayer.dexMod = 0;
                    break;
                case 11:
                    newPlayer.dexMod = 0;
                    break;
                case 12:
                    newPlayer.dexMod = 1;
                    break;
                case 13:
                    newPlayer.dexMod = 1;
                    break;
                case 14:
                    newPlayer.dexMod = 2;
                    break;
                case 15:
                    newPlayer.dexMod = 2;
                    break;
                case 16:
                    newPlayer.dexMod = 3;
                    break;
                case 17:
                    newPlayer.dexMod = 3;
                    break;
                case 18:
                    newPlayer.dexMod = 4;
                    break;
                case 19:
                    newPlayer.dexMod = 4;
                    break;
                case 20:
                    newPlayer.dexMod = 5;
                    break;
                case 21:
                    newPlayer.dexMod = 5;
                    break;
                case 22:
                    newPlayer.dexMod = 6;
                    break;
                case 23:
                    newPlayer.dexMod = 6;
                    break;
                case 24:
                    newPlayer.dexMod = 7;
                    break;
                case 25:
                    newPlayer.dexMod = 7;
                    break;
                case 26:
                    newPlayer.dexMod = 8;
                    break;
                case 27:
                    newPlayer.dexMod = 8;
                    break;
                case 28:
                    newPlayer.dexMod = 9;
                    break;
                case 29:
                    newPlayer.dexMod = 9;
                    break;
                case 30:
                    newPlayer.dexMod = 10;
                    newPlayer.Dexterity = 30;
                    break;
            }
            #endregion
            UpdateUI();
            DexSet = true;

            for (int i = 0; i < StatRollButtons.Length; i++)
            {
                StatRollButtons[1].SetActive(false);
            }
            if (StrSet == true && DexSet == true && ConSet == true && IntSet == true && WisSet == true && ChaSet == true)
            {
                AllStatsSet = true;
            }
        }
        else
        {

        }
    }

    public void ConRoll()
    {
        if (newPlayer.PlayerRace != null)
        {
            int dieRoll1;
            int dieRoll2;
            int dieRoll3;
            int dieRoll4;

            dieRoll1 = Random.Range(1, 6);
            dieRoll2 = Random.Range(1, 6);
            dieRoll3 = Random.Range(1, 6);
            dieRoll4 = Random.Range(1, 6);

            newPlayer.Constitution = (dieRoll1 + dieRoll2 + dieRoll3 + dieRoll4) + newPlayer.conRacebounes;

            #region StatModCalculation
            switch (newPlayer.Constitution)
            {
                case 0:
                    newPlayer.conMod = -5;
                    break;
                case 1:
                    newPlayer.conMod = -5;
                    break;
                case 2:
                    newPlayer.conMod = -4;
                    break;
                case 3:
                    newPlayer.conMod = -4;
                    break;
                case 4:
                    newPlayer.conMod = -3;
                    break;
                case 5:
                    newPlayer.conMod = -3;
                    break;
                case 6:
                    newPlayer.conMod = -2;
                    break;
                case 7:
                    newPlayer.conMod = -2;
                    break;
                case 8:
                    newPlayer.conMod = -1;
                    break;
                case 9:
                    newPlayer.conMod = -1;
                    break;
                case 10:
                    newPlayer.conMod = 0;
                    break;
                case 11:
                    newPlayer.conMod = 0;
                    break;
                case 12:
                    newPlayer.conMod = 1;
                    break;
                case 13:
                    newPlayer.conMod = 1;
                    break;
                case 14:
                    newPlayer.conMod = 2;
                    break;
                case 15:
                    newPlayer.conMod = 2;
                    break;
                case 16:
                    newPlayer.conMod = 3;
                    break;
                case 17:
                    newPlayer.conMod = 3;
                    break;
                case 18:
                    newPlayer.conMod = 4;
                    break;
                case 19:
                    newPlayer.conMod = 4;
                    break;
                case 20:
                    newPlayer.conMod = 5;
                    break;
                case 21:
                    newPlayer.conMod = 5;
                    break;
                case 22:
                    newPlayer.conMod = 6;
                    break;
                case 23:
                    newPlayer.conMod = 6;
                    break;
                case 24:
                    newPlayer.conMod = 7;
                    break;
                case 25:
                    newPlayer.conMod = 7;
                    break;
                case 26:
                    newPlayer.conMod = 8;
                    break;
                case 27:
                    newPlayer.conMod = 8;
                    break;
                case 28:
                    newPlayer.conMod = 9;
                    break;
                case 29:
                    newPlayer.conMod = 9;
                    break;
                case 30:
                    newPlayer.conMod = 10;
                    newPlayer.Constitution = 30;
                    break;
            }
            #endregion
            UpdateUI();

            ConSet = true;

            for (int i = 0; i < StatRollButtons.Length; i++)
            {
                StatRollButtons[2].SetActive(false);
            }
            if (StrSet == true && DexSet == true && ConSet == true && IntSet == true && WisSet == true && ChaSet == true)
            {
                AllStatsSet = true;
            }
        }
    }

    public void IntRoll()
    {
        if (newPlayer.PlayerRace != null)
        {
            int dieRoll1;
            int dieRoll2;
            int dieRoll3;
            int dieRoll4;

            dieRoll1 = Random.Range(1, 6);
            dieRoll2 = Random.Range(1, 6);
            dieRoll3 = Random.Range(1, 6);
            dieRoll4 = Random.Range(1, 6);

            newPlayer.Intelligence = (dieRoll1 + dieRoll2 + dieRoll3 + dieRoll4) + newPlayer.intRacebounes;
            #region StatModCalculation
            switch (newPlayer.Intelligence)
            {
                case 0:
                    newPlayer.intMod = -5;
                    break;
                case 1:
                    newPlayer.intMod = -5;
                    break;
                case 2:
                    newPlayer.intMod = -4;
                    break;
                case 3:
                    newPlayer.intMod = -4;
                    break;
                case 4:
                    newPlayer.intMod = -3;
                    break;
                case 5:
                    newPlayer.intMod = -3;
                    break;
                case 6:
                    newPlayer.intMod = -2;
                    break;
                case 7:
                    newPlayer.intMod = -2;
                    break;
                case 8:
                    newPlayer.intMod = -1;
                    break;
                case 9:
                    newPlayer.intMod = -1;
                    break;
                case 10:
                    newPlayer.intMod = 0;
                    break;
                case 11:
                    newPlayer.intMod = 0;
                    break;
                case 12:
                    newPlayer.intMod = 1;
                    break;
                case 13:
                    newPlayer.intMod = 1;
                    break;
                case 14:
                    newPlayer.intMod = 2;
                    break;
                case 15:
                    newPlayer.intMod = 2;
                    break;
                case 16:
                    newPlayer.intMod = 3;
                    break;
                case 17:
                    newPlayer.intMod = 3;
                    break;
                case 18:
                    newPlayer.intMod = 4;
                    break;
                case 19:
                    newPlayer.intMod = 4;
                    break;
                case 20:
                    newPlayer.intMod = 5;
                    break;
                case 21:
                    newPlayer.intMod = 5;
                    break;
                case 22:
                    newPlayer.intMod = 6;
                    break;
                case 23:
                    newPlayer.intMod = 6;
                    break;
                case 24:
                    newPlayer.intMod = 7;
                    break;
                case 25:
                    newPlayer.intMod = 7;
                    break;
                case 26:
                    newPlayer.intMod = 8;
                    break;
                case 27:
                    newPlayer.intMod = 8;
                    break;
                case 28:
                    newPlayer.intMod = 9;
                    break;
                case 29:
                    newPlayer.intMod = 9;
                    break;
                case 30:
                    newPlayer.intMod = 10;
                    newPlayer.Intelligence = 30;
                    break;
            }
            #endregion
            UpdateUI();
            IntSet = true;

            for (int i = 0; i < StatRollButtons.Length; i++)
            {
                StatRollButtons[3].SetActive(false);
            }

            if (StrSet == true && DexSet == true && ConSet == true && IntSet == true && WisSet == true && ChaSet == true)
            {
                AllStatsSet = true;
            }
        }
    }
    public void WisRoll()
    {
        if (newPlayer.PlayerRace != null)
        {
            int dieRoll1;
            int dieRoll2;
            int dieRoll3;
            int dieRoll4;

            dieRoll1 = Random.Range(1, 6);
            dieRoll2 = Random.Range(1, 6);
            dieRoll3 = Random.Range(1, 6);
            dieRoll4 = Random.Range(1, 6);

            newPlayer.Wisdom = (dieRoll1 + dieRoll2 + dieRoll3 + dieRoll4) + newPlayer.wisRacebounes;
            #region StatModCalculation
            switch (newPlayer.Wisdom)
            {
                case 0:
                    newPlayer.wisMod = -5;
                    break;
                case 1:
                    newPlayer.wisMod = -5;
                    break;
                case 2:
                    newPlayer.wisMod = -4;
                    break;
                case 3:
                    newPlayer.wisMod = -4;
                    break;
                case 4:
                    newPlayer.wisMod = -3;
                    break;
                case 5:
                    newPlayer.wisMod = -3;
                    break;
                case 6:
                    newPlayer.wisMod = -2;
                    break;
                case 7:
                    newPlayer.wisMod = -2;
                    break;
                case 8:
                    newPlayer.wisMod = -1;
                    break;
                case 9:
                    newPlayer.wisMod = -1;
                    break;
                case 10:
                    newPlayer.wisMod = 0;
                    break;
                case 11:
                    newPlayer.wisMod = 0;
                    break;
                case 12:
                    newPlayer.wisMod = 1;
                    break;
                case 13:
                    newPlayer.wisMod = 1;
                    break;
                case 14:
                    newPlayer.wisMod = 2;
                    break;
                case 15:
                    newPlayer.wisMod = 2;
                    break;
                case 16:
                    newPlayer.wisMod = 3;
                    break;
                case 17:
                    newPlayer.wisMod = 3;
                    break;
                case 18:
                    newPlayer.wisMod = 4;
                    break;
                case 19:
                    newPlayer.wisMod = 4;
                    break;
                case 20:
                    newPlayer.wisMod = 5;
                    break;
                case 21:
                    newPlayer.wisMod = 5;
                    break;
                case 22:
                    newPlayer.wisMod = 6;
                    break;
                case 23:
                    newPlayer.wisMod = 6;
                    break;
                case 24:
                    newPlayer.wisMod = 7;
                    break;
                case 25:
                    newPlayer.wisMod = 7;
                    break;
                case 26:
                    newPlayer.wisMod = 8;
                    break;
                case 27:
                    newPlayer.wisMod = 8;
                    break;
                case 28:
                    newPlayer.wisMod = 9;
                    break;
                case 29:
                    newPlayer.wisMod = 9;
                    break;
                case 30:
                    newPlayer.wisMod = 10;
                    newPlayer.Wisdom = 30;
                    break;
            }
            #endregion
            UpdateUI();
            WisSet = true;

            for (int i = 0; i < StatRollButtons.Length; i++)
            {
                StatRollButtons[4].SetActive(false);
            }

            if (StrSet == true && DexSet == true && ConSet == true && IntSet == true && WisSet == true && ChaSet == true)
            {
                AllStatsSet = true;
            }
        }
    }

    public void ChaRoll()
    {
        if (newPlayer.PlayerRace != null)
        {
            int dieRoll1;
            int dieRoll2;
            int dieRoll3;
            int dieRoll4;

            dieRoll1 = Random.Range(1, 6);
            dieRoll2 = Random.Range(1, 6);
            dieRoll3 = Random.Range(1, 6);
            dieRoll4 = Random.Range(1, 6);

            newPlayer.Charisma = (dieRoll1 + dieRoll2 + dieRoll3 + dieRoll4) + newPlayer.chrRacebounes;

            #region StatModCalculation
            switch (newPlayer.Charisma)
            {
                case 0:
                    newPlayer.chrMod = -5;
                    break;
                case 1:
                    newPlayer.chrMod = -5;
                    break;
                case 2:
                    newPlayer.chrMod = -4;
                    break;
                case 3:
                    newPlayer.chrMod = -4;
                    break;
                case 4:
                    newPlayer.chrMod = -3;
                    break;
                case 5:
                    newPlayer.chrMod = -3;
                    break;
                case 6:
                    newPlayer.chrMod = -2;
                    break;
                case 7:
                    newPlayer.chrMod = -2;
                    break;
                case 8:
                    newPlayer.chrMod = -1;
                    break;
                case 9:
                    newPlayer.chrMod = -1;
                    break;
                case 10:
                    newPlayer.chrMod = 0;
                    break;
                case 11:
                    newPlayer.chrMod = 0;
                    break;
                case 12:
                    newPlayer.chrMod = 1;
                    break;
                case 13:
                    newPlayer.chrMod = 1;
                    break;
                case 14:
                    newPlayer.chrMod = 2;
                    break;
                case 15:
                    newPlayer.chrMod = 2;
                    break;
                case 16:
                    newPlayer.chrMod = 3;
                    break;
                case 17:
                    newPlayer.chrMod = 3;
                    break;
                case 18:
                    newPlayer.chrMod = 4;
                    break;
                case 19:
                    newPlayer.chrMod = 4;
                    break;
                case 20:
                    newPlayer.chrMod = 5;
                    break;
                case 21:
                    newPlayer.chrMod = 5;
                    break;
                case 22:
                    newPlayer.chrMod = 6;
                    break;
                case 23:
                    newPlayer.chrMod = 6;
                    break;
                case 24:
                    newPlayer.chrMod = 7;
                    break;
                case 25:
                    newPlayer.chrMod = 7;
                    break;
                case 26:
                    newPlayer.chrMod = 8;
                    break;
                case 27:
                    newPlayer.chrMod = 8;
                    break;
                case 28:
                    newPlayer.chrMod = 9;
                    break;
                case 29:
                    newPlayer.chrMod = 9;
                    break;
                case 30:
                    newPlayer.chrMod = 10;
                    newPlayer.Charisma = 30;
                    break;
            }
            #endregion
            UpdateUI();
            ChaSet = true;

            for (int i = 0; i < StatRollButtons.Length; i++)
            {
                StatRollButtons[5].SetActive(false);
            }

            if (StrSet == true && DexSet == true && ConSet == true && IntSet == true && WisSet == true && ChaSet == true)
            {
                AllStatsSet = true;
            }
        }
    }

    #endregion
    [SerializeField]
    GameObject[] StatRollButtons;
    public void displayStatRollButtons()
    {
        StrSet = false;
        DexSet = false;
        ConSet = false;
        IntSet = false;
        WisSet = false;
        ChaSet = false;
        AllStatsSet = false;
        pointsToSpend = 2;
        jobPointstoSpend = 5;

        newPlayer.Strength = 0;
        newPlayer.Dexterity = 0;
        newPlayer.Constitution = 0;
        newPlayer.Intelligence = 0;
        newPlayer.Wisdom = 0;
        newPlayer.Charisma = 0;

        switch (GameInfo.setJobs)
        {
            case PlayerJobs.Acolyte:
                SetAcolyteJob();
                break;
            case PlayerJobs.Brawler:
                SetBrawlerJob();
                break;
            case PlayerJobs.Hunter:
                SetHunterJob();
                break;
            case PlayerJobs.Marader:
                SetMaraderJob();
                break;
            case PlayerJobs.PotionMixer:
                SetPotionMixerJob();
                break;
            case PlayerJobs.Sage:
                SetScoutJob();
                break;
            case PlayerJobs.Charlatan:
                SetCharlatanJob();
                break;
            case PlayerJobs.Criminal:
                SetCriminalJob();
                break;
            case PlayerJobs.Entertainer:
                SetEntertainerJob();
                break;
            case PlayerJobs.ExcomunicatedPolition:
                SetSocialSJob();
                break;
            case PlayerJobs.FolkHero:
                SetFolkHeroJob();
                break;
            case PlayerJobs.GuildArtisan:
                SetGuildArtisanJob();
                break;
            case PlayerJobs.Hermit:
                SetHermitJob();
                break;
            case PlayerJobs.HopfulDoctor:
                SetHopfulDoctor();
                break;
            case PlayerJobs.Noble:
                SetNobleJob();
                break;
            case PlayerJobs.Outlander:
                SetOutlanderJob();
                break;
            case PlayerJobs.RecoveringAssassin:
                SetAssassinJob();
                break;
            case PlayerJobs.Sailor:
                SetSailorJob();
                break;
            case PlayerJobs.Soldier:
                SetSoldierJob();
                break;
            case PlayerJobs.Urchin:
                SetUrchinJob();
                break;
        }

        for (int i = 0; i < StatRollButtons.Length; i++)
        {
            StatRollButtons[i].SetActive(true);
        }
        UpdateUI();
    }

    #region Classes
    public void SetBarbarianClass()
    {
        newPlayer.PlayerClass = new BaseBarbarianClass();
        GameInfo.setClass = PlayerClass.Barbarian;
        #region StatModCalculation
        switch (newPlayer.Strength)
        {
            case 0:
                newPlayer.strMod = -5;
                break;
            case 1:
                newPlayer.strMod = -5;
                break;
            case 2:
                newPlayer.strMod = -4;
                break;
            case 3:
                newPlayer.strMod = -4;
                break;
            case 4:
                newPlayer.strMod = -3;
                break;
            case 5:
                newPlayer.strMod = -3;
                break;
            case 6:
                newPlayer.strMod = -2;
                break;
            case 7:
                newPlayer.strMod = -2;
                break;
            case 8:
                newPlayer.strMod = -1;
                break;
            case 9:
                newPlayer.strMod = -1;
                break;
            case 10:
                newPlayer.strMod = 0;
                break;
            case 11:
                newPlayer.strMod = 0;
                break;
            case 12:
                newPlayer.strMod = 1;
                break;
            case 13:
                newPlayer.strMod = 1;
                break;
            case 14:
                newPlayer.strMod = 2;
                break;
            case 15:
                newPlayer.strMod = 2;
                break;
            case 16:
                newPlayer.strMod = 3;
                break;
            case 17:
                newPlayer.strMod = 3;
                break;
            case 18:
                newPlayer.strMod = 4;
                break;
            case 19:
                newPlayer.strMod = 4;
                break;
            case 20:
                newPlayer.strMod = 5;
                break;
            case 21:
                newPlayer.strMod = 5;
                break;
            case 22:
                newPlayer.strMod = 6;
                break;
            case 23:
                newPlayer.strMod = 6;
                break;
            case 24:
                newPlayer.strMod = 7;
                break;
            case 25:
                newPlayer.strMod = 7;
                break;
            case 26:
                newPlayer.strMod = 8;
                break;
            case 27:
                newPlayer.strMod = 8;
                break;
            case 28:
                newPlayer.strMod = 9;
                break;
            case 29:
                newPlayer.strMod = 9;
                break;
            case 30:
                newPlayer.strMod = 10;
                newPlayer.Strength = 30;
                break;
        }
        switch (newPlayer.Dexterity)
        {
            case 0:
                newPlayer.dexMod = -5;
                break;
            case 1:
                newPlayer.dexMod = -5;
                break;
            case 2:
                newPlayer.dexMod = -4;
                break;
            case 3:
                newPlayer.dexMod = -4;
                break;
            case 4:
                newPlayer.dexMod = -3;
                break;
            case 5:
                newPlayer.dexMod = -3;
                break;
            case 6:
                newPlayer.dexMod = -2;
                break;
            case 7:
                newPlayer.dexMod = -2;
                break;
            case 8:
                newPlayer.dexMod = -1;
                break;
            case 9:
                newPlayer.dexMod = -1;
                break;
            case 10:
                newPlayer.dexMod = 0;
                break;
            case 11:
                newPlayer.dexMod = 0;
                break;
            case 12:
                newPlayer.dexMod = 1;
                break;
            case 13:
                newPlayer.dexMod = 1;
                break;
            case 14:
                newPlayer.dexMod = 2;
                break;
            case 15:
                newPlayer.dexMod = 2;
                break;
            case 16:
                newPlayer.dexMod = 3;
                break;
            case 17:
                newPlayer.dexMod = 3;
                break;
            case 18:
                newPlayer.dexMod = 4;
                break;
            case 19:
                newPlayer.dexMod = 4;
                break;
            case 20:
                newPlayer.dexMod = 5;
                break;
            case 21:
                newPlayer.dexMod = 5;
                break;
            case 22:
                newPlayer.dexMod = 6;
                break;
            case 23:
                newPlayer.dexMod = 6;
                break;
            case 24:
                newPlayer.dexMod = 7;
                break;
            case 25:
                newPlayer.dexMod = 7;
                break;
            case 26:
                newPlayer.dexMod = 8;
                break;
            case 27:
                newPlayer.dexMod = 8;
                break;
            case 28:
                newPlayer.dexMod = 9;
                break;
            case 29:
                newPlayer.dexMod = 9;
                break;
            case 30:
                newPlayer.dexMod = 10;
                newPlayer.Dexterity = 30;
                break;
        }
        switch (newPlayer.Constitution)
        {
            case 0:
                newPlayer.conMod = -5;
                break;
            case 1:
                newPlayer.conMod = -5;
                break;
            case 2:
                newPlayer.conMod = -4;
                break;
            case 3:
                newPlayer.conMod = -4;
                break;
            case 4:
                newPlayer.conMod = -3;
                break;
            case 5:
                newPlayer.conMod = -3;
                break;
            case 6:
                newPlayer.conMod = -2;
                break;
            case 7:
                newPlayer.conMod = -2;
                break;
            case 8:
                newPlayer.conMod = -1;
                break;
            case 9:
                newPlayer.conMod = -1;
                break;
            case 10:
                newPlayer.conMod = 0;
                break;
            case 11:
                newPlayer.conMod = 0;
                break;
            case 12:
                newPlayer.conMod = 1;
                break;
            case 13:
                newPlayer.conMod = 1;
                break;
            case 14:
                newPlayer.conMod = 2;
                break;
            case 15:
                newPlayer.conMod = 2;
                break;
            case 16:
                newPlayer.conMod = 3;
                break;
            case 17:
                newPlayer.conMod = 3;
                break;
            case 18:
                newPlayer.conMod = 4;
                break;
            case 19:
                newPlayer.conMod = 4;
                break;
            case 20:
                newPlayer.conMod = 5;
                break;
            case 21:
                newPlayer.conMod = 5;
                break;
            case 22:
                newPlayer.conMod = 6;
                break;
            case 23:
                newPlayer.conMod = 6;
                break;
            case 24:
                newPlayer.conMod = 7;
                break;
            case 25:
                newPlayer.conMod = 7;
                break;
            case 26:
                newPlayer.conMod = 8;
                break;
            case 27:
                newPlayer.conMod = 8;
                break;
            case 28:
                newPlayer.conMod = 9;
                break;
            case 29:
                newPlayer.conMod = 9;
                break;
            case 30:
                newPlayer.conMod = 10;
                newPlayer.Constitution = 30;
                break;
        }
        switch (newPlayer.Intelligence)
        {
            case 0:
                newPlayer.intMod = -5;
                break;
            case 1:
                newPlayer.intMod = -5;
                break;
            case 2:
                newPlayer.intMod = -4;
                break;
            case 3:
                newPlayer.intMod = -4;
                break;
            case 4:
                newPlayer.intMod = -3;
                break;
            case 5:
                newPlayer.intMod = -3;
                break;
            case 6:
                newPlayer.intMod = -2;
                break;
            case 7:
                newPlayer.intMod = -2;
                break;
            case 8:
                newPlayer.intMod = -1;
                break;
            case 9:
                newPlayer.intMod = -1;
                break;
            case 10:
                newPlayer.intMod = 0;
                break;
            case 11:
                newPlayer.intMod = 0;
                break;
            case 12:
                newPlayer.intMod = 1;
                break;
            case 13:
                newPlayer.intMod = 1;
                break;
            case 14:
                newPlayer.intMod = 2;
                break;
            case 15:
                newPlayer.intMod = 2;
                break;
            case 16:
                newPlayer.intMod = 3;
                break;
            case 17:
                newPlayer.intMod = 3;
                break;
            case 18:
                newPlayer.intMod = 4;
                break;
            case 19:
                newPlayer.intMod = 4;
                break;
            case 20:
                newPlayer.intMod = 5;
                break;
            case 21:
                newPlayer.intMod = 5;
                break;
            case 22:
                newPlayer.intMod = 6;
                break;
            case 23:
                newPlayer.intMod = 6;
                break;
            case 24:
                newPlayer.intMod = 7;
                break;
            case 25:
                newPlayer.intMod = 7;
                break;
            case 26:
                newPlayer.intMod = 8;
                break;
            case 27:
                newPlayer.intMod = 8;
                break;
            case 28:
                newPlayer.intMod = 9;
                break;
            case 29:
                newPlayer.intMod = 9;
                break;
            case 30:
                newPlayer.intMod = 10;
                newPlayer.Intelligence = 30;
                break;
        }
        switch (newPlayer.Wisdom)
        {
            case 0:
                newPlayer.wisMod = -5;
                break;
            case 1:
                newPlayer.wisMod = -5;
                break;
            case 2:
                newPlayer.wisMod = -4;
                break;
            case 3:
                newPlayer.wisMod = -4;
                break;
            case 4:
                newPlayer.wisMod = -3;
                break;
            case 5:
                newPlayer.wisMod = -3;
                break;
            case 6:
                newPlayer.wisMod = -2;
                break;
            case 7:
                newPlayer.wisMod = -2;
                break;
            case 8:
                newPlayer.wisMod = -1;
                break;
            case 9:
                newPlayer.wisMod = -1;
                break;
            case 10:
                newPlayer.wisMod = 0;
                break;
            case 11:
                newPlayer.wisMod = 0;
                break;
            case 12:
                newPlayer.wisMod = 1;
                break;
            case 13:
                newPlayer.wisMod = 1;
                break;
            case 14:
                newPlayer.wisMod = 2;
                break;
            case 15:
                newPlayer.wisMod = 2;
                break;
            case 16:
                newPlayer.wisMod = 3;
                break;
            case 17:
                newPlayer.wisMod = 3;
                break;
            case 18:
                newPlayer.wisMod = 4;
                break;
            case 19:
                newPlayer.wisMod = 4;
                break;
            case 20:
                newPlayer.wisMod = 5;
                break;
            case 21:
                newPlayer.wisMod = 5;
                break;
            case 22:
                newPlayer.wisMod = 6;
                break;
            case 23:
                newPlayer.wisMod = 6;
                break;
            case 24:
                newPlayer.wisMod = 7;
                break;
            case 25:
                newPlayer.wisMod = 7;
                break;
            case 26:
                newPlayer.wisMod = 8;
                break;
            case 27:
                newPlayer.wisMod = 8;
                break;
            case 28:
                newPlayer.wisMod = 9;
                break;
            case 29:
                newPlayer.wisMod = 9;
                break;
            case 30:
                newPlayer.wisMod = 10;
                newPlayer.Wisdom = 30;
                break;
        }
        switch (newPlayer.Charisma)
        {
            case 0:
                newPlayer.chrMod = -5;
                break;
            case 1:
                newPlayer.chrMod = -5;
                break;
            case 2:
                newPlayer.chrMod = -4;
                break;
            case 3:
                newPlayer.chrMod = -4;
                break;
            case 4:
                newPlayer.chrMod = -3;
                break;
            case 5:
                newPlayer.chrMod = -3;
                break;
            case 6:
                newPlayer.chrMod = -2;
                break;
            case 7:
                newPlayer.chrMod = -2;
                break;
            case 8:
                newPlayer.chrMod = -1;
                break;
            case 9:
                newPlayer.chrMod = -1;
                break;
            case 10:
                newPlayer.chrMod = 0;
                break;
            case 11:
                newPlayer.chrMod = 0;
                break;
            case 12:
                newPlayer.chrMod = 1;
                break;
            case 13:
                newPlayer.chrMod = 1;
                break;
            case 14:
                newPlayer.chrMod = 2;
                break;
            case 15:
                newPlayer.chrMod = 2;
                break;
            case 16:
                newPlayer.chrMod = 3;
                break;
            case 17:
                newPlayer.chrMod = 3;
                break;
            case 18:
                newPlayer.chrMod = 4;
                break;
            case 19:
                newPlayer.chrMod = 4;
                break;
            case 20:
                newPlayer.chrMod = 5;
                break;
            case 21:
                newPlayer.chrMod = 5;
                break;
            case 22:
                newPlayer.chrMod = 6;
                break;
            case 23:
                newPlayer.chrMod = 6;
                break;
            case 24:
                newPlayer.chrMod = 7;
                break;
            case 25:
                newPlayer.chrMod = 7;
                break;
            case 26:
                newPlayer.chrMod = 8;
                break;
            case 27:
                newPlayer.chrMod = 8;
                break;
            case 28:
                newPlayer.chrMod = 9;
                break;
            case 29:
                newPlayer.chrMod = 9;
                break;
            case 30:
                newPlayer.chrMod = 10;
                newPlayer.Charisma = 30;
                break;
        }
        #endregion
        ClassTextDisplay.text = GameInfo.setClass.ToString();
        UpdateUI();
    }

    public void SetBardClass()
    {
        newPlayer.PlayerClass = new BardClass();
        GameInfo.setClass = PlayerClass.Bard;
        #region StatModCalculation
        switch (newPlayer.Strength)
        {
            case 0:
                newPlayer.strMod = -5;
                break;
            case 1:
                newPlayer.strMod = -5;
                break;
            case 2:
                newPlayer.strMod = -4;
                break;
            case 3:
                newPlayer.strMod = -4;
                break;
            case 4:
                newPlayer.strMod = -3;
                break;
            case 5:
                newPlayer.strMod = -3;
                break;
            case 6:
                newPlayer.strMod = -2;
                break;
            case 7:
                newPlayer.strMod = -2;
                break;
            case 8:
                newPlayer.strMod = -1;
                break;
            case 9:
                newPlayer.strMod = -1;
                break;
            case 10:
                newPlayer.strMod = 0;
                break;
            case 11:
                newPlayer.strMod = 0;
                break;
            case 12:
                newPlayer.strMod = 1;
                break;
            case 13:
                newPlayer.strMod = 1;
                break;
            case 14:
                newPlayer.strMod = 2;
                break;
            case 15:
                newPlayer.strMod = 2;
                break;
            case 16:
                newPlayer.strMod = 3;
                break;
            case 17:
                newPlayer.strMod = 3;
                break;
            case 18:
                newPlayer.strMod = 4;
                break;
            case 19:
                newPlayer.strMod = 4;
                break;
            case 20:
                newPlayer.strMod = 5;
                break;
            case 21:
                newPlayer.strMod = 5;
                break;
            case 22:
                newPlayer.strMod = 6;
                break;
            case 23:
                newPlayer.strMod = 6;
                break;
            case 24:
                newPlayer.strMod = 7;
                break;
            case 25:
                newPlayer.strMod = 7;
                break;
            case 26:
                newPlayer.strMod = 8;
                break;
            case 27:
                newPlayer.strMod = 8;
                break;
            case 28:
                newPlayer.strMod = 9;
                break;
            case 29:
                newPlayer.strMod = 9;
                break;
            case 30:
                newPlayer.strMod = 10;
                newPlayer.Strength = 30;
                break;
        }
        switch (newPlayer.Dexterity)
        {
            case 0:
                newPlayer.dexMod = -5;
                break;
            case 1:
                newPlayer.dexMod = -5;
                break;
            case 2:
                newPlayer.dexMod = -4;
                break;
            case 3:
                newPlayer.dexMod = -4;
                break;
            case 4:
                newPlayer.dexMod = -3;
                break;
            case 5:
                newPlayer.dexMod = -3;
                break;
            case 6:
                newPlayer.dexMod = -2;
                break;
            case 7:
                newPlayer.dexMod = -2;
                break;
            case 8:
                newPlayer.dexMod = -1;
                break;
            case 9:
                newPlayer.dexMod = -1;
                break;
            case 10:
                newPlayer.dexMod = 0;
                break;
            case 11:
                newPlayer.dexMod = 0;
                break;
            case 12:
                newPlayer.dexMod = 1;
                break;
            case 13:
                newPlayer.dexMod = 1;
                break;
            case 14:
                newPlayer.dexMod = 2;
                break;
            case 15:
                newPlayer.dexMod = 2;
                break;
            case 16:
                newPlayer.dexMod = 3;
                break;
            case 17:
                newPlayer.dexMod = 3;
                break;
            case 18:
                newPlayer.dexMod = 4;
                break;
            case 19:
                newPlayer.dexMod = 4;
                break;
            case 20:
                newPlayer.dexMod = 5;
                break;
            case 21:
                newPlayer.dexMod = 5;
                break;
            case 22:
                newPlayer.dexMod = 6;
                break;
            case 23:
                newPlayer.dexMod = 6;
                break;
            case 24:
                newPlayer.dexMod = 7;
                break;
            case 25:
                newPlayer.dexMod = 7;
                break;
            case 26:
                newPlayer.dexMod = 8;
                break;
            case 27:
                newPlayer.dexMod = 8;
                break;
            case 28:
                newPlayer.dexMod = 9;
                break;
            case 29:
                newPlayer.dexMod = 9;
                break;
            case 30:
                newPlayer.dexMod = 10;
                newPlayer.Dexterity = 30;
                break;
        }
        switch (newPlayer.Constitution)
        {
            case 0:
                newPlayer.conMod = -5;
                break;
            case 1:
                newPlayer.conMod = -5;
                break;
            case 2:
                newPlayer.conMod = -4;
                break;
            case 3:
                newPlayer.conMod = -4;
                break;
            case 4:
                newPlayer.conMod = -3;
                break;
            case 5:
                newPlayer.conMod = -3;
                break;
            case 6:
                newPlayer.conMod = -2;
                break;
            case 7:
                newPlayer.conMod = -2;
                break;
            case 8:
                newPlayer.conMod = -1;
                break;
            case 9:
                newPlayer.conMod = -1;
                break;
            case 10:
                newPlayer.conMod = 0;
                break;
            case 11:
                newPlayer.conMod = 0;
                break;
            case 12:
                newPlayer.conMod = 1;
                break;
            case 13:
                newPlayer.conMod = 1;
                break;
            case 14:
                newPlayer.conMod = 2;
                break;
            case 15:
                newPlayer.conMod = 2;
                break;
            case 16:
                newPlayer.conMod = 3;
                break;
            case 17:
                newPlayer.conMod = 3;
                break;
            case 18:
                newPlayer.conMod = 4;
                break;
            case 19:
                newPlayer.conMod = 4;
                break;
            case 20:
                newPlayer.conMod = 5;
                break;
            case 21:
                newPlayer.conMod = 5;
                break;
            case 22:
                newPlayer.conMod = 6;
                break;
            case 23:
                newPlayer.conMod = 6;
                break;
            case 24:
                newPlayer.conMod = 7;
                break;
            case 25:
                newPlayer.conMod = 7;
                break;
            case 26:
                newPlayer.conMod = 8;
                break;
            case 27:
                newPlayer.conMod = 8;
                break;
            case 28:
                newPlayer.conMod = 9;
                break;
            case 29:
                newPlayer.conMod = 9;
                break;
            case 30:
                newPlayer.conMod = 10;
                newPlayer.Constitution = 30;
                break;
        }
        switch (newPlayer.Intelligence)
        {
            case 0:
                newPlayer.intMod = -5;
                break;
            case 1:
                newPlayer.intMod = -5;
                break;
            case 2:
                newPlayer.intMod = -4;
                break;
            case 3:
                newPlayer.intMod = -4;
                break;
            case 4:
                newPlayer.intMod = -3;
                break;
            case 5:
                newPlayer.intMod = -3;
                break;
            case 6:
                newPlayer.intMod = -2;
                break;
            case 7:
                newPlayer.intMod = -2;
                break;
            case 8:
                newPlayer.intMod = -1;
                break;
            case 9:
                newPlayer.intMod = -1;
                break;
            case 10:
                newPlayer.intMod = 0;
                break;
            case 11:
                newPlayer.intMod = 0;
                break;
            case 12:
                newPlayer.intMod = 1;
                break;
            case 13:
                newPlayer.intMod = 1;
                break;
            case 14:
                newPlayer.intMod = 2;
                break;
            case 15:
                newPlayer.intMod = 2;
                break;
            case 16:
                newPlayer.intMod = 3;
                break;
            case 17:
                newPlayer.intMod = 3;
                break;
            case 18:
                newPlayer.intMod = 4;
                break;
            case 19:
                newPlayer.intMod = 4;
                break;
            case 20:
                newPlayer.intMod = 5;
                break;
            case 21:
                newPlayer.intMod = 5;
                break;
            case 22:
                newPlayer.intMod = 6;
                break;
            case 23:
                newPlayer.intMod = 6;
                break;
            case 24:
                newPlayer.intMod = 7;
                break;
            case 25:
                newPlayer.intMod = 7;
                break;
            case 26:
                newPlayer.intMod = 8;
                break;
            case 27:
                newPlayer.intMod = 8;
                break;
            case 28:
                newPlayer.intMod = 9;
                break;
            case 29:
                newPlayer.intMod = 9;
                break;
            case 30:
                newPlayer.intMod = 10;
                newPlayer.Intelligence = 30;
                break;
        }
        switch (newPlayer.Wisdom)
        {
            case 0:
                newPlayer.wisMod = -5;
                break;
            case 1:
                newPlayer.wisMod = -5;
                break;
            case 2:
                newPlayer.wisMod = -4;
                break;
            case 3:
                newPlayer.wisMod = -4;
                break;
            case 4:
                newPlayer.wisMod = -3;
                break;
            case 5:
                newPlayer.wisMod = -3;
                break;
            case 6:
                newPlayer.wisMod = -2;
                break;
            case 7:
                newPlayer.wisMod = -2;
                break;
            case 8:
                newPlayer.wisMod = -1;
                break;
            case 9:
                newPlayer.wisMod = -1;
                break;
            case 10:
                newPlayer.wisMod = 0;
                break;
            case 11:
                newPlayer.wisMod = 0;
                break;
            case 12:
                newPlayer.wisMod = 1;
                break;
            case 13:
                newPlayer.wisMod = 1;
                break;
            case 14:
                newPlayer.wisMod = 2;
                break;
            case 15:
                newPlayer.wisMod = 2;
                break;
            case 16:
                newPlayer.wisMod = 3;
                break;
            case 17:
                newPlayer.wisMod = 3;
                break;
            case 18:
                newPlayer.wisMod = 4;
                break;
            case 19:
                newPlayer.wisMod = 4;
                break;
            case 20:
                newPlayer.wisMod = 5;
                break;
            case 21:
                newPlayer.wisMod = 5;
                break;
            case 22:
                newPlayer.wisMod = 6;
                break;
            case 23:
                newPlayer.wisMod = 6;
                break;
            case 24:
                newPlayer.wisMod = 7;
                break;
            case 25:
                newPlayer.wisMod = 7;
                break;
            case 26:
                newPlayer.wisMod = 8;
                break;
            case 27:
                newPlayer.wisMod = 8;
                break;
            case 28:
                newPlayer.wisMod = 9;
                break;
            case 29:
                newPlayer.wisMod = 9;
                break;
            case 30:
                newPlayer.wisMod = 10;
                newPlayer.Wisdom = 30;
                break;
        }
        switch (newPlayer.Charisma)
        {
            case 0:
                newPlayer.chrMod = -5;
                break;
            case 1:
                newPlayer.chrMod = -5;
                break;
            case 2:
                newPlayer.chrMod = -4;
                break;
            case 3:
                newPlayer.chrMod = -4;
                break;
            case 4:
                newPlayer.chrMod = -3;
                break;
            case 5:
                newPlayer.chrMod = -3;
                break;
            case 6:
                newPlayer.chrMod = -2;
                break;
            case 7:
                newPlayer.chrMod = -2;
                break;
            case 8:
                newPlayer.chrMod = -1;
                break;
            case 9:
                newPlayer.chrMod = -1;
                break;
            case 10:
                newPlayer.chrMod = 0;
                break;
            case 11:
                newPlayer.chrMod = 0;
                break;
            case 12:
                newPlayer.chrMod = 1;
                break;
            case 13:
                newPlayer.chrMod = 1;
                break;
            case 14:
                newPlayer.chrMod = 2;
                break;
            case 15:
                newPlayer.chrMod = 2;
                break;
            case 16:
                newPlayer.chrMod = 3;
                break;
            case 17:
                newPlayer.chrMod = 3;
                break;
            case 18:
                newPlayer.chrMod = 4;
                break;
            case 19:
                newPlayer.chrMod = 4;
                break;
            case 20:
                newPlayer.chrMod = 5;
                break;
            case 21:
                newPlayer.chrMod = 5;
                break;
            case 22:
                newPlayer.chrMod = 6;
                break;
            case 23:
                newPlayer.chrMod = 6;
                break;
            case 24:
                newPlayer.chrMod = 7;
                break;
            case 25:
                newPlayer.chrMod = 7;
                break;
            case 26:
                newPlayer.chrMod = 8;
                break;
            case 27:
                newPlayer.chrMod = 8;
                break;
            case 28:
                newPlayer.chrMod = 9;
                break;
            case 29:
                newPlayer.chrMod = 9;
                break;
            case 30:
                newPlayer.chrMod = 10;
                newPlayer.Charisma = 30;
                break;
        }
        #endregion
        ClassTextDisplay.text = GameInfo.setClass.ToString();
        UpdateUI();
    }

    public void SetClericClass()
    {
        newPlayer.PlayerClass = new ClericClass();
        GameInfo.setClass = PlayerClass.Cleric;
        #region StatModCalculation
        switch (newPlayer.Strength)
        {
            case 0:
                newPlayer.strMod = -5;
                break;
            case 1:
                newPlayer.strMod = -5;
                break;
            case 2:
                newPlayer.strMod = -4;
                break;
            case 3:
                newPlayer.strMod = -4;
                break;
            case 4:
                newPlayer.strMod = -3;
                break;
            case 5:
                newPlayer.strMod = -3;
                break;
            case 6:
                newPlayer.strMod = -2;
                break;
            case 7:
                newPlayer.strMod = -2;
                break;
            case 8:
                newPlayer.strMod = -1;
                break;
            case 9:
                newPlayer.strMod = -1;
                break;
            case 10:
                newPlayer.strMod = 0;
                break;
            case 11:
                newPlayer.strMod = 0;
                break;
            case 12:
                newPlayer.strMod = 1;
                break;
            case 13:
                newPlayer.strMod = 1;
                break;
            case 14:
                newPlayer.strMod = 2;
                break;
            case 15:
                newPlayer.strMod = 2;
                break;
            case 16:
                newPlayer.strMod = 3;
                break;
            case 17:
                newPlayer.strMod = 3;
                break;
            case 18:
                newPlayer.strMod = 4;
                break;
            case 19:
                newPlayer.strMod = 4;
                break;
            case 20:
                newPlayer.strMod = 5;
                break;
            case 21:
                newPlayer.strMod = 5;
                break;
            case 22:
                newPlayer.strMod = 6;
                break;
            case 23:
                newPlayer.strMod = 6;
                break;
            case 24:
                newPlayer.strMod = 7;
                break;
            case 25:
                newPlayer.strMod = 7;
                break;
            case 26:
                newPlayer.strMod = 8;
                break;
            case 27:
                newPlayer.strMod = 8;
                break;
            case 28:
                newPlayer.strMod = 9;
                break;
            case 29:
                newPlayer.strMod = 9;
                break;
            case 30:
                newPlayer.strMod = 10;
                newPlayer.Strength = 30;
                break;
        }
        switch (newPlayer.Dexterity)
        {
            case 0:
                newPlayer.dexMod = -5;
                break;
            case 1:
                newPlayer.dexMod = -5;
                break;
            case 2:
                newPlayer.dexMod = -4;
                break;
            case 3:
                newPlayer.dexMod = -4;
                break;
            case 4:
                newPlayer.dexMod = -3;
                break;
            case 5:
                newPlayer.dexMod = -3;
                break;
            case 6:
                newPlayer.dexMod = -2;
                break;
            case 7:
                newPlayer.dexMod = -2;
                break;
            case 8:
                newPlayer.dexMod = -1;
                break;
            case 9:
                newPlayer.dexMod = -1;
                break;
            case 10:
                newPlayer.dexMod = 0;
                break;
            case 11:
                newPlayer.dexMod = 0;
                break;
            case 12:
                newPlayer.dexMod = 1;
                break;
            case 13:
                newPlayer.dexMod = 1;
                break;
            case 14:
                newPlayer.dexMod = 2;
                break;
            case 15:
                newPlayer.dexMod = 2;
                break;
            case 16:
                newPlayer.dexMod = 3;
                break;
            case 17:
                newPlayer.dexMod = 3;
                break;
            case 18:
                newPlayer.dexMod = 4;
                break;
            case 19:
                newPlayer.dexMod = 4;
                break;
            case 20:
                newPlayer.dexMod = 5;
                break;
            case 21:
                newPlayer.dexMod = 5;
                break;
            case 22:
                newPlayer.dexMod = 6;
                break;
            case 23:
                newPlayer.dexMod = 6;
                break;
            case 24:
                newPlayer.dexMod = 7;
                break;
            case 25:
                newPlayer.dexMod = 7;
                break;
            case 26:
                newPlayer.dexMod = 8;
                break;
            case 27:
                newPlayer.dexMod = 8;
                break;
            case 28:
                newPlayer.dexMod = 9;
                break;
            case 29:
                newPlayer.dexMod = 9;
                break;
            case 30:
                newPlayer.dexMod = 10;
                newPlayer.Dexterity = 30;
                break;
        }
        switch (newPlayer.Constitution)
        {
            case 0:
                newPlayer.conMod = -5;
                break;
            case 1:
                newPlayer.conMod = -5;
                break;
            case 2:
                newPlayer.conMod = -4;
                break;
            case 3:
                newPlayer.conMod = -4;
                break;
            case 4:
                newPlayer.conMod = -3;
                break;
            case 5:
                newPlayer.conMod = -3;
                break;
            case 6:
                newPlayer.conMod = -2;
                break;
            case 7:
                newPlayer.conMod = -2;
                break;
            case 8:
                newPlayer.conMod = -1;
                break;
            case 9:
                newPlayer.conMod = -1;
                break;
            case 10:
                newPlayer.conMod = 0;
                break;
            case 11:
                newPlayer.conMod = 0;
                break;
            case 12:
                newPlayer.conMod = 1;
                break;
            case 13:
                newPlayer.conMod = 1;
                break;
            case 14:
                newPlayer.conMod = 2;
                break;
            case 15:
                newPlayer.conMod = 2;
                break;
            case 16:
                newPlayer.conMod = 3;
                break;
            case 17:
                newPlayer.conMod = 3;
                break;
            case 18:
                newPlayer.conMod = 4;
                break;
            case 19:
                newPlayer.conMod = 4;
                break;
            case 20:
                newPlayer.conMod = 5;
                break;
            case 21:
                newPlayer.conMod = 5;
                break;
            case 22:
                newPlayer.conMod = 6;
                break;
            case 23:
                newPlayer.conMod = 6;
                break;
            case 24:
                newPlayer.conMod = 7;
                break;
            case 25:
                newPlayer.conMod = 7;
                break;
            case 26:
                newPlayer.conMod = 8;
                break;
            case 27:
                newPlayer.conMod = 8;
                break;
            case 28:
                newPlayer.conMod = 9;
                break;
            case 29:
                newPlayer.conMod = 9;
                break;
            case 30:
                newPlayer.conMod = 10;
                newPlayer.Constitution = 30;
                break;
        }
        switch (newPlayer.Intelligence)
        {
            case 0:
                newPlayer.intMod = -5;
                break;
            case 1:
                newPlayer.intMod = -5;
                break;
            case 2:
                newPlayer.intMod = -4;
                break;
            case 3:
                newPlayer.intMod = -4;
                break;
            case 4:
                newPlayer.intMod = -3;
                break;
            case 5:
                newPlayer.intMod = -3;
                break;
            case 6:
                newPlayer.intMod = -2;
                break;
            case 7:
                newPlayer.intMod = -2;
                break;
            case 8:
                newPlayer.intMod = -1;
                break;
            case 9:
                newPlayer.intMod = -1;
                break;
            case 10:
                newPlayer.intMod = 0;
                break;
            case 11:
                newPlayer.intMod = 0;
                break;
            case 12:
                newPlayer.intMod = 1;
                break;
            case 13:
                newPlayer.intMod = 1;
                break;
            case 14:
                newPlayer.intMod = 2;
                break;
            case 15:
                newPlayer.intMod = 2;
                break;
            case 16:
                newPlayer.intMod = 3;
                break;
            case 17:
                newPlayer.intMod = 3;
                break;
            case 18:
                newPlayer.intMod = 4;
                break;
            case 19:
                newPlayer.intMod = 4;
                break;
            case 20:
                newPlayer.intMod = 5;
                break;
            case 21:
                newPlayer.intMod = 5;
                break;
            case 22:
                newPlayer.intMod = 6;
                break;
            case 23:
                newPlayer.intMod = 6;
                break;
            case 24:
                newPlayer.intMod = 7;
                break;
            case 25:
                newPlayer.intMod = 7;
                break;
            case 26:
                newPlayer.intMod = 8;
                break;
            case 27:
                newPlayer.intMod = 8;
                break;
            case 28:
                newPlayer.intMod = 9;
                break;
            case 29:
                newPlayer.intMod = 9;
                break;
            case 30:
                newPlayer.intMod = 10;
                newPlayer.Intelligence = 30;
                break;
        }
        switch (newPlayer.Wisdom)
        {
            case 0:
                newPlayer.wisMod = -5;
                break;
            case 1:
                newPlayer.wisMod = -5;
                break;
            case 2:
                newPlayer.wisMod = -4;
                break;
            case 3:
                newPlayer.wisMod = -4;
                break;
            case 4:
                newPlayer.wisMod = -3;
                break;
            case 5:
                newPlayer.wisMod = -3;
                break;
            case 6:
                newPlayer.wisMod = -2;
                break;
            case 7:
                newPlayer.wisMod = -2;
                break;
            case 8:
                newPlayer.wisMod = -1;
                break;
            case 9:
                newPlayer.wisMod = -1;
                break;
            case 10:
                newPlayer.wisMod = 0;
                break;
            case 11:
                newPlayer.wisMod = 0;
                break;
            case 12:
                newPlayer.wisMod = 1;
                break;
            case 13:
                newPlayer.wisMod = 1;
                break;
            case 14:
                newPlayer.wisMod = 2;
                break;
            case 15:
                newPlayer.wisMod = 2;
                break;
            case 16:
                newPlayer.wisMod = 3;
                break;
            case 17:
                newPlayer.wisMod = 3;
                break;
            case 18:
                newPlayer.wisMod = 4;
                break;
            case 19:
                newPlayer.wisMod = 4;
                break;
            case 20:
                newPlayer.wisMod = 5;
                break;
            case 21:
                newPlayer.wisMod = 5;
                break;
            case 22:
                newPlayer.wisMod = 6;
                break;
            case 23:
                newPlayer.wisMod = 6;
                break;
            case 24:
                newPlayer.wisMod = 7;
                break;
            case 25:
                newPlayer.wisMod = 7;
                break;
            case 26:
                newPlayer.wisMod = 8;
                break;
            case 27:
                newPlayer.wisMod = 8;
                break;
            case 28:
                newPlayer.wisMod = 9;
                break;
            case 29:
                newPlayer.wisMod = 9;
                break;
            case 30:
                newPlayer.wisMod = 10;
                newPlayer.Wisdom = 30;
                break;
        }
        switch (newPlayer.Charisma)
        {
            case 0:
                newPlayer.chrMod = -5;
                break;
            case 1:
                newPlayer.chrMod = -5;
                break;
            case 2:
                newPlayer.chrMod = -4;
                break;
            case 3:
                newPlayer.chrMod = -4;
                break;
            case 4:
                newPlayer.chrMod = -3;
                break;
            case 5:
                newPlayer.chrMod = -3;
                break;
            case 6:
                newPlayer.chrMod = -2;
                break;
            case 7:
                newPlayer.chrMod = -2;
                break;
            case 8:
                newPlayer.chrMod = -1;
                break;
            case 9:
                newPlayer.chrMod = -1;
                break;
            case 10:
                newPlayer.chrMod = 0;
                break;
            case 11:
                newPlayer.chrMod = 0;
                break;
            case 12:
                newPlayer.chrMod = 1;
                break;
            case 13:
                newPlayer.chrMod = 1;
                break;
            case 14:
                newPlayer.chrMod = 2;
                break;
            case 15:
                newPlayer.chrMod = 2;
                break;
            case 16:
                newPlayer.chrMod = 3;
                break;
            case 17:
                newPlayer.chrMod = 3;
                break;
            case 18:
                newPlayer.chrMod = 4;
                break;
            case 19:
                newPlayer.chrMod = 4;
                break;
            case 20:
                newPlayer.chrMod = 5;
                break;
            case 21:
                newPlayer.chrMod = 5;
                break;
            case 22:
                newPlayer.chrMod = 6;
                break;
            case 23:
                newPlayer.chrMod = 6;
                break;
            case 24:
                newPlayer.chrMod = 7;
                break;
            case 25:
                newPlayer.chrMod = 7;
                break;
            case 26:
                newPlayer.chrMod = 8;
                break;
            case 27:
                newPlayer.chrMod = 8;
                break;
            case 28:
                newPlayer.chrMod = 9;
                break;
            case 29:
                newPlayer.chrMod = 9;
                break;
            case 30:
                newPlayer.chrMod = 10;
                newPlayer.Charisma = 30;
                break;
        }
        #endregion
        ClassTextDisplay.text = GameInfo.setClass.ToString();
        UpdateUI();
    }

    public void SetDruidClass()
    {
        newPlayer.PlayerClass = new DruidClass();
        GameInfo.setClass = PlayerClass.Druid;
        #region StatModCalculation
        switch (newPlayer.Strength)
        {
            case 0:
                newPlayer.strMod = -5;
                break;
            case 1:
                newPlayer.strMod = -5;
                break;
            case 2:
                newPlayer.strMod = -4;
                break;
            case 3:
                newPlayer.strMod = -4;
                break;
            case 4:
                newPlayer.strMod = -3;
                break;
            case 5:
                newPlayer.strMod = -3;
                break;
            case 6:
                newPlayer.strMod = -2;
                break;
            case 7:
                newPlayer.strMod = -2;
                break;
            case 8:
                newPlayer.strMod = -1;
                break;
            case 9:
                newPlayer.strMod = -1;
                break;
            case 10:
                newPlayer.strMod = 0;
                break;
            case 11:
                newPlayer.strMod = 0;
                break;
            case 12:
                newPlayer.strMod = 1;
                break;
            case 13:
                newPlayer.strMod = 1;
                break;
            case 14:
                newPlayer.strMod = 2;
                break;
            case 15:
                newPlayer.strMod = 2;
                break;
            case 16:
                newPlayer.strMod = 3;
                break;
            case 17:
                newPlayer.strMod = 3;
                break;
            case 18:
                newPlayer.strMod = 4;
                break;
            case 19:
                newPlayer.strMod = 4;
                break;
            case 20:
                newPlayer.strMod = 5;
                break;
            case 21:
                newPlayer.strMod = 5;
                break;
            case 22:
                newPlayer.strMod = 6;
                break;
            case 23:
                newPlayer.strMod = 6;
                break;
            case 24:
                newPlayer.strMod = 7;
                break;
            case 25:
                newPlayer.strMod = 7;
                break;
            case 26:
                newPlayer.strMod = 8;
                break;
            case 27:
                newPlayer.strMod = 8;
                break;
            case 28:
                newPlayer.strMod = 9;
                break;
            case 29:
                newPlayer.strMod = 9;
                break;
            case 30:
                newPlayer.strMod = 10;
                newPlayer.Strength = 30;
                break;
        }
        switch (newPlayer.Dexterity)
        {
            case 0:
                newPlayer.dexMod = -5;
                break;
            case 1:
                newPlayer.dexMod = -5;
                break;
            case 2:
                newPlayer.dexMod = -4;
                break;
            case 3:
                newPlayer.dexMod = -4;
                break;
            case 4:
                newPlayer.dexMod = -3;
                break;
            case 5:
                newPlayer.dexMod = -3;
                break;
            case 6:
                newPlayer.dexMod = -2;
                break;
            case 7:
                newPlayer.dexMod = -2;
                break;
            case 8:
                newPlayer.dexMod = -1;
                break;
            case 9:
                newPlayer.dexMod = -1;
                break;
            case 10:
                newPlayer.dexMod = 0;
                break;
            case 11:
                newPlayer.dexMod = 0;
                break;
            case 12:
                newPlayer.dexMod = 1;
                break;
            case 13:
                newPlayer.dexMod = 1;
                break;
            case 14:
                newPlayer.dexMod = 2;
                break;
            case 15:
                newPlayer.dexMod = 2;
                break;
            case 16:
                newPlayer.dexMod = 3;
                break;
            case 17:
                newPlayer.dexMod = 3;
                break;
            case 18:
                newPlayer.dexMod = 4;
                break;
            case 19:
                newPlayer.dexMod = 4;
                break;
            case 20:
                newPlayer.dexMod = 5;
                break;
            case 21:
                newPlayer.dexMod = 5;
                break;
            case 22:
                newPlayer.dexMod = 6;
                break;
            case 23:
                newPlayer.dexMod = 6;
                break;
            case 24:
                newPlayer.dexMod = 7;
                break;
            case 25:
                newPlayer.dexMod = 7;
                break;
            case 26:
                newPlayer.dexMod = 8;
                break;
            case 27:
                newPlayer.dexMod = 8;
                break;
            case 28:
                newPlayer.dexMod = 9;
                break;
            case 29:
                newPlayer.dexMod = 9;
                break;
            case 30:
                newPlayer.dexMod = 10;
                newPlayer.Dexterity = 30;
                break;
        }
        switch (newPlayer.Constitution)
        {
            case 0:
                newPlayer.conMod = -5;
                break;
            case 1:
                newPlayer.conMod = -5;
                break;
            case 2:
                newPlayer.conMod = -4;
                break;
            case 3:
                newPlayer.conMod = -4;
                break;
            case 4:
                newPlayer.conMod = -3;
                break;
            case 5:
                newPlayer.conMod = -3;
                break;
            case 6:
                newPlayer.conMod = -2;
                break;
            case 7:
                newPlayer.conMod = -2;
                break;
            case 8:
                newPlayer.conMod = -1;
                break;
            case 9:
                newPlayer.conMod = -1;
                break;
            case 10:
                newPlayer.conMod = 0;
                break;
            case 11:
                newPlayer.conMod = 0;
                break;
            case 12:
                newPlayer.conMod = 1;
                break;
            case 13:
                newPlayer.conMod = 1;
                break;
            case 14:
                newPlayer.conMod = 2;
                break;
            case 15:
                newPlayer.conMod = 2;
                break;
            case 16:
                newPlayer.conMod = 3;
                break;
            case 17:
                newPlayer.conMod = 3;
                break;
            case 18:
                newPlayer.conMod = 4;
                break;
            case 19:
                newPlayer.conMod = 4;
                break;
            case 20:
                newPlayer.conMod = 5;
                break;
            case 21:
                newPlayer.conMod = 5;
                break;
            case 22:
                newPlayer.conMod = 6;
                break;
            case 23:
                newPlayer.conMod = 6;
                break;
            case 24:
                newPlayer.conMod = 7;
                break;
            case 25:
                newPlayer.conMod = 7;
                break;
            case 26:
                newPlayer.conMod = 8;
                break;
            case 27:
                newPlayer.conMod = 8;
                break;
            case 28:
                newPlayer.conMod = 9;
                break;
            case 29:
                newPlayer.conMod = 9;
                break;
            case 30:
                newPlayer.conMod = 10;
                newPlayer.Constitution = 30;
                break;
        }
        switch (newPlayer.Intelligence)
        {
            case 0:
                newPlayer.intMod = -5;
                break;
            case 1:
                newPlayer.intMod = -5;
                break;
            case 2:
                newPlayer.intMod = -4;
                break;
            case 3:
                newPlayer.intMod = -4;
                break;
            case 4:
                newPlayer.intMod = -3;
                break;
            case 5:
                newPlayer.intMod = -3;
                break;
            case 6:
                newPlayer.intMod = -2;
                break;
            case 7:
                newPlayer.intMod = -2;
                break;
            case 8:
                newPlayer.intMod = -1;
                break;
            case 9:
                newPlayer.intMod = -1;
                break;
            case 10:
                newPlayer.intMod = 0;
                break;
            case 11:
                newPlayer.intMod = 0;
                break;
            case 12:
                newPlayer.intMod = 1;
                break;
            case 13:
                newPlayer.intMod = 1;
                break;
            case 14:
                newPlayer.intMod = 2;
                break;
            case 15:
                newPlayer.intMod = 2;
                break;
            case 16:
                newPlayer.intMod = 3;
                break;
            case 17:
                newPlayer.intMod = 3;
                break;
            case 18:
                newPlayer.intMod = 4;
                break;
            case 19:
                newPlayer.intMod = 4;
                break;
            case 20:
                newPlayer.intMod = 5;
                break;
            case 21:
                newPlayer.intMod = 5;
                break;
            case 22:
                newPlayer.intMod = 6;
                break;
            case 23:
                newPlayer.intMod = 6;
                break;
            case 24:
                newPlayer.intMod = 7;
                break;
            case 25:
                newPlayer.intMod = 7;
                break;
            case 26:
                newPlayer.intMod = 8;
                break;
            case 27:
                newPlayer.intMod = 8;
                break;
            case 28:
                newPlayer.intMod = 9;
                break;
            case 29:
                newPlayer.intMod = 9;
                break;
            case 30:
                newPlayer.intMod = 10;
                newPlayer.Intelligence = 30;
                break;
        }
        switch (newPlayer.Wisdom)
        {
            case 0:
                newPlayer.wisMod = -5;
                break;
            case 1:
                newPlayer.wisMod = -5;
                break;
            case 2:
                newPlayer.wisMod = -4;
                break;
            case 3:
                newPlayer.wisMod = -4;
                break;
            case 4:
                newPlayer.wisMod = -3;
                break;
            case 5:
                newPlayer.wisMod = -3;
                break;
            case 6:
                newPlayer.wisMod = -2;
                break;
            case 7:
                newPlayer.wisMod = -2;
                break;
            case 8:
                newPlayer.wisMod = -1;
                break;
            case 9:
                newPlayer.wisMod = -1;
                break;
            case 10:
                newPlayer.wisMod = 0;
                break;
            case 11:
                newPlayer.wisMod = 0;
                break;
            case 12:
                newPlayer.wisMod = 1;
                break;
            case 13:
                newPlayer.wisMod = 1;
                break;
            case 14:
                newPlayer.wisMod = 2;
                break;
            case 15:
                newPlayer.wisMod = 2;
                break;
            case 16:
                newPlayer.wisMod = 3;
                break;
            case 17:
                newPlayer.wisMod = 3;
                break;
            case 18:
                newPlayer.wisMod = 4;
                break;
            case 19:
                newPlayer.wisMod = 4;
                break;
            case 20:
                newPlayer.wisMod = 5;
                break;
            case 21:
                newPlayer.wisMod = 5;
                break;
            case 22:
                newPlayer.wisMod = 6;
                break;
            case 23:
                newPlayer.wisMod = 6;
                break;
            case 24:
                newPlayer.wisMod = 7;
                break;
            case 25:
                newPlayer.wisMod = 7;
                break;
            case 26:
                newPlayer.wisMod = 8;
                break;
            case 27:
                newPlayer.wisMod = 8;
                break;
            case 28:
                newPlayer.wisMod = 9;
                break;
            case 29:
                newPlayer.wisMod = 9;
                break;
            case 30:
                newPlayer.wisMod = 10;
                newPlayer.Wisdom = 30;
                break;
        }
        switch (newPlayer.Charisma)
        {
            case 0:
                newPlayer.chrMod = -5;
                break;
            case 1:
                newPlayer.chrMod = -5;
                break;
            case 2:
                newPlayer.chrMod = -4;
                break;
            case 3:
                newPlayer.chrMod = -4;
                break;
            case 4:
                newPlayer.chrMod = -3;
                break;
            case 5:
                newPlayer.chrMod = -3;
                break;
            case 6:
                newPlayer.chrMod = -2;
                break;
            case 7:
                newPlayer.chrMod = -2;
                break;
            case 8:
                newPlayer.chrMod = -1;
                break;
            case 9:
                newPlayer.chrMod = -1;
                break;
            case 10:
                newPlayer.chrMod = 0;
                break;
            case 11:
                newPlayer.chrMod = 0;
                break;
            case 12:
                newPlayer.chrMod = 1;
                break;
            case 13:
                newPlayer.chrMod = 1;
                break;
            case 14:
                newPlayer.chrMod = 2;
                break;
            case 15:
                newPlayer.chrMod = 2;
                break;
            case 16:
                newPlayer.chrMod = 3;
                break;
            case 17:
                newPlayer.chrMod = 3;
                break;
            case 18:
                newPlayer.chrMod = 4;
                break;
            case 19:
                newPlayer.chrMod = 4;
                break;
            case 20:
                newPlayer.chrMod = 5;
                break;
            case 21:
                newPlayer.chrMod = 5;
                break;
            case 22:
                newPlayer.chrMod = 6;
                break;
            case 23:
                newPlayer.chrMod = 6;
                break;
            case 24:
                newPlayer.chrMod = 7;
                break;
            case 25:
                newPlayer.chrMod = 7;
                break;
            case 26:
                newPlayer.chrMod = 8;
                break;
            case 27:
                newPlayer.chrMod = 8;
                break;
            case 28:
                newPlayer.chrMod = 9;
                break;
            case 29:
                newPlayer.chrMod = 9;
                break;
            case 30:
                newPlayer.chrMod = 10;
                newPlayer.Charisma = 30;
                break;
        }
        #endregion
        ClassTextDisplay.text = GameInfo.setClass.ToString();
        UpdateUI();
    }

    public void SetFighterClass()
    {
        newPlayer.PlayerClass = new BaseFighterClass();
        GameInfo.setClass = PlayerClass.Fighter;
        #region StatModCalculation
        switch (newPlayer.Strength)
        {
            case 0:
                newPlayer.strMod = -5;
                break;
            case 1:
                newPlayer.strMod = -5;
                break;
            case 2:
                newPlayer.strMod = -4;
                break;
            case 3:
                newPlayer.strMod = -4;
                break;
            case 4:
                newPlayer.strMod = -3;
                break;
            case 5:
                newPlayer.strMod = -3;
                break;
            case 6:
                newPlayer.strMod = -2;
                break;
            case 7:
                newPlayer.strMod = -2;
                break;
            case 8:
                newPlayer.strMod = -1;
                break;
            case 9:
                newPlayer.strMod = -1;
                break;
            case 10:
                newPlayer.strMod = 0;
                break;
            case 11:
                newPlayer.strMod = 0;
                break;
            case 12:
                newPlayer.strMod = 1;
                break;
            case 13:
                newPlayer.strMod = 1;
                break;
            case 14:
                newPlayer.strMod = 2;
                break;
            case 15:
                newPlayer.strMod = 2;
                break;
            case 16:
                newPlayer.strMod = 3;
                break;
            case 17:
                newPlayer.strMod = 3;
                break;
            case 18:
                newPlayer.strMod = 4;
                break;
            case 19:
                newPlayer.strMod = 4;
                break;
            case 20:
                newPlayer.strMod = 5;
                break;
            case 21:
                newPlayer.strMod = 5;
                break;
            case 22:
                newPlayer.strMod = 6;
                break;
            case 23:
                newPlayer.strMod = 6;
                break;
            case 24:
                newPlayer.strMod = 7;
                break;
            case 25:
                newPlayer.strMod = 7;
                break;
            case 26:
                newPlayer.strMod = 8;
                break;
            case 27:
                newPlayer.strMod = 8;
                break;
            case 28:
                newPlayer.strMod = 9;
                break;
            case 29:
                newPlayer.strMod = 9;
                break;
            case 30:
                newPlayer.strMod = 10;
                newPlayer.Strength = 30;
                break;
        }
        switch (newPlayer.Dexterity)
        {
            case 0:
                newPlayer.dexMod = -5;
                break;
            case 1:
                newPlayer.dexMod = -5;
                break;
            case 2:
                newPlayer.dexMod = -4;
                break;
            case 3:
                newPlayer.dexMod = -4;
                break;
            case 4:
                newPlayer.dexMod = -3;
                break;
            case 5:
                newPlayer.dexMod = -3;
                break;
            case 6:
                newPlayer.dexMod = -2;
                break;
            case 7:
                newPlayer.dexMod = -2;
                break;
            case 8:
                newPlayer.dexMod = -1;
                break;
            case 9:
                newPlayer.dexMod = -1;
                break;
            case 10:
                newPlayer.dexMod = 0;
                break;
            case 11:
                newPlayer.dexMod = 0;
                break;
            case 12:
                newPlayer.dexMod = 1;
                break;
            case 13:
                newPlayer.dexMod = 1;
                break;
            case 14:
                newPlayer.dexMod = 2;
                break;
            case 15:
                newPlayer.dexMod = 2;
                break;
            case 16:
                newPlayer.dexMod = 3;
                break;
            case 17:
                newPlayer.dexMod = 3;
                break;
            case 18:
                newPlayer.dexMod = 4;
                break;
            case 19:
                newPlayer.dexMod = 4;
                break;
            case 20:
                newPlayer.dexMod = 5;
                break;
            case 21:
                newPlayer.dexMod = 5;
                break;
            case 22:
                newPlayer.dexMod = 6;
                break;
            case 23:
                newPlayer.dexMod = 6;
                break;
            case 24:
                newPlayer.dexMod = 7;
                break;
            case 25:
                newPlayer.dexMod = 7;
                break;
            case 26:
                newPlayer.dexMod = 8;
                break;
            case 27:
                newPlayer.dexMod = 8;
                break;
            case 28:
                newPlayer.dexMod = 9;
                break;
            case 29:
                newPlayer.dexMod = 9;
                break;
            case 30:
                newPlayer.dexMod = 10;
                newPlayer.Dexterity = 30;
                break;
        }
        switch (newPlayer.Constitution)
        {
            case 0:
                newPlayer.conMod = -5;
                break;
            case 1:
                newPlayer.conMod = -5;
                break;
            case 2:
                newPlayer.conMod = -4;
                break;
            case 3:
                newPlayer.conMod = -4;
                break;
            case 4:
                newPlayer.conMod = -3;
                break;
            case 5:
                newPlayer.conMod = -3;
                break;
            case 6:
                newPlayer.conMod = -2;
                break;
            case 7:
                newPlayer.conMod = -2;
                break;
            case 8:
                newPlayer.conMod = -1;
                break;
            case 9:
                newPlayer.conMod = -1;
                break;
            case 10:
                newPlayer.conMod = 0;
                break;
            case 11:
                newPlayer.conMod = 0;
                break;
            case 12:
                newPlayer.conMod = 1;
                break;
            case 13:
                newPlayer.conMod = 1;
                break;
            case 14:
                newPlayer.conMod = 2;
                break;
            case 15:
                newPlayer.conMod = 2;
                break;
            case 16:
                newPlayer.conMod = 3;
                break;
            case 17:
                newPlayer.conMod = 3;
                break;
            case 18:
                newPlayer.conMod = 4;
                break;
            case 19:
                newPlayer.conMod = 4;
                break;
            case 20:
                newPlayer.conMod = 5;
                break;
            case 21:
                newPlayer.conMod = 5;
                break;
            case 22:
                newPlayer.conMod = 6;
                break;
            case 23:
                newPlayer.conMod = 6;
                break;
            case 24:
                newPlayer.conMod = 7;
                break;
            case 25:
                newPlayer.conMod = 7;
                break;
            case 26:
                newPlayer.conMod = 8;
                break;
            case 27:
                newPlayer.conMod = 8;
                break;
            case 28:
                newPlayer.conMod = 9;
                break;
            case 29:
                newPlayer.conMod = 9;
                break;
            case 30:
                newPlayer.conMod = 10;
                newPlayer.Constitution = 30;
                break;
        }
        switch (newPlayer.Intelligence)
        {
            case 0:
                newPlayer.intMod = -5;
                break;
            case 1:
                newPlayer.intMod = -5;
                break;
            case 2:
                newPlayer.intMod = -4;
                break;
            case 3:
                newPlayer.intMod = -4;
                break;
            case 4:
                newPlayer.intMod = -3;
                break;
            case 5:
                newPlayer.intMod = -3;
                break;
            case 6:
                newPlayer.intMod = -2;
                break;
            case 7:
                newPlayer.intMod = -2;
                break;
            case 8:
                newPlayer.intMod = -1;
                break;
            case 9:
                newPlayer.intMod = -1;
                break;
            case 10:
                newPlayer.intMod = 0;
                break;
            case 11:
                newPlayer.intMod = 0;
                break;
            case 12:
                newPlayer.intMod = 1;
                break;
            case 13:
                newPlayer.intMod = 1;
                break;
            case 14:
                newPlayer.intMod = 2;
                break;
            case 15:
                newPlayer.intMod = 2;
                break;
            case 16:
                newPlayer.intMod = 3;
                break;
            case 17:
                newPlayer.intMod = 3;
                break;
            case 18:
                newPlayer.intMod = 4;
                break;
            case 19:
                newPlayer.intMod = 4;
                break;
            case 20:
                newPlayer.intMod = 5;
                break;
            case 21:
                newPlayer.intMod = 5;
                break;
            case 22:
                newPlayer.intMod = 6;
                break;
            case 23:
                newPlayer.intMod = 6;
                break;
            case 24:
                newPlayer.intMod = 7;
                break;
            case 25:
                newPlayer.intMod = 7;
                break;
            case 26:
                newPlayer.intMod = 8;
                break;
            case 27:
                newPlayer.intMod = 8;
                break;
            case 28:
                newPlayer.intMod = 9;
                break;
            case 29:
                newPlayer.intMod = 9;
                break;
            case 30:
                newPlayer.intMod = 10;
                newPlayer.Intelligence = 30;
                break;
        }
        switch (newPlayer.Wisdom)
        {
            case 0:
                newPlayer.wisMod = -5;
                break;
            case 1:
                newPlayer.wisMod = -5;
                break;
            case 2:
                newPlayer.wisMod = -4;
                break;
            case 3:
                newPlayer.wisMod = -4;
                break;
            case 4:
                newPlayer.wisMod = -3;
                break;
            case 5:
                newPlayer.wisMod = -3;
                break;
            case 6:
                newPlayer.wisMod = -2;
                break;
            case 7:
                newPlayer.wisMod = -2;
                break;
            case 8:
                newPlayer.wisMod = -1;
                break;
            case 9:
                newPlayer.wisMod = -1;
                break;
            case 10:
                newPlayer.wisMod = 0;
                break;
            case 11:
                newPlayer.wisMod = 0;
                break;
            case 12:
                newPlayer.wisMod = 1;
                break;
            case 13:
                newPlayer.wisMod = 1;
                break;
            case 14:
                newPlayer.wisMod = 2;
                break;
            case 15:
                newPlayer.wisMod = 2;
                break;
            case 16:
                newPlayer.wisMod = 3;
                break;
            case 17:
                newPlayer.wisMod = 3;
                break;
            case 18:
                newPlayer.wisMod = 4;
                break;
            case 19:
                newPlayer.wisMod = 4;
                break;
            case 20:
                newPlayer.wisMod = 5;
                break;
            case 21:
                newPlayer.wisMod = 5;
                break;
            case 22:
                newPlayer.wisMod = 6;
                break;
            case 23:
                newPlayer.wisMod = 6;
                break;
            case 24:
                newPlayer.wisMod = 7;
                break;
            case 25:
                newPlayer.wisMod = 7;
                break;
            case 26:
                newPlayer.wisMod = 8;
                break;
            case 27:
                newPlayer.wisMod = 8;
                break;
            case 28:
                newPlayer.wisMod = 9;
                break;
            case 29:
                newPlayer.wisMod = 9;
                break;
            case 30:
                newPlayer.wisMod = 10;
                newPlayer.Wisdom = 30;
                break;
        }
        switch (newPlayer.Charisma)
        {
            case 0:
                newPlayer.chrMod = -5;
                break;
            case 1:
                newPlayer.chrMod = -5;
                break;
            case 2:
                newPlayer.chrMod = -4;
                break;
            case 3:
                newPlayer.chrMod = -4;
                break;
            case 4:
                newPlayer.chrMod = -3;
                break;
            case 5:
                newPlayer.chrMod = -3;
                break;
            case 6:
                newPlayer.chrMod = -2;
                break;
            case 7:
                newPlayer.chrMod = -2;
                break;
            case 8:
                newPlayer.chrMod = -1;
                break;
            case 9:
                newPlayer.chrMod = -1;
                break;
            case 10:
                newPlayer.chrMod = 0;
                break;
            case 11:
                newPlayer.chrMod = 0;
                break;
            case 12:
                newPlayer.chrMod = 1;
                break;
            case 13:
                newPlayer.chrMod = 1;
                break;
            case 14:
                newPlayer.chrMod = 2;
                break;
            case 15:
                newPlayer.chrMod = 2;
                break;
            case 16:
                newPlayer.chrMod = 3;
                break;
            case 17:
                newPlayer.chrMod = 3;
                break;
            case 18:
                newPlayer.chrMod = 4;
                break;
            case 19:
                newPlayer.chrMod = 4;
                break;
            case 20:
                newPlayer.chrMod = 5;
                break;
            case 21:
                newPlayer.chrMod = 5;
                break;
            case 22:
                newPlayer.chrMod = 6;
                break;
            case 23:
                newPlayer.chrMod = 6;
                break;
            case 24:
                newPlayer.chrMod = 7;
                break;
            case 25:
                newPlayer.chrMod = 7;
                break;
            case 26:
                newPlayer.chrMod = 8;
                break;
            case 27:
                newPlayer.chrMod = 8;
                break;
            case 28:
                newPlayer.chrMod = 9;
                break;
            case 29:
                newPlayer.chrMod = 9;
                break;
            case 30:
                newPlayer.chrMod = 10;
                newPlayer.Charisma = 30;
                break;
        }
        #endregion
        ClassTextDisplay.text = GameInfo.setClass.ToString();
        UpdateUI();
    }

    public void SetMonkClass()
    {
        newPlayer.PlayerClass = new MonkClass();
        GameInfo.setClass = PlayerClass.Monk;
        #region StatModCalculation
        switch (newPlayer.Strength)
        {
            case 0:
                newPlayer.strMod = -5;
                break;
            case 1:
                newPlayer.strMod = -5;
                break;
            case 2:
                newPlayer.strMod = -4;
                break;
            case 3:
                newPlayer.strMod = -4;
                break;
            case 4:
                newPlayer.strMod = -3;
                break;
            case 5:
                newPlayer.strMod = -3;
                break;
            case 6:
                newPlayer.strMod = -2;
                break;
            case 7:
                newPlayer.strMod = -2;
                break;
            case 8:
                newPlayer.strMod = -1;
                break;
            case 9:
                newPlayer.strMod = -1;
                break;
            case 10:
                newPlayer.strMod = 0;
                break;
            case 11:
                newPlayer.strMod = 0;
                break;
            case 12:
                newPlayer.strMod = 1;
                break;
            case 13:
                newPlayer.strMod = 1;
                break;
            case 14:
                newPlayer.strMod = 2;
                break;
            case 15:
                newPlayer.strMod = 2;
                break;
            case 16:
                newPlayer.strMod = 3;
                break;
            case 17:
                newPlayer.strMod = 3;
                break;
            case 18:
                newPlayer.strMod = 4;
                break;
            case 19:
                newPlayer.strMod = 4;
                break;
            case 20:
                newPlayer.strMod = 5;
                break;
            case 21:
                newPlayer.strMod = 5;
                break;
            case 22:
                newPlayer.strMod = 6;
                break;
            case 23:
                newPlayer.strMod = 6;
                break;
            case 24:
                newPlayer.strMod = 7;
                break;
            case 25:
                newPlayer.strMod = 7;
                break;
            case 26:
                newPlayer.strMod = 8;
                break;
            case 27:
                newPlayer.strMod = 8;
                break;
            case 28:
                newPlayer.strMod = 9;
                break;
            case 29:
                newPlayer.strMod = 9;
                break;
            case 30:
                newPlayer.strMod = 10;
                newPlayer.Strength = 30;
                break;
        }
        switch (newPlayer.Dexterity)
        {
            case 0:
                newPlayer.dexMod = -5;
                break;
            case 1:
                newPlayer.dexMod = -5;
                break;
            case 2:
                newPlayer.dexMod = -4;
                break;
            case 3:
                newPlayer.dexMod = -4;
                break;
            case 4:
                newPlayer.dexMod = -3;
                break;
            case 5:
                newPlayer.dexMod = -3;
                break;
            case 6:
                newPlayer.dexMod = -2;
                break;
            case 7:
                newPlayer.dexMod = -2;
                break;
            case 8:
                newPlayer.dexMod = -1;
                break;
            case 9:
                newPlayer.dexMod = -1;
                break;
            case 10:
                newPlayer.dexMod = 0;
                break;
            case 11:
                newPlayer.dexMod = 0;
                break;
            case 12:
                newPlayer.dexMod = 1;
                break;
            case 13:
                newPlayer.dexMod = 1;
                break;
            case 14:
                newPlayer.dexMod = 2;
                break;
            case 15:
                newPlayer.dexMod = 2;
                break;
            case 16:
                newPlayer.dexMod = 3;
                break;
            case 17:
                newPlayer.dexMod = 3;
                break;
            case 18:
                newPlayer.dexMod = 4;
                break;
            case 19:
                newPlayer.dexMod = 4;
                break;
            case 20:
                newPlayer.dexMod = 5;
                break;
            case 21:
                newPlayer.dexMod = 5;
                break;
            case 22:
                newPlayer.dexMod = 6;
                break;
            case 23:
                newPlayer.dexMod = 6;
                break;
            case 24:
                newPlayer.dexMod = 7;
                break;
            case 25:
                newPlayer.dexMod = 7;
                break;
            case 26:
                newPlayer.dexMod = 8;
                break;
            case 27:
                newPlayer.dexMod = 8;
                break;
            case 28:
                newPlayer.dexMod = 9;
                break;
            case 29:
                newPlayer.dexMod = 9;
                break;
            case 30:
                newPlayer.dexMod = 10;
                newPlayer.Dexterity = 30;
                break;
        }
        switch (newPlayer.Constitution)
        {
            case 0:
                newPlayer.conMod = -5;
                break;
            case 1:
                newPlayer.conMod = -5;
                break;
            case 2:
                newPlayer.conMod = -4;
                break;
            case 3:
                newPlayer.conMod = -4;
                break;
            case 4:
                newPlayer.conMod = -3;
                break;
            case 5:
                newPlayer.conMod = -3;
                break;
            case 6:
                newPlayer.conMod = -2;
                break;
            case 7:
                newPlayer.conMod = -2;
                break;
            case 8:
                newPlayer.conMod = -1;
                break;
            case 9:
                newPlayer.conMod = -1;
                break;
            case 10:
                newPlayer.conMod = 0;
                break;
            case 11:
                newPlayer.conMod = 0;
                break;
            case 12:
                newPlayer.conMod = 1;
                break;
            case 13:
                newPlayer.conMod = 1;
                break;
            case 14:
                newPlayer.conMod = 2;
                break;
            case 15:
                newPlayer.conMod = 2;
                break;
            case 16:
                newPlayer.conMod = 3;
                break;
            case 17:
                newPlayer.conMod = 3;
                break;
            case 18:
                newPlayer.conMod = 4;
                break;
            case 19:
                newPlayer.conMod = 4;
                break;
            case 20:
                newPlayer.conMod = 5;
                break;
            case 21:
                newPlayer.conMod = 5;
                break;
            case 22:
                newPlayer.conMod = 6;
                break;
            case 23:
                newPlayer.conMod = 6;
                break;
            case 24:
                newPlayer.conMod = 7;
                break;
            case 25:
                newPlayer.conMod = 7;
                break;
            case 26:
                newPlayer.conMod = 8;
                break;
            case 27:
                newPlayer.conMod = 8;
                break;
            case 28:
                newPlayer.conMod = 9;
                break;
            case 29:
                newPlayer.conMod = 9;
                break;
            case 30:
                newPlayer.conMod = 10;
                newPlayer.Constitution = 30;
                break;
        }
        switch (newPlayer.Intelligence)
        {
            case 0:
                newPlayer.intMod = -5;
                break;
            case 1:
                newPlayer.intMod = -5;
                break;
            case 2:
                newPlayer.intMod = -4;
                break;
            case 3:
                newPlayer.intMod = -4;
                break;
            case 4:
                newPlayer.intMod = -3;
                break;
            case 5:
                newPlayer.intMod = -3;
                break;
            case 6:
                newPlayer.intMod = -2;
                break;
            case 7:
                newPlayer.intMod = -2;
                break;
            case 8:
                newPlayer.intMod = -1;
                break;
            case 9:
                newPlayer.intMod = -1;
                break;
            case 10:
                newPlayer.intMod = 0;
                break;
            case 11:
                newPlayer.intMod = 0;
                break;
            case 12:
                newPlayer.intMod = 1;
                break;
            case 13:
                newPlayer.intMod = 1;
                break;
            case 14:
                newPlayer.intMod = 2;
                break;
            case 15:
                newPlayer.intMod = 2;
                break;
            case 16:
                newPlayer.intMod = 3;
                break;
            case 17:
                newPlayer.intMod = 3;
                break;
            case 18:
                newPlayer.intMod = 4;
                break;
            case 19:
                newPlayer.intMod = 4;
                break;
            case 20:
                newPlayer.intMod = 5;
                break;
            case 21:
                newPlayer.intMod = 5;
                break;
            case 22:
                newPlayer.intMod = 6;
                break;
            case 23:
                newPlayer.intMod = 6;
                break;
            case 24:
                newPlayer.intMod = 7;
                break;
            case 25:
                newPlayer.intMod = 7;
                break;
            case 26:
                newPlayer.intMod = 8;
                break;
            case 27:
                newPlayer.intMod = 8;
                break;
            case 28:
                newPlayer.intMod = 9;
                break;
            case 29:
                newPlayer.intMod = 9;
                break;
            case 30:
                newPlayer.intMod = 10;
                newPlayer.Intelligence = 30;
                break;
        }
        switch (newPlayer.Wisdom)
        {
            case 0:
                newPlayer.wisMod = -5;
                break;
            case 1:
                newPlayer.wisMod = -5;
                break;
            case 2:
                newPlayer.wisMod = -4;
                break;
            case 3:
                newPlayer.wisMod = -4;
                break;
            case 4:
                newPlayer.wisMod = -3;
                break;
            case 5:
                newPlayer.wisMod = -3;
                break;
            case 6:
                newPlayer.wisMod = -2;
                break;
            case 7:
                newPlayer.wisMod = -2;
                break;
            case 8:
                newPlayer.wisMod = -1;
                break;
            case 9:
                newPlayer.wisMod = -1;
                break;
            case 10:
                newPlayer.wisMod = 0;
                break;
            case 11:
                newPlayer.wisMod = 0;
                break;
            case 12:
                newPlayer.wisMod = 1;
                break;
            case 13:
                newPlayer.wisMod = 1;
                break;
            case 14:
                newPlayer.wisMod = 2;
                break;
            case 15:
                newPlayer.wisMod = 2;
                break;
            case 16:
                newPlayer.wisMod = 3;
                break;
            case 17:
                newPlayer.wisMod = 3;
                break;
            case 18:
                newPlayer.wisMod = 4;
                break;
            case 19:
                newPlayer.wisMod = 4;
                break;
            case 20:
                newPlayer.wisMod = 5;
                break;
            case 21:
                newPlayer.wisMod = 5;
                break;
            case 22:
                newPlayer.wisMod = 6;
                break;
            case 23:
                newPlayer.wisMod = 6;
                break;
            case 24:
                newPlayer.wisMod = 7;
                break;
            case 25:
                newPlayer.wisMod = 7;
                break;
            case 26:
                newPlayer.wisMod = 8;
                break;
            case 27:
                newPlayer.wisMod = 8;
                break;
            case 28:
                newPlayer.wisMod = 9;
                break;
            case 29:
                newPlayer.wisMod = 9;
                break;
            case 30:
                newPlayer.wisMod = 10;
                newPlayer.Wisdom = 30;
                break;
        }
        switch (newPlayer.Charisma)
        {
            case 0:
                newPlayer.chrMod = -5;
                break;
            case 1:
                newPlayer.chrMod = -5;
                break;
            case 2:
                newPlayer.chrMod = -4;
                break;
            case 3:
                newPlayer.chrMod = -4;
                break;
            case 4:
                newPlayer.chrMod = -3;
                break;
            case 5:
                newPlayer.chrMod = -3;
                break;
            case 6:
                newPlayer.chrMod = -2;
                break;
            case 7:
                newPlayer.chrMod = -2;
                break;
            case 8:
                newPlayer.chrMod = -1;
                break;
            case 9:
                newPlayer.chrMod = -1;
                break;
            case 10:
                newPlayer.chrMod = 0;
                break;
            case 11:
                newPlayer.chrMod = 0;
                break;
            case 12:
                newPlayer.chrMod = 1;
                break;
            case 13:
                newPlayer.chrMod = 1;
                break;
            case 14:
                newPlayer.chrMod = 2;
                break;
            case 15:
                newPlayer.chrMod = 2;
                break;
            case 16:
                newPlayer.chrMod = 3;
                break;
            case 17:
                newPlayer.chrMod = 3;
                break;
            case 18:
                newPlayer.chrMod = 4;
                break;
            case 19:
                newPlayer.chrMod = 4;
                break;
            case 20:
                newPlayer.chrMod = 5;
                break;
            case 21:
                newPlayer.chrMod = 5;
                break;
            case 22:
                newPlayer.chrMod = 6;
                break;
            case 23:
                newPlayer.chrMod = 6;
                break;
            case 24:
                newPlayer.chrMod = 7;
                break;
            case 25:
                newPlayer.chrMod = 7;
                break;
            case 26:
                newPlayer.chrMod = 8;
                break;
            case 27:
                newPlayer.chrMod = 8;
                break;
            case 28:
                newPlayer.chrMod = 9;
                break;
            case 29:
                newPlayer.chrMod = 9;
                break;
            case 30:
                newPlayer.chrMod = 10;
                newPlayer.Charisma = 30;
                break;
        }
        #endregion
        ClassTextDisplay.text = GameInfo.setClass.ToString();
        UpdateUI();
    }

    public void SetPalidinClass()
    {
        newPlayer.PlayerClass = new PalidinClass();
        GameInfo.setClass = PlayerClass.Palidin;
        #region StatModCalculation
        switch (newPlayer.Strength)
        {
            case 0:
                newPlayer.strMod = -5;
                break;
            case 1:
                newPlayer.strMod = -5;
                break;
            case 2:
                newPlayer.strMod = -4;
                break;
            case 3:
                newPlayer.strMod = -4;
                break;
            case 4:
                newPlayer.strMod = -3;
                break;
            case 5:
                newPlayer.strMod = -3;
                break;
            case 6:
                newPlayer.strMod = -2;
                break;
            case 7:
                newPlayer.strMod = -2;
                break;
            case 8:
                newPlayer.strMod = -1;
                break;
            case 9:
                newPlayer.strMod = -1;
                break;
            case 10:
                newPlayer.strMod = 0;
                break;
            case 11:
                newPlayer.strMod = 0;
                break;
            case 12:
                newPlayer.strMod = 1;
                break;
            case 13:
                newPlayer.strMod = 1;
                break;
            case 14:
                newPlayer.strMod = 2;
                break;
            case 15:
                newPlayer.strMod = 2;
                break;
            case 16:
                newPlayer.strMod = 3;
                break;
            case 17:
                newPlayer.strMod = 3;
                break;
            case 18:
                newPlayer.strMod = 4;
                break;
            case 19:
                newPlayer.strMod = 4;
                break;
            case 20:
                newPlayer.strMod = 5;
                break;
            case 21:
                newPlayer.strMod = 5;
                break;
            case 22:
                newPlayer.strMod = 6;
                break;
            case 23:
                newPlayer.strMod = 6;
                break;
            case 24:
                newPlayer.strMod = 7;
                break;
            case 25:
                newPlayer.strMod = 7;
                break;
            case 26:
                newPlayer.strMod = 8;
                break;
            case 27:
                newPlayer.strMod = 8;
                break;
            case 28:
                newPlayer.strMod = 9;
                break;
            case 29:
                newPlayer.strMod = 9;
                break;
            case 30:
                newPlayer.strMod = 10;
                newPlayer.Strength = 30;
                break;
        }
        switch (newPlayer.Dexterity)
        {
            case 0:
                newPlayer.dexMod = -5;
                break;
            case 1:
                newPlayer.dexMod = -5;
                break;
            case 2:
                newPlayer.dexMod = -4;
                break;
            case 3:
                newPlayer.dexMod = -4;
                break;
            case 4:
                newPlayer.dexMod = -3;
                break;
            case 5:
                newPlayer.dexMod = -3;
                break;
            case 6:
                newPlayer.dexMod = -2;
                break;
            case 7:
                newPlayer.dexMod = -2;
                break;
            case 8:
                newPlayer.dexMod = -1;
                break;
            case 9:
                newPlayer.dexMod = -1;
                break;
            case 10:
                newPlayer.dexMod = 0;
                break;
            case 11:
                newPlayer.dexMod = 0;
                break;
            case 12:
                newPlayer.dexMod = 1;
                break;
            case 13:
                newPlayer.dexMod = 1;
                break;
            case 14:
                newPlayer.dexMod = 2;
                break;
            case 15:
                newPlayer.dexMod = 2;
                break;
            case 16:
                newPlayer.dexMod = 3;
                break;
            case 17:
                newPlayer.dexMod = 3;
                break;
            case 18:
                newPlayer.dexMod = 4;
                break;
            case 19:
                newPlayer.dexMod = 4;
                break;
            case 20:
                newPlayer.dexMod = 5;
                break;
            case 21:
                newPlayer.dexMod = 5;
                break;
            case 22:
                newPlayer.dexMod = 6;
                break;
            case 23:
                newPlayer.dexMod = 6;
                break;
            case 24:
                newPlayer.dexMod = 7;
                break;
            case 25:
                newPlayer.dexMod = 7;
                break;
            case 26:
                newPlayer.dexMod = 8;
                break;
            case 27:
                newPlayer.dexMod = 8;
                break;
            case 28:
                newPlayer.dexMod = 9;
                break;
            case 29:
                newPlayer.dexMod = 9;
                break;
            case 30:
                newPlayer.dexMod = 10;
                newPlayer.Dexterity = 30;
                break;
        }
        switch (newPlayer.Constitution)
        {
            case 0:
                newPlayer.conMod = -5;
                break;
            case 1:
                newPlayer.conMod = -5;
                break;
            case 2:
                newPlayer.conMod = -4;
                break;
            case 3:
                newPlayer.conMod = -4;
                break;
            case 4:
                newPlayer.conMod = -3;
                break;
            case 5:
                newPlayer.conMod = -3;
                break;
            case 6:
                newPlayer.conMod = -2;
                break;
            case 7:
                newPlayer.conMod = -2;
                break;
            case 8:
                newPlayer.conMod = -1;
                break;
            case 9:
                newPlayer.conMod = -1;
                break;
            case 10:
                newPlayer.conMod = 0;
                break;
            case 11:
                newPlayer.conMod = 0;
                break;
            case 12:
                newPlayer.conMod = 1;
                break;
            case 13:
                newPlayer.conMod = 1;
                break;
            case 14:
                newPlayer.conMod = 2;
                break;
            case 15:
                newPlayer.conMod = 2;
                break;
            case 16:
                newPlayer.conMod = 3;
                break;
            case 17:
                newPlayer.conMod = 3;
                break;
            case 18:
                newPlayer.conMod = 4;
                break;
            case 19:
                newPlayer.conMod = 4;
                break;
            case 20:
                newPlayer.conMod = 5;
                break;
            case 21:
                newPlayer.conMod = 5;
                break;
            case 22:
                newPlayer.conMod = 6;
                break;
            case 23:
                newPlayer.conMod = 6;
                break;
            case 24:
                newPlayer.conMod = 7;
                break;
            case 25:
                newPlayer.conMod = 7;
                break;
            case 26:
                newPlayer.conMod = 8;
                break;
            case 27:
                newPlayer.conMod = 8;
                break;
            case 28:
                newPlayer.conMod = 9;
                break;
            case 29:
                newPlayer.conMod = 9;
                break;
            case 30:
                newPlayer.conMod = 10;
                newPlayer.Constitution = 30;
                break;
        }
        switch (newPlayer.Intelligence)
        {
            case 0:
                newPlayer.intMod = -5;
                break;
            case 1:
                newPlayer.intMod = -5;
                break;
            case 2:
                newPlayer.intMod = -4;
                break;
            case 3:
                newPlayer.intMod = -4;
                break;
            case 4:
                newPlayer.intMod = -3;
                break;
            case 5:
                newPlayer.intMod = -3;
                break;
            case 6:
                newPlayer.intMod = -2;
                break;
            case 7:
                newPlayer.intMod = -2;
                break;
            case 8:
                newPlayer.intMod = -1;
                break;
            case 9:
                newPlayer.intMod = -1;
                break;
            case 10:
                newPlayer.intMod = 0;
                break;
            case 11:
                newPlayer.intMod = 0;
                break;
            case 12:
                newPlayer.intMod = 1;
                break;
            case 13:
                newPlayer.intMod = 1;
                break;
            case 14:
                newPlayer.intMod = 2;
                break;
            case 15:
                newPlayer.intMod = 2;
                break;
            case 16:
                newPlayer.intMod = 3;
                break;
            case 17:
                newPlayer.intMod = 3;
                break;
            case 18:
                newPlayer.intMod = 4;
                break;
            case 19:
                newPlayer.intMod = 4;
                break;
            case 20:
                newPlayer.intMod = 5;
                break;
            case 21:
                newPlayer.intMod = 5;
                break;
            case 22:
                newPlayer.intMod = 6;
                break;
            case 23:
                newPlayer.intMod = 6;
                break;
            case 24:
                newPlayer.intMod = 7;
                break;
            case 25:
                newPlayer.intMod = 7;
                break;
            case 26:
                newPlayer.intMod = 8;
                break;
            case 27:
                newPlayer.intMod = 8;
                break;
            case 28:
                newPlayer.intMod = 9;
                break;
            case 29:
                newPlayer.intMod = 9;
                break;
            case 30:
                newPlayer.intMod = 10;
                newPlayer.Intelligence = 30;
                break;
        }
        switch (newPlayer.Wisdom)
        {
            case 0:
                newPlayer.wisMod = -5;
                break;
            case 1:
                newPlayer.wisMod = -5;
                break;
            case 2:
                newPlayer.wisMod = -4;
                break;
            case 3:
                newPlayer.wisMod = -4;
                break;
            case 4:
                newPlayer.wisMod = -3;
                break;
            case 5:
                newPlayer.wisMod = -3;
                break;
            case 6:
                newPlayer.wisMod = -2;
                break;
            case 7:
                newPlayer.wisMod = -2;
                break;
            case 8:
                newPlayer.wisMod = -1;
                break;
            case 9:
                newPlayer.wisMod = -1;
                break;
            case 10:
                newPlayer.wisMod = 0;
                break;
            case 11:
                newPlayer.wisMod = 0;
                break;
            case 12:
                newPlayer.wisMod = 1;
                break;
            case 13:
                newPlayer.wisMod = 1;
                break;
            case 14:
                newPlayer.wisMod = 2;
                break;
            case 15:
                newPlayer.wisMod = 2;
                break;
            case 16:
                newPlayer.wisMod = 3;
                break;
            case 17:
                newPlayer.wisMod = 3;
                break;
            case 18:
                newPlayer.wisMod = 4;
                break;
            case 19:
                newPlayer.wisMod = 4;
                break;
            case 20:
                newPlayer.wisMod = 5;
                break;
            case 21:
                newPlayer.wisMod = 5;
                break;
            case 22:
                newPlayer.wisMod = 6;
                break;
            case 23:
                newPlayer.wisMod = 6;
                break;
            case 24:
                newPlayer.wisMod = 7;
                break;
            case 25:
                newPlayer.wisMod = 7;
                break;
            case 26:
                newPlayer.wisMod = 8;
                break;
            case 27:
                newPlayer.wisMod = 8;
                break;
            case 28:
                newPlayer.wisMod = 9;
                break;
            case 29:
                newPlayer.wisMod = 9;
                break;
            case 30:
                newPlayer.wisMod = 10;
                newPlayer.Wisdom = 30;
                break;
        }
        switch (newPlayer.Charisma)
        {
            case 0:
                newPlayer.chrMod = -5;
                break;
            case 1:
                newPlayer.chrMod = -5;
                break;
            case 2:
                newPlayer.chrMod = -4;
                break;
            case 3:
                newPlayer.chrMod = -4;
                break;
            case 4:
                newPlayer.chrMod = -3;
                break;
            case 5:
                newPlayer.chrMod = -3;
                break;
            case 6:
                newPlayer.chrMod = -2;
                break;
            case 7:
                newPlayer.chrMod = -2;
                break;
            case 8:
                newPlayer.chrMod = -1;
                break;
            case 9:
                newPlayer.chrMod = -1;
                break;
            case 10:
                newPlayer.chrMod = 0;
                break;
            case 11:
                newPlayer.chrMod = 0;
                break;
            case 12:
                newPlayer.chrMod = 1;
                break;
            case 13:
                newPlayer.chrMod = 1;
                break;
            case 14:
                newPlayer.chrMod = 2;
                break;
            case 15:
                newPlayer.chrMod = 2;
                break;
            case 16:
                newPlayer.chrMod = 3;
                break;
            case 17:
                newPlayer.chrMod = 3;
                break;
            case 18:
                newPlayer.chrMod = 4;
                break;
            case 19:
                newPlayer.chrMod = 4;
                break;
            case 20:
                newPlayer.chrMod = 5;
                break;
            case 21:
                newPlayer.chrMod = 5;
                break;
            case 22:
                newPlayer.chrMod = 6;
                break;
            case 23:
                newPlayer.chrMod = 6;
                break;
            case 24:
                newPlayer.chrMod = 7;
                break;
            case 25:
                newPlayer.chrMod = 7;
                break;
            case 26:
                newPlayer.chrMod = 8;
                break;
            case 27:
                newPlayer.chrMod = 8;
                break;
            case 28:
                newPlayer.chrMod = 9;
                break;
            case 29:
                newPlayer.chrMod = 9;
                break;
            case 30:
                newPlayer.chrMod = 10;
                newPlayer.Charisma = 30;
                break;
        }
        #endregion
        ClassTextDisplay.text = GameInfo.setClass.ToString();
        UpdateUI();
    }

    public void SetRangerClass()
    {
        pointsToSpend = 2;
        newPlayer.PlayerClass = new BaseRangerClass();
        GameInfo.setClass = PlayerClass.Ranger;
        #region StatModCalculation
        switch (newPlayer.Strength)
        {
            case 0:
                newPlayer.strMod = -5;
                break;
            case 1:
                newPlayer.strMod = -5;
                break;
            case 2:
                newPlayer.strMod = -4;
                break;
            case 3:
                newPlayer.strMod = -4;
                break;
            case 4:
                newPlayer.strMod = -3;
                break;
            case 5:
                newPlayer.strMod = -3;
                break;
            case 6:
                newPlayer.strMod = -2;
                break;
            case 7:
                newPlayer.strMod = -2;
                break;
            case 8:
                newPlayer.strMod = -1;
                break;
            case 9:
                newPlayer.strMod = -1;
                break;
            case 10:
                newPlayer.strMod = 0;
                break;
            case 11:
                newPlayer.strMod = 0;
                break;
            case 12:
                newPlayer.strMod = 1;
                break;
            case 13:
                newPlayer.strMod = 1;
                break;
            case 14:
                newPlayer.strMod = 2;
                break;
            case 15:
                newPlayer.strMod = 2;
                break;
            case 16:
                newPlayer.strMod = 3;
                break;
            case 17:
                newPlayer.strMod = 3;
                break;
            case 18:
                newPlayer.strMod = 4;
                break;
            case 19:
                newPlayer.strMod = 4;
                break;
            case 20:
                newPlayer.strMod = 5;
                break;
            case 21:
                newPlayer.strMod = 5;
                break;
            case 22:
                newPlayer.strMod = 6;
                break;
            case 23:
                newPlayer.strMod = 6;
                break;
            case 24:
                newPlayer.strMod = 7;
                break;
            case 25:
                newPlayer.strMod = 7;
                break;
            case 26:
                newPlayer.strMod = 8;
                break;
            case 27:
                newPlayer.strMod = 8;
                break;
            case 28:
                newPlayer.strMod = 9;
                break;
            case 29:
                newPlayer.strMod = 9;
                break;
            case 30:
                newPlayer.strMod = 10;
                newPlayer.Strength = 30;
                break;
        }
        switch (newPlayer.Dexterity)
        {
            case 0:
                newPlayer.dexMod = -5;
                break;
            case 1:
                newPlayer.dexMod = -5;
                break;
            case 2:
                newPlayer.dexMod = -4;
                break;
            case 3:
                newPlayer.dexMod = -4;
                break;
            case 4:
                newPlayer.dexMod = -3;
                break;
            case 5:
                newPlayer.dexMod = -3;
                break;
            case 6:
                newPlayer.dexMod = -2;
                break;
            case 7:
                newPlayer.dexMod = -2;
                break;
            case 8:
                newPlayer.dexMod = -1;
                break;
            case 9:
                newPlayer.dexMod = -1;
                break;
            case 10:
                newPlayer.dexMod = 0;
                break;
            case 11:
                newPlayer.dexMod = 0;
                break;
            case 12:
                newPlayer.dexMod = 1;
                break;
            case 13:
                newPlayer.dexMod = 1;
                break;
            case 14:
                newPlayer.dexMod = 2;
                break;
            case 15:
                newPlayer.dexMod = 2;
                break;
            case 16:
                newPlayer.dexMod = 3;
                break;
            case 17:
                newPlayer.dexMod = 3;
                break;
            case 18:
                newPlayer.dexMod = 4;
                break;
            case 19:
                newPlayer.dexMod = 4;
                break;
            case 20:
                newPlayer.dexMod = 5;
                break;
            case 21:
                newPlayer.dexMod = 5;
                break;
            case 22:
                newPlayer.dexMod = 6;
                break;
            case 23:
                newPlayer.dexMod = 6;
                break;
            case 24:
                newPlayer.dexMod = 7;
                break;
            case 25:
                newPlayer.dexMod = 7;
                break;
            case 26:
                newPlayer.dexMod = 8;
                break;
            case 27:
                newPlayer.dexMod = 8;
                break;
            case 28:
                newPlayer.dexMod = 9;
                break;
            case 29:
                newPlayer.dexMod = 9;
                break;
            case 30:
                newPlayer.dexMod = 10;
                newPlayer.Dexterity = 30;
                break;
        }
        switch (newPlayer.Constitution)
        {
            case 0:
                newPlayer.conMod = -5;
                break;
            case 1:
                newPlayer.conMod = -5;
                break;
            case 2:
                newPlayer.conMod = -4;
                break;
            case 3:
                newPlayer.conMod = -4;
                break;
            case 4:
                newPlayer.conMod = -3;
                break;
            case 5:
                newPlayer.conMod = -3;
                break;
            case 6:
                newPlayer.conMod = -2;
                break;
            case 7:
                newPlayer.conMod = -2;
                break;
            case 8:
                newPlayer.conMod = -1;
                break;
            case 9:
                newPlayer.conMod = -1;
                break;
            case 10:
                newPlayer.conMod = 0;
                break;
            case 11:
                newPlayer.conMod = 0;
                break;
            case 12:
                newPlayer.conMod = 1;
                break;
            case 13:
                newPlayer.conMod = 1;
                break;
            case 14:
                newPlayer.conMod = 2;
                break;
            case 15:
                newPlayer.conMod = 2;
                break;
            case 16:
                newPlayer.conMod = 3;
                break;
            case 17:
                newPlayer.conMod = 3;
                break;
            case 18:
                newPlayer.conMod = 4;
                break;
            case 19:
                newPlayer.conMod = 4;
                break;
            case 20:
                newPlayer.conMod = 5;
                break;
            case 21:
                newPlayer.conMod = 5;
                break;
            case 22:
                newPlayer.conMod = 6;
                break;
            case 23:
                newPlayer.conMod = 6;
                break;
            case 24:
                newPlayer.conMod = 7;
                break;
            case 25:
                newPlayer.conMod = 7;
                break;
            case 26:
                newPlayer.conMod = 8;
                break;
            case 27:
                newPlayer.conMod = 8;
                break;
            case 28:
                newPlayer.conMod = 9;
                break;
            case 29:
                newPlayer.conMod = 9;
                break;
            case 30:
                newPlayer.conMod = 10;
                newPlayer.Constitution = 30;
                break;
        }
        switch (newPlayer.Intelligence)
        {
            case 0:
                newPlayer.intMod = -5;
                break;
            case 1:
                newPlayer.intMod = -5;
                break;
            case 2:
                newPlayer.intMod = -4;
                break;
            case 3:
                newPlayer.intMod = -4;
                break;
            case 4:
                newPlayer.intMod = -3;
                break;
            case 5:
                newPlayer.intMod = -3;
                break;
            case 6:
                newPlayer.intMod = -2;
                break;
            case 7:
                newPlayer.intMod = -2;
                break;
            case 8:
                newPlayer.intMod = -1;
                break;
            case 9:
                newPlayer.intMod = -1;
                break;
            case 10:
                newPlayer.intMod = 0;
                break;
            case 11:
                newPlayer.intMod = 0;
                break;
            case 12:
                newPlayer.intMod = 1;
                break;
            case 13:
                newPlayer.intMod = 1;
                break;
            case 14:
                newPlayer.intMod = 2;
                break;
            case 15:
                newPlayer.intMod = 2;
                break;
            case 16:
                newPlayer.intMod = 3;
                break;
            case 17:
                newPlayer.intMod = 3;
                break;
            case 18:
                newPlayer.intMod = 4;
                break;
            case 19:
                newPlayer.intMod = 4;
                break;
            case 20:
                newPlayer.intMod = 5;
                break;
            case 21:
                newPlayer.intMod = 5;
                break;
            case 22:
                newPlayer.intMod = 6;
                break;
            case 23:
                newPlayer.intMod = 6;
                break;
            case 24:
                newPlayer.intMod = 7;
                break;
            case 25:
                newPlayer.intMod = 7;
                break;
            case 26:
                newPlayer.intMod = 8;
                break;
            case 27:
                newPlayer.intMod = 8;
                break;
            case 28:
                newPlayer.intMod = 9;
                break;
            case 29:
                newPlayer.intMod = 9;
                break;
            case 30:
                newPlayer.intMod = 10;
                newPlayer.Intelligence = 30;
                break;
        }
        switch (newPlayer.Wisdom)
        {
            case 0:
                newPlayer.wisMod = -5;
                break;
            case 1:
                newPlayer.wisMod = -5;
                break;
            case 2:
                newPlayer.wisMod = -4;
                break;
            case 3:
                newPlayer.wisMod = -4;
                break;
            case 4:
                newPlayer.wisMod = -3;
                break;
            case 5:
                newPlayer.wisMod = -3;
                break;
            case 6:
                newPlayer.wisMod = -2;
                break;
            case 7:
                newPlayer.wisMod = -2;
                break;
            case 8:
                newPlayer.wisMod = -1;
                break;
            case 9:
                newPlayer.wisMod = -1;
                break;
            case 10:
                newPlayer.wisMod = 0;
                break;
            case 11:
                newPlayer.wisMod = 0;
                break;
            case 12:
                newPlayer.wisMod = 1;
                break;
            case 13:
                newPlayer.wisMod = 1;
                break;
            case 14:
                newPlayer.wisMod = 2;
                break;
            case 15:
                newPlayer.wisMod = 2;
                break;
            case 16:
                newPlayer.wisMod = 3;
                break;
            case 17:
                newPlayer.wisMod = 3;
                break;
            case 18:
                newPlayer.wisMod = 4;
                break;
            case 19:
                newPlayer.wisMod = 4;
                break;
            case 20:
                newPlayer.wisMod = 5;
                break;
            case 21:
                newPlayer.wisMod = 5;
                break;
            case 22:
                newPlayer.wisMod = 6;
                break;
            case 23:
                newPlayer.wisMod = 6;
                break;
            case 24:
                newPlayer.wisMod = 7;
                break;
            case 25:
                newPlayer.wisMod = 7;
                break;
            case 26:
                newPlayer.wisMod = 8;
                break;
            case 27:
                newPlayer.wisMod = 8;
                break;
            case 28:
                newPlayer.wisMod = 9;
                break;
            case 29:
                newPlayer.wisMod = 9;
                break;
            case 30:
                newPlayer.wisMod = 10;
                newPlayer.Wisdom = 30;
                break;
        }
        switch (newPlayer.Charisma)
        {
            case 0:
                newPlayer.chrMod = -5;
                break;
            case 1:
                newPlayer.chrMod = -5;
                break;
            case 2:
                newPlayer.chrMod = -4;
                break;
            case 3:
                newPlayer.chrMod = -4;
                break;
            case 4:
                newPlayer.chrMod = -3;
                break;
            case 5:
                newPlayer.chrMod = -3;
                break;
            case 6:
                newPlayer.chrMod = -2;
                break;
            case 7:
                newPlayer.chrMod = -2;
                break;
            case 8:
                newPlayer.chrMod = -1;
                break;
            case 9:
                newPlayer.chrMod = -1;
                break;
            case 10:
                newPlayer.chrMod = 0;
                break;
            case 11:
                newPlayer.chrMod = 0;
                break;
            case 12:
                newPlayer.chrMod = 1;
                break;
            case 13:
                newPlayer.chrMod = 1;
                break;
            case 14:
                newPlayer.chrMod = 2;
                break;
            case 15:
                newPlayer.chrMod = 2;
                break;
            case 16:
                newPlayer.chrMod = 3;
                break;
            case 17:
                newPlayer.chrMod = 3;
                break;
            case 18:
                newPlayer.chrMod = 4;
                break;
            case 19:
                newPlayer.chrMod = 4;
                break;
            case 20:
                newPlayer.chrMod = 5;
                break;
            case 21:
                newPlayer.chrMod = 5;
                break;
            case 22:
                newPlayer.chrMod = 6;
                break;
            case 23:
                newPlayer.chrMod = 6;
                break;
            case 24:
                newPlayer.chrMod = 7;
                break;
            case 25:
                newPlayer.chrMod = 7;
                break;
            case 26:
                newPlayer.chrMod = 8;
                break;
            case 27:
                newPlayer.chrMod = 8;
                break;
            case 28:
                newPlayer.chrMod = 9;
                break;
            case 29:
                newPlayer.chrMod = 9;
                break;
            case 30:
                newPlayer.chrMod = 10;
                newPlayer.Charisma = 30;
                break;
        }
        #endregion
        ClassTextDisplay.text = GameInfo.setClass.ToString();
        UpdateUI();
    }

    public void SetRougeClass()
    {
        newPlayer.PlayerClass = new RougeClass();
        GameInfo.setClass = PlayerClass.Rouge;
        #region StatModCalculation
        switch (newPlayer.Strength)
        {
            case 0:
                newPlayer.strMod = -5;
                break;
            case 1:
                newPlayer.strMod = -5;
                break;
            case 2:
                newPlayer.strMod = -4;
                break;
            case 3:
                newPlayer.strMod = -4;
                break;
            case 4:
                newPlayer.strMod = -3;
                break;
            case 5:
                newPlayer.strMod = -3;
                break;
            case 6:
                newPlayer.strMod = -2;
                break;
            case 7:
                newPlayer.strMod = -2;
                break;
            case 8:
                newPlayer.strMod = -1;
                break;
            case 9:
                newPlayer.strMod = -1;
                break;
            case 10:
                newPlayer.strMod = 0;
                break;
            case 11:
                newPlayer.strMod = 0;
                break;
            case 12:
                newPlayer.strMod = 1;
                break;
            case 13:
                newPlayer.strMod = 1;
                break;
            case 14:
                newPlayer.strMod = 2;
                break;
            case 15:
                newPlayer.strMod = 2;
                break;
            case 16:
                newPlayer.strMod = 3;
                break;
            case 17:
                newPlayer.strMod = 3;
                break;
            case 18:
                newPlayer.strMod = 4;
                break;
            case 19:
                newPlayer.strMod = 4;
                break;
            case 20:
                newPlayer.strMod = 5;
                break;
            case 21:
                newPlayer.strMod = 5;
                break;
            case 22:
                newPlayer.strMod = 6;
                break;
            case 23:
                newPlayer.strMod = 6;
                break;
            case 24:
                newPlayer.strMod = 7;
                break;
            case 25:
                newPlayer.strMod = 7;
                break;
            case 26:
                newPlayer.strMod = 8;
                break;
            case 27:
                newPlayer.strMod = 8;
                break;
            case 28:
                newPlayer.strMod = 9;
                break;
            case 29:
                newPlayer.strMod = 9;
                break;
            case 30:
                newPlayer.strMod = 10;
                newPlayer.Strength = 30;
                break;
        }
        switch (newPlayer.Dexterity)
        {
            case 0:
                newPlayer.dexMod = -5;
                break;
            case 1:
                newPlayer.dexMod = -5;
                break;
            case 2:
                newPlayer.dexMod = -4;
                break;
            case 3:
                newPlayer.dexMod = -4;
                break;
            case 4:
                newPlayer.dexMod = -3;
                break;
            case 5:
                newPlayer.dexMod = -3;
                break;
            case 6:
                newPlayer.dexMod = -2;
                break;
            case 7:
                newPlayer.dexMod = -2;
                break;
            case 8:
                newPlayer.dexMod = -1;
                break;
            case 9:
                newPlayer.dexMod = -1;
                break;
            case 10:
                newPlayer.dexMod = 0;
                break;
            case 11:
                newPlayer.dexMod = 0;
                break;
            case 12:
                newPlayer.dexMod = 1;
                break;
            case 13:
                newPlayer.dexMod = 1;
                break;
            case 14:
                newPlayer.dexMod = 2;
                break;
            case 15:
                newPlayer.dexMod = 2;
                break;
            case 16:
                newPlayer.dexMod = 3;
                break;
            case 17:
                newPlayer.dexMod = 3;
                break;
            case 18:
                newPlayer.dexMod = 4;
                break;
            case 19:
                newPlayer.dexMod = 4;
                break;
            case 20:
                newPlayer.dexMod = 5;
                break;
            case 21:
                newPlayer.dexMod = 5;
                break;
            case 22:
                newPlayer.dexMod = 6;
                break;
            case 23:
                newPlayer.dexMod = 6;
                break;
            case 24:
                newPlayer.dexMod = 7;
                break;
            case 25:
                newPlayer.dexMod = 7;
                break;
            case 26:
                newPlayer.dexMod = 8;
                break;
            case 27:
                newPlayer.dexMod = 8;
                break;
            case 28:
                newPlayer.dexMod = 9;
                break;
            case 29:
                newPlayer.dexMod = 9;
                break;
            case 30:
                newPlayer.dexMod = 10;
                newPlayer.Dexterity = 30;
                break;
        }
        switch (newPlayer.Constitution)
        {
            case 0:
                newPlayer.conMod = -5;
                break;
            case 1:
                newPlayer.conMod = -5;
                break;
            case 2:
                newPlayer.conMod = -4;
                break;
            case 3:
                newPlayer.conMod = -4;
                break;
            case 4:
                newPlayer.conMod = -3;
                break;
            case 5:
                newPlayer.conMod = -3;
                break;
            case 6:
                newPlayer.conMod = -2;
                break;
            case 7:
                newPlayer.conMod = -2;
                break;
            case 8:
                newPlayer.conMod = -1;
                break;
            case 9:
                newPlayer.conMod = -1;
                break;
            case 10:
                newPlayer.conMod = 0;
                break;
            case 11:
                newPlayer.conMod = 0;
                break;
            case 12:
                newPlayer.conMod = 1;
                break;
            case 13:
                newPlayer.conMod = 1;
                break;
            case 14:
                newPlayer.conMod = 2;
                break;
            case 15:
                newPlayer.conMod = 2;
                break;
            case 16:
                newPlayer.conMod = 3;
                break;
            case 17:
                newPlayer.conMod = 3;
                break;
            case 18:
                newPlayer.conMod = 4;
                break;
            case 19:
                newPlayer.conMod = 4;
                break;
            case 20:
                newPlayer.conMod = 5;
                break;
            case 21:
                newPlayer.conMod = 5;
                break;
            case 22:
                newPlayer.conMod = 6;
                break;
            case 23:
                newPlayer.conMod = 6;
                break;
            case 24:
                newPlayer.conMod = 7;
                break;
            case 25:
                newPlayer.conMod = 7;
                break;
            case 26:
                newPlayer.conMod = 8;
                break;
            case 27:
                newPlayer.conMod = 8;
                break;
            case 28:
                newPlayer.conMod = 9;
                break;
            case 29:
                newPlayer.conMod = 9;
                break;
            case 30:
                newPlayer.conMod = 10;
                newPlayer.Constitution = 30;
                break;
        }
        switch (newPlayer.Intelligence)
        {
            case 0:
                newPlayer.intMod = -5;
                break;
            case 1:
                newPlayer.intMod = -5;
                break;
            case 2:
                newPlayer.intMod = -4;
                break;
            case 3:
                newPlayer.intMod = -4;
                break;
            case 4:
                newPlayer.intMod = -3;
                break;
            case 5:
                newPlayer.intMod = -3;
                break;
            case 6:
                newPlayer.intMod = -2;
                break;
            case 7:
                newPlayer.intMod = -2;
                break;
            case 8:
                newPlayer.intMod = -1;
                break;
            case 9:
                newPlayer.intMod = -1;
                break;
            case 10:
                newPlayer.intMod = 0;
                break;
            case 11:
                newPlayer.intMod = 0;
                break;
            case 12:
                newPlayer.intMod = 1;
                break;
            case 13:
                newPlayer.intMod = 1;
                break;
            case 14:
                newPlayer.intMod = 2;
                break;
            case 15:
                newPlayer.intMod = 2;
                break;
            case 16:
                newPlayer.intMod = 3;
                break;
            case 17:
                newPlayer.intMod = 3;
                break;
            case 18:
                newPlayer.intMod = 4;
                break;
            case 19:
                newPlayer.intMod = 4;
                break;
            case 20:
                newPlayer.intMod = 5;
                break;
            case 21:
                newPlayer.intMod = 5;
                break;
            case 22:
                newPlayer.intMod = 6;
                break;
            case 23:
                newPlayer.intMod = 6;
                break;
            case 24:
                newPlayer.intMod = 7;
                break;
            case 25:
                newPlayer.intMod = 7;
                break;
            case 26:
                newPlayer.intMod = 8;
                break;
            case 27:
                newPlayer.intMod = 8;
                break;
            case 28:
                newPlayer.intMod = 9;
                break;
            case 29:
                newPlayer.intMod = 9;
                break;
            case 30:
                newPlayer.intMod = 10;
                newPlayer.Intelligence = 30;
                break;
        }
        switch (newPlayer.Wisdom)
        {
            case 0:
                newPlayer.wisMod = -5;
                break;
            case 1:
                newPlayer.wisMod = -5;
                break;
            case 2:
                newPlayer.wisMod = -4;
                break;
            case 3:
                newPlayer.wisMod = -4;
                break;
            case 4:
                newPlayer.wisMod = -3;
                break;
            case 5:
                newPlayer.wisMod = -3;
                break;
            case 6:
                newPlayer.wisMod = -2;
                break;
            case 7:
                newPlayer.wisMod = -2;
                break;
            case 8:
                newPlayer.wisMod = -1;
                break;
            case 9:
                newPlayer.wisMod = -1;
                break;
            case 10:
                newPlayer.wisMod = 0;
                break;
            case 11:
                newPlayer.wisMod = 0;
                break;
            case 12:
                newPlayer.wisMod = 1;
                break;
            case 13:
                newPlayer.wisMod = 1;
                break;
            case 14:
                newPlayer.wisMod = 2;
                break;
            case 15:
                newPlayer.wisMod = 2;
                break;
            case 16:
                newPlayer.wisMod = 3;
                break;
            case 17:
                newPlayer.wisMod = 3;
                break;
            case 18:
                newPlayer.wisMod = 4;
                break;
            case 19:
                newPlayer.wisMod = 4;
                break;
            case 20:
                newPlayer.wisMod = 5;
                break;
            case 21:
                newPlayer.wisMod = 5;
                break;
            case 22:
                newPlayer.wisMod = 6;
                break;
            case 23:
                newPlayer.wisMod = 6;
                break;
            case 24:
                newPlayer.wisMod = 7;
                break;
            case 25:
                newPlayer.wisMod = 7;
                break;
            case 26:
                newPlayer.wisMod = 8;
                break;
            case 27:
                newPlayer.wisMod = 8;
                break;
            case 28:
                newPlayer.wisMod = 9;
                break;
            case 29:
                newPlayer.wisMod = 9;
                break;
            case 30:
                newPlayer.wisMod = 10;
                newPlayer.Wisdom = 30;
                break;
        }
        switch (newPlayer.Charisma)
        {
            case 0:
                newPlayer.chrMod = -5;
                break;
            case 1:
                newPlayer.chrMod = -5;
                break;
            case 2:
                newPlayer.chrMod = -4;
                break;
            case 3:
                newPlayer.chrMod = -4;
                break;
            case 4:
                newPlayer.chrMod = -3;
                break;
            case 5:
                newPlayer.chrMod = -3;
                break;
            case 6:
                newPlayer.chrMod = -2;
                break;
            case 7:
                newPlayer.chrMod = -2;
                break;
            case 8:
                newPlayer.chrMod = -1;
                break;
            case 9:
                newPlayer.chrMod = -1;
                break;
            case 10:
                newPlayer.chrMod = 0;
                break;
            case 11:
                newPlayer.chrMod = 0;
                break;
            case 12:
                newPlayer.chrMod = 1;
                break;
            case 13:
                newPlayer.chrMod = 1;
                break;
            case 14:
                newPlayer.chrMod = 2;
                break;
            case 15:
                newPlayer.chrMod = 2;
                break;
            case 16:
                newPlayer.chrMod = 3;
                break;
            case 17:
                newPlayer.chrMod = 3;
                break;
            case 18:
                newPlayer.chrMod = 4;
                break;
            case 19:
                newPlayer.chrMod = 4;
                break;
            case 20:
                newPlayer.chrMod = 5;
                break;
            case 21:
                newPlayer.chrMod = 5;
                break;
            case 22:
                newPlayer.chrMod = 6;
                break;
            case 23:
                newPlayer.chrMod = 6;
                break;
            case 24:
                newPlayer.chrMod = 7;
                break;
            case 25:
                newPlayer.chrMod = 7;
                break;
            case 26:
                newPlayer.chrMod = 8;
                break;
            case 27:
                newPlayer.chrMod = 8;
                break;
            case 28:
                newPlayer.chrMod = 9;
                break;
            case 29:
                newPlayer.chrMod = 9;
                break;
            case 30:
                newPlayer.chrMod = 10;
                newPlayer.Charisma = 30;
                break;
        }
        #endregion
        ClassTextDisplay.text = GameInfo.setClass.ToString();
        UpdateUI();
    }

    public void SetSorcererClass()
    {
        newPlayer.PlayerClass = new ScorcererClass();
        GameInfo.setClass = PlayerClass.Scorcerer;
        #region StatModCalculation
        switch (newPlayer.Strength)
        {
            case 0:
                newPlayer.strMod = -5;
                break;
            case 1:
                newPlayer.strMod = -5;
                break;
            case 2:
                newPlayer.strMod = -4;
                break;
            case 3:
                newPlayer.strMod = -4;
                break;
            case 4:
                newPlayer.strMod = -3;
                break;
            case 5:
                newPlayer.strMod = -3;
                break;
            case 6:
                newPlayer.strMod = -2;
                break;
            case 7:
                newPlayer.strMod = -2;
                break;
            case 8:
                newPlayer.strMod = -1;
                break;
            case 9:
                newPlayer.strMod = -1;
                break;
            case 10:
                newPlayer.strMod = 0;
                break;
            case 11:
                newPlayer.strMod = 0;
                break;
            case 12:
                newPlayer.strMod = 1;
                break;
            case 13:
                newPlayer.strMod = 1;
                break;
            case 14:
                newPlayer.strMod = 2;
                break;
            case 15:
                newPlayer.strMod = 2;
                break;
            case 16:
                newPlayer.strMod = 3;
                break;
            case 17:
                newPlayer.strMod = 3;
                break;
            case 18:
                newPlayer.strMod = 4;
                break;
            case 19:
                newPlayer.strMod = 4;
                break;
            case 20:
                newPlayer.strMod = 5;
                break;
            case 21:
                newPlayer.strMod = 5;
                break;
            case 22:
                newPlayer.strMod = 6;
                break;
            case 23:
                newPlayer.strMod = 6;
                break;
            case 24:
                newPlayer.strMod = 7;
                break;
            case 25:
                newPlayer.strMod = 7;
                break;
            case 26:
                newPlayer.strMod = 8;
                break;
            case 27:
                newPlayer.strMod = 8;
                break;
            case 28:
                newPlayer.strMod = 9;
                break;
            case 29:
                newPlayer.strMod = 9;
                break;
            case 30:
                newPlayer.strMod = 10;
                newPlayer.Strength = 30;
                break;
        }
        switch (newPlayer.Dexterity)
        {
            case 0:
                newPlayer.dexMod = -5;
                break;
            case 1:
                newPlayer.dexMod = -5;
                break;
            case 2:
                newPlayer.dexMod = -4;
                break;
            case 3:
                newPlayer.dexMod = -4;
                break;
            case 4:
                newPlayer.dexMod = -3;
                break;
            case 5:
                newPlayer.dexMod = -3;
                break;
            case 6:
                newPlayer.dexMod = -2;
                break;
            case 7:
                newPlayer.dexMod = -2;
                break;
            case 8:
                newPlayer.dexMod = -1;
                break;
            case 9:
                newPlayer.dexMod = -1;
                break;
            case 10:
                newPlayer.dexMod = 0;
                break;
            case 11:
                newPlayer.dexMod = 0;
                break;
            case 12:
                newPlayer.dexMod = 1;
                break;
            case 13:
                newPlayer.dexMod = 1;
                break;
            case 14:
                newPlayer.dexMod = 2;
                break;
            case 15:
                newPlayer.dexMod = 2;
                break;
            case 16:
                newPlayer.dexMod = 3;
                break;
            case 17:
                newPlayer.dexMod = 3;
                break;
            case 18:
                newPlayer.dexMod = 4;
                break;
            case 19:
                newPlayer.dexMod = 4;
                break;
            case 20:
                newPlayer.dexMod = 5;
                break;
            case 21:
                newPlayer.dexMod = 5;
                break;
            case 22:
                newPlayer.dexMod = 6;
                break;
            case 23:
                newPlayer.dexMod = 6;
                break;
            case 24:
                newPlayer.dexMod = 7;
                break;
            case 25:
                newPlayer.dexMod = 7;
                break;
            case 26:
                newPlayer.dexMod = 8;
                break;
            case 27:
                newPlayer.dexMod = 8;
                break;
            case 28:
                newPlayer.dexMod = 9;
                break;
            case 29:
                newPlayer.dexMod = 9;
                break;
            case 30:
                newPlayer.dexMod = 10;
                newPlayer.Dexterity = 30;
                break;
        }
        switch (newPlayer.Constitution)
        {
            case 0:
                newPlayer.conMod = -5;
                break;
            case 1:
                newPlayer.conMod = -5;
                break;
            case 2:
                newPlayer.conMod = -4;
                break;
            case 3:
                newPlayer.conMod = -4;
                break;
            case 4:
                newPlayer.conMod = -3;
                break;
            case 5:
                newPlayer.conMod = -3;
                break;
            case 6:
                newPlayer.conMod = -2;
                break;
            case 7:
                newPlayer.conMod = -2;
                break;
            case 8:
                newPlayer.conMod = -1;
                break;
            case 9:
                newPlayer.conMod = -1;
                break;
            case 10:
                newPlayer.conMod = 0;
                break;
            case 11:
                newPlayer.conMod = 0;
                break;
            case 12:
                newPlayer.conMod = 1;
                break;
            case 13:
                newPlayer.conMod = 1;
                break;
            case 14:
                newPlayer.conMod = 2;
                break;
            case 15:
                newPlayer.conMod = 2;
                break;
            case 16:
                newPlayer.conMod = 3;
                break;
            case 17:
                newPlayer.conMod = 3;
                break;
            case 18:
                newPlayer.conMod = 4;
                break;
            case 19:
                newPlayer.conMod = 4;
                break;
            case 20:
                newPlayer.conMod = 5;
                break;
            case 21:
                newPlayer.conMod = 5;
                break;
            case 22:
                newPlayer.conMod = 6;
                break;
            case 23:
                newPlayer.conMod = 6;
                break;
            case 24:
                newPlayer.conMod = 7;
                break;
            case 25:
                newPlayer.conMod = 7;
                break;
            case 26:
                newPlayer.conMod = 8;
                break;
            case 27:
                newPlayer.conMod = 8;
                break;
            case 28:
                newPlayer.conMod = 9;
                break;
            case 29:
                newPlayer.conMod = 9;
                break;
            case 30:
                newPlayer.conMod = 10;
                newPlayer.Constitution = 30;
                break;
        }
        switch (newPlayer.Intelligence)
        {
            case 0:
                newPlayer.intMod = -5;
                break;
            case 1:
                newPlayer.intMod = -5;
                break;
            case 2:
                newPlayer.intMod = -4;
                break;
            case 3:
                newPlayer.intMod = -4;
                break;
            case 4:
                newPlayer.intMod = -3;
                break;
            case 5:
                newPlayer.intMod = -3;
                break;
            case 6:
                newPlayer.intMod = -2;
                break;
            case 7:
                newPlayer.intMod = -2;
                break;
            case 8:
                newPlayer.intMod = -1;
                break;
            case 9:
                newPlayer.intMod = -1;
                break;
            case 10:
                newPlayer.intMod = 0;
                break;
            case 11:
                newPlayer.intMod = 0;
                break;
            case 12:
                newPlayer.intMod = 1;
                break;
            case 13:
                newPlayer.intMod = 1;
                break;
            case 14:
                newPlayer.intMod = 2;
                break;
            case 15:
                newPlayer.intMod = 2;
                break;
            case 16:
                newPlayer.intMod = 3;
                break;
            case 17:
                newPlayer.intMod = 3;
                break;
            case 18:
                newPlayer.intMod = 4;
                break;
            case 19:
                newPlayer.intMod = 4;
                break;
            case 20:
                newPlayer.intMod = 5;
                break;
            case 21:
                newPlayer.intMod = 5;
                break;
            case 22:
                newPlayer.intMod = 6;
                break;
            case 23:
                newPlayer.intMod = 6;
                break;
            case 24:
                newPlayer.intMod = 7;
                break;
            case 25:
                newPlayer.intMod = 7;
                break;
            case 26:
                newPlayer.intMod = 8;
                break;
            case 27:
                newPlayer.intMod = 8;
                break;
            case 28:
                newPlayer.intMod = 9;
                break;
            case 29:
                newPlayer.intMod = 9;
                break;
            case 30:
                newPlayer.intMod = 10;
                newPlayer.Intelligence = 30;
                break;
        }
        switch (newPlayer.Wisdom)
        {
            case 0:
                newPlayer.wisMod = -5;
                break;
            case 1:
                newPlayer.wisMod = -5;
                break;
            case 2:
                newPlayer.wisMod = -4;
                break;
            case 3:
                newPlayer.wisMod = -4;
                break;
            case 4:
                newPlayer.wisMod = -3;
                break;
            case 5:
                newPlayer.wisMod = -3;
                break;
            case 6:
                newPlayer.wisMod = -2;
                break;
            case 7:
                newPlayer.wisMod = -2;
                break;
            case 8:
                newPlayer.wisMod = -1;
                break;
            case 9:
                newPlayer.wisMod = -1;
                break;
            case 10:
                newPlayer.wisMod = 0;
                break;
            case 11:
                newPlayer.wisMod = 0;
                break;
            case 12:
                newPlayer.wisMod = 1;
                break;
            case 13:
                newPlayer.wisMod = 1;
                break;
            case 14:
                newPlayer.wisMod = 2;
                break;
            case 15:
                newPlayer.wisMod = 2;
                break;
            case 16:
                newPlayer.wisMod = 3;
                break;
            case 17:
                newPlayer.wisMod = 3;
                break;
            case 18:
                newPlayer.wisMod = 4;
                break;
            case 19:
                newPlayer.wisMod = 4;
                break;
            case 20:
                newPlayer.wisMod = 5;
                break;
            case 21:
                newPlayer.wisMod = 5;
                break;
            case 22:
                newPlayer.wisMod = 6;
                break;
            case 23:
                newPlayer.wisMod = 6;
                break;
            case 24:
                newPlayer.wisMod = 7;
                break;
            case 25:
                newPlayer.wisMod = 7;
                break;
            case 26:
                newPlayer.wisMod = 8;
                break;
            case 27:
                newPlayer.wisMod = 8;
                break;
            case 28:
                newPlayer.wisMod = 9;
                break;
            case 29:
                newPlayer.wisMod = 9;
                break;
            case 30:
                newPlayer.wisMod = 10;
                newPlayer.Wisdom = 30;
                break;
        }
        switch (newPlayer.Charisma)
        {
            case 0:
                newPlayer.chrMod = -5;
                break;
            case 1:
                newPlayer.chrMod = -5;
                break;
            case 2:
                newPlayer.chrMod = -4;
                break;
            case 3:
                newPlayer.chrMod = -4;
                break;
            case 4:
                newPlayer.chrMod = -3;
                break;
            case 5:
                newPlayer.chrMod = -3;
                break;
            case 6:
                newPlayer.chrMod = -2;
                break;
            case 7:
                newPlayer.chrMod = -2;
                break;
            case 8:
                newPlayer.chrMod = -1;
                break;
            case 9:
                newPlayer.chrMod = -1;
                break;
            case 10:
                newPlayer.chrMod = 0;
                break;
            case 11:
                newPlayer.chrMod = 0;
                break;
            case 12:
                newPlayer.chrMod = 1;
                break;
            case 13:
                newPlayer.chrMod = 1;
                break;
            case 14:
                newPlayer.chrMod = 2;
                break;
            case 15:
                newPlayer.chrMod = 2;
                break;
            case 16:
                newPlayer.chrMod = 3;
                break;
            case 17:
                newPlayer.chrMod = 3;
                break;
            case 18:
                newPlayer.chrMod = 4;
                break;
            case 19:
                newPlayer.chrMod = 4;
                break;
            case 20:
                newPlayer.chrMod = 5;
                break;
            case 21:
                newPlayer.chrMod = 5;
                break;
            case 22:
                newPlayer.chrMod = 6;
                break;
            case 23:
                newPlayer.chrMod = 6;
                break;
            case 24:
                newPlayer.chrMod = 7;
                break;
            case 25:
                newPlayer.chrMod = 7;
                break;
            case 26:
                newPlayer.chrMod = 8;
                break;
            case 27:
                newPlayer.chrMod = 8;
                break;
            case 28:
                newPlayer.chrMod = 9;
                break;
            case 29:
                newPlayer.chrMod = 9;
                break;
            case 30:
                newPlayer.chrMod = 10;
                newPlayer.Charisma = 30;
                break;
        }
        #endregion   
        ClassTextDisplay.text = GameInfo.setClass.ToString();
        UpdateUI();
    }

    public void SetWarlockClass()
    {
        newPlayer.PlayerClass = new WarlockClass();
        GameInfo.setClass = PlayerClass.Warlock;
        #region StatModCalculation
        switch (newPlayer.Strength)
        {
            case 0:
                newPlayer.strMod = -5;
                break;
            case 1:
                newPlayer.strMod = -5;
                break;
            case 2:
                newPlayer.strMod = -4;
                break;
            case 3:
                newPlayer.strMod = -4;
                break;
            case 4:
                newPlayer.strMod = -3;
                break;
            case 5:
                newPlayer.strMod = -3;
                break;
            case 6:
                newPlayer.strMod = -2;
                break;
            case 7:
                newPlayer.strMod = -2;
                break;
            case 8:
                newPlayer.strMod = -1;
                break;
            case 9:
                newPlayer.strMod = -1;
                break;
            case 10:
                newPlayer.strMod = 0;
                break;
            case 11:
                newPlayer.strMod = 0;
                break;
            case 12:
                newPlayer.strMod = 1;
                break;
            case 13:
                newPlayer.strMod = 1;
                break;
            case 14:
                newPlayer.strMod = 2;
                break;
            case 15:
                newPlayer.strMod = 2;
                break;
            case 16:
                newPlayer.strMod = 3;
                break;
            case 17:
                newPlayer.strMod = 3;
                break;
            case 18:
                newPlayer.strMod = 4;
                break;
            case 19:
                newPlayer.strMod = 4;
                break;
            case 20:
                newPlayer.strMod = 5;
                break;
            case 21:
                newPlayer.strMod = 5;
                break;
            case 22:
                newPlayer.strMod = 6;
                break;
            case 23:
                newPlayer.strMod = 6;
                break;
            case 24:
                newPlayer.strMod = 7;
                break;
            case 25:
                newPlayer.strMod = 7;
                break;
            case 26:
                newPlayer.strMod = 8;
                break;
            case 27:
                newPlayer.strMod = 8;
                break;
            case 28:
                newPlayer.strMod = 9;
                break;
            case 29:
                newPlayer.strMod = 9;
                break;
            case 30:
                newPlayer.strMod = 10;
                newPlayer.Strength = 30;
                break;
        }
        switch (newPlayer.Dexterity)
        {
            case 0:
                newPlayer.dexMod = -5;
                break;
            case 1:
                newPlayer.dexMod = -5;
                break;
            case 2:
                newPlayer.dexMod = -4;
                break;
            case 3:
                newPlayer.dexMod = -4;
                break;
            case 4:
                newPlayer.dexMod = -3;
                break;
            case 5:
                newPlayer.dexMod = -3;
                break;
            case 6:
                newPlayer.dexMod = -2;
                break;
            case 7:
                newPlayer.dexMod = -2;
                break;
            case 8:
                newPlayer.dexMod = -1;
                break;
            case 9:
                newPlayer.dexMod = -1;
                break;
            case 10:
                newPlayer.dexMod = 0;
                break;
            case 11:
                newPlayer.dexMod = 0;
                break;
            case 12:
                newPlayer.dexMod = 1;
                break;
            case 13:
                newPlayer.dexMod = 1;
                break;
            case 14:
                newPlayer.dexMod = 2;
                break;
            case 15:
                newPlayer.dexMod = 2;
                break;
            case 16:
                newPlayer.dexMod = 3;
                break;
            case 17:
                newPlayer.dexMod = 3;
                break;
            case 18:
                newPlayer.dexMod = 4;
                break;
            case 19:
                newPlayer.dexMod = 4;
                break;
            case 20:
                newPlayer.dexMod = 5;
                break;
            case 21:
                newPlayer.dexMod = 5;
                break;
            case 22:
                newPlayer.dexMod = 6;
                break;
            case 23:
                newPlayer.dexMod = 6;
                break;
            case 24:
                newPlayer.dexMod = 7;
                break;
            case 25:
                newPlayer.dexMod = 7;
                break;
            case 26:
                newPlayer.dexMod = 8;
                break;
            case 27:
                newPlayer.dexMod = 8;
                break;
            case 28:
                newPlayer.dexMod = 9;
                break;
            case 29:
                newPlayer.dexMod = 9;
                break;
            case 30:
                newPlayer.dexMod = 10;
                newPlayer.Dexterity = 30;
                break;
        }
        switch (newPlayer.Constitution)
        {
            case 0:
                newPlayer.conMod = -5;
                break;
            case 1:
                newPlayer.conMod = -5;
                break;
            case 2:
                newPlayer.conMod = -4;
                break;
            case 3:
                newPlayer.conMod = -4;
                break;
            case 4:
                newPlayer.conMod = -3;
                break;
            case 5:
                newPlayer.conMod = -3;
                break;
            case 6:
                newPlayer.conMod = -2;
                break;
            case 7:
                newPlayer.conMod = -2;
                break;
            case 8:
                newPlayer.conMod = -1;
                break;
            case 9:
                newPlayer.conMod = -1;
                break;
            case 10:
                newPlayer.conMod = 0;
                break;
            case 11:
                newPlayer.conMod = 0;
                break;
            case 12:
                newPlayer.conMod = 1;
                break;
            case 13:
                newPlayer.conMod = 1;
                break;
            case 14:
                newPlayer.conMod = 2;
                break;
            case 15:
                newPlayer.conMod = 2;
                break;
            case 16:
                newPlayer.conMod = 3;
                break;
            case 17:
                newPlayer.conMod = 3;
                break;
            case 18:
                newPlayer.conMod = 4;
                break;
            case 19:
                newPlayer.conMod = 4;
                break;
            case 20:
                newPlayer.conMod = 5;
                break;
            case 21:
                newPlayer.conMod = 5;
                break;
            case 22:
                newPlayer.conMod = 6;
                break;
            case 23:
                newPlayer.conMod = 6;
                break;
            case 24:
                newPlayer.conMod = 7;
                break;
            case 25:
                newPlayer.conMod = 7;
                break;
            case 26:
                newPlayer.conMod = 8;
                break;
            case 27:
                newPlayer.conMod = 8;
                break;
            case 28:
                newPlayer.conMod = 9;
                break;
            case 29:
                newPlayer.conMod = 9;
                break;
            case 30:
                newPlayer.conMod = 10;
                newPlayer.Constitution = 30;
                break;
        }
        switch (newPlayer.Intelligence)
        {
            case 0:
                newPlayer.intMod = -5;
                break;
            case 1:
                newPlayer.intMod = -5;
                break;
            case 2:
                newPlayer.intMod = -4;
                break;
            case 3:
                newPlayer.intMod = -4;
                break;
            case 4:
                newPlayer.intMod = -3;
                break;
            case 5:
                newPlayer.intMod = -3;
                break;
            case 6:
                newPlayer.intMod = -2;
                break;
            case 7:
                newPlayer.intMod = -2;
                break;
            case 8:
                newPlayer.intMod = -1;
                break;
            case 9:
                newPlayer.intMod = -1;
                break;
            case 10:
                newPlayer.intMod = 0;
                break;
            case 11:
                newPlayer.intMod = 0;
                break;
            case 12:
                newPlayer.intMod = 1;
                break;
            case 13:
                newPlayer.intMod = 1;
                break;
            case 14:
                newPlayer.intMod = 2;
                break;
            case 15:
                newPlayer.intMod = 2;
                break;
            case 16:
                newPlayer.intMod = 3;
                break;
            case 17:
                newPlayer.intMod = 3;
                break;
            case 18:
                newPlayer.intMod = 4;
                break;
            case 19:
                newPlayer.intMod = 4;
                break;
            case 20:
                newPlayer.intMod = 5;
                break;
            case 21:
                newPlayer.intMod = 5;
                break;
            case 22:
                newPlayer.intMod = 6;
                break;
            case 23:
                newPlayer.intMod = 6;
                break;
            case 24:
                newPlayer.intMod = 7;
                break;
            case 25:
                newPlayer.intMod = 7;
                break;
            case 26:
                newPlayer.intMod = 8;
                break;
            case 27:
                newPlayer.intMod = 8;
                break;
            case 28:
                newPlayer.intMod = 9;
                break;
            case 29:
                newPlayer.intMod = 9;
                break;
            case 30:
                newPlayer.intMod = 10;
                newPlayer.Intelligence = 30;
                break;
        }
        switch (newPlayer.Wisdom)
        {
            case 0:
                newPlayer.wisMod = -5;
                break;
            case 1:
                newPlayer.wisMod = -5;
                break;
            case 2:
                newPlayer.wisMod = -4;
                break;
            case 3:
                newPlayer.wisMod = -4;
                break;
            case 4:
                newPlayer.wisMod = -3;
                break;
            case 5:
                newPlayer.wisMod = -3;
                break;
            case 6:
                newPlayer.wisMod = -2;
                break;
            case 7:
                newPlayer.wisMod = -2;
                break;
            case 8:
                newPlayer.wisMod = -1;
                break;
            case 9:
                newPlayer.wisMod = -1;
                break;
            case 10:
                newPlayer.wisMod = 0;
                break;
            case 11:
                newPlayer.wisMod = 0;
                break;
            case 12:
                newPlayer.wisMod = 1;
                break;
            case 13:
                newPlayer.wisMod = 1;
                break;
            case 14:
                newPlayer.wisMod = 2;
                break;
            case 15:
                newPlayer.wisMod = 2;
                break;
            case 16:
                newPlayer.wisMod = 3;
                break;
            case 17:
                newPlayer.wisMod = 3;
                break;
            case 18:
                newPlayer.wisMod = 4;
                break;
            case 19:
                newPlayer.wisMod = 4;
                break;
            case 20:
                newPlayer.wisMod = 5;
                break;
            case 21:
                newPlayer.wisMod = 5;
                break;
            case 22:
                newPlayer.wisMod = 6;
                break;
            case 23:
                newPlayer.wisMod = 6;
                break;
            case 24:
                newPlayer.wisMod = 7;
                break;
            case 25:
                newPlayer.wisMod = 7;
                break;
            case 26:
                newPlayer.wisMod = 8;
                break;
            case 27:
                newPlayer.wisMod = 8;
                break;
            case 28:
                newPlayer.wisMod = 9;
                break;
            case 29:
                newPlayer.wisMod = 9;
                break;
            case 30:
                newPlayer.wisMod = 10;
                newPlayer.Wisdom = 30;
                break;
        }
        switch (newPlayer.Charisma)
        {
            case 0:
                newPlayer.chrMod = -5;
                break;
            case 1:
                newPlayer.chrMod = -5;
                break;
            case 2:
                newPlayer.chrMod = -4;
                break;
            case 3:
                newPlayer.chrMod = -4;
                break;
            case 4:
                newPlayer.chrMod = -3;
                break;
            case 5:
                newPlayer.chrMod = -3;
                break;
            case 6:
                newPlayer.chrMod = -2;
                break;
            case 7:
                newPlayer.chrMod = -2;
                break;
            case 8:
                newPlayer.chrMod = -1;
                break;
            case 9:
                newPlayer.chrMod = -1;
                break;
            case 10:
                newPlayer.chrMod = 0;
                break;
            case 11:
                newPlayer.chrMod = 0;
                break;
            case 12:
                newPlayer.chrMod = 1;
                break;
            case 13:
                newPlayer.chrMod = 1;
                break;
            case 14:
                newPlayer.chrMod = 2;
                break;
            case 15:
                newPlayer.chrMod = 2;
                break;
            case 16:
                newPlayer.chrMod = 3;
                break;
            case 17:
                newPlayer.chrMod = 3;
                break;
            case 18:
                newPlayer.chrMod = 4;
                break;
            case 19:
                newPlayer.chrMod = 4;
                break;
            case 20:
                newPlayer.chrMod = 5;
                break;
            case 21:
                newPlayer.chrMod = 5;
                break;
            case 22:
                newPlayer.chrMod = 6;
                break;
            case 23:
                newPlayer.chrMod = 6;
                break;
            case 24:
                newPlayer.chrMod = 7;
                break;
            case 25:
                newPlayer.chrMod = 7;
                break;
            case 26:
                newPlayer.chrMod = 8;
                break;
            case 27:
                newPlayer.chrMod = 8;
                break;
            case 28:
                newPlayer.chrMod = 9;
                break;
            case 29:
                newPlayer.chrMod = 9;
                break;
            case 30:
                newPlayer.chrMod = 10;
                newPlayer.Charisma = 30;
                break;
        }
        #endregion
        ClassTextDisplay.text = GameInfo.setClass.ToString();
        UpdateUI();
    }

    public void SetWizardClass()
    {
        newPlayer.PlayerClass = new WizardClass();
        GameInfo.setClass = PlayerClass.Wizard;
        #region StatModCalculation
        switch (newPlayer.Strength)
        {
            case 0:
                newPlayer.strMod = -5;
                break;
            case 1:
                newPlayer.strMod = -5;
                break;
            case 2:
                newPlayer.strMod = -4;
                break;
            case 3:
                newPlayer.strMod = -4;
                break;
            case 4:
                newPlayer.strMod = -3;
                break;
            case 5:
                newPlayer.strMod = -3;
                break;
            case 6:
                newPlayer.strMod = -2;
                break;
            case 7:
                newPlayer.strMod = -2;
                break;
            case 8:
                newPlayer.strMod = -1;
                break;
            case 9:
                newPlayer.strMod = -1;
                break;
            case 10:
                newPlayer.strMod = 0;
                break;
            case 11:
                newPlayer.strMod = 0;
                break;
            case 12:
                newPlayer.strMod = 1;
                break;
            case 13:
                newPlayer.strMod = 1;
                break;
            case 14:
                newPlayer.strMod = 2;
                break;
            case 15:
                newPlayer.strMod = 2;
                break;
            case 16:
                newPlayer.strMod = 3;
                break;
            case 17:
                newPlayer.strMod = 3;
                break;
            case 18:
                newPlayer.strMod = 4;
                break;
            case 19:
                newPlayer.strMod = 4;
                break;
            case 20:
                newPlayer.strMod = 5;
                break;
            case 21:
                newPlayer.strMod = 5;
                break;
            case 22:
                newPlayer.strMod = 6;
                break;
            case 23:
                newPlayer.strMod = 6;
                break;
            case 24:
                newPlayer.strMod = 7;
                break;
            case 25:
                newPlayer.strMod = 7;
                break;
            case 26:
                newPlayer.strMod = 8;
                break;
            case 27:
                newPlayer.strMod = 8;
                break;
            case 28:
                newPlayer.strMod = 9;
                break;
            case 29:
                newPlayer.strMod = 9;
                break;
            case 30:
                newPlayer.strMod = 10;
                newPlayer.Strength = 30;
                break;
        }
        switch (newPlayer.Dexterity)
        {
            case 0:
                newPlayer.dexMod = -5;
                break;
            case 1:
                newPlayer.dexMod = -5;
                break;
            case 2:
                newPlayer.dexMod = -4;
                break;
            case 3:
                newPlayer.dexMod = -4;
                break;
            case 4:
                newPlayer.dexMod = -3;
                break;
            case 5:
                newPlayer.dexMod = -3;
                break;
            case 6:
                newPlayer.dexMod = -2;
                break;
            case 7:
                newPlayer.dexMod = -2;
                break;
            case 8:
                newPlayer.dexMod = -1;
                break;
            case 9:
                newPlayer.dexMod = -1;
                break;
            case 10:
                newPlayer.dexMod = 0;
                break;
            case 11:
                newPlayer.dexMod = 0;
                break;
            case 12:
                newPlayer.dexMod = 1;
                break;
            case 13:
                newPlayer.dexMod = 1;
                break;
            case 14:
                newPlayer.dexMod = 2;
                break;
            case 15:
                newPlayer.dexMod = 2;
                break;
            case 16:
                newPlayer.dexMod = 3;
                break;
            case 17:
                newPlayer.dexMod = 3;
                break;
            case 18:
                newPlayer.dexMod = 4;
                break;
            case 19:
                newPlayer.dexMod = 4;
                break;
            case 20:
                newPlayer.dexMod = 5;
                break;
            case 21:
                newPlayer.dexMod = 5;
                break;
            case 22:
                newPlayer.dexMod = 6;
                break;
            case 23:
                newPlayer.dexMod = 6;
                break;
            case 24:
                newPlayer.dexMod = 7;
                break;
            case 25:
                newPlayer.dexMod = 7;
                break;
            case 26:
                newPlayer.dexMod = 8;
                break;
            case 27:
                newPlayer.dexMod = 8;
                break;
            case 28:
                newPlayer.dexMod = 9;
                break;
            case 29:
                newPlayer.dexMod = 9;
                break;
            case 30:
                newPlayer.dexMod = 10;
                newPlayer.Dexterity = 30;
                break;
        }
        switch (newPlayer.Constitution)
        {
            case 0:
                newPlayer.conMod = -5;
                break;
            case 1:
                newPlayer.conMod = -5;
                break;
            case 2:
                newPlayer.conMod = -4;
                break;
            case 3:
                newPlayer.conMod = -4;
                break;
            case 4:
                newPlayer.conMod = -3;
                break;
            case 5:
                newPlayer.conMod = -3;
                break;
            case 6:
                newPlayer.conMod = -2;
                break;
            case 7:
                newPlayer.conMod = -2;
                break;
            case 8:
                newPlayer.conMod = -1;
                break;
            case 9:
                newPlayer.conMod = -1;
                break;
            case 10:
                newPlayer.conMod = 0;
                break;
            case 11:
                newPlayer.conMod = 0;
                break;
            case 12:
                newPlayer.conMod = 1;
                break;
            case 13:
                newPlayer.conMod = 1;
                break;
            case 14:
                newPlayer.conMod = 2;
                break;
            case 15:
                newPlayer.conMod = 2;
                break;
            case 16:
                newPlayer.conMod = 3;
                break;
            case 17:
                newPlayer.conMod = 3;
                break;
            case 18:
                newPlayer.conMod = 4;
                break;
            case 19:
                newPlayer.conMod = 4;
                break;
            case 20:
                newPlayer.conMod = 5;
                break;
            case 21:
                newPlayer.conMod = 5;
                break;
            case 22:
                newPlayer.conMod = 6;
                break;
            case 23:
                newPlayer.conMod = 6;
                break;
            case 24:
                newPlayer.conMod = 7;
                break;
            case 25:
                newPlayer.conMod = 7;
                break;
            case 26:
                newPlayer.conMod = 8;
                break;
            case 27:
                newPlayer.conMod = 8;
                break;
            case 28:
                newPlayer.conMod = 9;
                break;
            case 29:
                newPlayer.conMod = 9;
                break;
            case 30:
                newPlayer.conMod = 10;
                newPlayer.Constitution = 30;
                break;
        }
        switch (newPlayer.Intelligence)
        {
            case 0:
                newPlayer.intMod = -5;
                break;
            case 1:
                newPlayer.intMod = -5;
                break;
            case 2:
                newPlayer.intMod = -4;
                break;
            case 3:
                newPlayer.intMod = -4;
                break;
            case 4:
                newPlayer.intMod = -3;
                break;
            case 5:
                newPlayer.intMod = -3;
                break;
            case 6:
                newPlayer.intMod = -2;
                break;
            case 7:
                newPlayer.intMod = -2;
                break;
            case 8:
                newPlayer.intMod = -1;
                break;
            case 9:
                newPlayer.intMod = -1;
                break;
            case 10:
                newPlayer.intMod = 0;
                break;
            case 11:
                newPlayer.intMod = 0;
                break;
            case 12:
                newPlayer.intMod = 1;
                break;
            case 13:
                newPlayer.intMod = 1;
                break;
            case 14:
                newPlayer.intMod = 2;
                break;
            case 15:
                newPlayer.intMod = 2;
                break;
            case 16:
                newPlayer.intMod = 3;
                break;
            case 17:
                newPlayer.intMod = 3;
                break;
            case 18:
                newPlayer.intMod = 4;
                break;
            case 19:
                newPlayer.intMod = 4;
                break;
            case 20:
                newPlayer.intMod = 5;
                break;
            case 21:
                newPlayer.intMod = 5;
                break;
            case 22:
                newPlayer.intMod = 6;
                break;
            case 23:
                newPlayer.intMod = 6;
                break;
            case 24:
                newPlayer.intMod = 7;
                break;
            case 25:
                newPlayer.intMod = 7;
                break;
            case 26:
                newPlayer.intMod = 8;
                break;
            case 27:
                newPlayer.intMod = 8;
                break;
            case 28:
                newPlayer.intMod = 9;
                break;
            case 29:
                newPlayer.intMod = 9;
                break;
            case 30:
                newPlayer.intMod = 10;
                newPlayer.Intelligence = 30;
                break;
        }
        switch (newPlayer.Wisdom)
        {
            case 0:
                newPlayer.wisMod = -5;
                break;
            case 1:
                newPlayer.wisMod = -5;
                break;
            case 2:
                newPlayer.wisMod = -4;
                break;
            case 3:
                newPlayer.wisMod = -4;
                break;
            case 4:
                newPlayer.wisMod = -3;
                break;
            case 5:
                newPlayer.wisMod = -3;
                break;
            case 6:
                newPlayer.wisMod = -2;
                break;
            case 7:
                newPlayer.wisMod = -2;
                break;
            case 8:
                newPlayer.wisMod = -1;
                break;
            case 9:
                newPlayer.wisMod = -1;
                break;
            case 10:
                newPlayer.wisMod = 0;
                break;
            case 11:
                newPlayer.wisMod = 0;
                break;
            case 12:
                newPlayer.wisMod = 1;
                break;
            case 13:
                newPlayer.wisMod = 1;
                break;
            case 14:
                newPlayer.wisMod = 2;
                break;
            case 15:
                newPlayer.wisMod = 2;
                break;
            case 16:
                newPlayer.wisMod = 3;
                break;
            case 17:
                newPlayer.wisMod = 3;
                break;
            case 18:
                newPlayer.wisMod = 4;
                break;
            case 19:
                newPlayer.wisMod = 4;
                break;
            case 20:
                newPlayer.wisMod = 5;
                break;
            case 21:
                newPlayer.wisMod = 5;
                break;
            case 22:
                newPlayer.wisMod = 6;
                break;
            case 23:
                newPlayer.wisMod = 6;
                break;
            case 24:
                newPlayer.wisMod = 7;
                break;
            case 25:
                newPlayer.wisMod = 7;
                break;
            case 26:
                newPlayer.wisMod = 8;
                break;
            case 27:
                newPlayer.wisMod = 8;
                break;
            case 28:
                newPlayer.wisMod = 9;
                break;
            case 29:
                newPlayer.wisMod = 9;
                break;
            case 30:
                newPlayer.wisMod = 10;
                newPlayer.Wisdom = 30;
                break;
        }
        switch (newPlayer.Charisma)
        {
            case 0:
                newPlayer.chrMod = -5;
                break;
            case 1:
                newPlayer.chrMod = -5;
                break;
            case 2:
                newPlayer.chrMod = -4;
                break;
            case 3:
                newPlayer.chrMod = -4;
                break;
            case 4:
                newPlayer.chrMod = -3;
                break;
            case 5:
                newPlayer.chrMod = -3;
                break;
            case 6:
                newPlayer.chrMod = -2;
                break;
            case 7:
                newPlayer.chrMod = -2;
                break;
            case 8:
                newPlayer.chrMod = -1;
                break;
            case 9:
                newPlayer.chrMod = -1;
                break;
            case 10:
                newPlayer.chrMod = 0;
                break;
            case 11:
                newPlayer.chrMod = 0;
                break;
            case 12:
                newPlayer.chrMod = 1;
                break;
            case 13:
                newPlayer.chrMod = 1;
                break;
            case 14:
                newPlayer.chrMod = 2;
                break;
            case 15:
                newPlayer.chrMod = 2;
                break;
            case 16:
                newPlayer.chrMod = 3;
                break;
            case 17:
                newPlayer.chrMod = 3;
                break;
            case 18:
                newPlayer.chrMod = 4;
                break;
            case 19:
                newPlayer.chrMod = 4;
                break;
            case 20:
                newPlayer.chrMod = 5;
                break;
            case 21:
                newPlayer.chrMod = 5;
                break;
            case 22:
                newPlayer.chrMod = 6;
                break;
            case 23:
                newPlayer.chrMod = 6;
                break;
            case 24:
                newPlayer.chrMod = 7;
                break;
            case 25:
                newPlayer.chrMod = 7;
                break;
            case 26:
                newPlayer.chrMod = 8;
                break;
            case 27:
                newPlayer.chrMod = 8;
                break;
            case 28:
                newPlayer.chrMod = 9;
                break;
            case 29:
                newPlayer.chrMod = 9;
                break;
            case 30:
                newPlayer.chrMod = 10;
                newPlayer.Charisma = 30;
                break;
        }
        #endregion
        ClassTextDisplay.text = GameInfo.setClass.ToString();
        UpdateUI();
    }
    #endregion

    #region Jobs

    public void SetAcolyteJob()
    {
        jobPointstoSpend = 5;
        newPlayer.PlayerJob = new AcolyteBackground();
        GameInfo.setJobs = PlayerJobs.Acolyte;
        newPlayer.Acrobatics = newPlayer.PlayerJob.Acrobatics;
        newPlayer.AnimaHandling = newPlayer.PlayerJob.AnimaHandling;
        newPlayer.Arcana = newPlayer.PlayerJob.Arcana;
        newPlayer.Athletics = newPlayer.PlayerJob.Athletics;
        newPlayer.Deception = newPlayer.PlayerJob.Deception;
        newPlayer.History = newPlayer.PlayerJob.History;
        newPlayer.Insight = newPlayer.PlayerJob.Insight;
        newPlayer.Intimidation = newPlayer.PlayerJob.Intimidation;
        newPlayer.Investigation = newPlayer.PlayerJob.Investigation;
        newPlayer.Medicine = newPlayer.PlayerJob.Medicine;
        newPlayer.Nature = newPlayer.PlayerJob.Nature;
        newPlayer.Perception = newPlayer.PlayerJob.Perception;
        newPlayer.Performance = newPlayer.PlayerJob.Performance;
        newPlayer.Persuasion = newPlayer.PlayerJob.Persuasion;
        newPlayer.Religion = newPlayer.PlayerJob.Religion;
        newPlayer.SlightOfHand = newPlayer.PlayerJob.SlightOfHand;
        newPlayer.Stealth = newPlayer.PlayerJob.Stealth;
        BackgroundTextDisplay.text = GameInfo.setJobs.ToString();
        UpdateUI();
    }

    public void SetCharlatanJob()
    {
        jobPointstoSpend = 5;
        newPlayer.PlayerJob = new CharlatanBackground();
        GameInfo.setJobs = PlayerJobs.Charlatan;
        newPlayer.Acrobatics = newPlayer.PlayerJob.Acrobatics;
        newPlayer.AnimaHandling = newPlayer.PlayerJob.AnimaHandling;
        newPlayer.Arcana = newPlayer.PlayerJob.Arcana;
        newPlayer.Athletics = newPlayer.PlayerJob.Athletics;
        newPlayer.Deception = newPlayer.PlayerJob.Deception;
        newPlayer.History = newPlayer.PlayerJob.History;
        newPlayer.Insight = newPlayer.PlayerJob.Insight;
        newPlayer.Intimidation = newPlayer.PlayerJob.Intimidation;
        newPlayer.Investigation = newPlayer.PlayerJob.Investigation;
        newPlayer.Medicine = newPlayer.PlayerJob.Medicine;
        newPlayer.Nature = newPlayer.PlayerJob.Nature;
        newPlayer.Perception = newPlayer.PlayerJob.Perception;
        newPlayer.Performance = newPlayer.PlayerJob.Performance;
        newPlayer.Persuasion = newPlayer.PlayerJob.Persuasion;
        newPlayer.Religion = newPlayer.PlayerJob.Religion;
        newPlayer.SlightOfHand = newPlayer.PlayerJob.SlightOfHand;
        newPlayer.Stealth = newPlayer.PlayerJob.Stealth;
        BackgroundTextDisplay.text = GameInfo.setJobs.ToString();
        UpdateUI();
    }

    public void SetCriminalJob()
    {
        jobPointstoSpend = 5;
        newPlayer.PlayerJob = new CriminalBackground();
        GameInfo.setJobs = PlayerJobs.Criminal;
        newPlayer.Acrobatics = newPlayer.PlayerJob.Acrobatics;
        newPlayer.AnimaHandling = newPlayer.PlayerJob.AnimaHandling;
        newPlayer.Arcana = newPlayer.PlayerJob.Arcana;
        newPlayer.Athletics = newPlayer.PlayerJob.Athletics;
        newPlayer.Deception = newPlayer.PlayerJob.Deception;
        newPlayer.History = newPlayer.PlayerJob.History;
        newPlayer.Insight = newPlayer.PlayerJob.Insight;
        newPlayer.Intimidation = newPlayer.PlayerJob.Intimidation;
        newPlayer.Investigation = newPlayer.PlayerJob.Investigation;
        newPlayer.Medicine = newPlayer.PlayerJob.Medicine;
        newPlayer.Nature = newPlayer.PlayerJob.Nature;
        newPlayer.Perception = newPlayer.PlayerJob.Perception;
        newPlayer.Performance = newPlayer.PlayerJob.Performance;
        newPlayer.Persuasion = newPlayer.PlayerJob.Persuasion;
        newPlayer.Religion = newPlayer.PlayerJob.Religion;
        newPlayer.SlightOfHand = newPlayer.PlayerJob.SlightOfHand;
        newPlayer.Stealth = newPlayer.PlayerJob.Stealth;
        BackgroundTextDisplay.text = GameInfo.setJobs.ToString();
        UpdateUI();
    }

    public void SetEntertainerJob()
    {
        jobPointstoSpend = 5;
        newPlayer.PlayerJob = new EntertainerBackground();
        GameInfo.setJobs = PlayerJobs.Entertainer;
        newPlayer.Acrobatics = newPlayer.PlayerJob.Acrobatics;
        newPlayer.AnimaHandling = newPlayer.PlayerJob.AnimaHandling;
        newPlayer.Arcana = newPlayer.PlayerJob.Arcana;
        newPlayer.Athletics = newPlayer.PlayerJob.Athletics;
        newPlayer.Deception = newPlayer.PlayerJob.Deception;
        newPlayer.History = newPlayer.PlayerJob.History;
        newPlayer.Insight = newPlayer.PlayerJob.Insight;
        newPlayer.Intimidation = newPlayer.PlayerJob.Intimidation;
        newPlayer.Investigation = newPlayer.PlayerJob.Investigation;
        newPlayer.Medicine = newPlayer.PlayerJob.Medicine;
        newPlayer.Nature = newPlayer.PlayerJob.Nature;
        newPlayer.Perception = newPlayer.PlayerJob.Perception;
        newPlayer.Performance = newPlayer.PlayerJob.Performance;
        newPlayer.Persuasion = newPlayer.PlayerJob.Persuasion;
        newPlayer.Religion = newPlayer.PlayerJob.Religion;
        newPlayer.SlightOfHand = newPlayer.PlayerJob.SlightOfHand;
        newPlayer.Stealth = newPlayer.PlayerJob.Stealth;
        BackgroundTextDisplay.text = GameInfo.setJobs.ToString();
        UpdateUI();
    }

    public void SetFolkHeroJob()
    {
        jobPointstoSpend = 5;
        newPlayer.PlayerJob = new FolkHeroBackground();
        GameInfo.setJobs = PlayerJobs.FolkHero;
        newPlayer.Acrobatics = newPlayer.PlayerJob.Acrobatics;
        newPlayer.AnimaHandling = newPlayer.PlayerJob.AnimaHandling;
        newPlayer.Arcana = newPlayer.PlayerJob.Arcana;
        newPlayer.Athletics = newPlayer.PlayerJob.Athletics;
        newPlayer.Deception = newPlayer.PlayerJob.Deception;
        newPlayer.History = newPlayer.PlayerJob.History;
        newPlayer.Insight = newPlayer.PlayerJob.Insight;
        newPlayer.Intimidation = newPlayer.PlayerJob.Intimidation;
        newPlayer.Investigation = newPlayer.PlayerJob.Investigation;
        newPlayer.Medicine = newPlayer.PlayerJob.Medicine;
        newPlayer.Nature = newPlayer.PlayerJob.Nature;
        newPlayer.Perception = newPlayer.PlayerJob.Perception;
        newPlayer.Performance = newPlayer.PlayerJob.Performance;
        newPlayer.Persuasion = newPlayer.PlayerJob.Persuasion;
        newPlayer.Religion = newPlayer.PlayerJob.Religion;
        newPlayer.SlightOfHand = newPlayer.PlayerJob.SlightOfHand;
        newPlayer.Stealth = newPlayer.PlayerJob.Stealth;
        BackgroundTextDisplay.text = GameInfo.setJobs.ToString();
        UpdateUI();
    }

    public void SetGuildArtisanJob()
    {
        jobPointstoSpend = 5;
        newPlayer.PlayerJob = new GuildArtisanBackground();
        GameInfo.setJobs = PlayerJobs.GuildArtisan;
        newPlayer.Acrobatics = newPlayer.PlayerJob.Acrobatics;
        newPlayer.AnimaHandling = newPlayer.PlayerJob.AnimaHandling;
        newPlayer.Arcana = newPlayer.PlayerJob.Arcana;
        newPlayer.Athletics = newPlayer.PlayerJob.Athletics;
        newPlayer.Deception = newPlayer.PlayerJob.Deception;
        newPlayer.History = newPlayer.PlayerJob.History;
        newPlayer.Insight = newPlayer.PlayerJob.Insight;
        newPlayer.Intimidation = newPlayer.PlayerJob.Intimidation;
        newPlayer.Investigation = newPlayer.PlayerJob.Investigation;
        newPlayer.Medicine = newPlayer.PlayerJob.Medicine;
        newPlayer.Nature = newPlayer.PlayerJob.Nature;
        newPlayer.Perception = newPlayer.PlayerJob.Perception;
        newPlayer.Performance = newPlayer.PlayerJob.Performance;
        newPlayer.Persuasion = newPlayer.PlayerJob.Persuasion;
        newPlayer.Religion = newPlayer.PlayerJob.Religion;
        newPlayer.SlightOfHand = newPlayer.PlayerJob.SlightOfHand;
        newPlayer.Stealth = newPlayer.PlayerJob.Stealth;
        BackgroundTextDisplay.text = GameInfo.setJobs.ToString();
        UpdateUI();
    }

    public void SetHermitJob()
    {
        jobPointstoSpend = 5;
        newPlayer.PlayerJob = new HermitBackground();
        GameInfo.setJobs = PlayerJobs.Hermit;
        newPlayer.Acrobatics = newPlayer.PlayerJob.Acrobatics;
        newPlayer.AnimaHandling = newPlayer.PlayerJob.AnimaHandling;
        newPlayer.Arcana = newPlayer.PlayerJob.Arcana;
        newPlayer.Athletics = newPlayer.PlayerJob.Athletics;
        newPlayer.Deception = newPlayer.PlayerJob.Deception;
        newPlayer.History = newPlayer.PlayerJob.History;
        newPlayer.Insight = newPlayer.PlayerJob.Insight;
        newPlayer.Intimidation = newPlayer.PlayerJob.Intimidation;
        newPlayer.Investigation = newPlayer.PlayerJob.Investigation;
        newPlayer.Medicine = newPlayer.PlayerJob.Medicine;
        newPlayer.Nature = newPlayer.PlayerJob.Nature;
        newPlayer.Perception = newPlayer.PlayerJob.Perception;
        newPlayer.Performance = newPlayer.PlayerJob.Performance;
        newPlayer.Persuasion = newPlayer.PlayerJob.Persuasion;
        newPlayer.Religion = newPlayer.PlayerJob.Religion;
        newPlayer.SlightOfHand = newPlayer.PlayerJob.SlightOfHand;
        newPlayer.Stealth = newPlayer.PlayerJob.Stealth;
        BackgroundTextDisplay.text = GameInfo.setJobs.ToString();
        UpdateUI();
    }

    public void SetNobleJob()
    {
        jobPointstoSpend = 5;
        newPlayer.PlayerJob = new NobleBackground();
        GameInfo.setJobs = PlayerJobs.Noble;
        newPlayer.Acrobatics = newPlayer.PlayerJob.Acrobatics;
        newPlayer.AnimaHandling = newPlayer.PlayerJob.AnimaHandling;
        newPlayer.Arcana = newPlayer.PlayerJob.Arcana;
        newPlayer.Athletics = newPlayer.PlayerJob.Athletics;
        newPlayer.Deception = newPlayer.PlayerJob.Deception;
        newPlayer.History = newPlayer.PlayerJob.History;
        newPlayer.Insight = newPlayer.PlayerJob.Insight;
        newPlayer.Intimidation = newPlayer.PlayerJob.Intimidation;
        newPlayer.Investigation = newPlayer.PlayerJob.Investigation;
        newPlayer.Medicine = newPlayer.PlayerJob.Medicine;
        newPlayer.Nature = newPlayer.PlayerJob.Nature;
        newPlayer.Perception = newPlayer.PlayerJob.Perception;
        newPlayer.Performance = newPlayer.PlayerJob.Performance;
        newPlayer.Persuasion = newPlayer.PlayerJob.Persuasion;
        newPlayer.Religion = newPlayer.PlayerJob.Religion;
        newPlayer.SlightOfHand = newPlayer.PlayerJob.SlightOfHand;
        newPlayer.Stealth = newPlayer.PlayerJob.Stealth;
        BackgroundTextDisplay.text = GameInfo.setJobs.ToString();
        UpdateUI();
    }

    public void SetOutlanderJob()
    {
        jobPointstoSpend = 5;
        newPlayer.PlayerJob = new OutlanderBackground();
        GameInfo.setJobs = PlayerJobs.Outlander;
        newPlayer.Acrobatics = newPlayer.PlayerJob.Acrobatics;
        newPlayer.AnimaHandling = newPlayer.PlayerJob.AnimaHandling;
        newPlayer.Arcana = newPlayer.PlayerJob.Arcana;
        newPlayer.Athletics = newPlayer.PlayerJob.Athletics;
        newPlayer.Deception = newPlayer.PlayerJob.Deception;
        newPlayer.History = newPlayer.PlayerJob.History;
        newPlayer.Insight = newPlayer.PlayerJob.Insight;
        newPlayer.Intimidation = newPlayer.PlayerJob.Intimidation;
        newPlayer.Investigation = newPlayer.PlayerJob.Investigation;
        newPlayer.Medicine = newPlayer.PlayerJob.Medicine;
        newPlayer.Nature = newPlayer.PlayerJob.Nature;
        newPlayer.Perception = newPlayer.PlayerJob.Perception;
        newPlayer.Performance = newPlayer.PlayerJob.Performance;
        newPlayer.Persuasion = newPlayer.PlayerJob.Persuasion;
        newPlayer.Religion = newPlayer.PlayerJob.Religion;
        newPlayer.SlightOfHand = newPlayer.PlayerJob.SlightOfHand;
        newPlayer.Stealth = newPlayer.PlayerJob.Stealth;
        BackgroundTextDisplay.text = GameInfo.setJobs.ToString();
        UpdateUI();
    }

    public void SetSailorJob()
    {
        jobPointstoSpend = 5;
        newPlayer.PlayerJob = new SailorBackground();
        GameInfo.setJobs = PlayerJobs.Sailor;
        newPlayer.Acrobatics = newPlayer.PlayerJob.Acrobatics;
        newPlayer.AnimaHandling = newPlayer.PlayerJob.AnimaHandling;
        newPlayer.Arcana = newPlayer.PlayerJob.Arcana;
        newPlayer.Athletics = newPlayer.PlayerJob.Athletics;
        newPlayer.Deception = newPlayer.PlayerJob.Deception;
        newPlayer.History = newPlayer.PlayerJob.History;
        newPlayer.Insight = newPlayer.PlayerJob.Insight;
        newPlayer.Intimidation = newPlayer.PlayerJob.Intimidation;
        newPlayer.Investigation = newPlayer.PlayerJob.Investigation;
        newPlayer.Medicine = newPlayer.PlayerJob.Medicine;
        newPlayer.Nature = newPlayer.PlayerJob.Nature;
        newPlayer.Perception = newPlayer.PlayerJob.Perception;
        newPlayer.Performance = newPlayer.PlayerJob.Performance;
        newPlayer.Persuasion = newPlayer.PlayerJob.Persuasion;
        newPlayer.Religion = newPlayer.PlayerJob.Religion;
        newPlayer.SlightOfHand = newPlayer.PlayerJob.SlightOfHand;
        newPlayer.Stealth = newPlayer.PlayerJob.Stealth;
        BackgroundTextDisplay.text = GameInfo.setJobs.ToString();
        UpdateUI();
    }

    public void SetSoldierJob()
    {
        jobPointstoSpend = 5;
        newPlayer.PlayerJob = new SoldierBackground();
        GameInfo.setJobs = PlayerJobs.Soldier;
        newPlayer.Acrobatics = newPlayer.PlayerJob.Acrobatics;
        newPlayer.AnimaHandling = newPlayer.PlayerJob.AnimaHandling;
        newPlayer.Arcana = newPlayer.PlayerJob.Arcana;
        newPlayer.Athletics = newPlayer.PlayerJob.Athletics;
        newPlayer.Deception = newPlayer.PlayerJob.Deception;
        newPlayer.History = newPlayer.PlayerJob.History;
        newPlayer.Insight = newPlayer.PlayerJob.Insight;
        newPlayer.Intimidation = newPlayer.PlayerJob.Intimidation;
        newPlayer.Investigation = newPlayer.PlayerJob.Investigation;
        newPlayer.Medicine = newPlayer.PlayerJob.Medicine;
        newPlayer.Nature = newPlayer.PlayerJob.Nature;
        newPlayer.Perception = newPlayer.PlayerJob.Perception;
        newPlayer.Performance = newPlayer.PlayerJob.Performance;
        newPlayer.Persuasion = newPlayer.PlayerJob.Persuasion;
        newPlayer.Religion = newPlayer.PlayerJob.Religion;
        newPlayer.SlightOfHand = newPlayer.PlayerJob.SlightOfHand;
        newPlayer.Stealth = newPlayer.PlayerJob.Stealth;
        BackgroundTextDisplay.text = GameInfo.setJobs.ToString();
        UpdateUI();
    }

    public void SetUrchinJob()
    {
        jobPointstoSpend = 5;
        newPlayer.PlayerJob = new UrchinBackground();
        GameInfo.setJobs = PlayerJobs.Urchin;
        newPlayer.Acrobatics = newPlayer.PlayerJob.Acrobatics;
        newPlayer.AnimaHandling = newPlayer.PlayerJob.AnimaHandling;
        newPlayer.Arcana = newPlayer.PlayerJob.Arcana;
        newPlayer.Athletics = newPlayer.PlayerJob.Athletics;
        newPlayer.Deception = newPlayer.PlayerJob.Deception;
        newPlayer.History = newPlayer.PlayerJob.History;
        newPlayer.Insight = newPlayer.PlayerJob.Insight;
        newPlayer.Intimidation = newPlayer.PlayerJob.Intimidation;
        newPlayer.Investigation = newPlayer.PlayerJob.Investigation;
        newPlayer.Medicine = newPlayer.PlayerJob.Medicine;
        newPlayer.Nature = newPlayer.PlayerJob.Nature;
        newPlayer.Perception = newPlayer.PlayerJob.Perception;
        newPlayer.Performance = newPlayer.PlayerJob.Performance;
        newPlayer.Persuasion = newPlayer.PlayerJob.Persuasion;
        newPlayer.Religion = newPlayer.PlayerJob.Religion;
        newPlayer.SlightOfHand = newPlayer.PlayerJob.SlightOfHand;
        newPlayer.Stealth = newPlayer.PlayerJob.Stealth;
        BackgroundTextDisplay.text = GameInfo.setJobs.ToString();
        UpdateUI();
    }

    public void SetHunterJob()
    {
        jobPointstoSpend = 5;
        newPlayer.PlayerJob = new BaseHunterJob();
        GameInfo.setJobs = PlayerJobs.Hunter;
        newPlayer.Acrobatics = newPlayer.PlayerJob.Acrobatics;
        newPlayer.AnimaHandling = newPlayer.PlayerJob.AnimaHandling;
        newPlayer.Arcana = newPlayer.PlayerJob.Arcana;
        newPlayer.Athletics = newPlayer.PlayerJob.Athletics;
        newPlayer.Deception = newPlayer.PlayerJob.Deception;
        newPlayer.History = newPlayer.PlayerJob.History;
        newPlayer.Insight = newPlayer.PlayerJob.Insight;
        newPlayer.Intimidation = newPlayer.PlayerJob.Intimidation;
        newPlayer.Investigation = newPlayer.PlayerJob.Investigation;
        newPlayer.Medicine = newPlayer.PlayerJob.Medicine;
        newPlayer.Nature = newPlayer.PlayerJob.Nature;
        newPlayer.Perception = newPlayer.PlayerJob.Perception;
        newPlayer.Performance = newPlayer.PlayerJob.Performance;
        newPlayer.Persuasion = newPlayer.PlayerJob.Persuasion;
        newPlayer.Religion = newPlayer.PlayerJob.Religion;
        newPlayer.SlightOfHand = newPlayer.PlayerJob.SlightOfHand;
        newPlayer.Stealth = newPlayer.PlayerJob.Stealth;
        BackgroundTextDisplay.text = GameInfo.setJobs.ToString();
        UpdateUI();
    }

    public void SetScoutJob()
    {
        jobPointstoSpend = 5;
        newPlayer.PlayerJob = new BaseScoutJob();
        GameInfo.setJobs = PlayerJobs.Sage;
        newPlayer.Acrobatics = newPlayer.PlayerJob.Acrobatics;
        newPlayer.AnimaHandling = newPlayer.PlayerJob.AnimaHandling;
        newPlayer.Arcana = newPlayer.PlayerJob.Arcana;
        newPlayer.Athletics = newPlayer.PlayerJob.Athletics;
        newPlayer.Deception = newPlayer.PlayerJob.Deception;
        newPlayer.History = newPlayer.PlayerJob.History;
        newPlayer.Insight = newPlayer.PlayerJob.Insight;
        newPlayer.Intimidation = newPlayer.PlayerJob.Intimidation;
        newPlayer.Investigation = newPlayer.PlayerJob.Investigation;
        newPlayer.Medicine = newPlayer.PlayerJob.Medicine;
        newPlayer.Nature = newPlayer.PlayerJob.Nature;
        newPlayer.Perception = newPlayer.PlayerJob.Perception;
        newPlayer.Performance = newPlayer.PlayerJob.Performance;
        newPlayer.Persuasion = newPlayer.PlayerJob.Persuasion;
        newPlayer.Religion = newPlayer.PlayerJob.Religion;
        newPlayer.SlightOfHand = newPlayer.PlayerJob.SlightOfHand;
        newPlayer.Stealth = newPlayer.PlayerJob.Stealth;
        BackgroundTextDisplay.text = GameInfo.setJobs.ToString();
        UpdateUI();
    }

    public void SetAssassinJob()
    {
        jobPointstoSpend = 5;
        newPlayer.PlayerJob = new RecoveringAssassinBackground();
        GameInfo.setJobs = PlayerJobs.RecoveringAssassin;
        newPlayer.Acrobatics = newPlayer.PlayerJob.Acrobatics;
        newPlayer.AnimaHandling = newPlayer.PlayerJob.AnimaHandling;
        newPlayer.Arcana = newPlayer.PlayerJob.Arcana;
        newPlayer.Athletics = newPlayer.PlayerJob.Athletics;
        newPlayer.Deception = newPlayer.PlayerJob.Deception;
        newPlayer.History = newPlayer.PlayerJob.History;
        newPlayer.Insight = newPlayer.PlayerJob.Insight;
        newPlayer.Intimidation = newPlayer.PlayerJob.Intimidation;
        newPlayer.Investigation = newPlayer.PlayerJob.Investigation;
        newPlayer.Medicine = newPlayer.PlayerJob.Medicine;
        newPlayer.Nature = newPlayer.PlayerJob.Nature;
        newPlayer.Perception = newPlayer.PlayerJob.Perception;
        newPlayer.Performance = newPlayer.PlayerJob.Performance;
        newPlayer.Persuasion = newPlayer.PlayerJob.Persuasion;
        newPlayer.Religion = newPlayer.PlayerJob.Religion;
        newPlayer.SlightOfHand = newPlayer.PlayerJob.SlightOfHand;
        newPlayer.Stealth = newPlayer.PlayerJob.Stealth;
        BackgroundTextDisplay.text = GameInfo.setJobs.ToString();
        UpdateUI();
    }

    public void SetBrawlerJob()
    {
        jobPointstoSpend = 5;
        newPlayer.PlayerJob = new BaseBrawlerJob();
        GameInfo.setJobs = PlayerJobs.Brawler;
        newPlayer.Acrobatics = newPlayer.PlayerJob.Acrobatics;
        newPlayer.AnimaHandling = newPlayer.PlayerJob.AnimaHandling;
        newPlayer.Arcana = newPlayer.PlayerJob.Arcana;
        newPlayer.Athletics = newPlayer.PlayerJob.Athletics;
        newPlayer.Deception = newPlayer.PlayerJob.Deception;
        newPlayer.History = newPlayer.PlayerJob.History;
        newPlayer.Insight = newPlayer.PlayerJob.Insight;
        newPlayer.Intimidation = newPlayer.PlayerJob.Intimidation;
        newPlayer.Investigation = newPlayer.PlayerJob.Investigation;
        newPlayer.Medicine = newPlayer.PlayerJob.Medicine;
        newPlayer.Nature = newPlayer.PlayerJob.Nature;
        newPlayer.Perception = newPlayer.PlayerJob.Perception;
        newPlayer.Performance = newPlayer.PlayerJob.Performance;
        newPlayer.Persuasion = newPlayer.PlayerJob.Persuasion;
        newPlayer.Religion = newPlayer.PlayerJob.Religion;
        newPlayer.SlightOfHand = newPlayer.PlayerJob.SlightOfHand;
        newPlayer.Stealth = newPlayer.PlayerJob.Stealth;
        BackgroundTextDisplay.text = GameInfo.setJobs.ToString();
        UpdateUI();
    }

    public void SetHopfulDoctor()
    {
        jobPointstoSpend = 5;
        newPlayer.PlayerJob = new HopefulDoctorBackground();
        GameInfo.setJobs = PlayerJobs.HopfulDoctor;
        newPlayer.Acrobatics = newPlayer.PlayerJob.Acrobatics;
        newPlayer.AnimaHandling = newPlayer.PlayerJob.AnimaHandling;
        newPlayer.Arcana = newPlayer.PlayerJob.Arcana;
        newPlayer.Athletics = newPlayer.PlayerJob.Athletics;
        newPlayer.Deception = newPlayer.PlayerJob.Deception;
        newPlayer.History = newPlayer.PlayerJob.History;
        newPlayer.Insight = newPlayer.PlayerJob.Insight;
        newPlayer.Intimidation = newPlayer.PlayerJob.Intimidation;
        newPlayer.Investigation = newPlayer.PlayerJob.Investigation;
        newPlayer.Medicine = newPlayer.PlayerJob.Medicine;
        newPlayer.Nature = newPlayer.PlayerJob.Nature;
        newPlayer.Perception = newPlayer.PlayerJob.Perception;
        newPlayer.Performance = newPlayer.PlayerJob.Performance;
        newPlayer.Persuasion = newPlayer.PlayerJob.Persuasion;
        newPlayer.Religion = newPlayer.PlayerJob.Religion;
        newPlayer.SlightOfHand = newPlayer.PlayerJob.SlightOfHand;
        newPlayer.Stealth = newPlayer.PlayerJob.Stealth;
        BackgroundTextDisplay.text = GameInfo.setJobs.ToString();
        UpdateUI();
    }

    public void SetMaraderJob()
    {
        jobPointstoSpend = 5;
        newPlayer.PlayerJob = new BaseMaraderJob();
        GameInfo.setJobs = PlayerJobs.Marader;
        newPlayer.Acrobatics = newPlayer.PlayerJob.Acrobatics;
        newPlayer.AnimaHandling = newPlayer.PlayerJob.AnimaHandling;
        newPlayer.Arcana = newPlayer.PlayerJob.Arcana;
        newPlayer.Athletics = newPlayer.PlayerJob.Athletics;
        newPlayer.Deception = newPlayer.PlayerJob.Deception;
        newPlayer.History = newPlayer.PlayerJob.History;
        newPlayer.Insight = newPlayer.PlayerJob.Insight;
        newPlayer.Intimidation = newPlayer.PlayerJob.Intimidation;
        newPlayer.Investigation = newPlayer.PlayerJob.Investigation;
        newPlayer.Medicine = newPlayer.PlayerJob.Medicine;
        newPlayer.Nature = newPlayer.PlayerJob.Nature;
        newPlayer.Perception = newPlayer.PlayerJob.Perception;
        newPlayer.Performance = newPlayer.PlayerJob.Performance;
        newPlayer.Persuasion = newPlayer.PlayerJob.Persuasion;
        newPlayer.Religion = newPlayer.PlayerJob.Religion;
        newPlayer.SlightOfHand = newPlayer.PlayerJob.SlightOfHand;
        newPlayer.Stealth = newPlayer.PlayerJob.Stealth;
        BackgroundTextDisplay.text = GameInfo.setJobs.ToString();
        UpdateUI();
    }

    public void SetSocialSJob()
    {
        jobPointstoSpend = 5;
        newPlayer.PlayerJob = new ExcomunicatedPolitionBackground();
        GameInfo.setJobs = PlayerJobs.ExcomunicatedPolition;
        newPlayer.Acrobatics = newPlayer.PlayerJob.Acrobatics;
        newPlayer.AnimaHandling = newPlayer.PlayerJob.AnimaHandling;
        newPlayer.Arcana = newPlayer.PlayerJob.Arcana;
        newPlayer.Athletics = newPlayer.PlayerJob.Athletics;
        newPlayer.Deception = newPlayer.PlayerJob.Deception;
        newPlayer.History = newPlayer.PlayerJob.History;
        newPlayer.Insight = newPlayer.PlayerJob.Insight;
        newPlayer.Intimidation = newPlayer.PlayerJob.Intimidation;
        newPlayer.Investigation = newPlayer.PlayerJob.Investigation;
        newPlayer.Medicine = newPlayer.PlayerJob.Medicine;
        newPlayer.Nature = newPlayer.PlayerJob.Nature;
        newPlayer.Perception = newPlayer.PlayerJob.Perception;
        newPlayer.Performance = newPlayer.PlayerJob.Performance;
        newPlayer.Persuasion = newPlayer.PlayerJob.Persuasion;
        newPlayer.Religion = newPlayer.PlayerJob.Religion;
        newPlayer.SlightOfHand = newPlayer.PlayerJob.SlightOfHand;
        newPlayer.Stealth = newPlayer.PlayerJob.Stealth;
        BackgroundTextDisplay.text = GameInfo.setJobs.ToString();
        UpdateUI();
    }

    public void SetPotionMixerJob()
    {
        jobPointstoSpend = 5;
        newPlayer.PlayerJob = new BasePotionMixerJob();
        GameInfo.setJobs = PlayerJobs.PotionMixer;
        newPlayer.Acrobatics = newPlayer.PlayerJob.Acrobatics;
        newPlayer.AnimaHandling = newPlayer.PlayerJob.AnimaHandling;
        newPlayer.Arcana = newPlayer.PlayerJob.Arcana;
        newPlayer.Athletics = newPlayer.PlayerJob.Athletics;
        newPlayer.Deception = newPlayer.PlayerJob.Deception;
        newPlayer.History = newPlayer.PlayerJob.History;
        newPlayer.Insight = newPlayer.PlayerJob.Insight;
        newPlayer.Intimidation = newPlayer.PlayerJob.Intimidation;
        newPlayer.Investigation = newPlayer.PlayerJob.Investigation;
        newPlayer.Medicine = newPlayer.PlayerJob.Medicine;
        newPlayer.Nature = newPlayer.PlayerJob.Nature;
        newPlayer.Perception = newPlayer.PlayerJob.Perception;
        newPlayer.Performance = newPlayer.PlayerJob.Performance;
        newPlayer.Persuasion = newPlayer.PlayerJob.Persuasion;
        newPlayer.Religion = newPlayer.PlayerJob.Religion;
        newPlayer.SlightOfHand = newPlayer.PlayerJob.SlightOfHand;
        newPlayer.Stealth = newPlayer.PlayerJob.Stealth;
        BackgroundTextDisplay.text = GameInfo.setJobs.ToString();
        UpdateUI();
    }
    #endregion

    #region Races
    public void SetDwarfRace()
    {
        newPlayer.PlayerRace = new Dwarf();
        GameInfo.setRace = PlayerRace.Dwarf;
        newPlayer.strRacebounes = newPlayer.PlayerRace.StrRacebounes;
        newPlayer.dexRacebounes = newPlayer.PlayerRace.DexRacebounes;
        newPlayer.conRacebounes = newPlayer.PlayerRace.ConRacebounes;
        newPlayer.intRacebounes = newPlayer.PlayerRace.IntRacebounes;
        newPlayer.wisRacebounes = newPlayer.PlayerRace.WisRacebounes;
        newPlayer.chrRacebounes = newPlayer.PlayerRace.ChrRacebounes;

        newPlayer.PlayerHight = 111;
        newPlayer.PlayerWeight = 115;
        UpdateUI();
    }

    public void SetHillDwarfRace()
    {
        newPlayer.PlayerRace = new HillDwarf();
        GameInfo.setRace = PlayerRace.HillDwarf;
        newPlayer.strRacebounes = newPlayer.PlayerRace.StrRacebounes;
        newPlayer.dexRacebounes = newPlayer.PlayerRace.DexRacebounes;
        newPlayer.conRacebounes = newPlayer.PlayerRace.ConRacebounes;
        newPlayer.intRacebounes = newPlayer.PlayerRace.IntRacebounes;
        newPlayer.wisRacebounes = newPlayer.PlayerRace.WisRacebounes;
        newPlayer.chrRacebounes = newPlayer.PlayerRace.ChrRacebounes;

        newPlayer.PlayerHight = 111;
        newPlayer.PlayerWeight = 115;
        UpdateUI();
    }

    public void SetMountainDwarfRace()
    {
        newPlayer.PlayerRace = new MountainDwarf();
        GameInfo.setRace = PlayerRace.MountainDwarf;
        newPlayer.strRacebounes = newPlayer.PlayerRace.StrRacebounes;
        newPlayer.dexRacebounes = newPlayer.PlayerRace.DexRacebounes;
        newPlayer.conRacebounes = newPlayer.PlayerRace.ConRacebounes;
        newPlayer.intRacebounes = newPlayer.PlayerRace.IntRacebounes;
        newPlayer.wisRacebounes = newPlayer.PlayerRace.WisRacebounes;
        newPlayer.chrRacebounes = newPlayer.PlayerRace.ChrRacebounes;

        newPlayer.PlayerHight = 113;
        newPlayer.PlayerWeight = 130;
        UpdateUI();
    }

    public void SetElfRace()
    {
        newPlayer.PlayerRace = new Elf();
        GameInfo.setRace = PlayerRace.Elf;
        newPlayer.strRacebounes = newPlayer.PlayerRace.StrRacebounes;
        newPlayer.dexRacebounes = newPlayer.PlayerRace.DexRacebounes;
        newPlayer.conRacebounes = newPlayer.PlayerRace.ConRacebounes;
        newPlayer.intRacebounes = newPlayer.PlayerRace.IntRacebounes;
        newPlayer.wisRacebounes = newPlayer.PlayerRace.WisRacebounes;
        newPlayer.chrRacebounes = newPlayer.PlayerRace.ChrRacebounes;

        newPlayer.PlayerHight = 137;
        newPlayer.PlayerWeight = 90;
        UpdateUI();
    }

    public void SetHighElfRace()
    {
        newPlayer.PlayerRace = new HighElf();
        GameInfo.setRace = PlayerRace.HighElf;
        newPlayer.strRacebounes = newPlayer.PlayerRace.StrRacebounes;
        newPlayer.dexRacebounes = newPlayer.PlayerRace.DexRacebounes;
        newPlayer.conRacebounes = newPlayer.PlayerRace.ConRacebounes;
        newPlayer.intRacebounes = newPlayer.PlayerRace.IntRacebounes;
        newPlayer.wisRacebounes = newPlayer.PlayerRace.WisRacebounes;
        newPlayer.chrRacebounes = newPlayer.PlayerRace.ChrRacebounes;

        newPlayer.PlayerHight = 137;
        newPlayer.PlayerWeight = 90;
        UpdateUI();
    }

    public void SetWoodElfRace()
    {
        newPlayer.PlayerRace = new WoodElf();
        GameInfo.setRace = PlayerRace.WoodElf;
        newPlayer.strRacebounes = newPlayer.PlayerRace.StrRacebounes;
        newPlayer.dexRacebounes = newPlayer.PlayerRace.DexRacebounes;
        newPlayer.conRacebounes = newPlayer.PlayerRace.ConRacebounes;
        newPlayer.intRacebounes = newPlayer.PlayerRace.IntRacebounes;
        newPlayer.wisRacebounes = newPlayer.PlayerRace.WisRacebounes;
        newPlayer.chrRacebounes = newPlayer.PlayerRace.ChrRacebounes;

        newPlayer.PlayerHight = 137;
        newPlayer.PlayerWeight = 100;
        UpdateUI();
    }

    public void SetDarkElfRace()
    {
        newPlayer.PlayerRace = new DarkElf();
        GameInfo.setRace = PlayerRace.DarkElf;
        newPlayer.strRacebounes = newPlayer.PlayerRace.StrRacebounes;
        newPlayer.dexRacebounes = newPlayer.PlayerRace.DexRacebounes;
        newPlayer.conRacebounes = newPlayer.PlayerRace.ConRacebounes;
        newPlayer.intRacebounes = newPlayer.PlayerRace.IntRacebounes;
        newPlayer.wisRacebounes = newPlayer.PlayerRace.WisRacebounes;
        newPlayer.chrRacebounes = newPlayer.PlayerRace.ChrRacebounes;
        newPlayer.PlayerHight = 135;
        newPlayer.PlayerWeight = 75;
        UpdateUI();
    }

    public void SetHalflingRace()
    {
        newPlayer.PlayerRace = new Halfling();
        GameInfo.setRace = PlayerRace.Halfling;
        newPlayer.strRacebounes = newPlayer.PlayerRace.StrRacebounes;
        newPlayer.dexRacebounes = newPlayer.PlayerRace.DexRacebounes;
        newPlayer.conRacebounes = newPlayer.PlayerRace.ConRacebounes;
        newPlayer.intRacebounes = newPlayer.PlayerRace.IntRacebounes;
        newPlayer.wisRacebounes = newPlayer.PlayerRace.WisRacebounes;
        newPlayer.chrRacebounes = newPlayer.PlayerRace.ChrRacebounes;

        newPlayer.PlayerHight = 79;
        newPlayer.PlayerWeight = 35;
        UpdateUI();
    }

    public void SetStoutHalflingRace()
    {
        newPlayer.PlayerRace = new StoutHalfling();
        GameInfo.setRace = PlayerRace.StoutHalfling;
        newPlayer.strRacebounes = newPlayer.PlayerRace.StrRacebounes;
        newPlayer.dexRacebounes = newPlayer.PlayerRace.DexRacebounes;
        newPlayer.conRacebounes = newPlayer.PlayerRace.ConRacebounes;
        newPlayer.intRacebounes = newPlayer.PlayerRace.IntRacebounes;
        newPlayer.wisRacebounes = newPlayer.PlayerRace.WisRacebounes;
        newPlayer.chrRacebounes = newPlayer.PlayerRace.ChrRacebounes;

        newPlayer.PlayerHight = 79;
        newPlayer.PlayerWeight = 35;
        UpdateUI();
    }

    public void SetLightfootHalflingRace()
    {
        newPlayer.PlayerRace = new LightFootHalfLing();
        GameInfo.setRace = PlayerRace.LightFootHalfling;
        newPlayer.strRacebounes = newPlayer.PlayerRace.StrRacebounes;
        newPlayer.dexRacebounes = newPlayer.PlayerRace.DexRacebounes;
        newPlayer.conRacebounes = newPlayer.PlayerRace.ConRacebounes;
        newPlayer.intRacebounes = newPlayer.PlayerRace.IntRacebounes;
        newPlayer.wisRacebounes = newPlayer.PlayerRace.WisRacebounes;
        newPlayer.chrRacebounes = newPlayer.PlayerRace.ChrRacebounes;

        newPlayer.PlayerHight = 79;
        newPlayer.PlayerWeight = 35;
        UpdateUI();
    }

    public void SetHumanRace()
    {
        newPlayer.PlayerRace = new Human();
        GameInfo.setRace = PlayerRace.Human;
        newPlayer.strRacebounes = newPlayer.PlayerRace.StrRacebounes;
        newPlayer.dexRacebounes = newPlayer.PlayerRace.DexRacebounes;
        newPlayer.conRacebounes = newPlayer.PlayerRace.ConRacebounes;
        newPlayer.intRacebounes = newPlayer.PlayerRace.IntRacebounes;
        newPlayer.wisRacebounes = newPlayer.PlayerRace.WisRacebounes;
        newPlayer.chrRacebounes = newPlayer.PlayerRace.ChrRacebounes;

        newPlayer.PlayerHight = 142;
        newPlayer.PlayerWeight = 110;
        UpdateUI();
    }

    public void SetDragonbornRace()
    {
        newPlayer.PlayerRace = new DragonBorn();
        GameInfo.setRace = PlayerRace.Dragonborn;
        newPlayer.strRacebounes = newPlayer.PlayerRace.StrRacebounes;
        newPlayer.dexRacebounes = newPlayer.PlayerRace.DexRacebounes;
        newPlayer.conRacebounes = newPlayer.PlayerRace.ConRacebounes;
        newPlayer.intRacebounes = newPlayer.PlayerRace.IntRacebounes;
        newPlayer.wisRacebounes = newPlayer.PlayerRace.WisRacebounes;
        newPlayer.chrRacebounes = newPlayer.PlayerRace.ChrRacebounes;

        newPlayer.PlayerHight = 168;
        newPlayer.PlayerWeight = 175;
        UpdateUI();
    }

    public void SetGnomeRace()
    {
        newPlayer.PlayerRace = new Gnome();
        GameInfo.setRace = PlayerRace.Gnome;
        newPlayer.strRacebounes = newPlayer.PlayerRace.StrRacebounes;
        newPlayer.dexRacebounes = newPlayer.PlayerRace.DexRacebounes;
        newPlayer.conRacebounes = newPlayer.PlayerRace.ConRacebounes;
        newPlayer.intRacebounes = newPlayer.PlayerRace.IntRacebounes;
        newPlayer.wisRacebounes = newPlayer.PlayerRace.WisRacebounes;
        newPlayer.chrRacebounes = newPlayer.PlayerRace.ChrRacebounes;

        newPlayer.PlayerHight = 89;
        newPlayer.PlayerWeight = 35;
        UpdateUI();
    }

    public void SetForestGnomeRace()
    {
        newPlayer.PlayerRace = new ForestGnome();
        GameInfo.setRace = PlayerRace.ForestGnome;
        newPlayer.strRacebounes = newPlayer.PlayerRace.StrRacebounes;
        newPlayer.dexRacebounes = newPlayer.PlayerRace.DexRacebounes;
        newPlayer.conRacebounes = newPlayer.PlayerRace.ConRacebounes;
        newPlayer.intRacebounes = newPlayer.PlayerRace.IntRacebounes;
        newPlayer.wisRacebounes = newPlayer.PlayerRace.WisRacebounes;
        newPlayer.chrRacebounes = newPlayer.PlayerRace.ChrRacebounes;

        newPlayer.PlayerHight = 89;
        newPlayer.PlayerWeight = 35;
        UpdateUI();
    }

    public void SetRockGnomeRace()
    {
        newPlayer.PlayerRace = new RockGnome();
        GameInfo.setRace = PlayerRace.RockGnome;
        newPlayer.strRacebounes = newPlayer.PlayerRace.StrRacebounes;
        newPlayer.dexRacebounes = newPlayer.PlayerRace.DexRacebounes;
        newPlayer.conRacebounes = newPlayer.PlayerRace.ConRacebounes;
        newPlayer.intRacebounes = newPlayer.PlayerRace.IntRacebounes;
        newPlayer.wisRacebounes = newPlayer.PlayerRace.WisRacebounes;
        newPlayer.chrRacebounes = newPlayer.PlayerRace.ChrRacebounes;

        newPlayer.PlayerHight = 89;
        newPlayer.PlayerWeight = 35;
        UpdateUI();
    }

    public void SetHalfElfRace()
    {
        newPlayer.PlayerRace = new HalfElf();
        GameInfo.setRace = PlayerRace.HalfElf;
        newPlayer.strRacebounes = newPlayer.PlayerRace.StrRacebounes;
        newPlayer.dexRacebounes = newPlayer.PlayerRace.DexRacebounes;
        newPlayer.conRacebounes = newPlayer.PlayerRace.ConRacebounes;
        newPlayer.intRacebounes = newPlayer.PlayerRace.IntRacebounes;
        newPlayer.wisRacebounes = newPlayer.PlayerRace.WisRacebounes;
        newPlayer.chrRacebounes = newPlayer.PlayerRace.ChrRacebounes;

        newPlayer.PlayerHight = 145;
        newPlayer.PlayerWeight = 110;
        UpdateUI();
    }

    public void SetHalfOrcRace()
    {
        newPlayer.PlayerRace = new HalfOrc();
        GameInfo.setRace = PlayerRace.HalfOrc;
        newPlayer.strRacebounes = newPlayer.PlayerRace.StrRacebounes;
        newPlayer.dexRacebounes = newPlayer.PlayerRace.DexRacebounes;
        newPlayer.conRacebounes = newPlayer.PlayerRace.ConRacebounes;
        newPlayer.intRacebounes = newPlayer.PlayerRace.IntRacebounes;
        newPlayer.wisRacebounes = newPlayer.PlayerRace.WisRacebounes;
        newPlayer.chrRacebounes = newPlayer.PlayerRace.ChrRacebounes;

        newPlayer.PlayerHight = 147;
        newPlayer.PlayerWeight = 140;
        UpdateUI();
    }

    public void SetTieflingRace()
    {
        newPlayer.PlayerRace = new Tiefling();
        GameInfo.setRace = PlayerRace.Tiefling;
        newPlayer.strRacebounes = newPlayer.PlayerRace.StrRacebounes;
        newPlayer.dexRacebounes = newPlayer.PlayerRace.DexRacebounes;
        newPlayer.conRacebounes = newPlayer.PlayerRace.ConRacebounes;
        newPlayer.intRacebounes = newPlayer.PlayerRace.IntRacebounes;
        newPlayer.wisRacebounes = newPlayer.PlayerRace.WisRacebounes;
        newPlayer.chrRacebounes = newPlayer.PlayerRace.ChrRacebounes;

        newPlayer.PlayerHight = 145;
        newPlayer.PlayerWeight = 110;
        UpdateUI();
    }
    #endregion

    void UpdateUI()
    {
        strengthText.text = newPlayer.Strength.ToString();
        dexterityText.text = newPlayer.Dexterity.ToString();
        constitutionText.text = newPlayer.Constitution.ToString();        
        intelligenceText.text = newPlayer.Intelligence.ToString();        
        wisdomText.text = newPlayer.Wisdom.ToString();        
        charismaText.text = newPlayer.Charisma.ToString();

        pointsText.text = pointsToSpend.ToString();

        acrobaticsText.text = newPlayer.Acrobatics.ToString();
        animalHandelingText.text = newPlayer.AnimaHandling.ToString();
        arcanaText.text = newPlayer.Arcana.ToString();
        athleticsText.text = newPlayer.Athletics.ToString();
        deceptionText.text = newPlayer.Deception.ToString();
        historyText.text = newPlayer.History.ToString();
        insightText.text = newPlayer.Insight.ToString();
        intimidationText.text = newPlayer.Intimidation.ToString();
        investigationText.text = newPlayer.Investigation.ToString();
        medicineText.text = newPlayer.Medicine.ToString();
        natureText.text = newPlayer.Nature.ToString();
        perceptionText.text = newPlayer.Perception.ToString();
        performanceText.text = newPlayer.Performance.ToString();
        persuasionText.text = newPlayer.Persuasion.ToString();
        religionText.text = newPlayer.Religion.ToString();
        slightOfHandText.text = newPlayer.SlightOfHand.ToString();
        stealthText.text = newPlayer.Stealth.ToString();
        survivalText.text = newPlayer.Survival.ToString();

        jobPointsText.text = jobPointstoSpend.ToString();

        HeightTextDisplay.text = "" + newPlayer.PlayerHight;
        WeightTextDisplay.text = "" + newPlayer.PlayerWeight;

        RaceTextDisplay.text = newPlayer.PlayerRace.ToString();
        //ClassTextDisplay.text = GameInfo.setClass.ToString();
        //BackgroundTextDisplay.text = GameInfo.setJobs.ToString();

        foreach (TextMeshProUGUI cc in strmodtext)
        {
            cc.text = newPlayer.strMod.ToString();
        }

        foreach (TextMeshProUGUI cc in dexmodtext)
        {
            cc.text = newPlayer.dexMod.ToString();
        }

        foreach (TextMeshProUGUI cc in conmodtext)
        {
            cc.text = newPlayer.conMod.ToString();
        }
        
        foreach (TextMeshProUGUI cc in intmodtext)
        {
            cc.text = newPlayer.intMod.ToString();
        }
        
        foreach (TextMeshProUGUI cc in wismodtext)
        {
            cc.text = newPlayer.wisMod.ToString();
        }
        
        foreach (TextMeshProUGUI cc in chrmodtext)
        {
            cc.text = newPlayer.chrMod.ToString();
        }
    }

    #region SetStats
    public void SetStrength(int amount)
    {
        if (newPlayer.PlayerClass != null || newPlayer.PlayerRace != null)
        {
            if (amount > 0 && pointsToSpend > 0)
            {
                newPlayer.Strength += amount;
                pointsToSpend -= 1;
                UpdateUI();
                switch (newPlayer.Strength)
                {
                    case 0:
                        newPlayer.strMod = -5;
                        break;
                    case 1:
                        newPlayer.strMod = -5;
                        break;
                    case 2:
                        newPlayer.strMod = -4;
                        break;
                    case 3:
                        newPlayer.strMod = -4;
                        break;
                    case 4:
                        newPlayer.strMod = -3;
                        break;
                    case 5:
                        newPlayer.strMod = -3;
                        break;
                    case 6:
                        newPlayer.strMod = -2;
                        break;
                    case 7:
                        newPlayer.strMod = -2;
                        break;
                    case 8:
                        newPlayer.strMod = -1;
                        break;
                    case 9:
                        newPlayer.strMod = -1;
                        break;
                    case 10:
                        newPlayer.strMod = 0;
                        break;
                    case 11:
                        newPlayer.strMod = 0;
                        break;
                    case 12:
                        newPlayer.strMod = 1;
                        break;
                    case 13:
                        newPlayer.strMod = 1;
                        break;
                    case 14:
                        newPlayer.strMod = 2;
                        break;
                    case 15:
                        newPlayer.strMod = 2;
                        break;
                    case 16:
                        newPlayer.strMod = 3;
                        break;
                    case 17:
                        newPlayer.strMod = 3;
                        break;
                    case 18:
                        newPlayer.strMod = 4;
                        break;
                    case 19:
                        newPlayer.strMod = 4;
                        break;
                    case 20:
                        newPlayer.strMod = 5;
                        break;
                    case 21:
                        newPlayer.strMod = 5;
                        break;
                    case 22:
                        newPlayer.strMod = 6;
                        break;
                    case 23:
                        newPlayer.strMod = 6;
                        break;
                    case 24:
                        newPlayer.strMod = 7;
                        break;
                    case 25:
                        newPlayer.strMod = 7;
                        break;
                    case 26:
                        newPlayer.strMod = 8;
                        break;
                    case 27:
                        newPlayer.strMod = 8;
                        break;
                    case 28:
                        newPlayer.strMod = 9;
                        break;
                    case 29:
                        newPlayer.strMod = 9;
                        break;
                    case 30:
                        newPlayer.strMod = 10;
                        newPlayer.Strength = 30;
                        break;
                }
            }
            else if (amount < 0 && newPlayer.Strength > newPlayer.PlayerClass.Strength)
            {
                newPlayer.Strength += amount;
                pointsToSpend += 1;
                UpdateUI();

                switch (newPlayer.Strength)
                {
                    case 0:
                        newPlayer.strMod = -5;
                        break;
                    case 1:
                        newPlayer.strMod = -5;
                        break;
                    case 2:
                        newPlayer.strMod = -4;
                        break;
                    case 3:
                        newPlayer.strMod = -4;
                        break;
                    case 4:
                        newPlayer.strMod = -3;
                        break;
                    case 5:
                        newPlayer.strMod = -3;
                        break;
                    case 6:
                        newPlayer.strMod = -2;
                        break;
                    case 7:
                        newPlayer.strMod = -2;
                        break;
                    case 8:
                        newPlayer.strMod = -1;
                        break;
                    case 9:
                        newPlayer.strMod = -1;
                        break;
                    case 10:
                        newPlayer.strMod = 0;
                        break;
                    case 11:
                        newPlayer.strMod = 0;
                        break;
                    case 12:
                        newPlayer.strMod = 1;
                        break;
                    case 13:
                        newPlayer.strMod = 1;
                        break;
                    case 14:
                        newPlayer.strMod = 2;
                        break;
                    case 15:
                        newPlayer.strMod = 2;
                        break;
                    case 16:
                        newPlayer.strMod = 3;
                        break;
                    case 17:
                        newPlayer.strMod = 3;
                        break;
                    case 18:
                        newPlayer.strMod = 4;
                        break;
                    case 19:
                        newPlayer.strMod = 4;
                        break;
                    case 20:
                        newPlayer.strMod = 5;
                        break;
                    case 21:
                        newPlayer.strMod = 5;
                        break;
                    case 22:
                        newPlayer.strMod = 6;
                        break;
                    case 23:
                        newPlayer.strMod = 6;
                        break;
                    case 24:
                        newPlayer.strMod = 7;
                        break;
                    case 25:
                        newPlayer.strMod = 7;
                        break;
                    case 26:
                        newPlayer.strMod = 8;
                        break;
                    case 27:
                        newPlayer.strMod = 8;
                        break;
                    case 28:
                        newPlayer.strMod = 9;
                        break;
                    case 29:
                        newPlayer.strMod = 9;
                        break;
                    case 30:
                        newPlayer.strMod = 10;
                        newPlayer.Strength = 30;
                        break;
                }
            }
        }
        else
        {
            Debug.Log("No Class Chosen");
        }
    }

    public void SetDexterity(int amount)
    {
        if (newPlayer.PlayerClass != null || newPlayer.PlayerRace != null)
        {
            if (amount > 0 && pointsToSpend > 0)
            {
                newPlayer.Dexterity += amount;
                pointsToSpend -= 1;
                UpdateUI();

                switch (newPlayer.Dexterity)
                {
                    case 0:
                        newPlayer.dexMod = -5;
                        break;
                    case 1:
                        newPlayer.dexMod = -5;
                        break;
                    case 2:
                        newPlayer.dexMod = -4;
                        break;
                    case 3:
                        newPlayer.dexMod = -4;
                        break;
                    case 4:
                        newPlayer.dexMod = -3;
                        break;
                    case 5:
                        newPlayer.dexMod = -3;
                        break;
                    case 6:
                        newPlayer.dexMod = -2;
                        break;
                    case 7:
                        newPlayer.dexMod = -2;
                        break;
                    case 8:
                        newPlayer.dexMod = -1;
                        break;
                    case 9:
                        newPlayer.dexMod = -1;
                        break;
                    case 10:
                        newPlayer.dexMod = 0;
                        break;
                    case 11:
                        newPlayer.dexMod = 0;
                        break;
                    case 12:
                        newPlayer.dexMod = 1;
                        break;
                    case 13:
                        newPlayer.dexMod = 1;
                        break;
                    case 14:
                        newPlayer.dexMod = 2;
                        break;
                    case 15:
                        newPlayer.dexMod = 2;
                        break;
                    case 16:
                        newPlayer.dexMod = 3;
                        break;
                    case 17:
                        newPlayer.dexMod = 3;
                        break;
                    case 18:
                        newPlayer.dexMod = 4;
                        break;
                    case 19:
                        newPlayer.dexMod = 4;
                        break;
                    case 20:
                        newPlayer.dexMod = 5;
                        break;
                    case 21:
                        newPlayer.dexMod = 5;
                        break;
                    case 22:
                        newPlayer.dexMod = 6;
                        break;
                    case 23:
                        newPlayer.dexMod = 6;
                        break;
                    case 24:
                        newPlayer.dexMod = 7;
                        break;
                    case 25:
                        newPlayer.dexMod = 7;
                        break;
                    case 26:
                        newPlayer.dexMod = 8;
                        break;
                    case 27:
                        newPlayer.dexMod = 8;
                        break;
                    case 28:
                        newPlayer.dexMod = 9;
                        break;
                    case 29:
                        newPlayer.dexMod = 9;
                        break;
                    case 30:
                        newPlayer.dexMod = 10;
                        newPlayer.Dexterity = 30;
                        break;
                }
            }
            else if (amount < 0 && newPlayer.Dexterity > newPlayer.PlayerClass.Dexterity)
            {
                newPlayer.Dexterity += amount;
                pointsToSpend += 1;
                UpdateUI();

                switch (newPlayer.Dexterity)
                {
                    case 0:
                        newPlayer.dexMod = -5;
                        break;
                    case 1:
                        newPlayer.dexMod = -5;
                        break;
                    case 2:
                        newPlayer.dexMod = -4;
                        break;
                    case 3:
                        newPlayer.dexMod = -4;
                        break;
                    case 4:
                        newPlayer.dexMod = -3;
                        break;
                    case 5:
                        newPlayer.dexMod = -3;
                        break;
                    case 6:
                        newPlayer.dexMod = -2;
                        break;
                    case 7:
                        newPlayer.dexMod = -2;
                        break;
                    case 8:
                        newPlayer.dexMod = -1;
                        break;
                    case 9:
                        newPlayer.dexMod = -1;
                        break;
                    case 10:
                        newPlayer.dexMod = 0;
                        break;
                    case 11:
                        newPlayer.dexMod = 0;
                        break;
                    case 12:
                        newPlayer.dexMod = 1;
                        break;
                    case 13:
                        newPlayer.dexMod = 1;
                        break;
                    case 14:
                        newPlayer.dexMod = 2;
                        break;
                    case 15:
                        newPlayer.dexMod = 2;
                        break;
                    case 16:
                        newPlayer.dexMod = 3;
                        break;
                    case 17:
                        newPlayer.dexMod = 3;
                        break;
                    case 18:
                        newPlayer.dexMod = 4;
                        break;
                    case 19:
                        newPlayer.dexMod = 4;
                        break;
                    case 20:
                        newPlayer.dexMod = 5;
                        break;
                    case 21:
                        newPlayer.dexMod = 5;
                        break;
                    case 22:
                        newPlayer.dexMod = 6;
                        break;
                    case 23:
                        newPlayer.dexMod = 6;
                        break;
                    case 24:
                        newPlayer.dexMod = 7;
                        break;
                    case 25:
                        newPlayer.dexMod = 7;
                        break;
                    case 26:
                        newPlayer.dexMod = 8;
                        break;
                    case 27:
                        newPlayer.dexMod = 8;
                        break;
                    case 28:
                        newPlayer.dexMod = 9;
                        break;
                    case 29:
                        newPlayer.dexMod = 9;
                        break;
                    case 30:
                        newPlayer.dexMod = 10;
                        newPlayer.Dexterity = 30;
                        break;
                }
            }
        }
        else
        {
            Debug.Log("No Class Chosen");
        }
    }

    public void SetConstitution(int amount)
    {
        if (newPlayer.PlayerClass != null || newPlayer.PlayerRace != null)
        {
            if (amount > 0 && pointsToSpend > 0)
            {
                newPlayer.Constitution += amount;
                pointsToSpend -= 1;
                UpdateUI();

                switch (newPlayer.Constitution)
                {
                    case 0:
                        newPlayer.conMod = -5;
                        break;
                    case 1:
                        newPlayer.conMod = -5;
                        break;
                    case 2:
                        newPlayer.conMod = -4;
                        break;
                    case 3:
                        newPlayer.conMod = -4;
                        break;
                    case 4:
                        newPlayer.conMod = -3;
                        break;
                    case 5:
                        newPlayer.conMod = -3;
                        break;
                    case 6:
                        newPlayer.conMod = -2;
                        break;
                    case 7:
                        newPlayer.conMod = -2;
                        break;
                    case 8:
                        newPlayer.conMod = -1;
                        break;
                    case 9:
                        newPlayer.conMod = -1;
                        break;
                    case 10:
                        newPlayer.conMod = 0;
                        break;
                    case 11:
                        newPlayer.conMod = 0;
                        break;
                    case 12:
                        newPlayer.conMod = 1;
                        break;
                    case 13:
                        newPlayer.conMod = 1;
                        break;
                    case 14:
                        newPlayer.conMod = 2;
                        break;
                    case 15:
                        newPlayer.conMod = 2;
                        break;
                    case 16:
                        newPlayer.conMod = 3;
                        break;
                    case 17:
                        newPlayer.conMod = 3;
                        break;
                    case 18:
                        newPlayer.conMod = 4;
                        break;
                    case 19:
                        newPlayer.conMod = 4;
                        break;
                    case 20:
                        newPlayer.conMod = 5;
                        break;
                    case 21:
                        newPlayer.conMod = 5;
                        break;
                    case 22:
                        newPlayer.conMod = 6;
                        break;
                    case 23:
                        newPlayer.conMod = 6;
                        break;
                    case 24:
                        newPlayer.conMod = 7;
                        break;
                    case 25:
                        newPlayer.conMod = 7;
                        break;
                    case 26:
                        newPlayer.conMod = 8;
                        break;
                    case 27:
                        newPlayer.conMod = 8;
                        break;
                    case 28:
                        newPlayer.conMod = 9;
                        break;
                    case 29:
                        newPlayer.conMod = 9;
                        break;
                    case 30:
                        newPlayer.conMod = 10;
                        newPlayer.Constitution = 30;
                        break;
                }
            }
            else if (amount < 0 && newPlayer.Constitution > newPlayer.PlayerClass.Constitution)
            {
                newPlayer.Constitution += amount;
                pointsToSpend += 1;
                UpdateUI();

                switch (newPlayer.Constitution)
                {
                    case 0:
                        newPlayer.conMod = -5;
                        break;
                    case 1:
                        newPlayer.conMod = -5;
                        break;
                    case 2:
                        newPlayer.conMod = -4;
                        break;
                    case 3:
                        newPlayer.conMod = -4;
                        break;
                    case 4:
                        newPlayer.conMod = -3;
                        break;
                    case 5:
                        newPlayer.conMod = -3;
                        break;
                    case 6:
                        newPlayer.conMod = -2;
                        break;
                    case 7:
                        newPlayer.conMod = -2;
                        break;
                    case 8:
                        newPlayer.conMod = -1;
                        break;
                    case 9:
                        newPlayer.conMod = -1;
                        break;
                    case 10:
                        newPlayer.conMod = 0;
                        break;
                    case 11:
                        newPlayer.conMod = 0;
                        break;
                    case 12:
                        newPlayer.conMod = 1;
                        break;
                    case 13:
                        newPlayer.conMod = 1;
                        break;
                    case 14:
                        newPlayer.conMod = 2;
                        break;
                    case 15:
                        newPlayer.conMod = 2;
                        break;
                    case 16:
                        newPlayer.conMod = 3;
                        break;
                    case 17:
                        newPlayer.conMod = 3;
                        break;
                    case 18:
                        newPlayer.conMod = 4;
                        break;
                    case 19:
                        newPlayer.conMod = 4;
                        break;
                    case 20:
                        newPlayer.conMod = 5;
                        break;
                    case 21:
                        newPlayer.conMod = 5;
                        break;
                    case 22:
                        newPlayer.conMod = 6;
                        break;
                    case 23:
                        newPlayer.conMod = 6;
                        break;
                    case 24:
                        newPlayer.conMod = 7;
                        break;
                    case 25:
                        newPlayer.conMod = 7;
                        break;
                    case 26:
                        newPlayer.conMod = 8;
                        break;
                    case 27:
                        newPlayer.conMod = 8;
                        break;
                    case 28:
                        newPlayer.conMod = 9;
                        break;
                    case 29:
                        newPlayer.conMod = 9;
                        break;
                    case 30:
                        newPlayer.conMod = 10;
                        newPlayer.Constitution = 30;
                        break;
                }
            }
            else
            {
                Debug.Log("No Class Chosen");
            }
        }
    }

    public void SetIntelligence(int amount)
    {
        if (newPlayer.PlayerClass != null || newPlayer.PlayerRace != null)
        {
            if (amount > 0 && pointsToSpend > 0)
            {
                newPlayer.Intelligence += amount;
                pointsToSpend -= 1;
                UpdateUI();

                switch (newPlayer.Intelligence)
                {
                    case 0:
                        newPlayer.intMod = -5;
                        break;
                    case 1:
                        newPlayer.intMod = -5;
                        break;
                    case 2:
                        newPlayer.intMod = -4;
                        break;
                    case 3:
                        newPlayer.intMod = -4;
                        break;
                    case 4:
                        newPlayer.intMod = -3;
                        break;
                    case 5:
                        newPlayer.intMod = -3;
                        break;
                    case 6:
                        newPlayer.intMod = -2;
                        break;
                    case 7:
                        newPlayer.intMod = -2;
                        break;
                    case 8:
                        newPlayer.intMod = -1;
                        break;
                    case 9:
                        newPlayer.intMod = -1;
                        break;
                    case 10:
                        newPlayer.intMod = 0;
                        break;
                    case 11:
                        newPlayer.intMod = 0;
                        break;
                    case 12:
                        newPlayer.intMod = 1;
                        break;
                    case 13:
                        newPlayer.intMod = 1;
                        break;
                    case 14:
                        newPlayer.intMod = 2;
                        break;
                    case 15:
                        newPlayer.intMod = 2;
                        break;
                    case 16:
                        newPlayer.intMod = 3;
                        break;
                    case 17:
                        newPlayer.intMod = 3;
                        break;
                    case 18:
                        newPlayer.intMod = 4;
                        break;
                    case 19:
                        newPlayer.intMod = 4;
                        break;
                    case 20:
                        newPlayer.intMod = 5;
                        break;
                    case 21:
                        newPlayer.intMod = 5;
                        break;
                    case 22:
                        newPlayer.intMod = 6;
                        break;
                    case 23:
                        newPlayer.intMod = 6;
                        break;
                    case 24:
                        newPlayer.intMod = 7;
                        break;
                    case 25:
                        newPlayer.intMod = 7;
                        break;
                    case 26:
                        newPlayer.intMod = 8;
                        break;
                    case 27:
                        newPlayer.intMod = 8;
                        break;
                    case 28:
                        newPlayer.intMod = 9;
                        break;
                    case 29:
                        newPlayer.intMod = 9;
                        break;
                    case 30:
                        newPlayer.intMod = 10;
                        newPlayer.Intelligence = 30;
                        break;
                }
            }
            else if (amount < 0 && newPlayer.Intelligence > newPlayer.PlayerClass.Intelligence)
            {
                newPlayer.Intelligence += amount;
                pointsToSpend += 1;
                UpdateUI();

                switch (newPlayer.Intelligence)
                {
                    case 0:
                        newPlayer.intMod = -5;
                        break;
                    case 1:
                        newPlayer.intMod = -5;
                        break;
                    case 2:
                        newPlayer.intMod = -4;
                        break;
                    case 3:
                        newPlayer.intMod = -4;
                        break;
                    case 4:
                        newPlayer.intMod = -3;
                        break;
                    case 5:
                        newPlayer.intMod = -3;
                        break;
                    case 6:
                        newPlayer.intMod = -2;
                        break;
                    case 7:
                        newPlayer.intMod = -2;
                        break;
                    case 8:
                        newPlayer.intMod = -1;
                        break;
                    case 9:
                        newPlayer.intMod = -1;
                        break;
                    case 10:
                        newPlayer.intMod = 0;
                        break;
                    case 11:
                        newPlayer.intMod = 0;
                        break;
                    case 12:
                        newPlayer.intMod = 1;
                        break;
                    case 13:
                        newPlayer.intMod = 1;
                        break;
                    case 14:
                        newPlayer.intMod = 2;
                        break;
                    case 15:
                        newPlayer.intMod = 2;
                        break;
                    case 16:
                        newPlayer.intMod = 3;
                        break;
                    case 17:
                        newPlayer.intMod = 3;
                        break;
                    case 18:
                        newPlayer.intMod = 4;
                        break;
                    case 19:
                        newPlayer.intMod = 4;
                        break;
                    case 20:
                        newPlayer.intMod = 5;
                        break;
                    case 21:
                        newPlayer.intMod = 5;
                        break;
                    case 22:
                        newPlayer.intMod = 6;
                        break;
                    case 23:
                        newPlayer.intMod = 6;
                        break;
                    case 24:
                        newPlayer.intMod = 7;
                        break;
                    case 25:
                        newPlayer.intMod = 7;
                        break;
                    case 26:
                        newPlayer.intMod = 8;
                        break;
                    case 27:
                        newPlayer.intMod = 8;
                        break;
                    case 28:
                        newPlayer.intMod = 9;
                        break;
                    case 29:
                        newPlayer.intMod = 9;
                        break;
                    case 30:
                        newPlayer.intMod = 10;
                        newPlayer.Intelligence = 30;
                        break;
                }
            }
            else
            {
                Debug.Log("No Class Chosen");
            }
        }
    }

    public void SetWisdom(int amount)
    {
        if (newPlayer.PlayerClass != null || newPlayer.PlayerRace != null)
        {
            if (amount > 0 && pointsToSpend > 0)
            {
                newPlayer.Wisdom += amount;
                pointsToSpend -= 1;
                UpdateUI();

                switch (newPlayer.Wisdom)
        {
            case 0:
                newPlayer.wisMod = -5;
                break;
            case 1:
                newPlayer.wisMod = -5;
                break;
            case 2:
                newPlayer.wisMod = -4;
                break;
            case 3:
                newPlayer.wisMod = -4;
                break;
            case 4:
                newPlayer.wisMod = -3;
                break;
            case 5:
                newPlayer.wisMod = -3;
                break;
            case 6:
                newPlayer.wisMod = -2;
                break;
            case 7:
                newPlayer.wisMod = -2;
                break;
            case 8:
                newPlayer.wisMod = -1;
                break;
            case 9:
                newPlayer.wisMod = -1;
                break;
            case 10:
                newPlayer.wisMod = 0;
                break;
            case 11:
                newPlayer.wisMod = 0;
                break;
            case 12:
                newPlayer.wisMod = 1;
                break;
            case 13:
                newPlayer.wisMod = 1;
                break;
            case 14:
                newPlayer.wisMod = 2;
                break;
            case 15:
                newPlayer.wisMod = 2;
                break;
            case 16:
                newPlayer.wisMod = 3;
                break;
            case 17:
                newPlayer.wisMod = 3;
                break;
            case 18:
                newPlayer.wisMod = 4;
                break;
            case 19:
                newPlayer.wisMod = 4;
                break;
            case 20:
                newPlayer.wisMod = 5;
                break;
            case 21:
                newPlayer.wisMod = 5;
                break;
            case 22:
                newPlayer.wisMod = 6;
                break;
            case 23:
                newPlayer.wisMod = 6;
                break;
            case 24:
                newPlayer.wisMod = 7;
                break;
            case 25:
                newPlayer.wisMod = 7;
                break;
            case 26:
                newPlayer.wisMod = 8;
                break;
            case 27:
                newPlayer.wisMod = 8;
                break;
            case 28:
                newPlayer.wisMod = 9;
                break;
            case 29:
                newPlayer.wisMod = 9;
                break;
            case 30:
                newPlayer.wisMod = 10;
                newPlayer.Wisdom = 30;
                break;
        }
            }
            else if (amount < 0 && newPlayer.Wisdom > newPlayer.PlayerClass.Wisdom)
            {
                newPlayer.Wisdom += amount;
                pointsToSpend += 1;
                UpdateUI();

                switch (newPlayer.Wisdom)
                {
                    case 0:
                        newPlayer.wisMod = -5;
                        break;
                    case 1:
                        newPlayer.wisMod = -5;
                        break;
                    case 2:
                        newPlayer.wisMod = -4;
                        break;
                    case 3:
                        newPlayer.wisMod = -4;
                        break;
                    case 4:
                        newPlayer.wisMod = -3;
                        break;
                    case 5:
                        newPlayer.wisMod = -3;
                        break;
                    case 6:
                        newPlayer.wisMod = -2;
                        break;
                    case 7:
                        newPlayer.wisMod = -2;
                        break;
                    case 8:
                        newPlayer.wisMod = -1;
                        break;
                    case 9:
                        newPlayer.wisMod = -1;
                        break;
                    case 10:
                        newPlayer.wisMod = 0;
                        break;
                    case 11:
                        newPlayer.wisMod = 0;
                        break;
                    case 12:
                        newPlayer.wisMod = 1;
                        break;
                    case 13:
                        newPlayer.wisMod = 1;
                        break;
                    case 14:
                        newPlayer.wisMod = 2;
                        break;
                    case 15:
                        newPlayer.wisMod = 2;
                        break;
                    case 16:
                        newPlayer.wisMod = 3;
                        break;
                    case 17:
                        newPlayer.wisMod = 3;
                        break;
                    case 18:
                        newPlayer.wisMod = 4;
                        break;
                    case 19:
                        newPlayer.wisMod = 4;
                        break;
                    case 20:
                        newPlayer.wisMod = 5;
                        break;
                    case 21:
                        newPlayer.wisMod = 5;
                        break;
                    case 22:
                        newPlayer.wisMod = 6;
                        break;
                    case 23:
                        newPlayer.wisMod = 6;
                        break;
                    case 24:
                        newPlayer.wisMod = 7;
                        break;
                    case 25:
                        newPlayer.wisMod = 7;
                        break;
                    case 26:
                        newPlayer.wisMod = 8;
                        break;
                    case 27:
                        newPlayer.wisMod = 8;
                        break;
                    case 28:
                        newPlayer.wisMod = 9;
                        break;
                    case 29:
                        newPlayer.wisMod = 9;
                        break;
                    case 30:
                        newPlayer.wisMod = 10;
                        newPlayer.Wisdom = 30;
                        break;
                }

            }
            else
            {
                Debug.Log("No Class Chosen");
            }
        }
    }

    public void SetCharisma(int amount)
    {
        if (newPlayer.PlayerClass != null || newPlayer.PlayerRace != null)
        {
            if (amount > 0 && pointsToSpend > 0)
            {
                newPlayer.Charisma += amount;
                pointsToSpend -= 1;
                UpdateUI();

                switch (newPlayer.Charisma)
                {
                    case 0:
                        newPlayer.chrMod = -5;
                        break;
                    case 1:
                        newPlayer.chrMod = -5;
                        break;
                    case 2:
                        newPlayer.chrMod = -4;
                        break;
                    case 3:
                        newPlayer.chrMod = -4;
                        break;
                    case 4:
                        newPlayer.chrMod = -3;
                        break;
                    case 5:
                        newPlayer.chrMod = -3;
                        break;
                    case 6:
                        newPlayer.chrMod = -2;
                        break;
                    case 7:
                        newPlayer.chrMod = -2;
                        break;
                    case 8:
                        newPlayer.chrMod = -1;
                        break;
                    case 9:
                        newPlayer.chrMod = -1;
                        break;
                    case 10:
                        newPlayer.chrMod = 0;
                        break;
                    case 11:
                        newPlayer.chrMod = 0;
                        break;
                    case 12:
                        newPlayer.chrMod = 1;
                        break;
                    case 13:
                        newPlayer.chrMod = 1;
                        break;
                    case 14:
                        newPlayer.chrMod = 2;
                        break;
                    case 15:
                        newPlayer.chrMod = 2;
                        break;
                    case 16:
                        newPlayer.chrMod = 3;
                        break;
                    case 17:
                        newPlayer.chrMod = 3;
                        break;
                    case 18:
                        newPlayer.chrMod = 4;
                        break;
                    case 19:
                        newPlayer.chrMod = 4;
                        break;
                    case 20:
                        newPlayer.chrMod = 5;
                        break;
                    case 21:
                        newPlayer.chrMod = 5;
                        break;
                    case 22:
                        newPlayer.chrMod = 6;
                        break;
                    case 23:
                        newPlayer.chrMod = 6;
                        break;
                    case 24:
                        newPlayer.chrMod = 7;
                        break;
                    case 25:
                        newPlayer.chrMod = 7;
                        break;
                    case 26:
                        newPlayer.chrMod = 8;
                        break;
                    case 27:
                        newPlayer.chrMod = 8;
                        break;
                    case 28:
                        newPlayer.chrMod = 9;
                        break;
                    case 29:
                        newPlayer.chrMod = 9;
                        break;
                    case 30:
                        newPlayer.chrMod = 10;
                        newPlayer.Charisma = 30;
                        break;
                }
            }
            else if (amount < 0 && newPlayer.Charisma > newPlayer.PlayerClass.Charisma)
            {
                newPlayer.Charisma += amount;
                pointsToSpend += 1;
                UpdateUI();

                 switch (newPlayer.Charisma)
        {
            case 0:
                newPlayer.chrMod = -5;
                break;
            case 1:
                newPlayer.chrMod = -5;
                break;
            case 2:
                newPlayer.chrMod = -4;
                break;
            case 3:
                newPlayer.chrMod = -4;
                break;
            case 4:
                newPlayer.chrMod = -3;
                break;
            case 5:
                newPlayer.chrMod = -3;
                break;
            case 6:
                newPlayer.chrMod = -2;
                break;
            case 7:
                newPlayer.chrMod = -2;
                break;
            case 8:
                newPlayer.chrMod = -1;
                break;
            case 9:
                newPlayer.chrMod = -1;
                break;
            case 10:
                newPlayer.chrMod = 0;
                break;
            case 11:
                newPlayer.chrMod = 0;
                break;
            case 12:
                newPlayer.chrMod = 1;
                break;
            case 13:
                newPlayer.chrMod = 1;
                break;
            case 14:
                newPlayer.chrMod = 2;
                break;
            case 15:
                newPlayer.chrMod = 2;
                break;
            case 16:
                newPlayer.chrMod = 3;
                break;
            case 17:
                newPlayer.chrMod = 3;
                break;
            case 18:
                newPlayer.chrMod = 4;
                break;
            case 19:
                newPlayer.chrMod = 4;
                break;
            case 20:
                newPlayer.chrMod = 5;
                break;
            case 21:
                newPlayer.chrMod = 5;
                break;
            case 22:
                newPlayer.chrMod = 6;
                break;
            case 23:
                newPlayer.chrMod = 6;
                break;
            case 24:
                newPlayer.chrMod = 7;
                break;
            case 25:
                newPlayer.chrMod = 7;
                break;
            case 26:
                newPlayer.chrMod = 8;
                break;
            case 27:
                newPlayer.chrMod = 8;
                break;
            case 28:
                newPlayer.chrMod = 9;
                break;
            case 29:
                newPlayer.chrMod = 9;
                break;
            case 30:
                newPlayer.chrMod = 10;
                newPlayer.Charisma = 30;
                break;
        }

            }
            else
            {
                Debug.Log("No Class Chosen");
            }
        }
    }
    #endregion

    #region SetSkills
    public void SetAcrobatics(int amount)
    {
        if (newPlayer.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                newPlayer.Acrobatics += amount;
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && newPlayer.Acrobatics > newPlayer.PlayerJob.Acrobatics)
            {
                newPlayer.Acrobatics += amount;
                jobPointstoSpend += 1;
                UpdateUI();
             
            }
            else
            {
                Debug.Log("No Class Chosen");
            }
        }
    }

    public void SetAnimalHandeling(int amount)
    {
        if (newPlayer.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                newPlayer.AnimaHandling += amount;
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && newPlayer.AnimaHandling > newPlayer.PlayerJob.AnimaHandling)
            {
                newPlayer.AnimaHandling += amount;
                jobPointstoSpend += 1;
                UpdateUI();

            }
            else
            {
                Debug.Log("No Class Chosen");
            }
        }
    }

    public void SetArcana(int amount)
    {
        if (newPlayer.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                newPlayer.Arcana += amount;
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && newPlayer.Arcana > newPlayer.PlayerJob.Arcana)
            {
                newPlayer.Arcana += amount;
                jobPointstoSpend += 1;
                UpdateUI();

            }
            else
            {
                Debug.Log("No Class Chosen");
            }
        }
    }

    public void SetAthletics (int amount)
    {
        if (newPlayer.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                newPlayer.Athletics += amount;
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && newPlayer.Athletics > newPlayer.PlayerJob.Athletics)
            {
                newPlayer.Athletics += amount;
                jobPointstoSpend += 1;
                UpdateUI();

            }
            else
            {
                Debug.Log("No Class Chosen");
            }
        }
    }

    public void SetDeception(int amount)
    {
        if (newPlayer.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                newPlayer.Deception += amount;
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && newPlayer.Deception > newPlayer.PlayerJob.Deception)
            {
                newPlayer.Deception += amount;
                jobPointstoSpend += 1;
                UpdateUI();

            }
            else
            {
                Debug.Log("No Class Chosen");
            }
        }
    }

    public void SetHistory(int amount)
    {
        if (newPlayer.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                newPlayer.History += amount;
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && newPlayer.History > newPlayer.PlayerJob.History)
            {
                newPlayer.History += amount;
                jobPointstoSpend += 1;
                UpdateUI();

            }
            else
            {
                Debug.Log("No Class Chosen");
            }
        }
    }

    public void SetInsight(int amount)
    {
        if (newPlayer.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                newPlayer.Insight += amount;
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && newPlayer.Insight > newPlayer.PlayerJob.Insight)
            {
                newPlayer.Insight += amount;
                jobPointstoSpend += 1;
                UpdateUI();

            }
            else
            {
                Debug.Log("No Class Chosen");
            }
        }
    }

    public void SetIntimidation(int amount)
    {
        if (newPlayer.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                newPlayer.Intimidation += amount;
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && newPlayer.Intimidation > newPlayer.PlayerJob.Intimidation)
            {
                newPlayer.Intimidation += amount;
                jobPointstoSpend += 1;
                UpdateUI();

            }
            else
            {
                Debug.Log("No Class Chosen");
            }
        }
    }

    public void SetInvestigation(int amount)
    {
        if (newPlayer.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                newPlayer.Investigation += amount;
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && newPlayer.Investigation > newPlayer.PlayerJob.Investigation)
            {
                newPlayer.Investigation += amount;
                jobPointstoSpend += 1;
                UpdateUI();

            }
            else
            {
                Debug.Log("No Class Chosen");
            }
        }
    }

    public void SetMedicine(int amount)
    {
        if (newPlayer.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                newPlayer.Medicine += amount;
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && newPlayer.Medicine > newPlayer.PlayerJob.Medicine)
            {
                newPlayer.Medicine
 += amount;
                jobPointstoSpend += 1;
                UpdateUI();

            }
            else
            {
                Debug.Log("No Class Chosen");
            }
        }
    }

    public void SetNature(int amount)
    {
        if (newPlayer.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                newPlayer.Nature += amount;
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && newPlayer.Nature > newPlayer.PlayerJob.Nature)
            {
                newPlayer.Nature += amount;
                jobPointstoSpend += 1;
                UpdateUI();

            }
            else
            {
                Debug.Log("No Class Chosen");
            }
        }
    }

    public void SetPerception(int amount)
    {
        if (newPlayer.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                newPlayer.Perception += amount;
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && newPlayer.Perception > newPlayer.PlayerJob.Perception)
            {
                newPlayer.Perception += amount;
                jobPointstoSpend += 1;
                UpdateUI();

            }
            else
            {
                Debug.Log("No Class Chosen");
            }
        }
    }

    public void SetPerformance(int amount)
    {
        if (newPlayer.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                newPlayer.Performance += amount;
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && newPlayer.Performance > newPlayer.PlayerJob.Performance)
            {
                newPlayer.Performance += amount;
                jobPointstoSpend += 1;
                UpdateUI();

            }
            else
            {
                Debug.Log("No Class Chosen");
            }
        }
    }

    public void SetPersuasion(int amount)
    {
        if (newPlayer.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                newPlayer.Persuasion += amount;
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && newPlayer.Persuasion > newPlayer.PlayerJob.Persuasion)
            {
                newPlayer.Persuasion += amount;
                jobPointstoSpend += 1;
                UpdateUI();

            }
            else
            {
                Debug.Log("No Class Chosen");
            }
        }
    }

    public void SetReligion(int amount)
    {
        if (newPlayer.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                newPlayer.Religion += amount;
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && newPlayer.Religion > newPlayer.PlayerJob.Religion)
            {
                newPlayer.Religion += amount;
                jobPointstoSpend += 1;
                UpdateUI();

            }
            else
            {
                Debug.Log("No Class Chosen");
            }
        }
    }

    public void SetSlightOfHand(int amount)
    {
        if (newPlayer.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                newPlayer.SlightOfHand += amount;
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && newPlayer.SlightOfHand > newPlayer.PlayerJob.SlightOfHand)
            {
                newPlayer.SlightOfHand += amount;
                jobPointstoSpend += 1;
                UpdateUI();

            }
            else
            {
                Debug.Log("No Class Chosen");
            }
        }
    }

    public void SetStealth(int amount)
    {
        if (newPlayer.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                newPlayer.Stealth += amount;
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && newPlayer.Stealth > newPlayer.PlayerJob.Stealth)
            {
                newPlayer.Stealth += amount;
                jobPointstoSpend += 1;
                UpdateUI();

            }
            else
            {
                Debug.Log("No Class Chosen");
            }
        }
    }

    public void SetSurvival(int amount)
    {
        if (newPlayer.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                newPlayer.Survival += amount;
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && newPlayer.Survival > newPlayer.PlayerJob.Survival)
            {
                newPlayer.Survival += amount;
                jobPointstoSpend += 1;
                UpdateUI();

            }
            else
            {
                Debug.Log("No Class Chosen");
            }
        }
    }

    #endregion

    public void LoadSTuff()
    {
        if (pointsToSpend == 0 && jobPointstoSpend == 0 && PlayerNameGiven == true && AllStatsSet == true && PlayerAgeGiven == true)
        {
            LoadInfo.LoadALLInfo();
            SceneManager.LoadScene("TestScene");
        }
        else
        {
            Debug.Log("Need to Apply Points");
            //add a text prompt to pop in telling what needs to change and fade away with a sound
            //if statemenets for the multiple things needed
        }

    }
}
