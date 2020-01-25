using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food Object", menuName = "Inventory/Items/Food ")]
public class FoodObject : BaseItem
{

    public float foodLBValue;
    private void Awake()
    {
        type = ItemType.Food;
    }
}
