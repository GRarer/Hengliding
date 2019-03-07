using UnityEngine;
using UnityEditor;

public abstract class Item : MonoBehaviour {

    public string name;
    public int cost;
    public Mesh itemMesh;
    
    public abstract void UseItem();

    public bool CanAfford(int playerMoney) { return playerMoney >= cost; }
}