using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Take")]
public class Take : InputAction
{

    public override void RespondToValidInput(GameController controller, string[] seperatedInputWords)
    {
        controller.roomNavigation.AttemptToTakeItemFromRoom(seperatedInputWords[1]);
    }

    public override void RespondToInvalidInput(GameController gameController)
    {
        gameController.AddToMainOutput("What are you taking?");
    }
}
