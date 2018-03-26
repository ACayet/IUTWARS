using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemDatabase : MonoBehaviour {
    public List<Item> items = new List<Item>();
    // Use this for initialization

    private void Start()
    {
        items.Add(new Item("IronAxe", 0, "A beautiful axe", 2, Item.ItemType.Weapon));
    }
    // Update is called once per frame
    void Update () {
		
	}
}
