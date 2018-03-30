using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {
    public string itemName;
    public int itemID;
    public string itemDesc;
    public Texture2D itemIcon;
    public int itemPower;
    public int itemDef;
    public int itemRange;
    public int itemHealth;
    public int itemPA;
    public int itemPM;
    public int item;

    public ItemType itemType;

    public enum ItemType
    {
        Weapon,
        Consumable,
        Important,
        Trophy
    }

    public Item(string name, int id, string desc, int power, int def, int range, int hp, int PA, int PM, ItemType type)
    {
        itemName = name;
        itemID = id;
        itemIcon = Resources.Load<Texture2D>("Item Icons/" + name);
        itemDesc = desc;
        itemPower = power;
        itemDef = def;
        itemRange = range;
        itemHealth = hp;
        itemPA = PA;
        itemPM = PM;
        itemType = type;
    }

    public Item(){
        this.itemID = -1;
    }

}
