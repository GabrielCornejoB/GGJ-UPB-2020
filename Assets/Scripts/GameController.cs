using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
<<<<<<< HEAD
    
=======
    public GameObject[] Stages;
    public Vector3 spawnValues;

    public int stagesCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;


    void Start()
    {
    }

    void Update()
    {
        // StartCoroutine(SpawnStages());        
    }

    IEnumerator SpawnStages ()
    {
        
        GameObject Stage = Stages[0];
        Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(Stage, spawnPosition, spawnRotation);
        yield return new WaitForSeconds(waveWait);
    }
>>>>>>> f9abee489bb629a514551fab7ede75ec62dd7a67
}
