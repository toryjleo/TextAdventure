using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour {

    public Location currentLocation;

    Dictionary<string, Location> exitDictionary;
    GameController controller;

    void Awake()
    {
        exitDictionary = new Dictionary<string, Location>();
        controller = GetComponent<GameController>();
    }

    public void UnpackExitsInRoom()
    {
        for(int i = 0; i < currentLocation.exits.Length; i++)
        {
            exitDictionary.Add(currentLocation.exits[i].keyString, currentLocation.exits[i].valueLocation);
            controller.interactionDescriptions.Add(currentLocation.exits[i].exitDescription);
        }
    }

    public void AttemptToChangeRooms(string directionNown)
    {
        if(exitDictionary.ContainsKey(directionNown))
        {
            currentLocation = exitDictionary[directionNown];
            controller.DisplayFeedbackText("You head off to the " + directionNown);
            controller.interactionDescriptions.Clear();
            controller.DisplayRoomText();
        }
        else
        {
            controller.DisplayFeedbackText("There is no path to the " + directionNown);
        }
    }

    public void AttemptToTakeItemFromRoom(string objectName)
    {
        // Check the takeable items
        foreach(InteractibleItem o in currentLocation.interactibleItems)
        {
            if (o.name == objectName && o.isActive)
            {
                // Add to inventory

                controller.DisplayFeedbackText("You take " + objectName);
                InteractibleItem fdfd = ScriptableObject.CreateInstance<InteractibleItem>();
                fdfd.name = o.name;
                fdfd.description = o.description;
                controller.inventory.AddItem(fdfd);
                o.isActive = false;
                return;
            }
        }
        // Check the non-takeable items
        foreach(InteractibleNonTakeable o in currentLocation.interactibleNonTakeables)
        {
            if (o.name == objectName)
            {
                controller.DisplayFeedbackText("You cannot take " + objectName);
                return;
            }
        }
        // If object is not in the room
        controller.DisplayFeedbackText("There is no item " + objectName);
    }

    public bool LookAtItemsInCurrentLocation(string objectName)
    {
        // Check the takeable items
        foreach (InteractibleItem i in currentLocation.interactibleItems)
        {
            if (i.name == objectName && i.isActive)
            {
                // Display discription
                controller.DisplayOutputText(i.description);
                return true;
            }
        }
        // Check the non-takeable items
        foreach (InteractibleNonTakeable i in currentLocation.interactibleNonTakeables)
        {
            if (i.name == objectName)
            {
                // Display discription
                controller.DisplayOutputText(i.description);
                return true;
            }
        }
        return false;
    }

    public void ClearExits()
    {
        exitDictionary.Clear();
    }
}
