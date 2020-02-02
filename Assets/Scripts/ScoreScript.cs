using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Rigidbody2D rb;

    public int scoreValue = 1;
    public PlayerController playerController; 

    public Text scoreText;
    private int score;

    public AudioSource moneda;

    private void Awake()
    {
        //playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerController = GetComponent<PlayerController>();

    }

    void Start()
    {              
        score = 0;
    }
    /*
    void Update()
    {
        if (score == 100 || score == 200 || score == 300)
        {
            playerController.ChangePlayer();
        }
    }
    */
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
            moneda.Play(0);
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            AddScore(scoreValue);
        }
    }
}
