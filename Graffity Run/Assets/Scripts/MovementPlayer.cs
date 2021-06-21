using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementPlayer : MonoBehaviour
{
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

    public GameObject audioObject;
    private AudioSource FXaudioSource;
    private AudioSource MUSICaudioSource;
    public AudioClip partOneMusic;
    public AudioClip Music;
    public AudioClip Jump;
    public AudioClip Death;

    public AudioClip winSound;

    public GameObject winScreen;

    public GameObject parallax;

    public bool resetPressed = false;

    void Awake()
    {
        //if (!SceneManager.GetSceneByName("DontDestroyOnLoad").IsValid()) DontDestroyOnLoad(audioObject);
        FXaudioSource = audioObject.transform.Find("FXaudio").GetComponent<AudioSource>();
        MUSICaudioSource = audioObject.transform.Find("MUSICaudio").GetComponent<AudioSource>();
    }
    void Start()
    {
        MUSICaudioSource.clip = partOneMusic;
        MUSICaudioSource.Play();
        _rigidbody2D = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (resetPressed)
        {
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene("Test");
            }
        }

        if (!timerReached)
            timer += Time.deltaTime;

        if (!timerReached && timer > 1)
        {
            Debug.Log("Done waiting");

            timerReached = true;
        }
        //Debug.Log(onGround);
        // Keypress [Gravity Change]
        if (timerReached)
        {
            if (onGround == true)
            {
                if (Input.GetKeyDown("space"))
                {
                    FXaudioSource.clip = Jump;
                    FXaudioSource.Play();
                    _rigidbody2D.gravityScale *= -1;
                    for (int i = 0; i < 360; i++)
                    {
                        if (i % 2 == 0) player.transform.Rotate(1, 0, 0);
                    }
                }
            }
            // Movement
            playercam.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "DEATH")
        {
            FXaudioSource.clip = Death;
            FXaudioSource.Play();
            SceneManager.LoadScene("Test");
        }

        if (col.gameObject.tag == "WIN")
        {
            MUSICaudioSource.clip = winSound;
            MUSICaudioSource.loop = false;
            MUSICaudioSource.Play();
            trashPandaHellEdition.SetActive(false);
            winScreen.SetActive(true);
            bossPlatforms.SetActive(false);
            resetPressed = true;
            player.SetActive(false);

        }

        if (col.gameObject.tag == "BOSS")
        {
            bossPlatforms.SetActive(true);
            bossTrigger.SetActive(false);
            trashPandaHellEdition.SetActive(true);
            player.transform.position = new Vector3(player.transform.position.x - 3, player.transform.position.y, 5);

            MUSICaudioSource.clip = Music;
            MUSICaudioSource.Play();
            Debug.Log("BOSS");
        }

        onGround = true;
        //Debug.Log("onGround = true");
    }

    void OnCollisionExit2D(Collision2D col)
    {
        onGround = false;
        //Debug.Log("onGround = false");
    }

}

