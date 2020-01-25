using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI characterName;
    [SerializeField]
    private TextMeshProUGUI characterHealth;
    [SerializeField]
    private TextMeshProUGUI characterAC;
    [SerializeField]
    private TextMeshProUGUI characterLvl;
    [SerializeField]
    private Image characterPortrait;

    [SerializeField]
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        characterName.text = GameInfo.PlayerName;

        for (int i = 0; i < player.GetComponent<CharacterStats>().attributes.Length; i++)
        {
            switch (player.GetComponent<CharacterStats>().attributes[i].type)
            {
                case Atributes.MaxHP:
                    characterHealth.text = "HP :" + player.GetComponent<CharacterStats>().attributes[i].value.ModifiedValue;                   
                    break;
                case Atributes.AC:
                    characterAC.text = "AC :" + player.GetComponent<CharacterStats>().attributes[i].value.ModifiedValue;
                   
                    break;
            }
        }
       characterLvl.text = "Lvl: " + player.GetComponent<CharacterStats>().characterLevel.RuntimeValue.ToString();
        //characterPortrait?
    }
}
