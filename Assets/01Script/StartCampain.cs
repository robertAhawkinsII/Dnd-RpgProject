using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCampain : MonoBehaviour
{

    [SerializeField]
    public IntValue playerMaxHealth;

    [SerializeField]
    private IntValue playerHealth, PlayerAC;


    [SerializeField]
    private BoolValue Campaingstarted;
    ///To Do List
    ///2. Player Inventory Set up for Inventory scriptable obj
    ///3.

    [SerializeField]
    InventoryObject playerInventory;

    [SerializeField]
    private InventoryObject AcolyteSet, BrawlerSet, CharlatanSet, CriminalSet, EntertainerSet,
        ExcomunicatedPolitionSet, FolkHeroSet, GuildArtisanSet, HermitSet, HopfulDoctorSet, HunterSet, MaraderSet,
        NobleSet, OutlanderSet, PotionMixer, RecoveringAssassingSet, SageSet, SailorSet, SoldierSet, UrchinSet;

    private void Awake()
    {
        //playerInventory = GameObject.Find("Player").GetComponent<Inventory>();
        if(Campaingstarted.RuntimeValue == false)
        {
            StartCoroutine(CampaingStarting());
        }
        else
        {
            CampainStartEvaluationComplete();
        }
    }

    IEnumerator CampaingStarting()
    {
        //CalculateHealth();
        //CalculateAC();
        CharacterInventorySetUP();
        yield return new WaitForSeconds(.03f);
        Campaingstarted.RuntimeValue = true;
        yield return new WaitForSeconds(.03f);
        CampainStartEvaluationComplete();
    }

    public void CampainStartEvaluationComplete()
    {
        Destroy(this.gameObject);
    }


    public void CalculateHealth()
    {
        switch (GameInfo.setClass)
        {
            case (PlayerClass.Barbarian):
                playerMaxHealth.initialValue = 12 + GameInfo.conMod;
                break;
            case (PlayerClass.Bard):
                playerMaxHealth.initialValue = 8 + GameInfo.conMod;
                break;
            case (PlayerClass.Cleric):
                playerMaxHealth.initialValue = 8 + GameInfo.conMod;
                break;
            case (PlayerClass.Druid):
                playerMaxHealth.initialValue = 8 + GameInfo.conMod;
                break;
            case (PlayerClass.Fighter):
                playerMaxHealth.initialValue = 10 + GameInfo.conMod;
                break;
            case (PlayerClass.Monk):
                playerMaxHealth.initialValue = 8 + GameInfo.conMod;
                break;
            case (PlayerClass.Palidin):
                playerMaxHealth.initialValue = 10 + GameInfo.conMod;
                break;
            case (PlayerClass.Ranger):
                playerMaxHealth.initialValue = 10 + GameInfo.conMod;
                break;
            case (PlayerClass.Rouge):
                playerMaxHealth.initialValue = 8 + GameInfo.conMod;
                break;
            case (PlayerClass.Scorcerer):
                playerMaxHealth.initialValue = 6 + GameInfo.conMod;
                break;
            case (PlayerClass.Warlock):
                playerMaxHealth.initialValue = 8 + GameInfo.conMod;
                break;
            case (PlayerClass.Wizard):
                playerMaxHealth.initialValue = 6 + GameInfo.conMod;
                break;
        }
        playerHealth.initialValue = playerMaxHealth.initialValue;
        playerHealth.RuntimeValue = playerHealth.initialValue;
    }

    void CalculateAC()
    {
        PlayerAC.initialValue = 10 + GameInfo.dexMod;
    }

    void CharacterInventorySetUP()
    {
        //inventory addition based on class
        switch (GameInfo.setJobs)
        {
            case (PlayerJobs.Acolyte):
                    playerInventory.SetStartItems(AcolyteSet.Container);
                break;
            case (PlayerJobs.Brawler):
                    playerInventory.SetStartItems(BrawlerSet.Container);
                break;
            case (PlayerJobs.Charlatan):
                    playerInventory.SetStartItems(CharlatanSet.Container);

                break;
            case (PlayerJobs.Criminal):
                    playerInventory.SetStartItems(CriminalSet.Container);
                break;
            case (PlayerJobs.Entertainer):
                    playerInventory.SetStartItems(EntertainerSet.Container);
                break;
            case (PlayerJobs.ExcomunicatedPolition):
                    playerInventory.SetStartItems(ExcomunicatedPolitionSet.Container);
                break;
            case (PlayerJobs.FolkHero):
                    playerInventory.SetStartItems(FolkHeroSet.Container);
                break;
            case (PlayerJobs.GuildArtisan):
                    playerInventory.SetStartItems(GuildArtisanSet.Container);
                break;
            case (PlayerJobs.Hermit):
                    playerInventory.SetStartItems(HermitSet.Container);
                break;
            case (PlayerJobs.HopfulDoctor):
                    playerInventory.SetStartItems(HopfulDoctorSet.Container);
                break;
            case (PlayerJobs.Hunter):
                    playerInventory.SetStartItems(HunterSet.Container);
                break;
            case (PlayerJobs.Marader):
                    playerInventory.SetStartItems(MaraderSet.Container);
                break;
            case (PlayerJobs.Noble):
                    playerInventory.SetStartItems(NobleSet.Container);
                break;
            case (PlayerJobs.Outlander):
                    playerInventory.SetStartItems(OutlanderSet.Container);
                break;
            case (PlayerJobs.PotionMixer):
                    playerInventory.SetStartItems(PotionMixer.Container);
                break;
            case (PlayerJobs.RecoveringAssassin):
                    playerInventory.SetStartItems(RecoveringAssassingSet.Container);
                break;
            case (PlayerJobs.Sailor):
                    playerInventory.SetStartItems(SailorSet.Container);
                break;
            case (PlayerJobs.Sage):
                    playerInventory.SetStartItems(SageSet.Container);
                break;
            case (PlayerJobs.Soldier):
                    playerInventory.SetStartItems(SoldierSet.Container);
                break;
            case (PlayerJobs.Urchin):
                    playerInventory.SetStartItems(UrchinSet.Container);
                break;
        }
    }
}
