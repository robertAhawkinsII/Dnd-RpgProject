using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleInfo : ActorBattleInfo
{
    [SerializeField]
    public CharacterStats playerCore;

    [SerializeField]
    public PlayerMovementControles playMove;

    public bool attacking;

    [SerializeField]
    private GameObject playerRep;

    public Image speedBar;
    public Vector3 lastPosition;
    [SerializeField]
    private Transform resetPosition;
    float distancedMoved;

    ///[SerializeField]
    ///private GameObject resetButton;

    void Start()
    {
        playerCore = this.gameObject.GetComponent<CharacterStats>();
        playMove = this.gameObject.GetComponent<PlayerMovementControles>();
        lastPosition = playerRep.transform.position;
        NotPlayersTurn();
    }
    // Update is called once per frame
    void Update()
    {

        PlayerBattleMovement();

        UpdateUI();
    }

    public void NotPlayersTurn()
    {
        playerCore.speed = 0;
        playerCore.actionsTaken = 0;
        playerCore.TurnOver();
    }

    public void TurnStart()
    {
        lastPosition = playerRep.transform.position;
    }

    public void TurnActrionsCalculations()
    {
        if (playerCore.speed <= 0 && playerCore.actionsTaken <= 0)
        {
            EndTurn();
        }
    }
    void PlayerBattleMovement()
    {
        if (playerCore.speed <= 0 || attacking == true && playerCore.actionsTaken <= 0)
        {
            playMove.canMove = false;
        }
        else
        {
            playMove.canMove = true;
        }
        if(playMove.canMove == true)
        {
            distancedMoved += Vector3.Distance(playerRep.transform.position, lastPosition);
            playerCore.speed -= playMove.anim.GetFloat("Speed") / 45;
        }
    }

    public void EndTurn()
    {
        GameObject.Find("BattleManager").GetComponent<BattleManager>().WaitThenNextTurn();
        NotPlayersTurn();
    }

    ///public void ResetTurn()
    ///{
    ///
    ///        //make a screen black out fade
    ///        playerRep.transform.position = Vector3.MoveTowards(transform.position, resetPosition.position, Time.deltaTime;
    ///        playerCore.speed = playerCore.MaxSpeed;
    ///
    ///}
    void UpdateUI()
    {
        speedBar.fillAmount = playerCore.speed / playerCore.MaxSpeed;
        ///resetButton = GameObject.Find("ResetButton");
        ///if(playerCore.actionsTaken >= playerCore.MaxactionsTakable)
        ///{
        ///    resetButton.GetComponent<Button>().enabled = true;
        ///}
        ///else
        ///{
        ///    resetButton.GetComponent<Button>().enabled = false;
        ///}
    }
}
