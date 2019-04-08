using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItemUIEntry : Toggle {


    public Text itemCostText;
    public Image itemIcon;
    public Image selectionRing;
    public bool isHighlighted;
    
    public bool isSelected;
    public float itemBounceSpeed = 5;
    public AnimationCurve itemImageBounce;
    public float bounceHeight;
    Vector3 initialIconPosition;
    float progress = 0;

    public AnimationCurve scaleOnClickCurve;

    Shop shop;
    Item item;

    public void Initialize(Item i) {

        // ideally these wouldn't be necessary but there is a Unity inspector 
        // bug where classes that inherit from Selectable do not show all member variables
        if (itemCostText == null) {
            itemCostText = transform.GetComponentInChildren<Text>();
        }
        if (itemIcon == null) {
            itemIcon = transform.Find("Icon").GetComponent<Image>();
        }

        item = i;
        itemCostText.text = "$" + item.cost;
        itemIcon.sprite     = item.itemSprite;
        //itemIcon.transform.localScale = new Vector3(item.itemUIScaleFactor, item.itemUIScaleFactor, item.itemUIScaleFactor);

        SetTextColorOnAffordability();

        initialIconPosition = itemIcon.transform.localPosition;

        shop = GameObject.FindObjectOfType<Shop>();
    }

    public void SetTextColorOnAffordability() {

        if (!item.CanAfford(InventoryPersist.getMoney())) {
            itemCostText.color = Color.red;
        } else {
            itemCostText.color = Color.red;
        }
    }

    void Update() {
        if (EventSystem.current && EventSystem.current.currentSelectedGameObject) {
//            Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        }

        //isHighlighted = IsHighlighted(null);
        //isSelected = isSelected || IsPressed(); // if the user clicks on this, we select it, but we don't deselect it on mouse up
        if (IsPressed()) {
            //EventSystem.current.SetSelectedGameObject(this.gameObject);
            shop.SelectItem(item, this);
        }
        if (EventSystem.current) {
            //isSelected = EventSystem.current.currentSelectedGameObject == this.gameObject;
        }

        if (isSelected) {
            
            Select();

            progress += Time.deltaTime;
            if (progress > 1) progress = 0;
            
            // bounce the object up and down
            float bounce = itemImageBounce.Evaluate(progress * itemBounceSpeed);
            itemIcon.transform.localPosition = initialIconPosition + Vector3.up * bounceHeight * bounce;
        } else {
            itemIcon.transform.localPosition = initialIconPosition;
        }
    }

}