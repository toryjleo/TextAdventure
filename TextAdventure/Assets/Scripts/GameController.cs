using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text displayText;
    public Text errorText;
    public InputAction[] inputActions;

    [HideInInspector] public RoomNavigation roomNavigation;
    [HideInInspector] public PlayerInventory inventory;
    [HideInInspector] public List<string> interactionDescriptions;

    List<string> actionLog;
    List<string> inputLog;


    // Use this for initialization
    void Awake () {
        actionLog = new List<string>();
        inputLog = new List<string>();
        interactionDescriptions = new List<string>();
        roomNavigation = GetComponent<RoomNavigation>();
        inventory = GetComponent<PlayerInventory>();
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
        // Reset the state of all the ScriptableObjects, InteractibleObject in scene
        InteractibleObject[] s = (InteractibleObject[]) Resources.FindObjectsOfTypeAll(typeof(InteractibleObject));
        foreach (InteractibleObject v in s)
        {
            v.Reset();
        }
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
