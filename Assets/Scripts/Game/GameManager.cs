using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int score = 0;
    private float distanceScore = 0f;
    public Text scoreText;
    public Text distanceText;
    private bool isPaused = false;
    private AudioSource bgMusic;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        bgMusic = GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponent<AudioSource>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        if (!isPaused)
        {
            UpdateDistanceScore();
        }
        UpdateUIText();
    }

    public void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        UpdateUIText();
    }

    private void UpdateDistanceScore()
    {
        distanceScore += Time.deltaTime * 30;
    }

    private void UpdateUIText()
    {
        scoreText.text = "Score: " + score;
        distanceText.text = "Distance: " + distanceScore.ToString("F0");
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
        if (bgMusic != null)
        {
            if (isPaused)
            {
                bgMusic.Pause();
            }
            else
            {
                bgMusic.UnPause();
            }
        }
        if (playerMovement != null)
        {
            playerMovement.enabled = !isPaused;
        }
    }
}