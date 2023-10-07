using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        // Obtiene el puntaje almacenado desde PlayerPrefs
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);

        // Muestra el puntaje en el objeto de texto
        scoreText.text = "Final Score: " + finalScore;
    }
}
