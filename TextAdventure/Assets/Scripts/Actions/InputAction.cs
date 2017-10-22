using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputAction : ScriptableObject {

    public string keyWord;

    public abstract void RespondToInput(GameController controller, string inputWords);

    public abstract void RespondToInvalidInput(GameController controller);

}
