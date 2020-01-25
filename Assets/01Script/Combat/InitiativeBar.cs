using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitiativeBar : MonoBehaviour
{
    //get actors and placemenet based on battlemanager

    [SerializeField] GameObject InishitiveIcon;
    [SerializeField] BattleManager bms;
    BattleStatRelayer current;

    List<Image> icons;

    [SerializeField]
    private List<BattleStatRelayer> actors;

    public void StartBattle()
    {
        actors = bms.moveOrder;
        icons = new List<Image>();
        for (int i = 0; i < actors.Count; i++)
        {
            GameObject gameObject = Instantiate(InishitiveIcon, transform);
            icons.Add(gameObject.GetComponent<Image>());
        }
    }

    public void UpdateBar()
    {
        for(int i = 0; i < actors.Count; i++)
        {
            icons[i].sprite = actors[i].BattlePortraitIcon;
        }

    }
}
