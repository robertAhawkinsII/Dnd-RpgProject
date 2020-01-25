using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemieBaseStats : MonoBehaviour
{
    public int inishitiveRoll;

    [SerializeField]
    private int mobMaxHealth;

    [SerializeField]
    public int mobHealth;

    [SerializeField]
    private EnemyTurnAI mobBrain;

    [SerializeField]
    private int aC;

    public int MobMaxHealth { get => mobMaxHealth; set => mobMaxHealth = value; }
    public int AC { get => aC; set => aC = value; }

    public string EnemyName;

    public int strBounes;
    public int dexBounes;
    public int conBounes;
    public int intBounes;
    public int wisBounes;
    public int chaBounes;

    public int MaxSpeed;
    public float speed; //speed = random.range(1, 20) + (dexMod * 5);
    public int actionsTaken;
    public int MaxactionsTakable;

    [SerializeField]
    private GameObject damageTextPrefab;

    [SerializeField]
    private Vector2 damageTextPosition;

    [SerializeField]
    private GameObject cameraFocus;


    public List<TickBuff> BuffList = new List<TickBuff>();

    public bool CanMove
    {
        get
        {
            return speed > 0;
        }
    }

    public bool IsTurn
    {
        get
        {
            return speed > 0 && actionsTaken > 0;
        }
    }

    public bool isAlive
    {
        get
        {
            return mobHealth > 0;
        }
    }

    [SerializeField]
    private BattleStatRelayer statRelayer;

    [SerializeField]
    private float expValue;


    public void receiveDamage(int damage)
    {
        //anim.TakeDamage
        mobHealth -= damage;
        statRelayer.isDead = !isAlive;

        GameObject enemyHud = GameObject.Find("BattleGameCanvas");
        GameObject damageText = Instantiate(damageTextPrefab, enemyHud.transform);
        damageText.GetComponent<TextMeshProUGUI>().text = "" + Mathf.FloorToInt(damage);
        damageText.transform.localPosition = damageTextPosition;
        damageText.transform.localScale = Vector2.one;
        Destroy(damageText.gameObject, 1f);
        if (mobHealth <= 0)
        {
            gameObject.tag = "DeadUnit";
            Destroy(gameObject);
        }
    }

    public void MissedAttack()
    {
        GameObject enemyHud = GameObject.Find("BattleGameCanvas");
        GameObject damageText = Instantiate(damageTextPrefab, enemyHud.transform);
        damageText.GetComponent<TextMeshProUGUI>().text = "MISS";
        damageText.transform.localPosition = damageTextPosition;
        damageText.transform.localScale = Vector2.one;
        Destroy(damageText.gameObject, 1f);
    }

    void InishitiveRoll()
    {
        inishitiveRoll = Random.Range(1 , 21) + dexBounes;
    }

    private void Awake()
    {
        InishitiveRoll();
        MaxSpeed = Random.Range(1, 21) + (dexBounes * 5);
        statRelayer.isDead = !isAlive;
    }

    public void StartTurn()
    {
        actionsTaken = MaxactionsTakable;
        speed = MaxSpeed;
        mobBrain.BeginningTurn();
        cameraFocus.SetActive(true);
        for (int i = 0; i < BuffList.Count; i++)
        {
            if (i > 0)
            {
                BuffList[i].Tick();
            }
        }
    }

    public void removeDeBuff(TickBuff debuff)
    {
        if (debuff.canSaveAgainst)
        {

        }
        else
        {

        }
    }

    public void TurnOver()
    {
        cameraFocus.SetActive(false);
    }

    public enum PersonalBattleCondition
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

    public PersonalBattleCondition Charactercondition;
}
