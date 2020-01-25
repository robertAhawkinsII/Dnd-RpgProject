using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory/Items/Equipment")]
public class EquipmentObject : BaseItem
{
    public GameObject attackTypeButtonInstance;
    private void Awake()
    {
        type = ItemType.Armor;
    }
}
