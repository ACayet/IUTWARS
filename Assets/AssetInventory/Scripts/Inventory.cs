using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour {
    public List<Item> inventory = new List<Item>();
    private ItemDatabase database;
	// Use this for initialization
	void Start () {
        database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
        for(int a=0; a< database.items.Count; a++)
        {
            inventory.Add(database.items[a]);
        }
    }   
    
	
	// Update is called once per frame
	void OnGUI () {
		for(int b=0; b < inventory.Count; b++)
        {
            GUI.Label(new Rect(10, b*20, 200, 50), inventory[b].itemName);
        }
	}
}
