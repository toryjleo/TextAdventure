using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractibleObject : ScriptableObject {
    public string objectName;
    [TextArea] public string description;
    public abstract void Use(Location currentLocation);
    public abstract void Reset();
}
