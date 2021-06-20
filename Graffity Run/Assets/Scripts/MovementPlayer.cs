using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementPlayer : MonoBehaviour{
    public GameObject playercam;
    public GameObject player;
    public float speed = 15F;
    public bool gravityReverse = false; //true means gravity reversed
    public bool onGround = false; // is player on a Ground
    public float gravity = 1F;
    private Rigidbody2D _rigidbody2D;
    float timer = 0;
    bool timerReached = false;


    private void Start()
    {
        _rigidbody2D = player.GetComponent<Rigidbody2D>();
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
            SceneManager.LoadScene("Test");
            Debug.Log("DEATH");
        }
        onGround = true;
        //Debug.Log("onGround = true");
    }

    void OnCollisionExit2D(Collision2D col) {
        onGround = false;
        //Debug.Log("onGround = false");
    }
}
