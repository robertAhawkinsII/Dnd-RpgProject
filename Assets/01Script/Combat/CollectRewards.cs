using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectRewards : MonoBehaviour
{
    [SerializeField]
    private float experience;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CollectReward()
    {
        GameObject[] livingPlayers = GameObject.FindGameObjectsWithTag("Player");
        float experiencePerUnit = experience / livingPlayers.Length;

        foreach(GameObject playerUnit in livingPlayers)
        {
            playerUnit.GetComponent<CharacterStats>().GainExperience(experience);
        }
        Destroy(gameObject);
    }

    public void ExperienceManagement(float totalEXP)
    {
        experience += totalEXP;
    }
}
