using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/item")]
public class BaseItem : ScriptableObject
{
    public PlayerClass useableClass;
    public ItemType type;
    public string itemName;
    [TextArea(15, 20)]
    public string discription;
    public Sprite icon;

    public bool stackable;

    public Item data = new Item();

    [Header("platnum/pp = 1000 cp" +
        " gold/gp 100 cp" +
        " electrum/ep 50cp," +
        " silver/sp 10cp" +
        " copper/cp 1cp ")]
    [Min (1)]public int buyValue, sellValue;

    public float itemWeight;

    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
}

public enum Atributes
{
    MaxHP,
    AC,
    Strength,
    Dexterity,
    Constitution,
    Intelligence,
    Wisdon,
    Charisma,

    Acrobatics,
    AnimalHandeling,
    Arcana,
    Athletics,
    Deception,
    History,
    Insight,
    Intimidation,
    Investigation,
    Medicine,
    Nature,
    Perception,
    Performence,
    Persuasion,
    Religion,
    SlightOfHand,
    Stealth,
    Survival
}

public enum ItemType
{
    Food,
    Head,
    Weapon,
    Sheild,
    Armor,
    Boots,
    HandAccessory,
    headAccesory,
    Consumable,
    Default
}

[System.Serializable]
public class Item
{
    public string Name;
    public int Id = -1;
    public float Weight;
    public ItemBuff[] buffs;
    public Item()
    {
        Name = "";
        Id = -1;
    }

    public Item(BaseItem item)
    {
        Name = item.itemName;
        Id = item.data.Id;
        Weight = item.itemWeight;
        buffs = new ItemBuff[item.data.buffs.Length];
        for (int i = 0; i < buffs.Length; i++)
        {
            buffs[i] = new ItemBuff(item.data.buffs[i].min, item.data.buffs[i].max)
            {
                atributes = item.data.buffs[i].atributes
            };
        }
    }
}

[System.Serializable]
public class ItemBuff : IModifiers
{
    public Atributes atributes;
    public int Value;
    public int min, max;
    public ItemBuff(int _min, int _max)
    {
        min = _min;
        max = _max;
        generateValue();
    }

    public void AddValue(ref int baseValue)
    {
        baseValue += Value;
    }

    public void generateValue()
    {
        Value = UnityEngine.Random.Range(min, max);
    }
}
