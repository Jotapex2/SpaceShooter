using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public Text scoreText;
    public int score = 0; // Variable para llevar un registro de la puntuación
    public static scoreManager Instance { get; private set; }

    private void Awake()
    {
        // Asegúrate de que solo haya una instancia de ScoreManager en la escena
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
        // Asegúrate de configurar la referencia al Texto en tu inspector
        if (scoreText == null)
        {
            Debug.LogError("No se ha asignado el Texto de puntuación en el inspector.");
        }

        // Inicializa la puntuación en 0 al comenzar el juego
        UpdateScoreDisplay();
    }

    // Método para sumar puntos
    public void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        UpdateScoreDisplay();
    }

    // Método para actualizar el texto de puntuación en la UI
    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Puntuación: " + score;
        }
    }
}
