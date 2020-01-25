using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public static string PlayerName { get; set; }
    public static int PlayerLevel { get; set; }
    public static BaseClass PlayerClass { get; set; }
    public static PlayerClass setClass { get; set; }
    public static string className { get; set; }
    public static BaseJob PlayerJob { get; set; }
    public static PlayerJobs setJobs { get;set; }
    public static string jobName { get; set; }
    public static BaseRace PlayerRace { get; set; }
    public static PlayerRace setRace { get; set; }
    public static string RaceName { get; set; }

    public static int characterWeight;
    public static int characterHeight;
    public static int characterAge;

    public static int PlayerHealth { get; set; }

    public static int Strength { get; set; }
    public static int Dexterity { get; set; }
    public static int Constitution { get; set; }
    public static int Intelligence { get; set; }
    public static int Wisdom { get; set; }
    public static int Charisma { get; set; }

    public static int Acrobatics { get; set; }
    public static int AnimaHandling { get; set; }
    public static int Arcana { get; set; }
    public static int Athletics { get; set; }
    public static int Deception { get; set; }
    public static int History { get; set; }
    public static int Insight { get; set; }
    public static int Intimidation { get; set; }
    public static int Investigation { get; set; }
    public static int Medicine { get; set; }
    public static int Nature { get; set; }
    public static int Perception { get; set; }
    public static int Performance { get; set; }
    public static int Persuasion { get; set; }
    public static int Religion { get; set; }
    public static int SlightOfHand { get; set; }
    public static int Stealth { get; set; }
    public static int Survival { get; set; }

    public static int strMod { get; set; }
    public static int dexMod { get; set; }
    public static int conMod { get; set; }
    public static int intMod { get; set; }
    public static int wisMod { get; set; }
    public static int chrMod { get; set; }
}

public enum PlayerRace
{
    Dwarf,
    HillDwarf,
    MountainDwarf,
    Elf,
    WoodElf,
    HighElf,
    DarkElf,
    HalfElf,
    Human,
    Halfling,
    StoutHalfling,
    LightFootHalfling,
    Gnome, 
    ForestGnome,
    RockGnome,
    HalfOrc,
    Tiefling,
    Dragonborn
}

public enum PlayerClass
{
    //for inventory only this is so Items that arnt class spusific be allowed to be used
    None,
    Barbarian,
    Bard,
    Cleric,
    Druid,
    Fighter,
    Monk,
    Palidin,
    Ranger,
    Rouge,
    Scorcerer,
    Warlock,
    Wizard,
}

public enum PlayerJobs
{
    Acolyte,
    Charlatan,
    Criminal,
    Entertainer,
    FolkHero,
    GuildArtisan,
    Hermit,
    Noble,
    Outlander,
    Sailor,
    Soldier,
    Urchin,
    Hunter,
    Sage,
    RecoveringAssassin,
    Brawler,
    HopfulDoctor,
    Marader,
    Druid,
    ExcomunicatedPolition,
    PotionMixer
}