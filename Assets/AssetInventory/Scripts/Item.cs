using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {
    public string itemName;
    public int itemID;
    public string itemDesc;
    public Texture2D itemIcon;
    public int statUtil;
    public ItemType itemType;

    public enum ItemType
    {
        Weapon,
        Consumable,
        Important
    }

    public Item(string name, int id, string desc, int util, ItemType type)
    {
        itemName = name;
        itemID = id;
        itemIcon = Resources.Load<Texture2D>("Item Icons/" + name);
        itemDesc = desc;
        statUtil = util;
        itemType = type;
    }

    public Item(){
        this.itemID = -1;
    }

}
