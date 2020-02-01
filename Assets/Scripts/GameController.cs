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
        StartCoroutine(SpawnStages());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnStages ()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; 1 < stagesCount; i++)
            {
                GameObject Stage = Stages[Random.Range(0, Stages.Length)];

                Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(Stage, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
        }
    }
}
