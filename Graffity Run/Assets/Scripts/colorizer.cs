using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class colorizer : MonoBehaviour
{
    private bool satChangeable = true;
    public GameObject cam;
    public GameObject PostProcessingObject;
    private ColorGrading grading;
    public float xLevelEnd;
    private float scalingConstant;
    private PostProcessVolume processingVolume;
    // Start is called before the first frame update
    void Start()
    {
        scalingConstant = ((Mathf.Abs(xLevelEnd) / (1000)) * (Mathf.Abs(200 / xLevelEnd)));
        processingVolume = PostProcessingObject.GetComponent<PostProcessVolume>();
        processingVolume.profile.TryGetSettings(out grading);
    }

    // Update is called once per frame
    void Update()
    {
        if (satChangeable) grading.saturation.value = ((cam.transform.position.x * scalingConstant) - 100);
        if (grading.saturation.value > 50 && satChangeable) satChangeable = false;
        Debug.Log("Scaler: " + scalingConstant + "\t x: " + cam.transform.position.x + "\t sat: " + grading.saturation.value);
    }
}
