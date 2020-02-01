using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Rigidbody2D rb;

    public int scoreValue = 10;
    //public GameController gameController;

    public Text scoreText;
    private int score;

    /*
    public int curRepair;
    public int maxRepair = 3;

    bool repair;
    */

    void Start()
    {       
        //curRepair = 0;
        score = 0;
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    //public void SubstractScore(int )

    public void UpdateScore()
    {
        scoreText.text = "" + score;

    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            Destroy(other.gameObject);
            AddScore(scoreValue);
        }
    }
    /*
    public void Repair(int rpr)
    {
        curRepair += rpr;
        repair = true;
    }
    */

}
