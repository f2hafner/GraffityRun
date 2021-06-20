using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroyAudio : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(audioSource);
        /*foreach(var root in dontDestroyAudio.scene.GetRootGameObjects()){
            if(root.GetType() == typeof(GameObject)){
                root.GetComponent<AudioSource>();
            }
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
