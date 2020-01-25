using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;

public enum InterfaceType
{
    Inventory,
    Equipment,
    Chest
}

[CreateAssetMenu(fileName = "new inventory", menuName =  "Inventory System /Inventory")]
public class InventoryObject : ScriptableObject
{
    public string savePath;
    public ItemDataBase dataBase;
    public InterfaceType type;
    public Inventory Container;
    public InventorySlot[] GetSlots { get { return Container.Slots; } }

    public FloatValue weight;

    [SerializeField]
    //Item[] itemsOnStart;

    public void SetStartItems(Inventory _setInventory)
    {
        for (int i = 0; i < GetSlots.Length; i++)
        {
            GetSlots[i].UpdateSlot(_setInventory.Slots[i].item, _setInventory.Slots[i].amount);
        }
        CalculateWeight();
    }

    public bool ADDItem(Item _item, int _amount)
    {
        if (EmptySlotCount <= 0)
            return false;
        InventorySlot slot = FindItemOnInventory(_item);
        if(!dataBase.itemObjects[_item.Id].stackable || slot == null)
        {
            SetEmptySlot(_item, _amount);
            CalculateWeight();
            return true;
        }
        slot.AddAmount(_amount);
        CalculateWeight();
        return true;
    }

    public InventorySlot FindItemOnInventory(Item _item)
    {
        for (int i = 0; i < GetSlots.Length; i++)
        {
            if(GetSlots[i].item.Id == _item.Id)
            {
                return GetSlots[i];
            }
        }
        return null;
    }

    public int EmptySlotCount
    {
        get
        {
            int counter = 0;
            for (int i = 0; i < GetSlots.Length; i++)
            {
                if (GetSlots[i].item.Id <= -1)
                    counter++;
            }
            return counter; 
        }
    }

    public InventorySlot SetEmptySlot(Item _item, int _amount)
    {
        for (int i = 0; i < GetSlots.Length; i++)
        {
            if(GetSlots[i].item.Id <= -1)
            {
                GetSlots[i].UpdateSlot( _item, _amount);
                return GetSlots[i];
            }
        }
        //set up what happens when inventory array limit is reached
        return null;
    }

    public void SwapItems(InventorySlot item1, InventorySlot item2)
    {
        if (item2.CanPlaceInslot(item1.BaseItem) && item1.CanPlaceInslot(item2.BaseItem))
        {
            InventorySlot temp = new InventorySlot( item2.item, item2.amount);
            item2.UpdateSlot(item1.item, item1.amount);
            item1.UpdateSlot(temp.item, temp.amount);
        }
    }
   
    public void RemoveItem(Item _item)
    {
        for (int i = 0; i < GetSlots.Length; i++)
        {
            if (GetSlots[i].item == _item)
            {
                GetSlots[i].UpdateSlot(null, 0);
                CalculateWeight();
            }
        }
    }


    public void CalculateWeight()
    {
        for (int i = 0; i < GetSlots.Length; i++)
        {
            weight.RuntimeValue = (GetSlots[i].item.Weight * GetSlots[i].amount);
        }
    }

    [ContextMenu("Save")]
    public void Save()
    {
        //string saveData = JsonUtility.ToJson(this, this);
        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        //bf.Serialize(file, saveData);
        //file.Close();

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, Container);

        weight.initialValue = weight.RuntimeValue;
        stream.Close();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if(File.Exists(string.Concat(Application.persistentDataPath, savePath))){
            //BinaryFormatter bf = new BinaryFormatter();
            //FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            //JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            //file.Close();

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            Inventory newContainer = (Inventory)formatter.Deserialize(stream);
            for (int i = 0; i < GetSlots.Length; i++)
            {
                GetSlots[i].UpdateSlot(newContainer.Slots[i].item, newContainer.Slots[i].amount);
            }
            weight.RuntimeValue = weight.initialValue;
            stream.Close();
        }
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        Container.Clear();
    }  
}

[System.Serializable]
public class Inventory
{
    public InventorySlot[] Slots = new InventorySlot[100];

    public void Clear()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            Slots[i].RemoveItem();
        }
    }
}

public delegate void SlotUpdate(InventorySlot _slot);


[System.Serializable]
public class InventorySlot
{
    public ItemType[] AllowedItems = new ItemType[0];
    public PlayerClass[] slotClass = new PlayerClass[1];
    [System.NonSerialized]
    public UserInterface parent;
    [System.NonSerialized]
    public GameObject slotDisplay;
    [System.NonSerialized]
    public SlotUpdate OnAfterUpdate, OnBeforeUpdate;
    public Item item = new Item();
    public int amount;

    public BaseItem BaseItem
    {
        get
        {
            if(item.Id >= 0)
            {
                return parent.inventory.dataBase.itemObjects[item.Id];
            }
            return null;
        }
    }

    public InventorySlot()
    {
        UpdateSlot(new Item(), 0);
    }

    public InventorySlot( Item _item, int _amount)
    {
        UpdateSlot(_item, _amount);
    }

    public void UpdateSlot( Item _item, int _amount)
    {
        if (OnBeforeUpdate != null)
            OnBeforeUpdate.Invoke(this);
        item = _item;
        amount = _amount;
        if (OnAfterUpdate != null)
            OnAfterUpdate.Invoke(this);
    }

    public void RemoveItem()
    {
        UpdateSlot(new Item(), 0);
    }
    public void AddAmount(int value)
    {
        UpdateSlot(item, amount += value);
        amount += value;
    }
    public bool CanPlaceInslot(BaseItem _baseItem)
    {
        if (slotClass.Length <= 0 || AllowedItems.Length <= 0 || _baseItem == null || _baseItem.data.Id < 0)
            return true;
        for (int i = 0; i < AllowedItems.Length; i++)
        {
            for (int j = 0; j < slotClass.Length; j++)
            {
                if (_baseItem.type == AllowedItems[i] && _baseItem.useableClass == slotClass[j])
                    return true;
            }
        }       
        return false;
    }

    public void SetCharacterClass(PlayerClass _allowableClass)
    {
        for (int i = 0; i < slotClass.Length; i++)
        {
            slotClass[1] = _allowableClass;
        }
    }
}
