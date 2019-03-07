using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public List<Item> itemsForSale;

    public VerticalLayoutGroup itemsHolder;
    public ShopItemUIEntry shopItemUIEntryTemplate;
    public Text playerFundsText;

    int GetPlayerMoney() {
        return 0;
    }

    void Initialize() {

        CreateItemList();
    }

    void CreateItemList() {

        int playerFunds = GetPlayerMoney();

        foreach (Item i in itemsForSale) {
            ShopItemUIEntry uiEntry = GameObject.Instantiate(shopItemUIEntryTemplate).GetComponent<ShopItemUIEntry>();
            uiEntry.Initialize(i, playerFunds);
            uiEntry.gameObject.transform.parent = itemsHolder;
        }
    }

    void OpenShop() {
        playerFundsText.text = "$" + GetPlayerMoney();
    }

    void CloseShop() {
        
    }

    public void Pay(int cost) {
        // TODO subtract money from the player's wallet
    }

    public void BuyItem(Item item) {

        Pay(item.cost);

        // TODO Play sound
        
    }
}