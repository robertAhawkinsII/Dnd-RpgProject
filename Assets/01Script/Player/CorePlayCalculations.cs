using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CorePlayCalculations : MonoBehaviour
{
    public Sprite PortraitIcon;

    [SerializeField]
    public IntValue playerMaxHealth;

    [SerializeField]
    private IntValue playerHealth;

    [SerializeField]
    private FloatValue playerStomach, playerThirst;

    [SerializeField]
    private int playerWeight;

    [SerializeField]
    private IntValue aC;

    public int AC { get => aC.initialValue; set => aC.initialValue = value; }
    public int PlayerHealth { get => playerHealth.RuntimeValue; set => playerHealth.RuntimeValue = value; }
    
    [SerializeField]
    private GameObject damageTextPrefab;

    [SerializeField]
    private GameObject statusTextPrefab;

    [SerializeField]
    private Vector3 damageTextPosition;

    public InventoryObject inventory, equipment;

    public bool isAlive
    {
        get
        {
            return PlayerHealth > -10;
        }
    }

    public bool hasAParty = false;

    private bool isdead = false;

    public bool isDead()
    {
        return isdead;
    }

    [SerializeField]
    private BattleStatRelayer statRelayer;

    [SerializeField]
    private PlayerBattleInfo battleInfo;

    // Level Up
    public int PlayerLevel;
    public FloatValue playerLevelAmassed;
    public FloatValue experience;
    public FloatValue experienceNeeded;

    /// for Battle stuff
    public bool isMainCharacter;
    public int MaxSpeed;
    public float speed; 
    public int actionsTaken;
    public int MaxactionsTakable;

    public IntValue Maxcarryweight;
    public FloatValue carryWeight;

    [SerializeField]
    private GameObject BattleUI;

    public bool inBattle;

    public List<TickBuff> BuffList = new List<TickBuff>();

    public void Start()
    {
        CalculateAC();
        CalculatePlayer();
        CalculateBattleComponents();
    
    }

    

    public void CalculateFood(float cals)//change this to food managment
    {
        playerStomach.RuntimeValue += cals;
    }

    public void CalculateDrinks(float gal)//change this to food managment
    {

        playerThirst.RuntimeValue += gal;
    }

    void CalculateAC()
    {
        aC.RuntimeValue = aC.initialValue;
    }


  

    void CalculatePlayer()
    {
        PlayerLevel = GameInfo.PlayerLevel;
        experienceNeeded.RuntimeValue = experienceNeeded.initialValue;

        playerWeight = GameInfo.characterWeight;

        Maxcarryweight.RuntimeValue = (GameInfo.Strength * 15);
        for (int i = 0; i < equipment.GetSlots.Length; i++)
        {
            equipment.GetSlots[i].SetCharacterClass(GameInfo.setClass); // changethis to the character class when the overhaul happens
        }
    }


    public void carryCapasityCalculations()
    {        
        if(carryWeight.RuntimeValue >= Maxcarryweight.RuntimeValue * 5)
        {
            //add debuf encumbered
            //remove debuf heavily encumbered
        }
        else if(carryWeight.RuntimeValue >= Maxcarryweight.RuntimeValue * 10)
        {
            //add debuf heavily encumbered
            //remove debuf encumbered
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

    public void CalculateBattleComponents()
    {
        actionsTaken = MaxactionsTakable;
        MaxSpeed = 30 + (GameInfo.dexMod * 5);
        speed = MaxSpeed;
    }

    public GameObject levelSplashScreen;

    void EXPEvaluation()
    {

            playerLevelAmassed.RuntimeValue += 1;
            PlayerLevel += 1;
            if(playerLevelAmassed.RuntimeValue < 5)
            {
                PlayerMenuSetUp.Instance.LevelUpSkillsOnly();
                experience.RuntimeValue = experience.initialValue;
                levelSplashScreen.GetComponent<LevelUpSplashScreenDisplay>().LevelUPSplashUP();
            }
            else if(playerLevelAmassed.RuntimeValue >= 5)
            {
                PlayerMenuSetUp.Instance.LevelUpStatsandSkills();
                playerLevelAmassed.RuntimeValue = playerLevelAmassed.initialValue;
                experience.RuntimeValue = experience.initialValue;
                levelSplashScreen.GetComponent<LevelUpSplashScreenDisplay>().LevelUPSplashUP();
            }
        experienceNeeded.initialValue = experienceNeeded.initialValue * 3;
        experienceNeeded.RuntimeValue = experienceNeeded.initialValue;
    }

    public void ReceiveDamage(int attack)
    {
        if(attack <= 0)
        {
            attack = 0;
        }
        //anim.TakeDamage
        playerHealth.RuntimeValue -= attack;

        GameObject playerHud = GameObject.Find("BattleGameCanvas");
        GameObject damageText = Instantiate(damageTextPrefab, playerHud.transform);
        damageText.GetComponent<TextMeshProUGUI>().text = "" + Mathf.FloorToInt(attack);
        damageText.transform.localPosition = damageTextPosition;
        damageText.transform.localScale = Vector2.one;
        Destroy(damageText.gameObject, 1f);

        if(Charactercondition == BattleCondition.Casting)
        {
            Charactercondition = BattleCondition.Stunned;
            //GameObject playerHud = GameObject.Find("BattleGameCanvas");
            //GameObject damageText = Instantiate(damageTextPrefab, playerHud.transform); //change to StatusText
            //damageText.GetComponent<TextMeshProUGUI>().text = "Stunned!";
            //damageText.transform.localPosition = damageTextPosition;
            //damageText.transform.localScale = Vector2.one;
            //Destroy(damageText.gameObject, 1f);
        }

        if (playerHealth.RuntimeValue <= -10)
        {
            GameOver();
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

    void GameOver()
    {

    }

    
    private int inishitiveRoll;

    public int InishitiveRoll { get => inishitiveRoll; set => inishitiveRoll = value; }


    public void RollInishitive(int diceValue)
    {
        inishitiveRoll = diceValue;
        battleInfo.NotPlayersTurn();
    }

    public void TurnStart()
    {

        switch (Charactercondition)
        {
            case BattleCondition.Normal:
                actionsTaken = MaxactionsTakable;
                speed = MaxSpeed;
                BattleUI.SetActive(true);
                for (int i = 0; i < BuffList.Count; i++)
                {
                    if(i > 0)
                    {
                        BuffList[i].Tick();
                    }
                }
                break;
            case BattleCondition.Casting:
                actionsTaken = MaxactionsTakable;
                speed = MaxSpeed;
                BattleUI.SetActive(true);
                break;
            case BattleCondition.Frightened:
                actionsTaken = MaxactionsTakable;
                speed = MaxSpeed;
                //displySavingDice();
                //make frightend void
                break;
            case BattleCondition.Grapple:
                actionsTaken = MaxactionsTakable;
                speed = 0;
                BattleUI.SetActive(true);
                break;
            case BattleCondition.Incapacitated:
                speed = MaxSpeed;
                actionsTaken = 0;
                break;
            case BattleCondition.Paralized:
                Savingthrow();
                break;
            case BattleCondition.Prone:
                speed = MaxSpeed;
                actionsTaken = MaxactionsTakable / 2;
                //startGetUp Void
                break;
            case BattleCondition.Restrained:
                speed = 0;

                break;
            case BattleCondition.Stunned:
                speed = 0;
                actionsTaken = 1;
                break;
            case BattleCondition.Unconscious:
                //displaysavingDice();
                break;
        }
        battleInfo.TurnStart();
    }

    //for Future Spells
    public void ContributeToCasting(int spellCost)
    {
        actionsTaken -= spellCost;
        if(actionsTaken <=0)
        {
            actionsTaken = 0;
        }
    }

    public void DisplaySavingDice()
    {

    }

    public void Savingthrow()
    {
        int saveRoll = Random.Range(1, 21);
        switch (Charactercondition)
        {
            case BattleCondition.Frightened:

                break;
            case BattleCondition.Grapple:
                break;
            case BattleCondition.Paralized:
                break;
            case BattleCondition.Restrained:
                break;
            case BattleCondition.Unconscious:
                break;
        }
        
    }

    IEnumerator PassedSave()
    {
        yield return new WaitForSeconds(1f);
        switch (Charactercondition)
        {
            case BattleCondition.Frightened:

                break;
            case BattleCondition.Grapple:
                break;
            case BattleCondition.Paralized:
                break;
            case BattleCondition.Restrained:
                break;
            case BattleCondition.Unconscious:
                break;
        }
    }

    IEnumerator FailedSave()
    {
        yield return new WaitForSeconds(1f);

    }

    public void TurnOver()
    {
        BattleUI.SetActive(false);

    }

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


    private void OnApplicationQuit()
    {
        inventory.Clear();
        equipment.Clear();
    }
}
