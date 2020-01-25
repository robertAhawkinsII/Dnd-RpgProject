using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PerceptionRoomCheck : MonoBehaviour
{
    [Header("In Game Checks")]
    [SerializeField]
    private BoolValue hasBeenChecked;

    [SerializeField]
    private bool checkdone;//change to bool value later

    [SerializeField]
    private LookableObjects[] objectsForCheck;

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
    public int diceValueInvest;
    public int diceValuePer;
    #endregion

    [SerializeField]
    private GameObject rollOptionBox;

    [SerializeField]
    private GameObject DiePanel;

    private bool rollChecking = false;

    [SerializeField]
    private GameObject rollmenubutton;
    [SerializeField]
    private GameObject checkButtons1;
    [SerializeField]
    private GameObject checkButtons2;

    private void Awake()
    {
        rollmenubutton.GetComponent<FloorSearchCheck>().roomToCheck = this.gameObject;
        checkButtons1.GetComponent<FloorSearchCheck>().roomToCheck = this.gameObject;
        checkButtons2.GetComponent<FloorSearchCheck>().roomToCheck = this.gameObject;
    }

    public void DisplayRollOptions()
    {
        rollChecking = !rollChecking;
        rollOptionBox.SetActive(rollChecking);
    }


    public void DiceRoleEventForInvestigation()
    {
        diceValueInvest = Random.Range(1, 21);
        #region ImageSwitching
        if (diceValueInvest == 1)
        {
            diceOBJ.sprite = Dice1;
        }
        if (diceValueInvest == 2)
        {
            diceOBJ.sprite = Dice2;
        }
        if (diceValueInvest == 3)
        {
            diceOBJ.sprite = Dice3;
        }
        if (diceValueInvest == 4)
        {
            diceOBJ.sprite = Dice4;
        }
        if (diceValueInvest == 5)
        {
            diceOBJ.sprite = Dice5;
        }
        if (diceValueInvest == 6)
        {
            diceOBJ.sprite = Dice6;
        }
        if (diceValueInvest == 7)
        {
            diceOBJ.sprite = Dice7;
        }
        if (diceValueInvest == 8)
        {
            diceOBJ.sprite = Dice8;
        }
        if (diceValueInvest == 9)
        {
            diceOBJ.sprite = Dice9;
        }
        if (diceValueInvest == 10)
        {
            diceOBJ.sprite = Dice10;
        }
        if (diceValueInvest == 11)
        {
            diceOBJ.sprite = Dice11;
        }
        if (diceValueInvest == 12)
        {
            diceOBJ.sprite = Dice12;
        }
        if (diceValueInvest == 13)
        {
            diceOBJ.sprite = Dice13;
        }
        if (diceValueInvest == 14)
        {
            diceOBJ.sprite = Dice14;
        }
        if (diceValueInvest == 15)
        {
            diceOBJ.sprite = Dice15;
        }
        if (diceValueInvest == 16)
        {
            diceOBJ.sprite = Dice16;
        }
        if (diceValueInvest == 17)
        {
            diceOBJ.sprite = Dice17;
        }
        if (diceValueInvest == 18)
        {
            diceOBJ.sprite = Dice18;
        }
        if (diceValueInvest == 19)
        {
            diceOBJ.sprite = Dice19;
        }
        if (diceValueInvest == 20)
        {
            diceOBJ.sprite = Dice20;
        }
        #endregion

        StartCoroutine(InvestigationCheck());
        checkdone = true;
        hasBeenChecked.RuntimeValue = true;
    }

    IEnumerator InvestigationCheck()
    {
        yield return new WaitForSeconds(0.01f);
        SkillCheckInvestigation(diceValueInvest);
        yield return new WaitForSeconds(0.5f);
        ChecOnThisRoom(hasBeenChecked.RuntimeValue);
    }


    public void SkillCheckInvestigation(int roll)
    {
        for (int i = 0; i < objectsForCheck.Length; i++)
        {
            if (roll == 20)
            {
                objectsForCheck[i].CanBeSurched();
            }

            else 
            {
                objectsForCheck[i].CheckRoll(roll + GameInfo.Investigation + GameInfo.intMod);
            }

            if (roll == 1)
            {
               
            }
        }
    }

    public void DiceRoleEventForPerception()
    {
        diceValueInvest = Random.Range(1, 21);
        #region ImageSwitching
        if (diceValueInvest == 1)
        {
            diceOBJ.sprite = Dice1;
        }
        if (diceValueInvest == 2)
        {
            diceOBJ.sprite = Dice2;
        }
        if (diceValueInvest == 3)
        {
            diceOBJ.sprite = Dice3;
        }
        if (diceValueInvest == 4)
        {
            diceOBJ.sprite = Dice4;
        }
        if (diceValueInvest == 5)
        {
            diceOBJ.sprite = Dice5;
        }
        if (diceValueInvest == 6)
        {
            diceOBJ.sprite = Dice6;
        }
        if (diceValueInvest == 7)
        {
            diceOBJ.sprite = Dice7;
        }
        if (diceValueInvest == 8)
        {
            diceOBJ.sprite = Dice8;
        }
        if (diceValueInvest == 9)
        {
            diceOBJ.sprite = Dice9;
        }
        if (diceValueInvest == 10)
        {
            diceOBJ.sprite = Dice10;
        }
        if (diceValueInvest == 11)
        {
            diceOBJ.sprite = Dice11;
        }
        if (diceValueInvest == 12)
        {
            diceOBJ.sprite = Dice12;
        }
        if (diceValueInvest == 13)
        {
            diceOBJ.sprite = Dice13;
        }
        if (diceValueInvest == 14)
        {
            diceOBJ.sprite = Dice14;
        }
        if (diceValueInvest == 15)
        {
            diceOBJ.sprite = Dice15;
        }
        if (diceValueInvest == 16)
        {
            diceOBJ.sprite = Dice16;
        }
        if (diceValueInvest == 17)
        {
            diceOBJ.sprite = Dice17;
        }
        if (diceValueInvest == 18)
        {
            diceOBJ.sprite = Dice18;
        }
        if (diceValueInvest == 19)
        {
            diceOBJ.sprite = Dice19;
        }
        if (diceValueInvest == 20)
        {
            diceOBJ.sprite = Dice20;
        }
        #endregion

        StartCoroutine(PerceptionCheck());
        checkdone = true;
        hasBeenChecked.RuntimeValue = true;
    }

    IEnumerator PerceptionCheck()
    {
        yield return new WaitForSeconds(0.01f);
        SkillCheckPerception(diceValuePer);
        yield return new WaitForSeconds(0.0f);
        ChecOnThisRoom(hasBeenChecked.RuntimeValue);
    }

    public void SkillCheckPerception(int roll)
    {
        for (int i = 0; i < objectsForCheck.Length; i++)
        {
            if (roll == 20)
            {
                objectsForCheck[i].CanBeSurched();
            }

            else
            {
                objectsForCheck[i].CheckRoll(roll + GameInfo.Investigation + GameInfo.intMod);
            }

            if (roll == 1)
            {

            }
        }
    }

    public void ChecOnThisRoom(bool completion)
    {
        if(completion == true)
        {
            DiePanel.SetActive(false);
        }
        else
        {
            DiePanel.SetActive(true);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChecOnThisRoom(hasBeenChecked.RuntimeValue);
            rollmenubutton.GetComponent<FloorSearchCheck>().roomToCheck = this.gameObject;
            checkButtons1.GetComponent<FloorSearchCheck>().roomToCheck = this.gameObject;
            checkButtons2.GetComponent<FloorSearchCheck>().roomToCheck = this.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DiePanel.SetActive(false);
        }
    }
}
