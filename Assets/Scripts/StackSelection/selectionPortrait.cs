using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectionPortrait : MonoBehaviour
{

    public Sprite[] breedSprites;
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = breedSprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateImage(HenInfo hen) {
        int i = hen.breedNumber;

        if (i > 0 && i < 3) {
            image.sprite = breedSprites[i];
        }
    }
}
