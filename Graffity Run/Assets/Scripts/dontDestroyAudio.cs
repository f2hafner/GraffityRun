using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroyAudio : MonoBehaviour
{
    public AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(AudioSource);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
