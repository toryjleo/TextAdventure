using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
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

}