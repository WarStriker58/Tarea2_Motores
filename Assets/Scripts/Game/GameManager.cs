using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int score = 0;
    private float distanceScore = 0f; // Puntuación basada en la distancia
    public Text scoreText; // Referencia al objeto de texto para mostrar el puntaje
    public Text distanceText; // Referencia al objeto de texto para mostrar la distancia

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
    }

    private void Update()
    {
        // Actualiza la puntuación basada en la distancia
        UpdateDistanceScore();
        // Actualiza el texto del puntaje y la distancia
        UpdateUIText();
    }

    public void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        UpdateUIText(); // Actualiza el texto del puntaje
    }

    private void UpdateDistanceScore()
    {
        // Incrementa la puntuación basada en la distancia en función del tiempo transcurrido
        distanceScore += Time.deltaTime * 30; // Ajusta el factor multiplicativo según tus necesidades
    }

    private void UpdateUIText()
    {
        // Actualiza el texto mostrando el puntaje y la distancia
        scoreText.text = "Score: " + score;
        distanceText.text = "Distance: " + distanceScore.ToString("F0"); // Formatea la distancia como un entero
    }
}