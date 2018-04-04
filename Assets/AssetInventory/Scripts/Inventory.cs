using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour {
    public int slotsX, slotsY;
    public List<Item> inventory = new List<Item>();
    private ItemDatabase database;
    private bool showInventory;
    public GUISkin skin;
    private bool showTooltip;
    private string tooltip;
    private bool draggingItem;
    private Item draggedItem;
    private int prevIndex;
  
    // Use this for initialization
    void Start () {     
        for(int a = 0; a < (slotsX * slotsY); a++)
        {
            inventory.Add(new Item());

        }
        database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
        for (int b = 0; b <(slotsX * slotsY); b++)
        {
            AddItem(b);
            VerifTrophy(b);
        }
        //RemoveItem(0);
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            showInventory = !showInventory;
        }
    }


    // Update is called once per frame
    void OnGUI () {   
        tooltip = "";
        GUI.skin = skin;
        if (showInventory)
        {
            DrawInventory();
            if (showTooltip)
            {
                GUI.Box(new Rect(Event.current.mousePosition.x + 15f, Event.current.mousePosition.y, 200, 200), tooltip);
            }
        }
        if (draggingItem)
        {
            GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 50, 50), draggedItem.itemIcon);
        }
		
	}

    void DrawInventory()
    {
        Event e = Event.current;
        int i = 0;
        for(int y = 0; y < slotsY; y++)
        {
            for(int x = 0; x < slotsX; x++)
            {
                Rect slotRect = new Rect(1400 + x * 60, y * 60, 50, 50);
                GUI.Box(slotRect, "", skin.GetStyle("Slot"));
                Item item = inventory[i];
                
                if (inventory[i].itemName != null)
                {
                    GUI.DrawTexture(slotRect, inventory[i].itemIcon);
                    if (slotRect.Contains(e.mousePosition))
                    {
                        tooltip = CreateTooltip(inventory[i]);
                        showTooltip = true;
                        if (e.button == 0 && e.type == EventType.MouseDrag && !draggingItem)
                        {
                            draggingItem = true;
                            prevIndex = i;
                            draggedItem = inventory[i];
                            inventory[i] = new Item();
                        }
                        if (e.type == EventType.MouseUp && draggingItem)
                        {
                            inventory[prevIndex] = inventory[i];
                            inventory[i] = draggedItem;
                            draggingItem = false;
                            draggedItem = null;
                        }
                        if (e.isMouse && e.type == EventType.MouseDown && e.button == 1)
                        {                          
                            if (item.itemType == Item.ItemType.Consumable)
                            {
                                UseConsumable(inventory[i], i, true);
                            }
                        }
                    }
                }
                else
                {
                    if(slotRect.Contains(e.mousePosition))
                    {
                        if(e.type == EventType.MouseUp && draggingItem){
                            inventory[i] = draggedItem;
                            draggingItem = false;
                            draggedItem = null;
                        }
                    }
                }
                if(tooltip == "")
                {
                    showTooltip = false;
                }
                
                i++;
            }
        }
    }

    string CreateTooltip(Item item)
    {
        tooltip = "<color=#ffffff>" + item.itemName + "\n\n" + item.itemDesc + "\n\n" + item.itemPower + "</color>";
        return tooltip;
    }

    void AddItem(int id)
    {
        for(int i = 0; i<inventory.Count; i++)
        {
            if(inventory[i].itemName == null)
            {
                if (id < 0)
                {
                    inventory[i] = new Item();
                    break;
                }
                for(int j = 0; j<database.items.Count; j++)
                {
                    if (database.items[j].itemID == id)
                    {
                        inventory[i] = database.items[j];
                    }
                }
                break;
            }
        }
    }

    void VerifTrophy(int id)
    {
        if (inventory[id].itemType == Item.ItemType.Trophy)
        {
            
        }
    }

    void RemoveItem(int id)
    {
        for(int i = 0; i<inventory.Count; i++)
        {
            if(inventory[i].itemID == id)
            {
                inventory[i] = new Item();
                break;
            }
        }
    }

    void UseConsumable(Item item, int slot, bool deleteItem)
    {
        switch (item.itemID)
        {
            case 2:
                {
                    print("USED CONSUMABLE: ");
                    break;
                }
        }
        if (deleteItem)
        {
            inventory[slot] = new Item();
        }
    }


    bool InventoryContains(int id)
    {
        bool result = false;
        for (int i = 0; i<inventory.Count; i++)
        {
            result = inventory[i].itemID == id;
            if (result)
            {
                break;
            }
        }
        return result;
    }

    void SaveInventory()
    {
       for(int i = 0; i<inventory.Count; i++)
        {
            PlayerPrefs.SetInt("Inventory" + i, inventory[i].itemID);
        }
    }

    void LoadInventory()
    {
        for(int i = 0; i < inventory.Count; i++)
        {
            inventory[i] = PlayerPrefs.GetInt("Inventory" + i, -1) >= 0 ? database.items[PlayerPrefs.GetInt("Inventory" + i)] : new Item();
        }
    }
}
