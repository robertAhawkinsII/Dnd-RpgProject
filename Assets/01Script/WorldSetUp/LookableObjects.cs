using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookableObjects : MonoBehaviour
{


    [SerializeField]
    private Material outlinMat;

    public int perceptionCheckToBeat;

    public GameObject searchArea;

    public void CheckRoll(int rollValue)
    {
        if(rollValue > perceptionCheckToBeat)
        {
            CanBeSurched();
        }
    }

    public void CanBeSurched()
    {
        Debug.Log("roll Passed");
        //add a gloo highlight effect
        outlinMat.SetFloat("_Outline", 1.15f);
        searchArea.SetActive(true);
    }
}
