using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private GameObject InishitiveRollDie;

    public List<Transform> playerPosistions;
    public List<Transform> enemyPosistions = new List<Transform>();

    private List<PlayerCombatants> players;
    private List<EnemyCombatants> mobs;

    public GameObject enemyEncounter;

    [SerializeField]
    public List<BattleStatRelayer> moveOrder;

    [SerializeField] public GameObject[] enemySpawnPositions;
    [SerializeField] private GameObject[] playerSpawnPositions;

    private GameObject turnorderDisplay;

    public static BattleManager instance;

    void Awake()
    {
        if (instance = null)
        {
            instance = this;
        }

        for (int i = 0; i < enemySpawnPositions.Length; i++)
        {
            enemyPosistions.Add(enemySpawnPositions[i].transform);
        }

        for (int i = 0; i < GameManager.instance.enemeyAmount; i++)
        {
            GameObject NewEnemy = Instantiate(GameManager.instance.enemiesToBattle[i], enemyPosistions[i].position, Quaternion.identity) as GameObject;
            NewEnemy.name = NewEnemy.GetComponent<EnemieBaseStats>().EnemyName + "_" + (i+1);
            NewEnemy.GetComponent<EnemieBaseStats>().EnemyName = NewEnemy.name;
            
        }

        //PartyMember Spawns

        for (int i = 0; i < playerSpawnPositions.Length; i++)
        {
            playerPosistions.Add(playerSpawnPositions[i].transform);
        }
        for (int i = 0; i < PartyManager.instance.partyNumber; i++)
        {
            GameObject NewCharacter = Instantiate(PartyManager.instance.PartyMembers[i], playerPosistions[i].position, Quaternion.identity) as GameObject;
            //NewCharacter.name = NewCharacter.GetComponent<PartyStats>().MemberName;
            //NewCharacter.GetComponent<PartyStats>().MemberName = NewCharacter.name;
        }
    }

    private void Start()
    {
        moveOrder = new List<BattleStatRelayer>();
        
        playerSpawnPositions = GameObject.FindGameObjectsWithTag("PlayerSpawnPoint");//change to ally spawn point later for a party system       
        enemySpawnPositions = GameObject.FindGameObjectsWithTag("PlayerSpawnPoint");
        turnorderDisplay = GameObject.Find("TurnOrderPanel");
    
    }

   

    public bool PlayerAlive
    {
        get
        {
            foreach (PlayerCombatants player in players)
            {
                if (player.stats.isAlive)
                    return true;
            }
            return false;
        }
    }

    public bool EnemiesAlive
    {
        get
        {
            foreach (EnemyCombatants enemy in mobs)
            {
                if (enemy.eStats.isAlive)
                    return true;
            }
            return false;
        }
    }

    public bool inBattle
    {
        get { return PlayerAlive && EnemiesAlive; }
    }
    

    public event Action OnCombatStart;


    public void StartCombat (CharacterStats[] players, PartyStats[] members, EnemieBaseStats[] enemies)
    {
        for (int i = 0; i < players.Length; i++)
        {
            if(i < playerPosistions.Count)
            {
                players[i].transform.position = playerPosistions[i].position;
                PlayerCombatants pc = new PlayerCombatants(players[i], players[i].transform);
                this.players.Add(pc);
            }
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            if (i < enemyPosistions.Count)
            {
                enemies[i].transform.position = enemyPosistions[i].position;
                EnemyCombatants mob = new EnemyCombatants(enemies[i], enemies[i].transform);
                this.mobs.Add(mob);
            }
        }
        StartCoroutine(TakeInInishitive());
    }

    public void InishiateComBat()
    {
        StartCoroutine(TakeInInishitive());
    }

    IEnumerator TakeInInishitive()
    {
        yield return new WaitForSeconds(.3f);
        InishitiveRollDie.SetActive(false);        
        yield return new WaitForSeconds(.5f);
        setUpCharacterOrder();
    }

    public void setUpCharacterOrder()
    {
            GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("Player");

            foreach (GameObject playerUnit in playerUnits)
            {
                BattleStatRelayer currentUnitStats = playerUnit.GetComponent<BattleStatRelayer>();
                currentUnitStats.CalculateNextActTurn(0);
                moveOrder.Add(currentUnitStats);
            }

            ///GameObject[] memberUnits = GameObject.FindGameObjectsWithTag("PartyMember");
            ///
            ///foreach (GameObject partyUnits in memberUnits)
            ///{
            ///    BattleStatRelayer currentUnitStats = partyUnits.GetComponent<BattleStatRelayer>();
            ///    currentUnitStats.CalculateNextActTurn(0);
            ///    moveOrder.Add(currentUnitStats);
            ///}         

            GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemyunit in enemyUnits)
            {
                BattleStatRelayer currentUnitStats = enemyunit.GetComponent<BattleStatRelayer>();
                currentUnitStats.CalculateNextActTurn(0);
                moveOrder.Add(currentUnitStats);
            }

            moveOrder.Sort();
            turnorderDisplay.GetComponent<InitiativeBar>().StartBattle();
            NextTurn();
    }

    public void NextTurn()
    {
        GameObject[] remainingEnemyUnits = GameObject.FindGameObjectsWithTag("Enemy");
        if(remainingEnemyUnits.Length == 0)
        {
            //enemyEncounter.GetComponent<CollectRewards>().CollectReward();

            GameManager.instance.LoadSceneAfterBattle();
            GameManager.instance.gameState = GameManager.GameStates.World_State;
            GameManager.instance.enemiesToBattle.Clear();
        }

        GameObject[] remainingPlayerUnits = GameObject.FindGameObjectsWithTag("Player");
        //GameObject[] remainingPartyMembers = GameObject.FindGameObjectsWithTag("PartyMember");
        
        if (remainingPlayerUnits.Length == 0 /*&& remainingPartyMembers.Length == 0*/)
        {
            //make and Ienumirator White out effect and then load title screen
            SceneManager.LoadScene("");
        }
        BattleStatRelayer currentUnitsStats = moveOrder[0];
        moveOrder.Remove(currentUnitsStats);
        turnorderDisplay.GetComponent<InitiativeBar>().UpdateBar();
        if (!currentUnitsStats.isDead)
        {
            GameObject currentUnit = currentUnitsStats.gameObject;

            currentUnitsStats.CalculateNextActTurn(currentUnitsStats.nextActTurn);
            moveOrder.Add(currentUnitsStats);
            moveOrder.Sort();

            if(currentUnit.tag == "Player")
            {
                currentUnit.GetComponent<CharacterStats>().TurnStart();
                Debug.Log("PlayerTurn");
            }
            else if (currentUnit.tag == "PartyMember")
            {
                //currentUnit.GetComponent<PartyStats>().TurnStart();
            }
            else
            {
                currentUnit.GetComponent<EnemieBaseStats>().StartTurn();
                Debug.Log("Enemy turn");
            }
        }
        else
        {
            NextTurn();
        }
    }

    public void WaitThenNextTurn()
    {
        StartCoroutine(WaitThenNextTurnRoutine());
    }

    IEnumerator WaitThenNextTurnRoutine()
    {
        yield return new WaitForSeconds(1.0f);
        NextTurn();
    }

    private struct PlayerCombatants
    {
        public CharacterStats stats;
        public Transform transform;
        public Animator anim;

        public PlayerCombatants(CharacterStats stats, Transform transform)
        {
            this.stats = stats;
            this.transform = transform;
            this.anim = transform.GetComponent<Animator>();
        }

        public PlayerCombatants(CharacterStats stats)
        {
            this.stats = stats;
            this.transform = stats.transform;
            this.anim = transform.GetComponent<Animator>();
        }
    }

    private struct EnemyCombatants
    {
        public EnemieBaseStats eStats;
        public Transform eTransform;
        public Animator anim;

        public EnemyCombatants(EnemieBaseStats EStats, Transform ETransform)
        {
            this.eStats = EStats;
            this.eTransform = ETransform;
            this.anim = eTransform.GetComponent<Animator>();
        }
        public EnemyCombatants(EnemieBaseStats EStats)
        {
            this.eStats = EStats;
            this.eTransform = EStats.transform;
            this.anim = eTransform.GetComponent<Animator>();
        }
    }
}