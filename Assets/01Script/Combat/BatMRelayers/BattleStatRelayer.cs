using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleStatRelayer : MonoBehaviour, IComparable
{
    public Sprite BattlePortraitIcon;

    public CharacterStats playerCheck;
    public EnemieBaseStats enemyCheck;

    public bool isPlayer;
    public bool isMember;
    public bool isDead;

    [SerializeField]
    private int actionCost;

    public int initiativeValue;

    private void Update()
    {
        if (isPlayer)
        {
            playerCheck = gameObject.GetComponent<CharacterStats>();
            enemyCheck = null;
            isDead = !playerCheck.isAlive;
        }
        else
        {
            enemyCheck = gameObject.GetComponent<EnemieBaseStats>();
            playerCheck = null;
            isDead = !enemyCheck.isAlive;
        }
    }

    public int nextActTurn; 

    public void CalculateNextActTurn (int currentTurn)
    {
        if (isPlayer)
        {
            nextActTurn = currentTurn + Mathf.CeilToInt(50f / playerCheck.InishitiveRoll);
        }
        else
        {
            nextActTurn = currentTurn + Mathf.CeilToInt(50f / enemyCheck.inishitiveRoll);
        }
    }

    public int CompareTo (object otherStats)
    {
        return nextActTurn.CompareTo(((BattleStatRelayer)otherStats).nextActTurn);
    }
}
