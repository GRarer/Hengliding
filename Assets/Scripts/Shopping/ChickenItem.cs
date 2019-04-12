using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenItem : Item
{

    public Raising.HenBreed henBreed;

    public override bool CanBeBought() {
        return true;
    }

    public override void UseItem() {
        Debug.LogError("Not implemented yet!");
    }
}
