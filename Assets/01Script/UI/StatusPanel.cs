using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusPanel : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI HPText, ACText, attackTypeText;

    [SerializeField]
    GameObject setCharacter;

    [SerializeField]
    GameObject textObj;

    [SerializeField]
    GameObject PlayerStsDisplayPanel;

    // Start is called before the first frame update
    void Start()
    {
        setCharacter = GameObject.Find("Player");
        SetCharacterValues(setCharacter);
    }

    public void SetCharacterValues(GameObject character)
    {
        for (int i = 0; i < setCharacter.GetComponent<CharacterStats>().attributes.Length; i++)
        {
            switch (setCharacter.GetComponent<CharacterStats>().attributes[i].type)
            {          
                default:
                case Atributes.MaxHP:
                    HPText.text = "HP: " + setCharacter.GetComponent<CharacterStats>().attributes[i].value.ModifiedValue;
                    break;
                case Atributes.AC:
                    ACText.text = "AC: " + setCharacter.GetComponent<CharacterStats>().attributes[i].value.ModifiedValue;
                    break;
            }
            
        }
    }

    public void SetPartMember()
    {
        
    }
}
