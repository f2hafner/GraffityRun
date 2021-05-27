using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public GameObject player;

    public float speed = 10;

    void Update()
    {
        player.transform.position += new Vector3(speed*Time.deltaTime,0,0);
    }
}
