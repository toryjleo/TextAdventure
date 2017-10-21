using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Inventory")]
public class Inventory : InputAction
{
    // Never called
    public override void RespondToInvalidInput(GameController gameController)
    {
        gameController.DisplayFeedbackText("Invalid");
    }

    public override void RespondToInput(GameController gameController, string seperatedInputWords)
    {
        gameController.DisplayFeedbackText("Inventory: " + gameController.inventory.GetItemsString());
    }
}
