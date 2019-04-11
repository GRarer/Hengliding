using UnityEngine;

public class FoodPowerUp : Item {


    public override bool CanBeBought() {return true;}
    public override void UseItem() {
        Debug.LogError("Not implemented yet!");
    }
}