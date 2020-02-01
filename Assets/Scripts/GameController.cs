using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
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
        StartCoroutine(SpawnStages());        
    }

    IEnumerator SpawnStages ()
    {
        yield return new WaitForSeconds(waveWait);
        GameObject Stage = Stages[Random.Range(0, Stages.Length)];
        Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(Stage, spawnPosition, spawnRotation);
        
    }
}
