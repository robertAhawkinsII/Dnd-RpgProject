using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMenuSetUp : MonoBehaviour
{


    public static PlayerMenuSetUp Instance;

    private void Awake()
    {

        if (Instance != null)
        {
            Debug.LogWarning("fix this" + gameObject);
        }
        else
        {
            Instance = this;
        }

        GameObject player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMovementControles>();
        playerStats = player.GetComponent<CharacterStats>();
        UpdateUI();
    }

    [SerializeField]
    private CharacterStats playerStats;
    [SerializeField]
    private PlayerMovementControles playerMove;

    private BasePlayerClass PlayingCharacter;

    private int pointsToSpend = 0;
    private int jobPointstoSpend = 0;

    [SerializeField]
    private Button openStatMenuButton, openSkillMenu, closeStatmenu, closeSkillMenu;

    [SerializeField]
    private GameObject StatLevelUpPanel, skillsLevelupPanel, characterMenuPanel, skillMenuPanel;


    public TextMeshProUGUI[] strmodtext;
    public TextMeshProUGUI[] dexmodtext;
    public TextMeshProUGUI[] conmodtext;
    public TextMeshProUGUI[] intmodtext;
    public TextMeshProUGUI[] wismodtext;
    public TextMeshProUGUI[] chrmodtext;

    [Header("Text values Containment")]
    [SerializeField]
    private TextMeshProUGUI playerNameText, playerACText, playerArmorBounesText, playerHPText, playerHealthBounesText, playerLevelUpCalculationText, playerstrengthValueText, playerStrengthmodText, playerStrenghtLevelupValueText, playerDexValueText, playerDexModText, playerDexLevelupValueText,
        playerConstitutionValueText, playerConModText, playerConLevelupValueText, playerIntelligenceValueText, playerintModText, playerIntLevelupValueText, playerWisdomValueText, playerWisModText, playerWisLevelupValueText, playerCharismaValueText,
        playerChaModText, playerChaLevelupValueText, playerAcrobaticsValueText, playerAcrobaticsLevelAdditionValueText, playerAnimalHValueText, playerAnimalHLevelAdditionValueText,
        playerArcanaValueText, playerArcanaLevelAdditionValueText, playerAthleticsValueText, playerAthleticsLevelAdditionValueText, playerDeceptionValueText,
        playerDeceptionLevelAdditionValueText, playerHistoryValueText, playerHistooryLevelAdditionValueText, playerInsightValueText, playerInsightLevelAdditionValueText, playerIntimidationvalueText,
        playerIntimidationLevelAdditionValueText, playerInvestigationvalueText, playerInvestigationLevelAdditionValueText, playerMedicineValueText, playerMedicineLevelAdditionValueText,
        playerNatureValueText, playerNatureLevelAdditionValueText, playerPerceptionValueText, playerPerceptionLevelAdditionValueText, playerPerformanceValueText,
        playerPerformanceLevelAdditionValueText, playerPersuasionValueText, playerPersuasionLevelAdditionValueText, playerReligionValueText, playerReligionLevelAdditionValueText,
        playerSlightOfHandValueText, playerSlightOfHandLevelAdditionValueText, playerStealthValueText, playerStealthLevelAdditionValueText, playerSurvivalValueText,
        playerSurvivalLevelAdditionValueText, totalStatLevelPointstoSpendText, totalSkillLevelUpPointstoSpendText, characterClassText, characterJobText;


    [SerializeField]
    private GameObject[] StatLevelupButtons, SkillLvlUpButtons;

    [SerializeField]
    private Image expBar;


    public void DisplayCharacterMenu()
    {
        GameObject player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMovementControles>();
        playerStats = player.GetComponent<CharacterStats>();
        characterMenuPanel.SetActive(true);
        playerMove.canMove = false;
        UpdateUI();
    }

    public void ClosecharacterMenuPanel()
    {
        characterMenuPanel.SetActive(false);
        playerMove.canMove = true;
    }

    public void DisplaySkillMenu()
    {
        skillMenuPanel.SetActive(true);
        closeStatmenu.interactable = false;
    }

    public void CloseStatMenu()
    {
        skillMenuPanel.SetActive(false);
        closeStatmenu.interactable = true;
    }

    private void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {

        for (int i = 0; i < playerStats.attributes.Length; i++)
        {
            switch (playerStats.attributes[i].type)
            {
                case Atributes.MaxHP:
                    playerHPText.text = "HP :" + playerStats.attributes[i].value.BaseValue;

                    playerHealthBounesText.text = "" + (playerStats.attributes[i].value.ModifiedValue - playerStats.attributes[i].value.BaseValue);
                    break;
                case Atributes.AC:
                    playerACText.text = "AC :" + playerStats.attributes[i].value.BaseValue;
                    playerArmorBounesText.text = "+ ArmorB: " + (playerStats.attributes[i].value.ModifiedValue - playerStats.attributes[i].value.BaseValue);
                    break;
                case Atributes.Strength:

                    playerstrengthValueText.text = "" + playerStats.attributes[i].value.ModifiedValue.ToString(); ;
                    break;
                case Atributes.Dexterity:
                    playerDexValueText.text = "" + playerStats.attributes[i].value.ModifiedValue.ToString();
                    break;
                case Atributes.Constitution:
                    playerConstitutionValueText.text = "" + playerStats.attributes[i].value.ModifiedValue.ToString();
                    break;
                case Atributes.Intelligence:
                    playerIntelligenceValueText.text = "" + playerStats.attributes[i].value.ModifiedValue.ToString();
                    break;
                case Atributes.Wisdon:
                    playerWisdomValueText.text = "" + playerStats.attributes[i].value.ModifiedValue.ToString();
                    break;
                case Atributes.Charisma:
                    playerCharismaValueText.text = "" + playerStats.attributes[i].value.ModifiedValue.ToString();
                    break;
                case Atributes.Acrobatics:
                    playerAcrobaticsValueText.text = "" + playerStats.attributes[i].value.ModifiedValue.ToString();
                    break;
                case Atributes.AnimalHandeling:
                    playerAnimalHValueText.text = "" + playerStats.attributes[i].value.ModifiedValue.ToString();
                    break;
                case Atributes.Arcana:
                    playerArcanaValueText.text = "" + playerStats.attributes[i].value.ModifiedValue.ToString();
                    break;
                case Atributes.Athletics:
                    playerAthleticsValueText.text = "" + playerStats.attributes[i].value.ModifiedValue.ToString();
                    break;
                case Atributes.Deception:
                    playerDeceptionValueText.text = "" + playerStats.attributes[i].value.ModifiedValue.ToString();
                    break;
                case Atributes.History:
                    playerHistoryValueText.text = "" + playerStats.attributes[i].value.ModifiedValue.ToString();
                    break;
                case Atributes.Insight:
                    playerInsightValueText.text = "" + playerStats.attributes[i].value.ModifiedValue.ToString();
                    break;
                case Atributes.Intimidation:
                    playerIntimidationvalueText.text = "" + playerStats.attributes[i].value.ModifiedValue.ToString();
                    break;
                case Atributes.Investigation:
                    playerInvestigationvalueText.text = "" + playerStats.attributes[i].value.ModifiedValue.ToString();
                    break;
                case Atributes.Medicine:
                    playerMedicineValueText.text = "" + playerStats.attributes[i].value.ModifiedValue.ToString();
                    break;
                case Atributes.Nature:
                    playerNatureValueText.text = "" + playerStats.attributes[i].value.ModifiedValue.ToString();
                    break;
                case Atributes.Perception:
                    playerPerceptionValueText.text = "" + playerStats.attributes[i].value.ModifiedValue.ToString();
                    break;
                case Atributes.Performence:
                    playerPerformanceValueText.text = "" +playerStats.attributes[i].value.ModifiedValue.ToString();
                    break;
                case Atributes.Persuasion:
                    playerPersuasionValueText.text = "" + playerStats.attributes[i].value.ModifiedValue.ToString();
                    break;
                case Atributes.Religion:
                    playerReligionValueText.text = "" + playerStats.attributes[i].value.ModifiedValue.ToString();
                    break;
                case Atributes.SlightOfHand:
                    playerSlightOfHandValueText.text = "" + playerStats.attributes[i].value.ModifiedValue.ToString();
                    break;
                case Atributes.Stealth:
                    playerStealthValueText.text = "" + playerStats.attributes[i].value.ModifiedValue.ToString();
                    break;
                case Atributes.Survival:
                    playerSurvivalValueText.text = "" + playerStats.attributes[i].value.ModifiedValue.ToString();
                    break;
                default:
                    break;
            }
        }

        playerNameText.text = playerStats.CharacterName;
        
         // change when equipment is implamented
        
        characterClassText.text = playerStats.characterClass.ToString();
        characterJobText.text = playerStats.characterJobs.ToString();
        expBar.fillAmount = playerStats.experience.RuntimeValue / playerStats.experienceNeeded.initialValue;
        playerLevelUpCalculationText.text = playerStats.experience.RuntimeValue.ToString() + "         /         " + playerStats.experienceNeeded.initialValue.ToString(); 
        
        playerStrengthmodText.text = playerStats.strMod.ToString();
        
        playerDexModText.text = playerStats.dexMod.ToString();
        
        playerConModText.text = playerStats.conMod.ToString();
        
        playerintModText.text = playerStats.intMod.ToString();
        
        playerWisModText.text = playerStats.wisMod.ToString();
        
        playerChaModText.text = playerStats.chrMod.ToString();

      


        totalStatLevelPointstoSpendText.text = pointsToSpend.ToString();
        totalSkillLevelUpPointstoSpendText.text = jobPointstoSpend.ToString();

        foreach (TextMeshProUGUI cc in strmodtext)
        {
            cc.text = playerStats.strMod.ToString();
        }

        foreach (TextMeshProUGUI cc in dexmodtext)
        {
            cc.text = playerStats.dexMod.ToString();
        }

        foreach (TextMeshProUGUI cc in conmodtext)
        {
            cc.text = playerStats.conMod.ToString();
        }

        foreach (TextMeshProUGUI cc in intmodtext)
        {
            cc.text = playerStats.intMod.ToString();
        }

        foreach (TextMeshProUGUI cc in wismodtext)
        {
            cc.text = playerStats.wisMod.ToString();
        }

        foreach (TextMeshProUGUI cc in chrmodtext)
        {
            cc.text = playerStats.chrMod.ToString();
        }
    }

    #region LevelUpStuff

    public void LevelUpStatsandSkills()
    {
        StatLevelUpPanel.SetActive(true);
        for (int i = 0; i < StatLevelupButtons.Length; i++)
        {
            StatLevelupButtons[i].SetActive(true);
            pointsToSpend += 2;
        }

        skillsLevelupPanel.SetActive(true);
        for (int i = 0; i < SkillLvlUpButtons.Length; i++)
        {
            SkillLvlUpButtons[i].SetActive(true);
            jobPointstoSpend += 5;
        }
    }

    public void LevelUpSkillsOnly()
    {
        skillsLevelupPanel.SetActive(true);
        for (int i = 0; i < SkillLvlUpButtons.Length; i++)
        {
            SkillLvlUpButtons[i].SetActive(true);
            jobPointstoSpend += 5;
        }
    }

    public void RollForHealthUpgrade()
    {
        int HealthAddValue;

        for (int i = 0; i < playerStats.attributes.Length; i++)
        {
            switch (playerStats.attributes[i].type)
            {
                case Atributes.MaxHP:
                    switch (GameInfo.setClass)
                    {
                        case PlayerClass.Barbarian:
                            HealthAddValue = Random.Range(1, 12);
                            playerStats.playerMaxHealth.initialValue += HealthAddValue + playerStats.conMod;
                            playerStats.attributes[i].value.BaseValue = playerStats.playerMaxHealth.initialValue;
                            break;

                        case PlayerClass.Bard:
                            HealthAddValue = Random.Range(1, 8);
                            playerStats.playerMaxHealth.initialValue += HealthAddValue + playerStats.conMod;
                            playerStats.attributes[i].value.BaseValue = playerStats.playerMaxHealth.initialValue;
                            break;

                        case PlayerClass.Cleric:
                            HealthAddValue = Random.Range(1, 8);
                            playerStats.playerMaxHealth.initialValue += HealthAddValue + playerStats.conMod;
                            playerStats.attributes[i].value.BaseValue = playerStats.playerMaxHealth.initialValue;
                            break;

                        case PlayerClass.Druid:
                            HealthAddValue = Random.Range(1, 8);
                            playerStats.playerMaxHealth.initialValue += HealthAddValue + playerStats.conMod;
                            playerStats.attributes[i].value.BaseValue = playerStats.playerMaxHealth.initialValue;
                            break;

                        case PlayerClass.Fighter:
                            HealthAddValue = Random.Range(1, 10);
                            playerStats.playerMaxHealth.initialValue += HealthAddValue + playerStats.conMod;
                            playerStats.attributes[i].value.BaseValue = playerStats.playerMaxHealth.initialValue;
                            break;

                        case PlayerClass.Monk:
                            HealthAddValue = Random.Range(1, 8);
                            playerStats.playerMaxHealth.initialValue += HealthAddValue + playerStats.conMod;
                            playerStats.attributes[i].value.BaseValue = playerStats.playerMaxHealth.initialValue;
                            break;

                        case PlayerClass.Palidin:
                            HealthAddValue = Random.Range(1, 10);
                            playerStats.playerMaxHealth.initialValue += HealthAddValue + playerStats.conMod;
                            playerStats.attributes[i].value.BaseValue = playerStats.playerMaxHealth.initialValue;
                            break;

                        case PlayerClass.Ranger:
                            HealthAddValue = Random.Range(1, 10);
                            playerStats.playerMaxHealth.initialValue += HealthAddValue + playerStats.conMod;
                            playerStats.attributes[i].value.BaseValue = playerStats.playerMaxHealth.initialValue;
                            break;

                        case PlayerClass.Rouge:
                            HealthAddValue = Random.Range(1, 8);
                            playerStats.playerMaxHealth.initialValue += HealthAddValue + playerStats.conMod;
                            playerStats.attributes[i].value.BaseValue = playerStats.playerMaxHealth.initialValue;
                            break;

                        case PlayerClass.Scorcerer:
                            HealthAddValue = Random.Range(1, 6);
                            playerStats.playerMaxHealth.initialValue += HealthAddValue + playerStats.conMod;
                            playerStats.attributes[i].value.BaseValue = playerStats.playerMaxHealth.initialValue;
                            break;

                        case PlayerClass.Warlock:
                            HealthAddValue = Random.Range(1, 8);
                            playerStats.playerMaxHealth.initialValue += HealthAddValue + playerStats.conMod;
                            playerStats.attributes[i].value.BaseValue = playerStats.playerMaxHealth.initialValue;
                            break;

                        case PlayerClass.Wizard:
                            HealthAddValue = Random.Range(1, 6);
                            playerStats.playerMaxHealth.initialValue += HealthAddValue + playerStats.conMod;
                            playerStats.attributes[i].value.BaseValue = playerStats.playerMaxHealth.initialValue;
                            break;
                    }
                    break;

            }
        }
    }

    public void ConfirmLevel()///make a differet one for party members
    {
        RollForHealthUpgrade();

        PlayingCharacter.PlayerLevel = playerStats.characterLevel.initialValue;

        GameInfo.PlayerLevel = PlayingCharacter.PlayerLevel;
        GameInfo.PlayerName = PlayingCharacter.PlayerName;
        GameInfo.PlayerClass = PlayingCharacter.PlayerClass;
        GameInfo.PlayerJob = PlayingCharacter.PlayerJob;

        GameInfo.Strength = PlayingCharacter.Strength;
        GameInfo.Dexterity = PlayingCharacter.Dexterity;
        GameInfo.Constitution = PlayingCharacter.Constitution;
        GameInfo.Intelligence = PlayingCharacter.Intelligence;
        GameInfo.Wisdom = PlayingCharacter.Wisdom;
        GameInfo.Charisma = PlayingCharacter.Charisma;

        GameInfo.Acrobatics = PlayingCharacter.Acrobatics;
        GameInfo.AnimaHandling = PlayingCharacter.AnimaHandling;
        GameInfo.Arcana = PlayingCharacter.Arcana;
        GameInfo.Athletics = PlayingCharacter.Athletics;
        GameInfo.Deception = PlayingCharacter.Deception;
        GameInfo.History = PlayingCharacter.History;
        GameInfo.Insight = PlayingCharacter.Insight;
        GameInfo.Intimidation = PlayingCharacter.Intimidation;
        GameInfo.Investigation = PlayingCharacter.Investigation;
        GameInfo.Medicine = PlayingCharacter.Medicine;
        GameInfo.Nature = PlayingCharacter.Nature;
        GameInfo.Perception = PlayingCharacter.Perception;
        GameInfo.Persuasion = PlayingCharacter.Persuasion;
        GameInfo.Religion = PlayingCharacter.Religion;
        GameInfo.SlightOfHand = PlayingCharacter.SlightOfHand;
        GameInfo.Stealth = PlayingCharacter.Stealth;
        GameInfo.Survival = PlayingCharacter.Survival;

        GameInfo.strMod = PlayingCharacter.strMod;
        GameInfo.dexMod = PlayingCharacter.dexMod;
        GameInfo.conMod = PlayingCharacter.conMod;
        GameInfo.intMod = PlayingCharacter.intMod;
        GameInfo.wisMod = PlayingCharacter.wisMod;
        GameInfo.chrMod = PlayingCharacter.chrMod;

        playerStrenghtLevelupValueText.text = 0.ToString(); 
        playerDexLevelupValueText.text = 0.ToString();
        playerConLevelupValueText.text = 0.ToString();
        playerIntLevelupValueText.text = 0.ToString();
        playerWisLevelupValueText.text = 0.ToString();
        playerChaLevelupValueText.text = 0.ToString();

        playerAcrobaticsLevelAdditionValueText.text = 0.ToString();
        playerAnimalHLevelAdditionValueText.text = 0.ToString();
        playerArcanaLevelAdditionValueText.text = 0.ToString();
        playerAthleticsLevelAdditionValueText.text = 0.ToString();
        playerDeceptionLevelAdditionValueText.text = 0.ToString();
        playerHistooryLevelAdditionValueText.text = 0.ToString();
        playerInsightLevelAdditionValueText.text = 0.ToString();
        playerIntimidationLevelAdditionValueText.text = 0.ToString();
        playerInvestigationLevelAdditionValueText.text = 0.ToString();
        playerMedicineLevelAdditionValueText.text = 0.ToString();
        playerNatureLevelAdditionValueText.text = 0.ToString();
        playerPerceptionLevelAdditionValueText.text = 0.ToString();
        playerPersuasionLevelAdditionValueText.text = 0.ToString();
        playerReligionLevelAdditionValueText.text = 0.ToString();
        playerSlightOfHandLevelAdditionValueText.text = 0.ToString();
        playerStealthLevelAdditionValueText.text = 0.ToString();
        playerSurvivalLevelAdditionValueText.text = 0.ToString();

        SaveInfo.SaveAllInfo();

        LoadSTuff();
    }

    #region SetStats//update bouneses to 30
    public void SetStrength(int amount)
    {
        if (PlayingCharacter.PlayerClass != null)
        {
            if (amount > 0 && pointsToSpend > 0)
            {
                PlayingCharacter.Strength += amount;
                playerStrenghtLevelupValueText.text = amount.ToString();
                pointsToSpend -= 1;
                UpdateUI();

                switch (PlayingCharacter.Strength)
                {
                    case 0:
                        PlayingCharacter.strMod = -5;
                        break;
                    case 1:
                        PlayingCharacter.strMod = -5;
                        break;
                    case 2:
                        PlayingCharacter.strMod = -4;
                        break;
                    case 3:
                        PlayingCharacter.strMod = -4;
                        break;
                    case 4:
                        PlayingCharacter.strMod = -3;
                        break;
                    case 5:
                        PlayingCharacter.strMod = -3;
                        break;
                    case 6:
                        PlayingCharacter.strMod = -2;
                        break;
                    case 7:
                        PlayingCharacter.strMod = -2;
                        break;
                    case 8:
                        PlayingCharacter.strMod = -1;
                        break;
                    case 9:
                        PlayingCharacter.strMod = -1;
                        break;
                    case 10:
                        PlayingCharacter.strMod = 0;
                        break;
                    case 11:
                        PlayingCharacter.strMod = 0;
                        break;
                    case 12:
                        PlayingCharacter.strMod = 1;
                        break;
                    case 13:
                        PlayingCharacter.strMod = 1;
                        break;
                    case 14:
                        PlayingCharacter.strMod = 2;
                        break;
                    case 15:
                        PlayingCharacter.strMod = 2;
                        break;
                    case 16:
                        PlayingCharacter.strMod = 3;
                        break;
                    case 17:
                        PlayingCharacter.strMod = 3;
                        break;
                    case 18:
                        PlayingCharacter.strMod = 4;
                        break;
                    case 19:
                        PlayingCharacter.strMod = 4;
                        break;
                    case 20:
                        PlayingCharacter.strMod = 5;
                        break;
                }
            }
            else if (amount < 0 && PlayingCharacter.Strength > PlayingCharacter.PlayerClass.Strength)
            {
                PlayingCharacter.Strength += amount;
                playerStrenghtLevelupValueText.text = amount.ToString();
                pointsToSpend += 1;
                UpdateUI();

                switch (PlayingCharacter.Strength)
                {
                    case 0:
                        PlayingCharacter.strMod = -5;
                        break;
                    case 1:
                        PlayingCharacter.strMod = -5;
                        break;
                    case 2:
                        PlayingCharacter.strMod = -4;
                        break;
                    case 3:
                        PlayingCharacter.strMod = -4;
                        break;
                    case 4:
                        PlayingCharacter.strMod = -3;
                        break;
                    case 5:
                        PlayingCharacter.strMod = -3;
                        break;
                    case 6:
                        PlayingCharacter.strMod = -2;
                        break;
                    case 7:
                        PlayingCharacter.strMod = -2;
                        break;
                    case 8:
                        PlayingCharacter.strMod = -1;
                        break;
                    case 9:
                        PlayingCharacter.strMod = -1;
                        break;
                    case 10:
                        PlayingCharacter.strMod = 0;
                        break;
                    case 11:
                        PlayingCharacter.strMod = 0;
                        break;
                    case 12:
                        PlayingCharacter.strMod = 1;
                        break;
                    case 13:
                        PlayingCharacter.strMod = 1;
                        break;
                    case 14:
                        PlayingCharacter.strMod = 2;
                        break;
                    case 15:
                        PlayingCharacter.strMod = 2;
                        break;
                    case 16:
                        PlayingCharacter.strMod = 3;
                        break;
                    case 17:
                        PlayingCharacter.strMod = 3;
                        break;
                    case 18:
                        PlayingCharacter.strMod = 4;
                        break;
                    case 19:
                        PlayingCharacter.strMod = 4;
                        break;
                    case 20:
                        PlayingCharacter.strMod = 5;
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
        if (PlayingCharacter.PlayerClass != null)
        {
            if (amount > 0 && pointsToSpend > 0)
            {
                PlayingCharacter.Dexterity += amount;
                playerDexLevelupValueText.text = amount.ToString();
                pointsToSpend -= 1;
                UpdateUI();

                switch (PlayingCharacter.Dexterity)
                {
                    case 0:
                        PlayingCharacter.dexMod = -5;
                        break;
                    case 1:
                        PlayingCharacter.dexMod = -5;
                        break;
                    case 2:
                        PlayingCharacter.dexMod = -4;
                        break;
                    case 3:
                        PlayingCharacter.dexMod = -4;
                        break;
                    case 4:
                        PlayingCharacter.dexMod = -3;
                        break;
                    case 5:
                        PlayingCharacter.dexMod = -3;
                        break;
                    case 6:
                        PlayingCharacter.dexMod = -2;
                        break;
                    case 7:
                        PlayingCharacter.dexMod = -2;
                        break;
                    case 8:
                        PlayingCharacter.dexMod = -1;
                        break;
                    case 9:
                        PlayingCharacter.dexMod = -1;
                        break;
                    case 10:
                        PlayingCharacter.dexMod = 0;
                        break;
                    case 11:
                        PlayingCharacter.dexMod = 0;
                        break;
                    case 12:
                        PlayingCharacter.dexMod = 1;
                        break;
                    case 13:
                        PlayingCharacter.dexMod = 1;
                        break;
                    case 14:
                        PlayingCharacter.dexMod = 2;
                        break;
                    case 15:
                        PlayingCharacter.dexMod = 2;
                        break;
                    case 16:
                        PlayingCharacter.dexMod = 3;
                        break;
                    case 17:
                        PlayingCharacter.dexMod = 3;
                        break;
                    case 18:
                        PlayingCharacter.dexMod = 4;
                        break;
                    case 19:
                        PlayingCharacter.dexMod = 4;
                        break;
                    case 20:
                        PlayingCharacter.dexMod = 5;
                        break;
                }
            }
            else if (amount < 0 && PlayingCharacter.Dexterity > PlayingCharacter.PlayerClass.Dexterity)
            {
                PlayingCharacter.Dexterity += amount;
                playerDexLevelupValueText.text = amount.ToString();
                pointsToSpend += 1;
                UpdateUI();

                switch (PlayingCharacter.Dexterity)
                {
                    case 0:
                        PlayingCharacter.dexMod = -5;
                        break;
                    case 1:
                        PlayingCharacter.dexMod = -5;
                        break;
                    case 2:
                        PlayingCharacter.dexMod = -4;
                        break;
                    case 3:
                        PlayingCharacter.dexMod = -4;
                        break;
                    case 4:
                        PlayingCharacter.dexMod = -3;
                        break;
                    case 5:
                        PlayingCharacter.dexMod = -3;
                        break;
                    case 6:
                        PlayingCharacter.dexMod = -2;
                        break;
                    case 7:
                        PlayingCharacter.dexMod = -2;
                        break;
                    case 8:
                        PlayingCharacter.dexMod = -1;
                        break;
                    case 9:
                        PlayingCharacter.dexMod = -1;
                        break;
                    case 10:
                        PlayingCharacter.dexMod = 0;
                        break;
                    case 11:
                        PlayingCharacter.dexMod = 0;
                        break;
                    case 12:
                        PlayingCharacter.dexMod = 1;
                        break;
                    case 13:
                        PlayingCharacter.dexMod = 1;
                        break;
                    case 14:
                        PlayingCharacter.dexMod = 2;
                        break;
                    case 15:
                        PlayingCharacter.dexMod = 2;
                        break;
                    case 16:
                        PlayingCharacter.dexMod = 3;
                        break;
                    case 17:
                        PlayingCharacter.dexMod = 3;
                        break;
                    case 18:
                        PlayingCharacter.dexMod = 4;
                        break;
                    case 19:
                        PlayingCharacter.dexMod = 4;
                        break;
                    case 20:
                        PlayingCharacter.dexMod = 5;
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
        if (PlayingCharacter.PlayerClass != null)
        {
            if (amount > 0 && pointsToSpend > 0)
            {
                PlayingCharacter.Constitution += amount;
                playerConLevelupValueText.text = amount.ToString();
                pointsToSpend -= 1;
                UpdateUI();

                switch (PlayingCharacter.Constitution)
                {
                    case 0:
                        PlayingCharacter.conMod = -5;
                        break;
                    case 1:
                        PlayingCharacter.conMod = -5;
                        break;
                    case 2:
                        PlayingCharacter.conMod = -4;
                        break;
                    case 3:
                        PlayingCharacter.conMod = -4;
                        break;
                    case 4:
                        PlayingCharacter.conMod = -3;
                        break;
                    case 5:
                        PlayingCharacter.conMod = -3;
                        break;
                    case 6:
                        PlayingCharacter.conMod = -2;
                        break;
                    case 7:
                        PlayingCharacter.conMod = -2;
                        break;
                    case 8:
                        PlayingCharacter.conMod = -1;
                        break;
                    case 9:
                        PlayingCharacter.conMod = -1;
                        break;
                    case 10:
                        PlayingCharacter.conMod = 0;
                        break;
                    case 11:
                        PlayingCharacter.conMod = 0;
                        break;
                    case 12:
                        PlayingCharacter.conMod = 1;
                        break;
                    case 13:
                        PlayingCharacter.conMod = 1;
                        break;
                    case 14:
                        PlayingCharacter.conMod = 2;
                        break;
                    case 15:
                        PlayingCharacter.conMod = 2;
                        break;
                    case 16:
                        PlayingCharacter.conMod = 3;
                        break;
                    case 17:
                        PlayingCharacter.conMod = 3;
                        break;
                    case 18:
                        PlayingCharacter.conMod = 4;
                        break;
                    case 19:
                        PlayingCharacter.conMod = 4;
                        break;
                    case 20:
                        PlayingCharacter.conMod = 5;
                        break;
                }
            }
            else if (amount < 0 && PlayingCharacter.Constitution > PlayingCharacter.PlayerClass.Constitution)
            {
                PlayingCharacter.Constitution += amount;
                playerConLevelupValueText.text = amount.ToString();
                pointsToSpend += 1;
                UpdateUI();

                switch (PlayingCharacter.Constitution)
                {
                    case 0:
                        PlayingCharacter.conMod = -5;
                        break;
                    case 1:
                        PlayingCharacter.conMod = -5;
                        break;
                    case 2:
                        PlayingCharacter.conMod = -4;
                        break;
                    case 3:
                        PlayingCharacter.conMod = -4;
                        break;
                    case 4:
                        PlayingCharacter.conMod = -3;
                        break;
                    case 5:
                        PlayingCharacter.conMod = -3;
                        break;
                    case 6:
                        PlayingCharacter.conMod = -2;
                        break;
                    case 7:
                        PlayingCharacter.conMod = -2;
                        break;
                    case 8:
                        PlayingCharacter.conMod = -1;
                        break;
                    case 9:
                        PlayingCharacter.conMod = -1;
                        break;
                    case 10:
                        PlayingCharacter.conMod = 0;
                        break;
                    case 11:
                        PlayingCharacter.conMod = 0;
                        break;
                    case 12:
                        PlayingCharacter.conMod = 1;
                        break;
                    case 13:
                        PlayingCharacter.conMod = 1;
                        break;
                    case 14:
                        PlayingCharacter.conMod = 2;
                        break;
                    case 15:
                        PlayingCharacter.conMod = 2;
                        break;
                    case 16:
                        PlayingCharacter.conMod = 3;
                        break;
                    case 17:
                        PlayingCharacter.conMod = 3;
                        break;
                    case 18:
                        PlayingCharacter.conMod = 4;
                        break;
                    case 19:
                        PlayingCharacter.conMod = 4;
                        break;
                    case 20:
                        PlayingCharacter.conMod = 5;
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
        if (PlayingCharacter.PlayerClass != null)
        {
            if (amount > 0 && pointsToSpend > 0)
            {
                PlayingCharacter.Intelligence += amount;
                playerIntLevelupValueText.text = amount.ToString();
                pointsToSpend -= 1;
                UpdateUI();

                switch (PlayingCharacter.Intelligence)
                {
                    case 0:
                        PlayingCharacter.intMod = -5;
                        break;
                    case 1:
                        PlayingCharacter.intMod = -5;
                        break;
                    case 2:
                        PlayingCharacter.intMod = -4;
                        break;
                    case 3:
                        PlayingCharacter.intMod = -4;
                        break;
                    case 4:
                        PlayingCharacter.intMod = -3;
                        break;
                    case 5:
                        PlayingCharacter.intMod = -3;
                        break;
                    case 6:
                        PlayingCharacter.intMod = -2;
                        break;
                    case 7:
                        PlayingCharacter.intMod = -2;
                        break;
                    case 8:
                        PlayingCharacter.intMod = -1;
                        break;
                    case 9:
                        PlayingCharacter.intMod = -1;
                        break;
                    case 10:
                        PlayingCharacter.intMod = 0;
                        break;
                    case 11:
                        PlayingCharacter.intMod = 0;
                        break;
                    case 12:
                        PlayingCharacter.intMod = 1;
                        break;
                    case 13:
                        PlayingCharacter.intMod = 1;
                        break;
                    case 14:
                        PlayingCharacter.intMod = 2;
                        break;
                    case 15:
                        PlayingCharacter.intMod = 2;
                        break;
                    case 16:
                        PlayingCharacter.intMod = 3;
                        break;
                    case 17:
                        PlayingCharacter.intMod = 3;
                        break;
                    case 18:
                        PlayingCharacter.intMod = 4;
                        break;
                    case 19:
                        PlayingCharacter.intMod = 4;
                        break;
                    case 20:
                        PlayingCharacter.intMod = 5;
                        break;
                }
            }
            else if (amount < 0 && PlayingCharacter.Intelligence > PlayingCharacter.PlayerClass.Intelligence)
            {
                PlayingCharacter.Intelligence += amount;
                playerIntLevelupValueText.text = amount.ToString();
                pointsToSpend += 1;
                UpdateUI();

                switch (PlayingCharacter.Intelligence)
                {
                    case 0:
                        PlayingCharacter.intMod = -5;
                        break;
                    case 1:
                        PlayingCharacter.intMod = -5;
                        break;
                    case 2:
                        PlayingCharacter.intMod = -4;
                        break;
                    case 3:
                        PlayingCharacter.intMod = -4;
                        break;
                    case 4:
                        PlayingCharacter.intMod = -3;
                        break;
                    case 5:
                        PlayingCharacter.intMod = -3;
                        break;
                    case 6:
                        PlayingCharacter.intMod = -2;
                        break;
                    case 7:
                        PlayingCharacter.intMod = -2;
                        break;
                    case 8:
                        PlayingCharacter.intMod = -1;
                        break;
                    case 9:
                        PlayingCharacter.intMod = -1;
                        break;
                    case 10:
                        PlayingCharacter.intMod = 0;
                        break;
                    case 11:
                        PlayingCharacter.intMod = 0;
                        break;
                    case 12:
                        PlayingCharacter.intMod = 1;
                        break;
                    case 13:
                        PlayingCharacter.intMod = 1;
                        break;
                    case 14:
                        PlayingCharacter.intMod = 2;
                        break;
                    case 15:
                        PlayingCharacter.intMod = 2;
                        break;
                    case 16:
                        PlayingCharacter.intMod = 3;
                        break;
                    case 17:
                        PlayingCharacter.intMod = 3;
                        break;
                    case 18:
                        PlayingCharacter.intMod = 4;
                        break;
                    case 19:
                        PlayingCharacter.intMod = 4;
                        break;
                    case 20:
                        PlayingCharacter.intMod = 5;
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
        if (PlayingCharacter.PlayerClass != null)
        {
            if (amount > 0 && pointsToSpend > 0)
            {
                PlayingCharacter.Wisdom += amount;
                playerWisLevelupValueText.text = amount.ToString();
                pointsToSpend -= 1;
                UpdateUI();

                switch (PlayingCharacter.Wisdom)
                {
                    case 0:
                        PlayingCharacter.wisMod = -5;
                        break;
                    case 1:
                        PlayingCharacter.wisMod = -5;
                        break;
                    case 2:
                        PlayingCharacter.wisMod = -4;
                        break;
                    case 3:
                        PlayingCharacter.wisMod = -4;
                        break;
                    case 4:
                        PlayingCharacter.wisMod = -3;
                        break;
                    case 5:
                        PlayingCharacter.wisMod = -3;
                        break;
                    case 6:
                        PlayingCharacter.wisMod = -2;
                        break;
                    case 7:
                        PlayingCharacter.wisMod = -2;
                        break;
                    case 8:
                        PlayingCharacter.wisMod = -1;
                        break;
                    case 9:
                        PlayingCharacter.wisMod = -1;
                        break;
                    case 10:
                        PlayingCharacter.wisMod = 0;
                        break;
                    case 11:
                        PlayingCharacter.wisMod = 0;
                        break;
                    case 12:
                        PlayingCharacter.wisMod = 1;
                        break;
                    case 13:
                        PlayingCharacter.wisMod = 1;
                        break;
                    case 14:
                        PlayingCharacter.wisMod = 2;
                        break;
                    case 15:
                        PlayingCharacter.wisMod = 2;
                        break;
                    case 16:
                        PlayingCharacter.wisMod = 3;
                        break;
                    case 17:
                        PlayingCharacter.wisMod = 3;
                        break;
                    case 18:
                        PlayingCharacter.wisMod = 4;
                        break;
                    case 19:
                        PlayingCharacter.wisMod = 4;
                        break;
                    case 20:
                        PlayingCharacter.wisMod = 5;
                        break;
                }
            }
            else if (amount < 0 && PlayingCharacter.Wisdom > PlayingCharacter.PlayerClass.Wisdom)
            {
                PlayingCharacter.Wisdom += amount;
                playerWisLevelupValueText.text = amount.ToString();
                pointsToSpend += 1;
                UpdateUI();

                switch (PlayingCharacter.Wisdom)
                {
                    case 0:
                        PlayingCharacter.wisMod = -5;
                        break;
                    case 1:
                        PlayingCharacter.wisMod = -5;
                        break;
                    case 2:
                        PlayingCharacter.wisMod = -4;
                        break;
                    case 3:
                        PlayingCharacter.wisMod = -4;
                        break;
                    case 4:
                        PlayingCharacter.wisMod = -3;
                        break;
                    case 5:
                        PlayingCharacter.wisMod = -3;
                        break;
                    case 6:
                        PlayingCharacter.wisMod = -2;
                        break;
                    case 7:
                        PlayingCharacter.wisMod = -2;
                        break;
                    case 8:
                        PlayingCharacter.wisMod = -1;
                        break;
                    case 9:
                        PlayingCharacter.wisMod = -1;
                        break;
                    case 10:
                        PlayingCharacter.wisMod = 0;
                        break;
                    case 11:
                        PlayingCharacter.wisMod = 0;
                        break;
                    case 12:
                        PlayingCharacter.wisMod = 1;
                        break;
                    case 13:
                        PlayingCharacter.wisMod = 1;
                        break;
                    case 14:
                        PlayingCharacter.wisMod = 2;
                        break;
                    case 15:
                        PlayingCharacter.wisMod = 2;
                        break;
                    case 16:
                        PlayingCharacter.wisMod = 3;
                        break;
                    case 17:
                        PlayingCharacter.wisMod = 3;
                        break;
                    case 18:
                        PlayingCharacter.wisMod = 4;
                        break;
                    case 19:
                        PlayingCharacter.wisMod = 4;
                        break;
                    case 20:
                        PlayingCharacter.wisMod = 5;
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
        if (PlayingCharacter.PlayerClass != null)
        {
            if (amount > 0 && pointsToSpend > 0)
            {
                PlayingCharacter.Charisma += amount;
                playerChaLevelupValueText.text = amount.ToString();
                pointsToSpend -= 1;
                UpdateUI();

                switch (PlayingCharacter.Charisma)
                {
                    case 0:
                        PlayingCharacter.chrMod = -5;
                        break;
                    case 1:
                        PlayingCharacter.chrMod = -5;
                        break;
                    case 2:
                        PlayingCharacter.chrMod = -4;
                        break;
                    case 3:
                        PlayingCharacter.chrMod = -4;
                        break;
                    case 4:
                        PlayingCharacter.chrMod = -3;
                        break;
                    case 5:
                        PlayingCharacter.chrMod = -3;
                        break;
                    case 6:
                        PlayingCharacter.chrMod = -2;
                        break;
                    case 7:
                        PlayingCharacter.chrMod = -2;
                        break;
                    case 8:
                        PlayingCharacter.chrMod = -1;
                        break;
                    case 9:
                        PlayingCharacter.chrMod = -1;
                        break;
                    case 10:
                        PlayingCharacter.chrMod = 0;
                        break;
                    case 11:
                        PlayingCharacter.chrMod = 0;
                        break;
                    case 12:
                        PlayingCharacter.chrMod = 1;
                        break;
                    case 13:
                        PlayingCharacter.chrMod = 1;
                        break;
                    case 14:
                        PlayingCharacter.chrMod = 2;
                        break;
                    case 15:
                        PlayingCharacter.chrMod = 2;
                        break;
                    case 16:
                        PlayingCharacter.chrMod = 3;
                        break;
                    case 17:
                        PlayingCharacter.chrMod = 3;
                        break;
                    case 18:
                        PlayingCharacter.chrMod = 4;
                        break;
                    case 19:
                        PlayingCharacter.chrMod = 4;
                        break;
                    case 20:
                        PlayingCharacter.chrMod = 5;
                        break;
                }
            }
            else if (amount < 0 && PlayingCharacter.Charisma > PlayingCharacter.PlayerClass.Charisma)
            {
                PlayingCharacter.Charisma += amount;
                playerChaLevelupValueText.text = amount.ToString();
                pointsToSpend += 1;
                UpdateUI();

                switch (PlayingCharacter.Charisma)
                {
                    case 0:
                        PlayingCharacter.chrMod = -5;
                        break;
                    case 1:
                        PlayingCharacter.chrMod = -5;
                        break;
                    case 2:
                        PlayingCharacter.chrMod = -4;
                        break;
                    case 3:
                        PlayingCharacter.chrMod = -4;
                        break;
                    case 4:
                        PlayingCharacter.chrMod = -3;
                        break;
                    case 5:
                        PlayingCharacter.chrMod = -3;
                        break;
                    case 6:
                        PlayingCharacter.chrMod = -2;
                        break;
                    case 7:
                        PlayingCharacter.chrMod = -2;
                        break;
                    case 8:
                        PlayingCharacter.chrMod = -1;
                        break;
                    case 9:
                        PlayingCharacter.chrMod = -1;
                        break;
                    case 10:
                        PlayingCharacter.chrMod = 0;
                        break;
                    case 11:
                        PlayingCharacter.chrMod = 0;
                        break;
                    case 12:
                        PlayingCharacter.chrMod = 1;
                        break;
                    case 13:
                        PlayingCharacter.chrMod = 1;
                        break;
                    case 14:
                        PlayingCharacter.chrMod = 2;
                        break;
                    case 15:
                        PlayingCharacter.chrMod = 2;
                        break;
                    case 16:
                        PlayingCharacter.chrMod = 3;
                        break;
                    case 17:
                        PlayingCharacter.chrMod = 3;
                        break;
                    case 18:
                        PlayingCharacter.chrMod = 4;
                        break;
                    case 19:
                        PlayingCharacter.chrMod = 4;
                        break;
                    case 20:
                        PlayingCharacter.chrMod = 5;
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
        if (PlayingCharacter.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                PlayingCharacter.Acrobatics += amount;
                playerAcrobaticsLevelAdditionValueText.text = amount.ToString();
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && PlayingCharacter.Acrobatics > PlayingCharacter.PlayerJob.Acrobatics)
            {
                PlayingCharacter.Acrobatics += amount;
                playerAcrobaticsLevelAdditionValueText.text = amount.ToString();
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
        if (PlayingCharacter.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                PlayingCharacter.AnimaHandling += amount;
                playerAnimalHLevelAdditionValueText.text = amount.ToString();
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && PlayingCharacter.AnimaHandling > PlayingCharacter.PlayerJob.AnimaHandling)
            {
                PlayingCharacter.AnimaHandling += amount;
                playerAnimalHLevelAdditionValueText.text = amount.ToString();
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
        if (PlayingCharacter.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                PlayingCharacter.Arcana += amount;
                playerArcanaLevelAdditionValueText.text = amount.ToString();
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && PlayingCharacter.Arcana > PlayingCharacter.PlayerJob.Arcana)
            {
                PlayingCharacter.Arcana += amount;
                playerArcanaLevelAdditionValueText.text = amount.ToString();
                jobPointstoSpend += 1;
                UpdateUI();

            }
            else
            {
                Debug.Log("No Class Chosen");
            }
        }
    }

    public void SetAthletics(int amount)
    {
        if (PlayingCharacter.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                PlayingCharacter.Athletics += amount;
                playerAthleticsLevelAdditionValueText.text = amount.ToString();
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && PlayingCharacter.Athletics > PlayingCharacter.PlayerJob.Athletics)
            {
                PlayingCharacter.Athletics += amount;
                playerAthleticsLevelAdditionValueText.text = amount.ToString();
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
        if (PlayingCharacter.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                PlayingCharacter.Deception += amount;
                playerDeceptionLevelAdditionValueText.text = amount.ToString();
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && PlayingCharacter.Deception > PlayingCharacter.PlayerJob.Deception)
            {
                PlayingCharacter.Deception += amount;
                playerDeceptionLevelAdditionValueText.text = amount.ToString();
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
        if (PlayingCharacter.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                PlayingCharacter.History += amount;
                playerHistooryLevelAdditionValueText.text = amount.ToString();
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && PlayingCharacter.History > PlayingCharacter.PlayerJob.History)
            {
                PlayingCharacter.History += amount;
                playerHistooryLevelAdditionValueText.text = amount.ToString();
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
        if (PlayingCharacter.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                PlayingCharacter.Insight += amount;
                playerInsightLevelAdditionValueText.text = amount.ToString();
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && PlayingCharacter.Insight > PlayingCharacter.PlayerJob.Insight)
            {
                PlayingCharacter.Insight += amount;
                playerInsightLevelAdditionValueText.text = amount.ToString();
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
        if (PlayingCharacter.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                PlayingCharacter.Intimidation += amount;
                playerIntimidationLevelAdditionValueText.text = amount.ToString();
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && PlayingCharacter.Intimidation > PlayingCharacter.PlayerJob.Intimidation)
            {
                PlayingCharacter.Intimidation += amount;
                playerIntimidationLevelAdditionValueText.text = amount.ToString();
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
        if (PlayingCharacter.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                PlayingCharacter.Investigation += amount;
                playerInvestigationLevelAdditionValueText.text = amount.ToString();
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && PlayingCharacter.Investigation > PlayingCharacter.PlayerJob.Investigation)
            {
                PlayingCharacter.Investigation += amount;
                playerInvestigationLevelAdditionValueText.text = amount.ToString();
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
        if (PlayingCharacter.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                PlayingCharacter.Medicine += amount;
                playerMedicineLevelAdditionValueText.text = amount.ToString();
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && PlayingCharacter.Medicine > PlayingCharacter.PlayerJob.Medicine)
            {
                PlayingCharacter.Medicine += amount;
                playerMedicineLevelAdditionValueText.text = amount.ToString();
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
        if (PlayingCharacter.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                PlayingCharacter.Nature += amount;
                playerNatureLevelAdditionValueText.text = amount.ToString();
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && PlayingCharacter.Nature > PlayingCharacter.PlayerJob.Nature)
            {
                PlayingCharacter.Nature += amount;
                playerNatureLevelAdditionValueText.text = amount.ToString();
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
        if (PlayingCharacter.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                PlayingCharacter.Perception += amount;
                playerPerceptionLevelAdditionValueText.text = amount.ToString();
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && PlayingCharacter.Perception > PlayingCharacter.PlayerJob.Perception)
            {
                PlayingCharacter.Perception += amount;
                playerPerceptionLevelAdditionValueText.text = amount.ToString();
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
        if (PlayingCharacter.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                PlayingCharacter.Performance += amount;
                playerPerformanceLevelAdditionValueText.text = amount.ToString();
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && PlayingCharacter.Performance > PlayingCharacter.PlayerJob.Performance)
            {
                PlayingCharacter.Performance += amount;
                playerPerformanceLevelAdditionValueText.text = amount.ToString();
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
        if (PlayingCharacter.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                PlayingCharacter.Persuasion += amount;
                playerPersuasionLevelAdditionValueText.text = amount.ToString();
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && PlayingCharacter.Persuasion > PlayingCharacter.PlayerJob.Persuasion)
            {
                PlayingCharacter.Persuasion += amount;
                playerPersuasionLevelAdditionValueText.text = amount.ToString();
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
        if (PlayingCharacter.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                PlayingCharacter.Religion += amount;
                playerReligionLevelAdditionValueText.text = amount.ToString();
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && PlayingCharacter.Religion > PlayingCharacter.PlayerJob.Religion)
            {
                PlayingCharacter.Religion += amount;
                playerReligionLevelAdditionValueText.text = amount.ToString();
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
        if (PlayingCharacter.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                PlayingCharacter.SlightOfHand += amount;
                playerSlightOfHandLevelAdditionValueText.text = amount.ToString();
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && PlayingCharacter.SlightOfHand > PlayingCharacter.PlayerJob.SlightOfHand)
            {
                PlayingCharacter.SlightOfHand += amount;
                playerSlightOfHandLevelAdditionValueText.text = amount.ToString();
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
        if (PlayingCharacter.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                PlayingCharacter.Stealth += amount;
                playerStealthLevelAdditionValueText.text = amount.ToString();
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && PlayingCharacter.Stealth > PlayingCharacter.PlayerJob.Stealth)
            {
                PlayingCharacter.Stealth += amount;
                playerStealthLevelAdditionValueText.text = amount.ToString();
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
        if (PlayingCharacter.PlayerJob != null)
        {
            if (amount > 0 && jobPointstoSpend > 0)
            {
                PlayingCharacter.Survival += amount;
                playerSurvivalLevelAdditionValueText.text = amount.ToString();
                jobPointstoSpend -= 1;
                UpdateUI();

            }
            else if (amount < 0 && PlayingCharacter.Survival > PlayingCharacter.PlayerJob.Survival)
            {
                PlayingCharacter.Survival += amount;
                playerSurvivalLevelAdditionValueText.text = amount.ToString();
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

    #endregion


    public void LoadSTuff()
    {
        LoadInfo.LoadALLInfo();
        playerStats.CalculateCharacter();
    }
}
