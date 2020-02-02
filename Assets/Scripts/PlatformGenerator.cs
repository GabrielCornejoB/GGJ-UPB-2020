using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

  public GameObject theStage;
  public Transform generationPoint;
  private float platformWidth;
  private float stageWidth;
  public GameObject[] stages;
    DestroyByTime _destroyByTime;

    // Start is called before the first frame update
    void Start()
  {
    stageWidth = theStage.GetComponent<BoxCollider2D>().size.x;
  }

  public void SetInScene()
  {
    GameObject[] stages = new GameObject[2];
    stages[0] = Resources.Load <GameObject>("Stages/Stage1");
    stages[1] = Resources.Load <GameObject>("Stages/Stage2");
    }

  // Update is called once per frame
  void Update()
  {
    if (transform.position.x < generationPoint.position.x)
    {
        GameObject nextStage = stages[Random.Range(0, stages.Length - 1)];
        transform.position = new Vector3(transform.position.x + stageWidth, transform.position.y, transform.position.z);
    //   Component[] generators = theStage.GetComponentsInChildren<PlatformGenerator>();
    //   foreach (PlatformGenerator generator in generators)
    //   {
    //     generator.theStage = nextStage;
    //     generator.generationPoint = generationPoint;
    //     generator.stages = stages;
    //   }
        GameObject currentStage = Instantiate(nextStage, transform.position, transform.rotation);
        currentStage.GetComponentInChildren<PlatformGenerator>().SetInScene();
        nextStage.AddComponent<DestroyByTime>();    
        nextStage.GetComponent<DestroyByTime>().lifeTime = 10;
    }
  }
}
