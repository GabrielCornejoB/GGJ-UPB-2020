using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    // public GameObject thePlatform;
    public GameObject theStage;
    public Transform generationPoint;
    // public float distanceBetween;
    private float platformWidth;
    DestroyByTime _destroyByTime;

    private float stageWidth;

    // Start is called before the first frame update
    void Start()
    {
        // platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        stageWidth = theStage.GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x) {
            transform.position = new Vector3(transform.position.x + stageWidth, transform.position.y, transform.position.z);
            

            
            GameObject nextStage = Instantiate(theStage, transform.position, transform.rotation);
            nextStage.AddComponent<DestroyByTime>();
            nextStage.GetComponent<DestroyByTime>().lifeTime = 10;
        }
    }
}
