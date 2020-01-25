using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory/Items/Default")]
public class DefaultObject : BaseItem
{
    public void Awake()
    {
        type = ItemType.Default;
    }
}
