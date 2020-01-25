using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RunFromBattle : MonoBehaviour
{
    [SerializeField]
    public float runtimeNeeded;

    [SerializeField]
    public float runningtime;

    [SerializeField]
    PlayerBattleInfo playerinquestion;

    [SerializeField]
    private GameObject RunUIPrefab;


    private void OnTriggerEnter(Collider other)
    {
        RunUIPrefab.gameObject.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            playerinquestion = other.GetComponent<PlayerBattleInfo>();
            if(playerinquestion.playMove.canMove == true)
            {
              runningtime += (playerinquestion.playMove.anim.GetFloat("Speed") / 60);
            }


            if (runningtime >= runtimeNeeded)
            {
                //Ienumorator for Whiting out and loading the previous scene also run noise
                GameManager.instance.LoadSceneAfterRunning();
                GameManager.instance.gameState = GameManager.GameStates.World_State;
                GameManager.instance.enemiesToBattle.Clear();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            RunUIPrefab.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if(playerinquestion != null)
        {
          RunUIPrefab.transform.localPosition = new Vector3(-3.5f, 1.5f, playerinquestion.gameObject.transform.position.z );
        }
    }
}
