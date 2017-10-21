using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour {

    public Location currentRoom;

    Dictionary<string, Location> exitDictionary;
    GameController controller;

    void Awake()
    {
        exitDictionary = new Dictionary<string, Location>();
        controller = GetComponent<GameController>();
    }

    public void UnpackExitsInRoom()
    {
        for(int i = 0; i < currentRoom.exits.Length; i++)
        {
            exitDictionary.Add(currentRoom.exits[i].keyString, currentRoom.exits[i].valueLocation);
            controller.interactionDescriptions.Add(currentRoom.exits[i].exitDescription);
        }
    }

    public void AttemptToChangeRooms(string directionNown)
    {
        if(exitDictionary.ContainsKey(directionNown))
        {
            currentRoom = exitDictionary[directionNown];
            controller.AddToMainOutput("You head off to the " + directionNown);
            controller.interactionDescriptions.Clear();
            controller.DisplayRoomText();
        }
        else
        {
            controller.AddToMainOutput("There is no path to the " + directionNown);
        }
    }

    public void AttemptToTakeItemFromRoom(string objectName)
    {
        Debug.Log("Item is:" + objectName);
        // Check the takeable items
        foreach(InteractibleItem o in currentRoom.interactibleItems)
        {
            if (o.name == objectName && o.isActive)
            {
                // Add to inventory
                Debug.Log("Object in room");

                controller.AddToMainOutput("You take " + objectName);
                InteractibleItem fdfd = ScriptableObject.CreateInstance<InteractibleItem>();
                fdfd.name = o.name;
                fdfd.description = o.description;
                controller.inventory.AddItem(fdfd);
                o.isActive = false;
                return;
            }
        }
        // Check the non-takeable items
        foreach(InteractibleNonTakeable o in currentRoom.interactibleNonTakeables)
        {
            if (o.name == objectName)
            {
                controller.AddToMainOutput("You cannot take " + objectName);
                return;
            }
        }
        // If object is not in the room
        controller.AddToMainOutput("There is no item " + objectName);
    }

    public void ClearExits()
    {
        exitDictionary.Clear();
    }
}
