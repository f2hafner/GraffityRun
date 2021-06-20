using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementPlayer : MonoBehaviour{
    public GameObject playercam;
    public GameObject player;
    public GameObject dino;
    public float speed = 15F;
    public bool gravityReverse = false; //true means gravity reversed
    public bool onGround = false; // is player on a Ground
    public float gravity = 1F;
    private Rigidbody2D _rigidbody2D;
    bool timerReached = false;
    float timer = 0;
    public GameObject bossPlatforms;
    public GameObject bossTrigger;
    public GameObject trashPandaHellEdition;
    public GameObject FXaudioSource;
    private AudioSource fxAudioSource;
    private AudioSource audioSourceObject;
    public AudioClip Music;
    public AudioClip Jump;
    public AudioClip Death;

    private void Start()
    {
        _rigidbody2D = player.GetComponent<Rigidbody2D>();
        GameObject[] objectList = SceneManager.GetSceneByName("DontDestroyOnLoad").GetRootGameObjects();
        audioSourceObject = objectList[0].GetComponent<AudioSource>();
        fxAudioSource = FXaudioSource.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!timerReached)
        timer += Time.deltaTime;

        if (!timerReached && timer > 1){
        Debug.Log("Done waiting");

        timerReached = true;
        }
        //Debug.Log(onGround);
        // Keypress [Gravity Change]
        if(timerReached){
            if(onGround == true){
                if(Input.GetKeyDown("space")){
                    fxAudioSource.clip = Jump;
                    fxAudioSource.Play();
                    _rigidbody2D.gravityScale *= -1;
                    for (int i = 0; i < 360; i++)
                    {
                        if(i%2 == 0) player.transform.Rotate(1,0,0);
                    }
                }
            }

            // Movement
            playercam.transform.position += new Vector3(speed*Time.deltaTime,0,0);
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "DEATH")
        { 
            //fxAudioSource.clip = Death;
            //fxAudioSource.Play();
            SceneManager.LoadScene("Test");
        }

        if (col.gameObject.tag == "BOSS")
        { 
            bossPlatforms.SetActive(true);
            bossTrigger.SetActive(false);
            trashPandaHellEdition.SetActive(true);
            
            audioSourceObject.clip = Music;
            audioSourceObject.Play();
            Debug.Log("BOSS");
        }

        onGround = true;
        //Debug.Log("onGround = true");
    }

    void OnCollisionExit2D(Collision2D col) {
        onGround = false;
        //Debug.Log("onGround = false");
    }

}
