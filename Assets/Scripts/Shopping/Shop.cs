using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public List<Item> itemsForSale;

    public GridLayoutGroup itemsHolder;
    public ShopItemUIEntry shopItemUIEntryTemplate;
    public ShopItemUIEntry selectedUIEntry;
    public Text playerFundsText;
    public Text itemDescriptionText;
    public Button buyButton;

    Item selectedItem;

    void OnEnable() {
        OpenShop();
    }
    void OnDisable() {
        CloseShop();
    }

    int GetPlayerMoney() {
        return InventoryPersist.getMoney();
    }

    void Initialize() {
        SetFundsText();
        CreateItemList();
    }

    void CreateItemList() {

        int playerFunds = GetPlayerMoney();

        foreach (Item i in itemsForSale) {
            ShopItemUIEntry uiEntry = GameObject.Instantiate(shopItemUIEntryTemplate, itemsHolder.transform).GetComponent<ShopItemUIEntry>();
            uiEntry.Initialize(i);
            //uiEntry.gameObject.transform.parent = itemsHolder.transform;
        }
    }

    void SetCanBuyEachItem() {
        foreach (Transform t in itemsHolder.transform) {
            t.GetComponent<ShopItemUIEntry>().SetTextColorOnAffordability();
        }
    }

    void OpenShop() {
        Initialize();
        
        CameraController cam = GameObject.FindObjectOfType<CameraController>();
        if (cam) {
            //cam.enabled = false;
        }
    }

    void SetFundsText() {

        playerFundsText.text = "Funds: $" + GetPlayerMoney();
    }

    void CloseShop() {
        CameraController cam = GameObject.FindObjectOfType<CameraController>();
        if (cam) {
            //cam.enabled = true;
        }

        foreach(Transform child in itemsHolder.transform) {
            Destroy(child.gameObject);
        }
    }

    public void Pay(Item cost) {
    }

    public void BuySelectedItem() {

        //Pay(selectedItem);

        if (selectedItem.CanAfford(InventoryPersist.getMoney())) {
            // TODO play "purchase made" sound
            InventoryPersist.setMoney(InventoryPersist.getMoney() - selectedItem.cost);
            selectedItem.UseItem();
            SetFundsText();
        } else {
            // TODO play "purchase failed" sound, if wanted
        }
        
    }

    public void SelectItem(Item item, ShopItemUIEntry uiEntry) {

        selectedItem = item;
        itemDescriptionText.text = item.description;

        // mark the last selected UI entry as not selected so the image stops bouncing
        if (selectedUIEntry) {
            selectedUIEntry.isSelected = false;
        }
        selectedUIEntry = uiEntry;
        selectedUIEntry.isSelected = true;

        buyButton.gameObject.SetActive(item != null);
    }
}