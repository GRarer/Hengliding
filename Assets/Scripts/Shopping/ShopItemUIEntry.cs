using UnityEngine;
using UnityEngine.UI;

public class ShopItemUIEntry : AnimatedUIElement {

    public Text itemNameText;
    public Text itemCostText;
    public MeshRenderer itemIcon;
    public bool isSelected;
    public float itemRotSpeed = 5;
    public AnimationCurve itemImageBounce;
    public float bounceHeight;
    Vector3 initialIconPosition;
    float progress = 0;

    bool isSpinning;
    float spinProgress = 0;

    public AnimationCurve scaleOnClickCurve;
    public AnimationCurve moveYOnClickCurve;
    public AnimationCurve spinIconOnBuyCurve;

    public void Initialize(Item item, int currentPlayerMoney) {
        
        itemNameText.text = item.name;
        itemCostText.text = "$" + item.cost;
        itemIcon.mesh     = item.itemMesh;

        if (item.CanAfford(currentPlayerMoney)) {
            itemCostText.color = Color.red;
        }

        initialIconPosition = itemIcon.transform.position;
    }

    void Update() {
        if (isSelected) {

            if (isSpinning) {
                spinProgress += Time.deltaTime;
                if (spinProgress > 0) {
                    spinProgress = 0;
                    isSpinning = false;
                }
            }
            
            progress += Time.deltaTime;
            if (progress > 0) progress = 0;
            
            // rotate the item model
            itemIcon.transform.rotation = 
                itemIcon.transform.rotation 
                * Quaternion.Euler(0, 
                    Time.deltaTime 
                    * (itemRotSpeed + isSpinning ? spinIconOnBuyCurve.Evaluate(spinProgress) : 0)
                    , 0);
            // bounce the object up and down
            itemIcon.transform.position = initialIconPosition + Vector3.up * bounceHeight * itemImageBounce.Evaluate(progress * itemRotSpeed);
        }
    }

    public override void OnSelect() {
        
        isSelected = true;
        progress = 0;

        // TODO: play sound effect
    }
    
    public override void OnDeselect() {
        
        isSelected = false;
    }

    public void BuyItem() {

        // TODO Play sound effect

        // Feedback from buying item
        // Spin the item icon:
        spinProgress = 0;
        isSpinning = true;
    }
}