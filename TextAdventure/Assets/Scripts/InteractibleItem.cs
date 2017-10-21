using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InteractibleObject/InteractibleItem")]
public class InteractibleItem : InteractibleObject
{
    public bool isActive = true;

    public override void Reset()
    {
        isActive = true;
    }

    public override void Use(Location currentLocation)
    {
        throw new System.NotImplementedException();
    }
}
