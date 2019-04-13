using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerStaticReference : MonoBehaviour
{

    static SoundManager GetSoundManager() {
        return FindObjectOfType<SoundManager>();
    }
    
    static SoundOptions GetSoundOptions() {
        return FindObjectOfType<SoundOptions>();
    }

}
