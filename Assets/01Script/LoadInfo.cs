using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInfo 
{
    public static void LoadALLInfo()
    {
        GameInfo.PlayerName = PlayerPrefs.GetString("PLAYERNAME");
        GameInfo.PlayerLevel = PlayerPrefs.GetInt("PLAYERLEVEL");
        GameInfo.characterWeight = PlayerPrefs.GetInt("PLAYERWEIGHT");
        GameInfo.characterHeight = PlayerPrefs.GetInt("PLAYERHEIGHT");
        //
        GameInfo.Strength = PlayerPrefs.GetInt("STREANGTH");
        GameInfo.Dexterity = PlayerPrefs.GetInt("DEXTERITY");
        GameInfo.Constitution = PlayerPrefs.GetInt("CONSTITUTION" );
        GameInfo.Intelligence = PlayerPrefs.GetInt("INTELLIGENCE" );
        GameInfo.Wisdom = PlayerPrefs.GetInt("WISDOM");
        GameInfo.Charisma = PlayerPrefs.GetInt("CHARISMA");
        //
        GameInfo.strMod = PlayerPrefs.GetInt("STREANGHTMOD");
        GameInfo.dexMod = PlayerPrefs.GetInt("DEXTERITYMOD");
        GameInfo.conMod = PlayerPrefs.GetInt("CONSTITUTIONMOD");
        GameInfo.intMod =PlayerPrefs.GetInt("INTELLIGENCEMOD");
        GameInfo.wisMod = PlayerPrefs.GetInt("WISDOMMOD");
        GameInfo.chrMod = PlayerPrefs.GetInt("CHARISMAMOD");
        //
         GameInfo.Acrobatics = PlayerPrefs.GetInt("ACROBATICS");
         GameInfo.AnimaHandling = PlayerPrefs.GetInt("ANIMALHANDILING");
         GameInfo.Arcana = PlayerPrefs.GetInt("ARCANA");
         GameInfo.Athletics = PlayerPrefs.GetInt("ATHLETICS");
         GameInfo.Deception = PlayerPrefs.GetInt("DECEPTION");
         GameInfo.History = PlayerPrefs.GetInt("HISTORY");
         GameInfo.Insight = PlayerPrefs.GetInt("INSIGHT");
         GameInfo.Intimidation = PlayerPrefs.GetInt("INTIMIDATION");
         GameInfo.Investigation = PlayerPrefs.GetInt("INVESTIGATION");
         GameInfo.Medicine = PlayerPrefs.GetInt("MEDICINE");
         GameInfo.Nature = PlayerPrefs.GetInt("NATURE");
         GameInfo.Perception = PlayerPrefs.GetInt("PERCEPTION");
         GameInfo.Performance = PlayerPrefs.GetInt("PERFORMANCE");
         GameInfo.Persuasion = PlayerPrefs.GetInt("PERSUASION");
         GameInfo.Religion = PlayerPrefs.GetInt("RELIGION");
         GameInfo.SlightOfHand = PlayerPrefs.GetInt("SLIGHTOFHAND");
         GameInfo.Survival = PlayerPrefs.GetInt("SURVIVAL");

         GameInfo.setClass = (PlayerClass)System.Enum.Parse(typeof(PlayerClass), PlayerPrefs.GetString("CHARACTERCLASS") );
         GameInfo.setJobs = (PlayerJobs)System.Enum.Parse(typeof(PlayerJobs), PlayerPrefs.GetString("CHARACTERJOB") );

        Debug.Log(GameInfo.PlayerName);
        Debug.Log("InfoLoaded");
    }
}
