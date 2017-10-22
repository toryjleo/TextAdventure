using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Take")]
public class Take : InputAction
{

    public override void RespondToInput(GameController controller, string inputWords)
    {
        if (inputWords.Length == 0)
            RespondToInvalidInput(controller);
        else
            controller.roomNavigation.AttemptToTakeItemFromRoom( inputWords);
    }

    public override void RespondToInvalidInput(GameController controller)
    {
        controller.DisplayFeedbackText("What are you taking?");
    }
}
