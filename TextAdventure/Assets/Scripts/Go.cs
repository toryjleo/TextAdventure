using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="TextAdventure/InputActions/Go")]
public class Go : InputAction
{

    public override void RespondToValidInput(GameController controller, string[] seperatedInputWords)
    {
        controller.roomNavigation.AttemptToChangeRooms(seperatedInputWords[1]);
    }

    public override void RespondToInvalidInput(GameController gameController)
    {
        gameController.LogStringWithReturn("Go where?");
    }
}
