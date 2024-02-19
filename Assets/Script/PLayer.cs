using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PLayer : MonoBehaviour
{


    public float turnSpeed;

    public int health;
    int score;
    public TMP_Text healthDisplay;
    public TMP_Text scoreDisplay;

    [SerializeField] private AudioSource Boom;
    [SerializeField] private AudioSource Points;

    GameOverManager gameOverManager;

  



    // Start is called before the first frame update
    void Start()
    {
        gameOverManager = FindObjectOfType<GameOverManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * turnSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime);
    }



    public void TakeDame()
    {
        health--;
        healthDisplay.text = "Health: " + health;
        Boom.Play();
        if (health <= 0)
        {
            gameOverManager.ShowGameOverScreen(score);
            Time.timeScale = 0;
        }
    }

    public void AddScore()
    {
        score++;
        Points.Play();
        scoreDisplay.text = "Score: " + score;
    }
}
