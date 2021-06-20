using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour {

    public GameObject parentObject;
    public GameObject cityPrefab;
    public float widthOfBGObject;
    GameObject[] backgroundObjects;
    public int layoutZLevel;
    public GameObject cam;
    
    public float scrollSpeed;

    public float height;
    private void Start(){
        backgroundObjects = new GameObject[3];
        backgroundObjects[0] = Instantiate(cityPrefab, new Vector3(0-widthOfBGObject,height,layoutZLevel), Quaternion.Euler(0, 0, 0), parentObject.transform);
        backgroundObjects[1] = Instantiate(cityPrefab, new Vector3(0,height,layoutZLevel), Quaternion.Euler(0, 0, 0), parentObject.transform);
        backgroundObjects[2] = Instantiate(cityPrefab, new Vector3(0+widthOfBGObject,height,layoutZLevel), Quaternion.Euler(0, 0, 0), parentObject.transform);
    }

    void Update(){
        backgroundObjects[0].transform.Translate(scrollSpeed, 0, 0);
        backgroundObjects[1].transform.Translate(scrollSpeed, 0, 0);
        backgroundObjects[2].transform.Translate(scrollSpeed, 0, 0);

        if(backgroundObjects[0].transform.position.x < cam.transform.position.x-(widthOfBGObject*2)){
            backgroundObjects[0].transform.position = new Vector3(cam.transform.position.x+widthOfBGObject,height,layoutZLevel);
            Debug.Log("BGSwitchOccured");
        }
        if(backgroundObjects[1].transform.position.x < cam.transform.position.x-(widthOfBGObject*2)){
            backgroundObjects[1].transform.position = new Vector3(cam.transform.position.x+widthOfBGObject,height,layoutZLevel);
            Debug.Log("BGSwitchOccured");
        }
        if(backgroundObjects[2].transform.position.x < cam.transform.position.x-(widthOfBGObject*2)){
            backgroundObjects[2].transform.position = new Vector3(cam.transform.position.x+widthOfBGObject,height,layoutZLevel);
            Debug.Log("BGSwitchOccured");
        }
        //-0.001
    }
}

