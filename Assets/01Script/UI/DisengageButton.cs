using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisengageButton : MonoBehaviour
{
    [SerializeField] GameObject AttackButtonUsed;
    [SerializeField] BaseAttack attackNuttonValue;

    private void Start()
    {
        attackNuttonValue = AttackButtonUsed.GetComponent<BaseAttack>();
    }

    public void Disengage()
    {
        attackNuttonValue.DisengageAttack();
    }
}
