using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyBattleInfo : MonoBehaviour
{
    [SerializeField]
    public PartyStats partyCore;

    [SerializeField]
    public PlayerMovementControles partyMove;

    public bool attacking;

    [SerializeField]
    private GameObject characterRep;

    public Image speedBar;
    public Vector3 lastPosition;
    [SerializeField]
    private Transform resetPosition;
    float distancedMoved;

    ///[SerializeField]
    ///private GameObject resetButton;

    void Start()
    {
        partyCore = this.gameObject.GetComponent<PartyStats>();
        partyMove = this.gameObject.GetComponent<PlayerMovementControles>();
        lastPosition = characterRep.transform.position;
    }
    // Update is called once per frame
    void Update()
    {

        PlayerBattleMovement();

        UpdateUI();
    }

    public void NotPlayersTurn()
    {
        //partyCore.speed = 0;
        //partyCore.actionsTaken = 0;
        partyCore.TurnOver();
    }

    public void TurnStart()
    {
        lastPosition = characterRep.transform.position;
    }

    public void TurnActrionsCalculations()
    {
        //if (partyCore.speed <= 0 && partyCore.actionsTaken <= 0)
        //{
        //    EndTurn();
        //}
    }
    void PlayerBattleMovement()
    {
        //if (partyCore.speed <= 0 || attacking == true && partyCore.actionsTaken <= 0)
        //{
        //    partyMove.canMove = false;
        //}
        //else
        //{
        //    partyMove.canMove = true;
        //}
        //if (partyMove.canMove == true)
        //{
        //    distancedMoved += Vector3.Distance(characterRep.transform.position, lastPosition);
        //    partyCore.speed -= partyMove.anim.GetFloat("Speed") / 45;
        //}
    }

    public void EndTurn()
    {
        GameObject.Find("BattleManager").GetComponent<BattleManager>().WaitThenNextTurn();
        NotPlayersTurn();
    }

    void UpdateUI()
    {
        //speedBar.fillAmount = partyCore.speed / partyCore.MaxSpeed;
    }
}
