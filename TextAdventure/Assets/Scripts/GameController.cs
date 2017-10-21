using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text displayText;
    public InputAction[] inputActions;

    [HideInInspector] public RoomNavigation roomNavigation;
    [HideInInspector] public List<string> interactionDescriptions;

    List<string> actionLog;

    // Use this for initialization
    void Awake () {
        actionLog = new List<string>();
        interactionDescriptions = new List<string>();
        roomNavigation = GetComponent<RoomNavigation>();
	}

    private void UnpackRoom()
    {
        roomNavigation.UnpackExitsInRoom();
    }

    void ClearCollectionsForNewRoom()
    {
        interactionDescriptions.Clear();
        roomNavigation.ClearExits();
    }

    private void Start()
    {
        DisplayRoomText();
        DisplayLogText();
    }

    public void DisplayLogText()
    {
        string logAsText = string.Join("\n", actionLog.ToArray());
        displayText.text = logAsText;
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }

    public string GetFromActionLogIndex(int idx)
    {
        return actionLog[idx];
    }

    public int GetActionLogCount()
    {
        return actionLog.Count;
    }

	public void DisplayRoomText()
    {
        ClearCollectionsForNewRoom();
        UnpackRoom();

        string joinedInteractionDescriptions = string.Join("\n", interactionDescriptions.ToArray());
        string combinedText = roomNavigation.currentRoom.description + "\n" + string.Join("\n", interactionDescriptions.ToArray());

        LogStringWithReturn(combinedText);
    }
}
