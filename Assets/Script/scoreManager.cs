using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public Text scoreText;
    public int score = 0; // Variable para llevar un registro de la puntuaci�n
    public static scoreManager Instance { get; private set; }

    private void Awake()
    {
        // Aseg�rate de que solo haya una instancia de ScoreManager en la escena
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // Si ya existe una instancia, destruye esta para evitar duplicados
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        // Aseg�rate de configurar la referencia al Texto en tu inspector
        if (scoreText == null)
        {
            Debug.LogError("No se ha asignado el Texto de puntuaci�n en el inspector.");
        }

        // Inicializa la puntuaci�n en 0 al comenzar el juego
        UpdateScoreDisplay();
    }

    // M�todo para sumar puntos
    public void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        UpdateScoreDisplay();
    }

    // M�todo para actualizar el texto de puntuaci�n en la UI
    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
    public void SaveScore()
      {
    PlayerPrefs.SetInt("FinalScore", score);
    PlayerPrefs.Save();
      }

}
