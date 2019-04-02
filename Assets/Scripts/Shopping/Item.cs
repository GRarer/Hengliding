using UnityEngine;
using UnityEditor;

public abstract class Item : MonoBehaviour {

    public string name;
    public string description;
    public int cost;
    public Sprite itemSprite;
    public float itemUIScaleFactor = 1;
    
    public abstract void UseItem();

    /*
        Should always be true for items that can be purchased infinitely, like chickens.
        For items that can only be purchased once, this should only be true
        if the item is not purchased yet, and if all previous upgrades have been
        bought.
     */
    public abstract bool CanBeBought();

    public bool CanAfford(int playerMoney) { return playerMoney >= cost; }
}