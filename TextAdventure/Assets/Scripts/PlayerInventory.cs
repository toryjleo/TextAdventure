using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    private List<InteractibleItem> itemsHeld;

    private GameController controller;

    void Awake()
    {
        itemsHeld = new List<InteractibleItem>();
        controller = GetComponent<GameController>();
    }

    public void AddItem(InteractibleItem item)
    {
        itemsHeld.Add(item);
    }


    public void UseInventoryItem(Location currentLocation, string itemName)
    {
        
    }

    public bool LookAtInventoryItems(string objectName)
    {
        foreach(InteractibleItem i in itemsHeld)
        {
            if (i.name == objectName && i.isActive)
            {
                // Display discription
                controller.DisplayOutputText(i.description);
                return true;
            }
        }
        return false;
    }

    public string GetItemsString()
    {
        string items = "";
        foreach(InteractibleItem i in itemsHeld)
        {
            if (items != "")
                items += i.name + ", ";
            else
                items += i.name;
        }
        return items;
    }

}