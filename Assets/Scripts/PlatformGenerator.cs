﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platform;
    public Transform generationPoint;
    public float distanceBetween;
    public float platformWidth;
    // Start is called before the first frame update
    void Start()
    {
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        generate();
    }

    void generate() {
        if (transform.position.x < generationPoint.position.x) {
            transform.position = new Vector2(transform.position.x + platformWidth + distanceBetween, transform.position.y);
            Instantiate (platform, transform.position, transform.rotation);
        }
    }
}