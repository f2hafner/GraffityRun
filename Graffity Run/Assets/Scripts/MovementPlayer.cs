using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public GameObject playercam;
    public GameObject player;
    public float speed = 10F;
    public bool gravityReverse = false; //true means gravity reversed
    public bool onGround = false; // is player on a Ground
    public float gravity = 1F;
    private Rigidbody2D _rigidbody2D;


    private void Start()
    {
        _rigidbody2D = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.Log(onGround);
        // Keypress [Gravity Change]
        if(onGround == true){
            if(Input.GetKeyDown("space")){
                _rigidbody2D.gravityScale *= -1;
            }
        }

        // Movement
        playercam.transform.position += new Vector3(speed*Time.deltaTime,0,0);
    }

    void OnCollisionEnter2D(Collision2D col) {
        onGround = true;
        Debug.Log("onGround = true");
    }

    void OnCollisionExit2D(Collision2D col) {
        onGround = false;
        Debug.Log("onGround = false");
    }
}
