using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="TextAdventure/InputActions/Go")]
public class Go : InputAction
{

    public override void RespondToInput(GameController controller, string inputWords)
    {
        if (inputWords.Length == 0)
            RespondToInvalidInput(controller);
        else
            controller.roomNavigation.AttemptToChangeRooms(inputWords);
    }

    public override void RespondToInvalidInput(GameController controller)
    {
        controller.DisplayFeedbackText("Go where?");
    }
}
