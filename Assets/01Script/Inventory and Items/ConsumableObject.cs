using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable Object", menuName = "Inventory/Items/Consumable")]
public class ConsumableObject : BaseItem
{
    private void Awake()
    {
        type = ItemType.Consumable;
        generateHealValue();
    }

    public int min, max;

    public int HealValue;
    public ConsumableObject(int _min, int _max)
    {
        min = _min;
        max = _max;
    }

    public void generateHealValue()
    {
        HealValue = UnityEngine.Random.Range(min, max);
    }
}
