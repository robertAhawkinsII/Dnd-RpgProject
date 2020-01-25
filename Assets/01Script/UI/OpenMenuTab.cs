using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenuTab : MonoBehaviour
{
    [SerializeField]
    GameObject tabMenu, MainMenu;


    public void OpenTab()
    {
        tabMenu.SetActive(true);
        MainMenu.SetActive(false);
    }
}
