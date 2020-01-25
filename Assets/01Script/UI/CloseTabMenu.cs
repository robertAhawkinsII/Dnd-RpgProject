using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTabMenu : MonoBehaviour
{
    [SerializeField]
    GameObject tabMenu, MainMenu;


    public void CloseTab()
    {
        MainMenu.SetActive(true);
        tabMenu.SetActive(false);
    }
}
