using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

[System.Serializable]
public class BaseAttack : MonoBehaviour
{
    [SerializeField]
    private enum WeaponType
    {
        Stregth,
        Dexterity,
        base1D4AttackSTR,
        base1D4AttackDEX,
        base2D4AttackSTR,
        base2D4AttackDEX
    }

    [SerializeField]
    WeaponType weaponType;

    [SerializeField]
    string attackType;

    public Transform fireingPoint;
    public GameObject attackTarget;

    [SerializeField]
    private List<GameObject> selectableEnemies;

    [SerializeField]
    private GameObject HitCalculationUI;

    [SerializeField]
    private GameObject enemyCamera;

    [SerializeField]
    private GameObject hitCalculation;

    public float Distance_;
    public float DisadvantageDistance;


    public int actionCost;

    private int attackValue;

    [SerializeField]
    private int firstD4roll , secondD4roll, D20Roll;

    [SerializeField]
    private int advantageDieRoll;
    [SerializeField]
    private int dieRoll;
    [SerializeField]
    public int DisadvantageDieRoll;

    public int usedRoll;

    public LineRenderer targetingLine;

    [SerializeField]
    private GameObject CombatOptionsCanvas;

    [SerializeField]
    private PlayerBattleInfo mPlayer; // Hero character for futurePartyUse


    ///Enemy selectingValue
    private int targNum;

    int TargLenght;


    private void Start()
    {
        selectableEnemies = new List<GameObject>();
        CheckOnEnemies();
        TargLenght = selectableEnemies.Count;
        attackTarget = selectableEnemies[targNum];
       
    }

    private void Update()
    {
        
    }

    public void AttackEstimation()
    {
        

            if (mPlayer.playerCore.actionsTaken > 0)
            {
                Distance_ = Vector3.Distance(fireingPoint.position, attackTarget.transform.position);

                hitCalculation = Instantiate(HitCalculationUI, attackTarget.transform.position, Quaternion.identity);
                CombatOptionsCanvas.SetActive(true);
                CombatOptionsCanvas.transform.position = hitCalculation.transform.position;
                mPlayer.attacking = true;
                if (Distance_ <= DisadvantageDistance)
                {
                    if (Distance_ <= DisadvantageDistance / 2)
                    {
                        hitCalculation.GetComponent<HitCalculatorPanel>().RollTypeText.text = "Advantage";
                    }
                    else
                    {
                        hitCalculation.GetComponent<HitCalculatorPanel>().RollTypeText.text = "Normal";
                    }

                }
                else
                {
                    hitCalculation.GetComponent<HitCalculatorPanel>().RollTypeText.text = "Disadvantage";
                }

                hitCalculation.GetComponent<HitCalculatorPanel>().enemyNameText.text = attackTarget.GetComponent<EnemieBaseStats>().EnemyName;
                enemyCamera = attackTarget.transform.GetChild(0).gameObject;//changeit to cinimachine later

                enemyCamera.SetActive(true);

                targetingLine.SetPosition(0, fireingPoint.position);

                targetingLine.SetPosition(1, attackTarget.transform.position);
                targetingLine.enabled = true;
            }
            else if (mPlayer.playerCore.speed <= 0 && mPlayer.playerCore.actionsTaken <= 0)
            {
                mPlayer.TurnActrionsCalculations();
            }
    }

    public void DisengageAttack()
    {
        enemyCamera.SetActive(false);
        targetingLine.enabled = false;
        Destroy(hitCalculation);
        mPlayer.attacking = false;
        CombatOptionsCanvas.SetActive(false);
    }

    public void StartAttacck()
    {       
        if(Distance_ <= DisadvantageDistance)
        {
            if(Distance_ <= DisadvantageDistance / 2)
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
        hitCalculation.GetComponent<HitCalculatorPanel>().NormalDiceRoleEvent(dieRoll);
        hitCalculation.GetComponent<HitCalculatorPanel>().AdvantDiceRoleEvent(advantageDieRoll);
        if (dieRoll>= advantageDieRoll)
        {
            usedRoll = dieRoll;

        }
        else
        {
            usedRoll = advantageDieRoll;
        }
        hitCalculation.GetComponent<HitCalculatorPanel>().ACRollNumber.text = "" + usedRoll;
        StartCoroutine(clerafyAttack());
    }

    public void AttackRoll()
    {
        dieRoll = Random.Range(1, 21);
        hitCalculation.GetComponent<HitCalculatorPanel>().NormalDiceRoleEvent(dieRoll);
        usedRoll = dieRoll;
        hitCalculation.GetComponent<HitCalculatorPanel>().ACRollNumber.text = "" + usedRoll;
        StartCoroutine(clerafyAttack());
    }

    public void DisadvatageAttackRoll()
    {
        dieRoll = Random.Range(1, 21);
        DisadvantageDieRoll = Random.Range(1, 21);
        hitCalculation.GetComponent<HitCalculatorPanel>().NormalDiceRoleEvent(dieRoll);
        hitCalculation.GetComponent<HitCalculatorPanel>().AdvantDiceRoleEvent(DisadvantageDieRoll);
        if (dieRoll <= DisadvantageDieRoll)
        {
            usedRoll = dieRoll;
        }
        else if (DisadvantageDieRoll <= dieRoll)
        {
            usedRoll = DisadvantageDieRoll;
        }
        hitCalculation.GetComponent<HitCalculatorPanel>().ACRollNumber.text = "" + usedRoll;
        StartCoroutine(clerafyAttack());
        //change to Ienumorator to do attack animation and then finalize the damage
    }

    IEnumerator clerafyAttack()
    {

        yield return new WaitForSeconds(1f);
        FinalizeAttack();
    }

    public void FinalizeAttack()
    {
        firstD4roll = Random.Range(1, 5);
        secondD4roll = Random.Range(1, 5);
        D20Roll = Random.Range(1, 21);
        if(usedRoll != 0)
        {
            if(attackTarget.tag == "Enemy")
            {
                switch (weaponType)
                {//changeLater
                    case (WeaponType.Stregth):
                        attackValue = D20Roll + GameInfo.strMod;
                        break;
                    case (WeaponType.Dexterity):
                        attackValue = D20Roll + GameInfo.dexMod;
                        break;
                    case (WeaponType.base1D4AttackSTR):
                        attackValue = firstD4roll + GameInfo.strMod;
                        break;
                    case (WeaponType.base1D4AttackDEX):
                        attackValue = firstD4roll + GameInfo.dexMod;
                        break;
                    case (WeaponType.base2D4AttackSTR):
                        attackValue = firstD4roll + secondD4roll + GameInfo.strMod;
                        break;
                    case (WeaponType.base2D4AttackDEX):
                        attackValue = firstD4roll + secondD4roll + GameInfo.dexMod;
                        break;
                }
                if(usedRoll > attackTarget.GetComponent<EnemieBaseStats>().AC)
                {
                    attackTarget.GetComponent<EnemieBaseStats>().receiveDamage(attackValue);
                    DisengageAttack();

                    if(attackTarget.GetComponent<EnemieBaseStats>().mobHealth <= 0)
                    {
                        NextTarget();
                        DisengageAttack();
                        CheckOnEnemies();
                    }

                    Debug.Log("Hit");                   
                }
                else if(usedRoll <= attackTarget.GetComponent<EnemieBaseStats>().AC)
                {
                    mPlayer.playerCore.Missattack();
                    Debug.Log("Miss");
                    DisengageAttack();
                }
                mPlayer.playerCore.actionsTaken--;
                mPlayer.TurnActrionsCalculations();
            }
        }
    }

    void CheckOnEnemies()
    {
        selectableEnemies.Clear();
        foreach (GameObject MobsAlive in GameObject.FindGameObjectsWithTag("Enemy"))
        {           
            selectableEnemies.Add(MobsAlive);
            TargLenght = selectableEnemies.Count;
        }
    }
   

    public void NextTarget()
    {
        targNum++;
        targNum = (targNum >= TargLenght) ? 0 : targNum;
        attackTarget = selectableEnemies[targNum];
        DisengageAttack();
        AttackEstimation();
    }

    public void PreviousTarget()
    {
        if(targNum <= 0)
        {
            targNum = TargLenght - 1;
        }
        else
        {
            targNum--;
        }
        attackTarget = selectableEnemies[targNum];
        DisengageAttack();
        AttackEstimation();
    }
}
