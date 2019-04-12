using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgradeable : MonoBehaviour
{
    public Material[] levelMaterials;
    public MeshRenderer[] meshesToRecolor;
    public SkinnedMeshRenderer[] skinnedMeshesToRecolor;
    
    public void SetMaterial(int matIndex) {

        
        if (matIndex >= levelMaterials.Length) {
            Debug.LogError("level exceeds number of upgrade materials!");
        } else {
            Material upgradeRecolor = levelMaterials[matIndex];
            foreach (MeshRenderer mr in meshesToRecolor) {
                mr.sharedMaterial = upgradeRecolor;
            }
            foreach (SkinnedMeshRenderer mr in skinnedMeshesToRecolor) {
                mr.sharedMaterial = upgradeRecolor;
            }
        }
    }
}
public class DraggableUpgradeable : Raising.Interaction.Draggable {
    
    public Material[] levelMaterials;
    public MeshRenderer[] meshesToRecolor;
    public SkinnedMeshRenderer[] skinnedMeshesToRecolor;
    
    public void SetMaterial(int matIndex) {

        
        if (matIndex >= levelMaterials.Length) {
            Debug.LogError("Feeder level exceeds number of upgrade materials!");
        } else {
            Material upgradeRecolor = levelMaterials[matIndex];
            foreach (MeshRenderer mr in meshesToRecolor) {
                mr.sharedMaterial = upgradeRecolor;
            }
            foreach (SkinnedMeshRenderer mr in skinnedMeshesToRecolor) {
                mr.sharedMaterial = upgradeRecolor;
            }
        }
    }
}