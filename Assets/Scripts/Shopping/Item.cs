using UnityEngine;
using UnityEditor;

public abstract class Item : MonoBehaviour {

    public string name;
    public string description;
    public int cost;
    public Sprite itemSprite;
    public float itemUIScaleFactor = 1;
    
    public abstract void UseItem();

    public bool CanAfford(int playerMoney) { return playerMoney >= cost; }
}