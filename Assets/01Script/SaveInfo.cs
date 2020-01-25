using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveInfo 
{
   public static void SaveAllInfo()
    {
        PlayerPrefs.SetString("PLAYERNAME", GameInfo.PlayerName);
        PlayerPrefs.SetInt("PLAYERLEVEL", GameInfo.PlayerLevel);
        PlayerPrefs.SetInt("PLAYERWEIGHT", GameInfo.characterWeight);
        PlayerPrefs.SetInt("PLAYERHEIGHT", GameInfo.characterHeight);
        //
        PlayerPrefs.SetInt("STREANGTH", GameInfo.Strength);
        PlayerPrefs.SetInt("DEXTERITY", GameInfo.Dexterity);
        PlayerPrefs.SetInt("CONSTITUTION", GameInfo.Constitution);
        PlayerPrefs.SetInt("INTELLIGENCE", GameInfo.Intelligence);
        PlayerPrefs.SetInt("WISDOM", GameInfo.Wisdom);
        PlayerPrefs.SetInt("CHARISMA", GameInfo.Charisma);
        //
        PlayerPrefs.SetInt("STREANGHTMOD", GameInfo.strMod);
        PlayerPrefs.SetInt("DEXTERITYMOD", GameInfo.dexMod);
        PlayerPrefs.SetInt("CONSTITUTIONMOD", GameInfo.conMod);
        PlayerPrefs.SetInt("INTELLIGENCEMOD", GameInfo.intMod);
        PlayerPrefs.SetInt("WISDOMMOD", GameInfo.wisMod);
        PlayerPrefs.SetInt("CHARISMAMOD", GameInfo.chrMod);
        //
        PlayerPrefs.SetInt("ACROBATICS", GameInfo.Acrobatics);
        PlayerPrefs.SetInt("ANIMALHANDILING", GameInfo.AnimaHandling);
        PlayerPrefs.SetInt("ARCANA", GameInfo.Arcana);
        PlayerPrefs.SetInt("ATHLETICS", GameInfo.Athletics);
        PlayerPrefs.SetInt("DECEPTION", GameInfo.Deception);
        PlayerPrefs.SetInt("HISTORY", GameInfo.History);
        PlayerPrefs.SetInt("INSIGHT", GameInfo.Insight);
        PlayerPrefs.SetInt("INTIMIDATION", GameInfo.Intimidation);
        PlayerPrefs.SetInt("INVESTIGATION", GameInfo.Investigation);
        PlayerPrefs.SetInt("MEDICINE", GameInfo.Medicine);
        PlayerPrefs.SetInt("NATURE", GameInfo.Nature);
        PlayerPrefs.SetInt("PERCEPTION", GameInfo.Perception);
        PlayerPrefs.SetInt("PERFORMANCE", GameInfo.Performance);
        PlayerPrefs.SetInt("PERSUASION", GameInfo.Persuasion);
        PlayerPrefs.SetInt("RELIGION", GameInfo.Religion);
        PlayerPrefs.SetInt("SLIGHTOFHAND", GameInfo.SlightOfHand);
        PlayerPrefs.SetInt("SURVIVAL", GameInfo.Survival);
        //
        PlayerPrefs.SetString("CHARACTERCLASS", GameInfo.setClass.ToString());
        PlayerPrefs.SetString("CHARACTERJOB", GameInfo.setJobs.ToString());
    }
}
