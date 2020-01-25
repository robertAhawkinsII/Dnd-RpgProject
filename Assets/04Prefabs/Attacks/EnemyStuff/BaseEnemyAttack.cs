using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyAttack : MonoBehaviour
{

    public GameObject owner;

    [SerializeField]
    private string attackAnimation;

    public float Distance_;
    public float DisadvantageDistance;


    public int actionCost;

    private int attackValue;

    [SerializeField]
    private int damageRoll;

    [SerializeField]
    private int advantageDieRoll;
    [SerializeField]
    private int dieRoll;
    [SerializeField]
    public int DisadvantageDieRoll;

    public int usedRoll;

    [SerializeField]
    private int diceLimit;

    [SerializeField]
    private bool hasDebuff;

    public void StartAttacck()
    {
        if (Distance_ <= DisadvantageDistance)
        {
            if (Distance_ <= DisadvantageDistance / 2)
            {
                CritAttackRoll();
                Debug.Log("advantage");
            }
            else
            {
                AttackRoll();
                Debug.Log("Normal");
            }

        }
        else
        {
            DisadvatageAttackRoll();
            Debug.Log("DisAd");
        }
    }

    public void CritAttackRoll()
    {
        dieRoll = Random.Range(1, 21);
        advantageDieRoll = Random.Range(1, 21);
        
        if (dieRoll >= advantageDieRoll)
        {
            usedRoll = dieRoll;

        }
        else
        {
            usedRoll = advantageDieRoll;
        }
        Hit(owner.GetComponent<EnemyTurnAI>().heroTarget);
    }

    public void AttackRoll()
    {
        dieRoll = Random.Range(1, 21);
        
        usedRoll = dieRoll;
        Hit(owner.GetComponent<EnemyTurnAI>().heroTarget);
    }

    public void DisadvatageAttackRoll()
    {
        dieRoll = Random.Range(1, 21);
        DisadvantageDieRoll = Random.Range(1, 21);
        
        if (dieRoll <= DisadvantageDieRoll)
        {
            usedRoll = dieRoll;
        }
        else if (DisadvantageDieRoll <= dieRoll)
        {
            usedRoll = DisadvantageDieRoll;
        }
        //change to Ienumorator to do attack animation and then finalize the damage
        Hit(owner.GetComponent<EnemyTurnAI>().heroTarget);
    }

    public void Hit(GameObject target)
    {
        EnemieBaseStats ownerStats = owner.GetComponent<EnemieBaseStats>();
        CharacterStats targetStats = target.GetComponent<CharacterStats>();

        if(ownerStats.actionsTaken >= ownerStats.MaxactionsTakable)
        {
            damageRoll = Random.Range(1, diceLimit);

            //owner.Animation play attack
            for (int i = 0; i < targetStats.attributes.Length; i++)
            {
                switch (targetStats.attributes[i].type)
                {
                    case Atributes.AC:
                        Debug.Log("enemy attacks against characters " + targetStats.attributes[i].type + "that has a total of " + targetStats.attributes[i].value.ModifiedValue);
                        if (usedRoll > targetStats.attributes[i].value.ModifiedValue)
                        {                           
                            targetStats.ReceiveDamage(damageRoll + ownerStats.strBounes);//change to a switch system for eisier customization;
                            StatusImplimentation(target);
                        }
                        else if (usedRoll <= targetStats.attributes[i].value.ModifiedValue)
                        {
                            ownerStats.MissedAttack();
                        }
                        break;
                    default:
                        break;
                }
            }
            


            ownerStats.actionsTaken--;
        }
    }

    //for making the player character go through different effects
    public virtual void StatusImplimentation(GameObject victim)
    {
        ///victim.CharacterCondition = BattleCondition.StatofChoice
    }
}
