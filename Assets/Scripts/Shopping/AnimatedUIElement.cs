using UnityEngine.UI;
using UnityEngine;

public abstract class AnimatedUIElement : MonoBehaviour {


    public abstract void OnSelect();
    public abstract void OnDeselect();
    public abstract void Show();
}