using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{

    public GameObject Boss;

    public GameObject ProjectilePrefab;
    public GameObject parent;
    public float speed;

    public float offset;
    public int lowerBound;
    public int upperBound;

    public int lowerAdd;
    public int upperAdd;
    private float funcAngle;
    private int value;
    private float update;
    public void Start()
    {
        value = Random.Range(lowerBound, upperBound);
        funcAngle = 0;
        update = 0.0f;
    }

    public void Update()
    {
        update += Time.deltaTime;
        if (update > 1.0f)
        {
            StartCoroutine(Shooter());
            update = 0.0f;
        }

        if (funcAngle >= 360)
        {

            funcAngle = 0;
        }

        float y = offset * Mathf.Sin(funcAngle);
        Boss.transform.position = new Vector3(Boss.transform.parent.gameObject.transform.position.x + 7.5f + y / 25, y, 5);
        funcAngle += speed;

    }

    IEnumerator Shooter()
    {
        Debug.LogWarning("Coroutine");
        yield return new WaitForSeconds(Random.Range(lowerBound, upperBound));
        Instantiate(ProjectilePrefab, new Vector3(Boss.transform.position.x - 1, Boss.transform.position.y, 1), Quaternion.Euler(0, 0, 0), parent.transform);
    }
}