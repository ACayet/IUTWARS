﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemDatabase : MonoBehaviour {
    public List<Item> items = new List<Item>();
    // Use this for initialization

    private void Start()
    {
        items.Add(new Item("IronAxe", 0, "A beautiful axe", 2, Item.ItemType.Weapon));
        items.Add(new Item("DiamondSword", 1, "A beautiful sword", 8, Item.ItemType.Important));
        items.Add(new Item("DrinkableSpear", 2, "This spear is drinkable !", 0, Item.ItemType.Consumable));
    }
    // Update is called once per frame
    void Update () {
		
	}
}
