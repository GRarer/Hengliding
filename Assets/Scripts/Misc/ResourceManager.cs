using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [Header("Hen Breed materials")]
    public HenMaterials newHampshireMaterials;
    public HenMaterials silkiematerials;
    public HenMaterials ayamCemaniMaterials;

    static ResourceManager rm;
    public static ResourceManager Instance() {
        return rm;
    }
    void Awake() {
        if (rm == null) {
            rm = this;
        } else {
            Destroy(this);
        }
    }

    public HenMaterials GetHenMaterial(Raising.HenBreed breed) {

        switch(breed) {
            case Raising.HenBreed.RedStar:
            return newHampshireMaterials;
            case Raising.HenBreed.Silkie:
            return silkiematerials;
            case Raising.HenBreed.AyamCemani:
            return ayamCemaniMaterials;
        }
        return newHampshireMaterials;
    }
}

[System.Serializable]
public class HenMaterials {

    public Material featherMat;
    public Material eyeMat;
    public Material crownMat;
    public Material beakMat;
}