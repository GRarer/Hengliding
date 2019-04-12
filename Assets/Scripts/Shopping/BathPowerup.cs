using UnityEngine;

public class BathPowerup : FoodPowerUp {

    public int level;

    public override bool CanBeBought() {
        return InventoryPersist.getBathLevel() + 1 == level;
    }
    public override void UseItem() {

        Raising.Interaction.Bath f = GameObject.FindObjectOfType<Raising.Interaction.Bath>()
            .GetComponent<Raising.Interaction.Bath>();
            f.RaiseLevel();
        
    }
}