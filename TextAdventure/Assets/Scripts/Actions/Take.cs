using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Take")]
public class Take : InputAction
{

    public override void RespondToInput(GameController controller, string seperatedInputWords)
    {
        if (seperatedInputWords.Length == 0)
            RespondToInvalidInput(controller);
        else
            controller.roomNavigation.AttemptToTakeItemFromRoom( seperatedInputWords);
    }

    public override void RespondToInvalidInput(GameController gameController)
    {
        gameController.DisplayFeedbackText("What are you taking?");
    }
}
