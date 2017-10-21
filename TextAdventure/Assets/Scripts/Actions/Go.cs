using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="TextAdventure/InputActions/Go")]
public class Go : InputAction
{

    public override void RespondToInput(GameController controller, string seperatedInputWords)
    {
        if (seperatedInputWords.Length == 0)
            RespondToInvalidInput(controller);
        else
            controller.roomNavigation.AttemptToChangeRooms(seperatedInputWords);
    }

    public override void RespondToInvalidInput(GameController controller)
    {
        controller.AddToMainOutput("Go where?");
    }
}
