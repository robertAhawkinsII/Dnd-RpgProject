using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarRunAwayCheck : MonoBehaviour
{

    [SerializeField]
    private GameObject runAwayFeild;

    [SerializeField]
    private Image runProgressBar;

    // Start is called before the first frame update
    void Awake()
    {
        runAwayFeild = GameObject.Find("RunAwayFeild");
        //UpdateUI();
    }

    void UpdateUI()
    {
        RunFromBattle runAwayInfo = runAwayFeild.GetComponent<RunFromBattle>();

        runProgressBar.fillAmount = runAwayInfo.runningtime / runAwayInfo.runtimeNeeded;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //runAwayFeild = GameObject.Find("RunAwayFeild");
        UpdateUI();
    }
}
