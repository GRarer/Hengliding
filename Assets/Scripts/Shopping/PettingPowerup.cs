using UnityEngine;

public class PettingPowerup : FoodPowerUp {

    public int level;

    public override bool CanBeBought() {
        return InventoryPersist.getPettingLevel() + 1 == level;
    }
    public override void UseItem() {

        Raising.Interaction.Brush f = GameObject.FindObjectOfType<Raising.Interaction.Brush>()
            .GetComponent<Raising.Interaction.Brush>();
            f.RaiseLevel();
        
    }
}