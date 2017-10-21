using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InteractibleObject/InteractibleItem")]
public class InteractibleNonTakeable : InteractibleObject
{
    public override void Use(Location currentLocation)
    {
        throw new System.NotImplementedException();
    }
}
