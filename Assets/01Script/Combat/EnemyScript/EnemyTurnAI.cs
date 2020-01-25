using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Linq;

public class EnemyTurnAI : MonoBehaviour
{
    [SerializeField]
    private GameObject attackPrefab;

    [SerializeField]
    private string targetsTag;

    private GameObject attack;

    [SerializeField]
    private EnemieBaseStats thisMob;

    public NavMeshAgent agent;

    [SerializeField]
    private float movementTime;

    public Image speedBar;
    Vector3 lastPosition;
    float distancedMoved;

    [SerializeField] private float speedX = 5;
    [SerializeField] private float speedY = 5;
    public Animator anim;

    [SerializeField]
    private Vector3 moveVector;


    [SerializeField]
    private bool activeTurn;

    public GameObject heroTarget;

    private enum TurnState
    {
        Waiting,
        Processing,
        ChooseAction,
        Attack,
        Resolution,

    }

    private TurnState currentState;

    private void Awake()
    {
        attack = Instantiate(attackPrefab);
        attack.GetComponent<BaseEnemyAttack>().owner = thisMob.gameObject;
    }

    private GameObject FindRandomTarget()
    {
        GameObject[] target1 = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] target2 = GameObject.FindGameObjectsWithTag("Player"/*"PartyMember"*/);
        GameObject[] possibleTargets = target1.Concat(target2).ToArray();

        if(possibleTargets.Length > 0)
        {
            return possibleTargets[Random.Range(0, possibleTargets.Length)];
        }
        else
        {
            return null;
        }
    }


    public void BeginningTurn()
    {
        GameObject target = FindRandomTarget();

        heroTarget = target;

        activeTurn = true;

        currentState = TurnState.ChooseAction;

    }



    public void Move()
    {
        float distance = Vector3.Distance(heroTarget.transform.position, transform.position);
        agent.isStopped = false;
        agent.SetDestination(heroTarget.transform.position);
        anim?.SetFloat("Speed", moveVector.magnitude);
        MobBattleMovement();
        if (distance <= agent.stoppingDistance)
        {
            currentState = TurnState.Attack;
        }
        else if(thisMob.speed <= 0)
        {
            agent.isStopped = true;
            currentState = TurnState.Resolution;
        }
    }


    public void MobBattleMovement()
    {
        if (thisMob.CanMove == true)
        {
            distancedMoved += Vector3.Distance(this.transform.position, lastPosition);
            thisMob.speed -= movementTime * Time.deltaTime;
        }
    }

    public void SetAttacks()
    {
        attack.GetComponent<BaseEnemyAttack>().StartAttacck();
        currentState = TurnState.Resolution;
    }

    public void EndTurn()
    {
        thisMob.TurnOver();
        GameObject.Find("BattleManager").GetComponent<BattleManager>().WaitThenNextTurn();
        currentState = TurnState.Waiting;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = new Vector3( speedX, 0, speedY);
        this.gameObject.transform.rotation = Quaternion.identity;
        switch (currentState)
        {
            case (TurnState.Waiting):

                break;
            case (TurnState.Processing):
                BeginningTurn();
                break;
            case (TurnState.ChooseAction):
                Move();
                break;
            case (TurnState.Attack):
                SetAttacks();
                break;
            case (TurnState.Resolution):
                EndTurn();
                break;
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        speedBar.fillAmount = thisMob.speed / thisMob.MaxSpeed;
    }
}
