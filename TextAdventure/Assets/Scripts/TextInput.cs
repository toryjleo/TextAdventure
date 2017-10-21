using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextInput : MonoBehaviour {

    public InputField inputField;
    private GameController controller;
    private int logidx;

    void Awake()
    {
        controller = GetComponent<GameController>();
        inputField.onEndEdit.AddListener(AcceptStringInput);
        logidx = 100;
    }
     void Start()
    {

        inputField.Select();
        inputField.ActivateInputField();
        logidx = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
            DisplayNextInput();
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            DisplayPreviousInput();
    }

    void AcceptStringInput(string userInput)
    {
        controller.LogStringWithReturn(userInput);
        userInput = userInput.ToLower();
        //controller.LogStringWithReturn(userInput);
        logidx = controller.GetActionLogCount();

        char[] delimiterCharacters = {' '};
        string[] seperatedInputWords = userInput.Split(delimiterCharacters);

        for(int i = 0; i < controller.inputActions.Length; i++)
        {
            InputAction inputAction = controller.inputActions[i];
            // Check the string for the input action against the first input string
            if(inputAction.keyWord == seperatedInputWords[0])
            {
                if (seperatedInputWords.Length == 1)
                    inputAction.RespondToInvalidInput(controller);
                else 
                    // Check second word in array
                    inputAction.RespondToValidInput(controller, seperatedInputWords);
                break;
            }
        }

        InputComplete();
    }

    void InputComplete()
    {
        controller.DisplayLogText();
        // Puts cursor back in inputfield
        inputField.ActivateInputField();
        inputField.text = null;
    }

    private void DisplayNextInput()
    {
        if (logidx < controller.GetActionLogCount() - 1)
        {
            logidx++;
            inputField.text = controller.GetFromActionLogIndex(logidx);
        }
    }

    private void DisplayPreviousInput()
    {
        if(logidx > 0)
        {
            logidx--;
            inputField.text = controller.GetFromActionLogIndex(logidx);
        }
    }
}
