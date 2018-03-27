using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour {
    public int slotsX, slotsY;
    public List<Item> inventory = new List<Item>();
    public List<Item> slots = new List<Item>();
    private ItemDatabase database;
    private bool showInventory;
    public GUISkin skin;
    private bool showTooltip;
    private string tooltip;

    // Use this for initialization
    void Start () {
        for(int i = 0; i < (slotsX * slotsY); i++)
        {
            slots.Add(new Item());
            inventory.Add(new Item());
        }
        database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
        for(int a = 0; a < (slotsX * slotsY); a++)
        {
            AddItem(a);
            AddItem(a);
        }
        RemoveItem(0);
        print(InventoryContains(1));
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
        }
        if (showTooltip)
        {
            GUI.Box(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 200, 200), tooltip);
        }
		
	}

    void DrawInventory()
    {
        int i = 0;
        for(int y = 0; y < slotsY; y++)
        {
            for(int x = 0; x < slotsX; x++)
            {
                Rect slotRect = new Rect(x * 60, y * 60, 50, 50);
                GUI.Box(slotRect, "", skin.GetStyle("Slot"));
                slots[i] = inventory[i];
                if (slots[i].itemName != null)
                {
                    GUI.DrawTexture(slotRect, slots[i].itemIcon);
                    if (slotRect.Contains(Event.current.mousePosition))
                    {
                        tooltip = CreateTooltip(slots[i]);
                        showTooltip = true;
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
        tooltip = "<color=#ffffff>" + item.itemName + "</color>";
        return tooltip;
    }

    void AddItem(int id)
    {
        for(int i = 0; i<inventory.Count; i++)
        {
            if(inventory[i].itemName == null)
            {
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
}
