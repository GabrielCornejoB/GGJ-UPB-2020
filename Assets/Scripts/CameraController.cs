using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController playerController;

    private Vector3 lastPlayerPosition;
    private float distanceToMove;


    // Start is called before the first frame update
    void Start()
    {
        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        if (playerControllerObject != null)
        {
            playerController = playerControllerObject.GetComponent<PlayerController>();
        }
        lastPlayerPosition = playerController.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToMove = playerController.transform.position.x - lastPlayerPosition.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        lastPlayerPosition = playerController.transform.position;
    }
}
