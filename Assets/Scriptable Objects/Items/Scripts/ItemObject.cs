using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Consumable, 
    Weapon,
    Ammo,
    Default
}
public enum Attributes
{
    Range,
    AttackPower,
    Health,
    Stamina
}
[CreateAssetMenu(fileName = "New Object", menuName = "Inventory System/Items/Item")]
public class ItemObject : ScriptableObject
{
    public Sprite uiDisplay;
    public GameObject characterDisplay;
    public bool stackable;
    public ItemType type;
    [TextArea(15,20)]
    public string description;
    public Item data = new Item();

}

[System.Serializable]
public class Item
{
    public string Name;
    public int Id = -1;
    public ItemBuff[] buffs;
    public Item(ItemObject item)
    {
        Name = item.data.Name;
        Id = item.data.Id;
        buffs = new ItemBuff[item.data.buffs.Length];
        for (int i = 0; i < buffs.Length; i++)
        {
            buffs[i] = new ItemBuff(item.data.buffs[i].min, item.data.buffs[i].max)
            {
                attribute = item.data.buffs[i].attribute
            };
        }
    }
    public Item()
    {
        Name = "";
        Id = -1;
    }
}
[System.Serializable]
public class ItemBuff : IModifier
{
    public Attributes attribute;
    public int value;
    public int min;
    public int max;
    public ItemBuff(int _min,int _max)
    {
        min = _min;
        max = _max;
        GenerateValue();
    }
    public void AddValue(ref int baseValue)
    {
        baseValue += value;
    }
    public void GenerateValue()
    {
        value = UnityEngine.Random.Range(min, max);
    }
}