using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image[] lifeImages; // Asigna las imágenes de vida desde el Inspector.
    private int lives = 3; // Cantidad de vidas del jugador.

    // Añade una referencia al Canvas que contiene las imágenes de vida.
    public GameObject lifeCanvas;
    public scoreManager scoreManager; //Score

    public int scoreToWin = 2000; // Puntaje necesario para ganar

    private void Start()
    {
     
        lifeCanvas = GameObject.Find("LifeCanvas");

        lifeImages = lifeCanvas.GetComponentsInChildren<Image>();
    }

    private void Update()
    {
        int currentScore = scoreManager.score; // Obtiene el puntaje actual desde el script de administración de puntuación.

        // Verifica si el jugador ha alcanzado el puntaje necesario para ganar.
        if (currentScore >= scoreToWin)
        {
            // Cambia a la escena de victoria.
            SceneManager.LoadScene("WinScene");
        }
    }

    // Método para actualizar las imágenes de vida en el Canvas.
    void UpdateLifeImages()
    {
        for (int i = 0; i < lifeImages.Length; i++)
        {
            // Activa o desactiva las imágenes de vida según la cantidad actual de vidas.
            lifeImages[i].gameObject.SetActive(i < lives);
        }
    }

    // Método para reducir una vida cuando el jugador colisiona con un enemigo.
    public void ReduceLife()
    {
        if (lives > 0)
        {
            lives--;
            UpdateLifeImages();

            if (lives <= 0)
            {
                scoreManager.Instance.SaveScore();
                SceneManager.LoadScene("LooseScene");
            }
        }
    }

    // Método para aumentar una vida cuando el jugador recoge un power-up, por ejemplo.
    public void IncreaseLife()
    {
        if (lives < lifeImages.Length)
        {
            lives++;
            UpdateLifeImages();
        }
    }
}
