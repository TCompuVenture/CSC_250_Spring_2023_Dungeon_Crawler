using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepSadMusicPlaying : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
