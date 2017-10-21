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
        userInput = userInput.Trim();
        userInput = userInput.ToLower();
        controller.AddToInputLog(userInput);

        //controller.LogStringWithReturn(userInput);
        logidx = controller.GetInputLogCount();

        char[] delimiterCharacters = {' '};

        for(int i = 0; i < controller.inputActions.Length; i++)
        {
            InputAction inputAction = controller.inputActions[i];
            // Check the string for the input action against the first input string
            if (userInput.StartsWith(inputAction.keyWord))
            {
                string stripped = userInput.TrimStart(inputAction.keyWord.ToCharArray());
                stripped = stripped.Trim();
                inputAction.RespondToInput(controller, stripped);
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
        if (logidx < controller.GetInputLogCount() - 1)
        {
            logidx++;
            inputField.text = controller.GetFromInputLogIndex(logidx);
        }
    }

    private void DisplayPreviousInput()
    {
        if(logidx > 0)
        {
            logidx--;
            inputField.text = controller.GetFromInputLogIndex(logidx);
        }
    }
}
