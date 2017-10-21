using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text displayText;
    public Text feedbackText;
    public InputAction[] inputActions;

    [HideInInspector] public RoomNavigation roomNavigation;
    [HideInInspector] public PlayerInventory inventory;
    [HideInInspector] public List<string> interactionDescriptions;

    List<string> inputLog;


    // Use this for initialization
    void Awake () {
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
        // Reset the state of all the ScriptableObjects, InteractibleObject in scene
        InteractibleObject[] s = (InteractibleObject[]) Resources.FindObjectsOfTypeAll(typeof(InteractibleObject));
        foreach (InteractibleObject v in s)
        {
            v.Reset();
        }
    }

    public void DisplayOutputText(string text)
    {
        displayText.text = text;
    }

    public void DisplayFeedbackText(string text)
    {
        feedbackText.text = text;
    }

    public void DisplayRoomText()
    {
        ClearCollectionsForNewRoom();
        UnpackRoom();

        string joinedInteractionDescriptions = string.Join("\n", interactionDescriptions.ToArray());
        string combinedText = roomNavigation.currentRoom.description + "\n" + string.Join("\n", interactionDescriptions.ToArray());

        DisplayOutputText(combinedText);
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


}
