using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    private List<InteractibleItem> itemsHeld;


    void Awake()
    {
        itemsHeld = new List<InteractibleItem>();
    }

    public void AddItem(InteractibleItem item)
    {
        itemsHeld.Add(item);
    }


    public void UseInventoryItem(Location currentLocation, string itemName)
    {
        
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