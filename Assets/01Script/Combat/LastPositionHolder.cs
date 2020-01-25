using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPositionHolder : MonoBehaviour
{
    [SerializeField]
    private PlayerBattleInfo parentInfo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        resetPosition();
    }

    void resetPosition()
    {
        this.gameObject.transform.position = parentInfo.lastPosition;
    }
}
