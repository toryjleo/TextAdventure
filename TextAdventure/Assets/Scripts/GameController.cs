using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text displayText;
    public InputAction[] inputActions;

    [HideInInspector] public RoomNavigation roomNavigation;
    [HideInInspector] public Inventory inventory;
    [HideInInspector] public List<string> interactionDescriptions;

    List<string> actionLog;
    List<string> inputLog;



    // Use this for initialization
    void Awake () {
        actionLog = new List<string>();
        inputLog = new List<string>();
        interactionDescriptions = new List<string>();
        roomNavigation = GetComponent<RoomNavigation>();
        inventory = GetComponent<Inventory>();
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

    public void AddToMainOutput(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }

    public void AddToInputLog(string stringToAdd)
    {
        inputLog.Add(stringToAdd);
    }

    public string GetFromInputLogIndex(int idx)
    {
        return inputLog[idx];
    }

    public int GetInputLogCount()
    {
        return inputLog.Count;
    }

	public void DisplayRoomText()
    {
        ClearCollectionsForNewRoom();
        UnpackRoom();

        string joinedInteractionDescriptions = string.Join("\n", interactionDescriptions.ToArray());
        string combinedText = roomNavigation.currentRoom.description + "\n" + string.Join("\n", interactionDescriptions.ToArray());

        AddToMainOutput(combinedText);
    }
}
