using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpSplashScreenDisplay : MonoBehaviour
{
    public void LevelUPSplashUP()
    {
        this.gameObject.SetActive(true);
    }

    public void closePrompt()
    {
        this.gameObject.SetActive(false);
    }
}
