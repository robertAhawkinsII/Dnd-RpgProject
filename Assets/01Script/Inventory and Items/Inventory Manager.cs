using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            instance = this.gameObject.GetComponent<InventoryManager>();
        }
        return;
    }

    public void AddItem()
    {
        //UIManager.instance.DrawItem(item);
    }
}
