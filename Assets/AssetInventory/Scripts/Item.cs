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
    public ItemType itemType;

    public enum ItemType
    {
        Weapon,
        Consumable,
        Important
    }

    public Item(string name, int id, string desc, int power, ItemType type)
    {
        itemName = name;
        itemID = id;
        itemIcon = Resources.Load<Texture2D>("Item Icons/" + name);
        itemDesc = desc;
        itemPower = power;
        itemType = type;
    }

    public Item(){
    }

}
