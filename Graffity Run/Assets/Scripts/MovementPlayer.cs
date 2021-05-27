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
    

    void Update()
    {
        // Keypress [Gravity Change]
        if(onGround == true){
            if(Input.GetKeyDown("space")){
                player.GetComponent<Rigidbody2D>().gravityScale *= -1;
            }
        }

        // Movement
        playercam.transform.position += new Vector3(speed*Time.deltaTime,0,0);
    }

    void OnCollisionEnter2D(Collision2D col) {
        onGround = true;
    }
    void OnCollisionExit2D(Collision2D col) {
        onGround = false;
    }
}
