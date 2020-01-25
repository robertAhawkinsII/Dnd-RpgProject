using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSearchCheck : MonoBehaviour
{

    public GameObject roomToCheck;
    
    public void CheckPrepare()
    {
        roomToCheck.GetComponent<PerceptionRoomCheck>().DisplayRollOptions();
        ///if (roomToCheck = null)
        ///{
        ///    return;
        ///}       
    }

    public void PerseptionCheckonRoom()
    {
        roomToCheck.GetComponent<PerceptionRoomCheck>().DiceRoleEventForPerception();
        ///if (roomToCheck = null)
        ///{
        ///    return;
        ///}
    }

    public void InvestigationCheckonRoom()
    {
        roomToCheck.GetComponent<PerceptionRoomCheck>().DiceRoleEventForInvestigation();
        ///if (roomToCheck = null)
        ///{
        ///    return;
        ///}
    }
}
