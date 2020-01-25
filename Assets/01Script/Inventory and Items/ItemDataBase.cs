using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName =  "New Item Database", menuName = "Inventory System/ Database")]
public class ItemDataBase : ScriptableObject, ISerializationCallbackReceiver
{
    public BaseItem[] itemObjects;

    public void UpdateID()
    {
        for (int i = 0; i < itemObjects.Length; i++)
        {
            if (itemObjects[i].data.Id != i)
                itemObjects[i].data.Id = i;
        }
    }

    public void OnAfterDeserialize()
    {
        UpdateID();
    }

    public void OnBeforeSerialize()
    {
        
    }
}
