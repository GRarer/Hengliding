using UnityEngine;

public class TreadmillPowerUp : Item {


    public int level;

    public override bool CanBeBought() {
        return InventoryPersist.getTreadmillLevel() + 1 == level;
    }
    public override void UseItem() {

        Raising.Interaction.Treadmill f = GameObject.FindObjectOfType<Raising.Interaction.Treadmill>()
            .GetComponent<Raising.Interaction.Treadmill>();
            f.RaiseLevel();
        
    }
}