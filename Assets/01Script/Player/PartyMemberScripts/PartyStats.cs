using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PartyStats : MonoBehaviour
{

    public int inishitiveRoll;  

    [SerializeField]
    private IntValue characterMaxHealth;
    
    [SerializeField]
    public IntValue characterHealth;

    [SerializeField]
    private IntValue aC;

    [SerializeField]
    IntValue Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma, Level;
    
    public int strBounes;
    public int dexBounes;
    public int conBounes;
    public int intBounes;
    public int wisBounes;
    public int chaBounes;

    public int raceHealthBonus;

    //public int MaxSpeed;
    //public float speed; //speed = random.range(1, 20) + (dexMod * 5);

    public string MemberName;
    public int actionsTaken;
    public int MaxactionsTakable;


    [SerializeField]
    private GameObject damageTextPrefab;

    [SerializeField]
    private GameObject statusTextPrefab;

    [SerializeField]
    private Vector2 damageTextPosition;

    [SerializeField]
    private GameObject cameraFocus;

    public bool isAlive;

    public IntValue CharacterLevel;
    public FloatValue characterLevelAmassed;
    public FloatValue experience;
    public FloatValue experienceNeeded;

    [SerializeField]
    private GameObject BattleUI;

    [SerializeField]
    private BattleStatRelayer statRelayer;

    [SerializeField]
    private PartyBattleInfo battleInfo;


    public List<TickBuff> BuffList = new List<TickBuff>();


    // Start is called before the first frame update
    void Start()
    {

    }
    

    void CalculateHealth()
    {
        characterMaxHealth.initialValue = raceHealthBonus + conBounes;
        //statRelayer.isDead = !isAlive;
    }

    void CalculateAC()
    {
        aC.initialValue = 10 + dexBounes;
    }

    void CalculatePlayer()
    {
        //CharacterLevel = 1;//change to character spacific float values later
        //experience.RuntimeValue = experience.initialValue;
        //experienceNeeded.RuntimeValue = experienceNeeded.initialValue;
    }

    public void GainExperience(float expValue)
    {
        //experience.RuntimeValue += expValue;
        //if (experience.RuntimeValue >= experienceNeeded.RuntimeValue)
        //{
        //    EXPEvaluation();
        //}
    }

    public void CalculateBattleComponents()
    {
        //actionsTaken = MaxactionsTakable;
        //MaxSpeed = 30 + (dexBounes * 5);
        //speed = MaxSpeed;
    }

    public GameObject levelSplashScreen;

    void EXPEvaluation()
    {

        characterLevelAmassed.RuntimeValue += 1;
        CharacterLevel.initialValue += 1;
        if (characterLevelAmassed.RuntimeValue < 5)
        {
            //PlayerMenuSetUp.Instance.LevelUpSkillsOnly(); change this to another level up screen later
            experience.RuntimeValue = experience.initialValue;
            levelSplashScreen.GetComponent<LevelUpSplashScreenDisplay>().LevelUPSplashUP();
        }
        else if (characterLevelAmassed.RuntimeValue >= 5)
        {
            //PlayerMenuSetUp.Instance.LevelUpStatsandSkills(); change this to another level up screen later
            characterLevelAmassed.RuntimeValue = characterLevelAmassed.initialValue;
            experience.RuntimeValue = experience.initialValue;
            levelSplashScreen.GetComponent<LevelUpSplashScreenDisplay>().LevelUPSplashUP();
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStatBounuses();
    }

    void UpdateStatBounuses()
    {
        switch (Strength.initialValue)
        {
            case 0:
                strBounes = -5;
                break;
            case 1:
                strBounes = -5;
                break;
            case 2:
                strBounes = -4;
                break;
            case 3:
                strBounes = -4;
                break;
            case 4:
                strBounes = -3;
                break;
            case 5:
                strBounes = -3;
                break;
            case 6:
                strBounes = -2;
                break;
            case 7:
                strBounes = -2;
                break;
            case 8:
                strBounes = -1;
                break;
            case 9:
                strBounes = -1;
                break;
            case 10:
                strBounes = 0;
                break;
            case 11:
                strBounes = 0;
                break;
            case 12:
                strBounes = 1;
                break;
            case 13:
                strBounes = 1;
                break;
            case 14:
                strBounes = 2;
                break;
            case 15:
                strBounes = 2;
                break;
            case 16:
                strBounes = 3;
                break;
            case 17:
                strBounes = 3;
                break;
            case 18:
                strBounes = 4;
                break;
            case 19:
                strBounes = 4;
                break;
            case 20:
                strBounes = 5;
                break;
            case 21:
                strBounes = 5;
                break;
            case 22:
                strBounes = 6;
                break;
            case 23:
                strBounes = 6;
                break;
            case 24:
                strBounes = 7;
                break;
            case 25:
                strBounes = 7;
                break;
            case 26:
                strBounes = 8;
                break;
            case 27:
                strBounes = 8;
                break;
            case 28:
                strBounes = 9;
                break;
            case 29:
                strBounes = 9;
                break;
            case 30:
                strBounes = 10;
                Strength.initialValue = 30;
                break;
        }
        switch (Dexterity.initialValue)
        {
            case 0:
                dexBounes = -5;
                break;
            case 1:
                dexBounes = -5;
                break;
            case 2:
                dexBounes = -4;
                break;
            case 3:
                dexBounes = -4;
                break;
            case 4:
                dexBounes = -3;
                break;
            case 5:
                dexBounes = -3;
                break;
            case 6:
                dexBounes = -2;
                break;
            case 7:
                dexBounes = -2;
                break;
            case 8:
                dexBounes = -1;
                break;
            case 9:
                dexBounes = -1;
                break;
            case 10:
                dexBounes = 0;
                break;
            case 11:
                dexBounes = 0;
                break;
            case 12:
                dexBounes = 1;
                break;
            case 13:
                dexBounes = 1;
                break;
            case 14:
                dexBounes = 2;
                break;
            case 15:
                dexBounes = 2;
                break;
            case 16:
                dexBounes = 3;
                break;
            case 17:
                dexBounes = 3;
                break;
            case 18:
                dexBounes = 4;
                break;
            case 19:
                dexBounes = 4;
                break;
            case 20:
                dexBounes = 5;
                break;
            case 21:
                dexBounes = 5;
                break;
            case 22:
                dexBounes = 6;
                break;
            case 23:
                dexBounes = 6;
                break;
            case 24:
                dexBounes = 7;
                break;
            case 25:
                dexBounes = 7;
                break;
            case 26:
                dexBounes = 8;
                break;
            case 27:
                dexBounes = 8;
                break;
            case 28:
                dexBounes = 9;
                break;
            case 29:
                dexBounes = 9;
                break;
            case 30:
                dexBounes = 10;
                Dexterity.initialValue = 30;
                break;
        }
        switch (Constitution.initialValue)
        {
            case 0:
                conBounes = -5;
                break;
            case 1:
                conBounes = -5;
                break;
            case 2:
                conBounes = -4;
                break;
            case 3:
                conBounes = -4;
                break;
            case 4:
                conBounes = -3;
                break;
            case 5:
                conBounes = -3;
                break;
            case 6:
                conBounes = -2;
                break;
            case 7:
                conBounes = -2;
                break;
            case 8:
                conBounes = -1;
                break;
            case 9:
                conBounes = -1;
                break;
            case 10:
                conBounes = 0;
                break;
            case 11:
                conBounes = 0;
                break;
            case 12:
                conBounes = 1;
                break;
            case 13:
                conBounes = 1;
                break;
            case 14:
                conBounes = 2;
                break;
            case 15:
                conBounes = 2;
                break;
            case 16:
                conBounes = 3;
                break;
            case 17:
                conBounes = 3;
                break;
            case 18:
                conBounes = 4;
                break;
            case 19:
                conBounes = 4;
                break;
            case 20:
                conBounes = 5;
                break;
            case 21:
                conBounes = 5;
                break;
            case 22:
                conBounes = 6;
                break;
            case 23:
                conBounes = 6;
                break;
            case 24:
                conBounes = 7;
                break;
            case 25:
                conBounes = 7;
                break;
            case 26:
                conBounes = 8;
                break;
            case 27:
                conBounes = 8;
                break;
            case 28:
                conBounes = 9;
                break;
            case 29:
                conBounes = 9;
                break;
            case 30:
                conBounes = 10;
                Constitution.initialValue = 30;
                break;
        }
        switch (Intelligence.initialValue)
        {
            case 0:
                intBounes = -5;
                break;
            case 1:
                intBounes = -5;
                break;
            case 2:
                intBounes = -4;
                break;
            case 3:
                intBounes = -4;
                break;
            case 4:
                intBounes = -3;
                break;
            case 5:
                intBounes = -3;
                break;
            case 6:
                intBounes = -2;
                break;
            case 7:
                intBounes = -2;
                break;
            case 8:
                intBounes = -1;
                break;
            case 9:
                intBounes = -1;
                break;
            case 10:
                intBounes = 0;
                break;
            case 11:
                intBounes = 0;
                break;
            case 12:
                intBounes = 1;
                break;
            case 13:
                intBounes = 1;
                break;
            case 14:
                intBounes = 2;
                break;
            case 15:
                intBounes = 2;
                break;
            case 16:
                intBounes = 3;
                break;
            case 17:
                intBounes = 3;
                break;
            case 18:
                intBounes = 4;
                break;
            case 19:
                intBounes = 4;
                break;
            case 20:
                intBounes = 5;
                break;
            case 21:
                intBounes = 5;
                break;
            case 22:
                intBounes = 6;
                break;
            case 23:
                intBounes = 6;
                break;
            case 24:
                intBounes = 7;
                break;
            case 25:
                intBounes = 7;
                break;
            case 26:
                intBounes = 8;
                break;
            case 27:
                intBounes = 8;
                break;
            case 28:
                intBounes = 9;
                break;
            case 29:
                intBounes = 9;
                break;
            case 30:
                intBounes = 10;
                Intelligence.initialValue = 30;
                break;
        }
        switch (Wisdom.initialValue)
        {
            case 0:
                wisBounes = -5;
                break;
            case 1:
                wisBounes = -5;
                break;
            case 2:
                wisBounes = -4;
                break;
            case 3:
                wisBounes = -4;
                break;
            case 4:
                wisBounes = -3;
                break;
            case 5:
                wisBounes = -3;
                break;
            case 6:
                wisBounes = -2;
                break;
            case 7:
                wisBounes = -2;
                break;
            case 8:
                wisBounes = -1;
                break;
            case 9:
                wisBounes = -1;
                break;
            case 10:
                wisBounes = 0;
                break;
            case 11:
                wisBounes = 0;
                break;
            case 12:
                wisBounes = 1;
                break;
            case 13:
                wisBounes = 1;
                break;
            case 14:
                wisBounes = 2;
                break;
            case 15:
                wisBounes = 2;
                break;
            case 16:
                wisBounes = 3;
                break;
            case 17:
                wisBounes = 3;
                break;
            case 18:
                wisBounes = 4;
                break;
            case 19:
                wisBounes = 4;
                break;
            case 20:
                wisBounes = 5;
                break;
            case 21:
                wisBounes = 5;
                break;
            case 22:
                wisBounes = 6;
                break;
            case 23:
                wisBounes = 6;
                break;
            case 24:
                wisBounes = 7;
                break;
            case 25:
                wisBounes = 7;
                break;
            case 26:
                wisBounes = 8;
                break;
            case 27:
                wisBounes = 8;
                break;
            case 28:
                wisBounes = 9;
                break;
            case 29:
                wisBounes = 9;
                break;
            case 30:
                wisBounes = 10;
                Wisdom.initialValue = 30;
                break;
        }
        switch (Charisma.initialValue)
        {
            case 0:
                chaBounes = -5;
                break;
            case 1:
                chaBounes = -5;
                break;
            case 2:
                chaBounes = -4;
                break;
            case 3:
                chaBounes = -4;
                break;
            case 4:
                chaBounes = -3;
                break;
            case 5:
                chaBounes = -3;
                break;
            case 6:
                chaBounes = -2;
                break;
            case 7:
                chaBounes = -2;
                break;
            case 8:
                chaBounes = -1;
                break;
            case 9:
                chaBounes = -1;
                break;
            case 10:
                chaBounes = 0;
                break;
            case 11:
                chaBounes = 0;
                break;
            case 12:
                chaBounes = 1;
                break;
            case 13:
                chaBounes = 1;
                break;
            case 14:
                chaBounes = 2;
                break;
            case 15:
                chaBounes = 2;
                break;
            case 16:
                chaBounes = 3;
                break;
            case 17:
                chaBounes = 3;
                break;
            case 18:
                chaBounes = 4;
                break;
            case 19:
                chaBounes = 4;
                break;
            case 20:
                chaBounes = 5;
                break;
            case 21:
                chaBounes = 5;
                break;
            case 22:
                chaBounes = 6;
                break;
            case 23:
                chaBounes = 6;
                break;
            case 24:
                chaBounes = 7;
                break;
            case 25:
                chaBounes = 7;
                break;
            case 26:
                chaBounes = 8;
                break;
            case 27:
                chaBounes = 8;
                break;
            case 28:
                chaBounes = 9;
                break;
            case 29:
                chaBounes = 9;
                break;
            case 30:
                chaBounes = 10;
                Charisma.initialValue = 30;
                break;
        }
    }

    public void ReceiveDamage(int attack)
    {
        if (attack <= 0)
        {
            attack = 0;
        }
        //anim.TakeDamage
        //characterHealth -= attack;
        //statRelayer.isDead = !isAlive;

        GameObject playerHud = GameObject.Find("BattleGameCanvas");
        GameObject damageText = Instantiate(damageTextPrefab, playerHud.transform);
        damageText.GetComponent<TextMeshProUGUI>().text = "" + Mathf.FloorToInt(attack);
        damageText.transform.localPosition = damageTextPosition;
        damageText.transform.localScale = Vector2.one;
        Destroy(damageText.gameObject, 1f);

        //if (Charactercondition == BattleCondition.Casting)
        //{
        //    Charactercondition = BattleCondition.Stunned;
        //    GameObject statsText = Instantiate(statusTextPrefab, playerHud.transform); //change to StatusText
        //    statsText.GetComponent<TextMeshProUGUI>().text = "Stunned!";
        //    statsText.transform.localPosition = damageTextPosition;
        //    statsText.transform.localScale = Vector2.one;
        //    Destroy(statsText.gameObject, 1f);
        //}
        //
        //if (characterHealth <= 0)
        //{
        //    //Knock Out
        //}
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

    public int InishitiveRoll { get => inishitiveRoll; set => inishitiveRoll = value; }


    public void RollInishitive(int diceValue)
    {
        inishitiveRoll = diceValue;
        battleInfo.NotPlayersTurn();
    }

    //public void TurnStart()
    //{
    //
    //    switch (Charactercondition)
    //    {
    //        case BattleCondition.Normal:
    //            actionsTaken = MaxactionsTakable;
    //            speed = MaxSpeed;
    //            BattleUI.SetActive(true);
    //            for (int i = 0; i < BuffList.Count; i++)
    //            {
    //                if (i > 0)
    //                {
    //                    BuffList[i].Tick();
    //                }
    //            }
    //            break;
    //        case BattleCondition.Casting:
    //            actionsTaken = MaxactionsTakable;
    //            speed = MaxSpeed;
    //            BattleUI.SetActive(true);
    //            break;
    //        case BattleCondition.Frightened:
    //            actionsTaken = MaxactionsTakable;
    //            speed = MaxSpeed;
    //            //displySavingDice();
    //            //make frightend void
    //            break;
    //        case BattleCondition.Grapple:
    //            actionsTaken = MaxactionsTakable;
    //            speed = 0;
    //            BattleUI.SetActive(true);
    //            break;
    //        case BattleCondition.Incapacitated:
    //            speed = MaxSpeed;
    //            actionsTaken = 0;
    //            break;
    //        case BattleCondition.Paralized:
    //            Savingthrow();
    //            break;
    //        case BattleCondition.Prone:
    //            speed = MaxSpeed;
    //            actionsTaken = MaxactionsTakable / 2;
    //            //startGetUp Void
    //            break;
    //        case BattleCondition.Restrained:
    //            speed = 0;
    //
    //            break;
    //        case BattleCondition.Stunned:
    //            speed = 0;
    //            actionsTaken = 1;
    //            break;
    //        case BattleCondition.Unconscious:
    //            //displaysavingDice();
    //            break;
    //    }
    //    battleInfo.TurnStart();
    //}
    //
    ////for Future Spells
    //public void ContributeToCasting(int spellCost)
    //{
    //    actionsTaken -= spellCost;
    //    if (actionsTaken <= 0)
    //    {
    //        actionsTaken = 0;
    //    }
    //}

    public void DisplaySavingDice()
    {

    }

    public void Savingthrow()
    {
        int saveRoll = UnityEngine.Random.Range(1, 21);
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

}
