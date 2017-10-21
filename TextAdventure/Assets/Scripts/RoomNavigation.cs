using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour {

    public Room currentRoom;

    Dictionary<string, Room> exitDictionary;
    GameController controller;

    void Awake()
    {
        exitDictionary = new Dictionary<string, Room>();
        controller = GetComponent<GameController>();
    }

    public void UnpackExitsInRoom()
    {
        for(int i = 0; i < currentRoom.exits.Length; i++)
        {
            exitDictionary.Add(currentRoom.exits[i].keyString, currentRoom.exits[i].valueRoom);
            Debug.Log("string being added: " + currentRoom.exits[i].exitDescription);
            controller.interactionDescriptions.Add(currentRoom.exits[i].exitDescription);
            
        }
    }

    public void AttemptToChangeRooms(string directionNown)
    {
        if(exitDictionary.ContainsKey(directionNown))
        {
            currentRoom = exitDictionary[directionNown];
            controller.LogStringWithReturn("You head off to the " + directionNown);
            controller.interactionDescriptions.Clear();
            controller.DisplayRoomText();
        }
        else
        {
            controller.LogStringWithReturn("There is no path to the " + directionNown);
        }
    }

    public void ClearExits()
    {
        exitDictionary.Clear();
    }
}
