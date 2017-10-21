using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Inventory")]
public class Inventory : InputAction
{
    // Never called
    public override void RespondToInvalidInput(GameController gameController)
    {
        gameController.AddToMainOutput("Invalid");
    }

    public override void RespondToInput(GameController gameController, string seperatedInputWords)
    {
        gameController.AddToMainOutput("Inventory: " + gameController.inventory.GetItemsString());
    }
}
