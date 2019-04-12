using UnityEngine;

public class FeederPowerup : FoodPowerUp {

    public int level;

    public override bool CanBeBought() {
        return InventoryPersist.getFeederLevel() + 1 == level;
    }
    public override void UseItem() {

        Raising.Interaction.Feeder f = GameObject.FindObjectOfType<Raising.Interaction.Feeder>()
            .GetComponent<Raising.Interaction.Feeder>();
            f.RaiseLevel();
        
    }
}