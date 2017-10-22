using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Look")]
public class Look : InputAction
{
    public override void RespondToInput(GameController controller, string inputWords)
    {
        bool haveFoundObject = false;
        if (inputWords.Length == 0)
            controller.DisplayFeedbackText("Look where?");
        else
        {
            // Look at objects in current location
            haveFoundObject = controller.roomNavigation.LookAtItemsInCurrentLocation(inputWords);
            if (!haveFoundObject)
            {
                // Look through inventory
                haveFoundObject = controller.inventory.LookAtInventoryItems(inputWords);
            }
        }
        if (!haveFoundObject)
        {
            controller.DisplayFeedbackText("Can't look at " + inputWords);
        }
                
    }

    public override void RespondToInvalidInput(GameController controller)
    {
        controller.DisplayFeedbackText("You can't look at that");
    }
}
