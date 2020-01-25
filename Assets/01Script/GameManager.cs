using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //Class for enemyEncounters
    [System.Serializable]
    public class EncounterData
    {
        public string encounterName;
        public int maxAmountEnemies = 5;
        public List<GameObject> possibleEncounters = new List<GameObject>();
        public string BattleScene;
    }

    public int curEncounter;

    public List<EncounterData> Encounters = new List<EncounterData>();

    public GameObject playerCharacter;


    public Vector3 nextPlayerPosition;
    public Vector3 lastPlayerPosition;//for Battle

    public string SceneToLoad;
    public string LastScene;//for battle

    public bool gotAttacked = false;

    public enum GameStates
    {
        World_State,
        Town_State,//in NPC zones
        Battle_State,
        Idle
    }

    public int enemeyAmount;
    public List<GameObject> enemiesToBattle = new List<GameObject>();

    public GameStates gameState;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        LoadInfo.LoadALLInfo();

        if (!GameObject.Find("Player"))
        {
            GameObject Player = Instantiate(playerCharacter, Vector3.zero, Quaternion.identity) as GameObject;
            Player.name = "Player";
        }
    }

    private void Update()
    {
        switch (gameState)
        {
            case (GameStates.World_State):
                if (gotAttacked)
                {
                    gameState = GameStates.Battle_State;
                }
                break;
            case (GameStates.Town_State):

                break;
            case (GameStates.Battle_State):
                //LoadBattleScene
                StartBattle();
                //Go to Idle
                gameState = GameStates.Idle;
                break;
            case (GameStates.Idle):

                break;
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void LoadSceneAfterBattle()
    {
        nextPlayerPosition = lastPlayerPosition;
        SceneManager.LoadScene(LastScene);
        playerCharacter.GetComponent<PlayerMovementControles>().results = PlayerMovementControles.battleResults.Victory;        
    }

    public void LoadSceneAfterRunning()
    {
        nextPlayerPosition = lastPlayerPosition;
        SceneManager.LoadScene(LastScene);
        playerCharacter.GetComponent<PlayerMovementControles>().results = PlayerMovementControles.battleResults.Flee;
    }

    public void BattleEncounter()
    {
        gotAttacked = true;
    }

    void StartBattle()
    {
        enemeyAmount = Random.Range(1, Encounters[curEncounter].maxAmountEnemies + 1);
        //which enemies to spawn
        for (int i = 0; i < enemeyAmount; i++)
        {
            enemiesToBattle.Add(Encounters[curEncounter].possibleEncounters[Random.Range(0, Encounters[curEncounter].possibleEncounters.Count)]);
        }

        lastPlayerPosition = GameObject.Find("Player").gameObject.transform.position;
        
        LastScene = SceneManager.GetActiveScene().name;

        //LoadBattleScene
        SceneManager.LoadScene(Encounters[curEncounter].BattleScene);
        //reset Player
        gotAttacked = false;
    }

   
}
