using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerStaticReference : MonoBehaviour
{

    public static SoundManager GetSoundManager() {
        return FindObjectOfType<SoundManager>();
    }
    
    public static SoundOptions GetSoundOptions() {
        return FindObjectOfType<SoundOptions>();
    }

}
