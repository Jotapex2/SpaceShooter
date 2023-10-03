using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image[] lifeImages; // Asigna las imágenes de vida desde el Inspector.
    private int lives = 3; // Cantidad de vidas del jugador (puedes cambiar esto según tu juego).

    // Añade una referencia al Canvas que contiene las imágenes de vida.
    public GameObject lifeCanvas;
    public int asteroidsNeededToWin = 30; // Cantidad necesaria de asteroides para ganar

    private int asteroidsDestroyed = 0;

    private void Start()
    {
        // Puedes encontrar el Canvas por su nombre o etiqueta, dependiendo de tu configuración.
        lifeCanvas = GameObject.Find("LifeCanvas");

        // Luego, puedes obtener las imágenes de vida desde el Canvas.
        lifeImages = lifeCanvas.GetComponentsInChildren<Image>();
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

    // Método para reducir una vida cuando el jugador colisiona con un enemigo, por ejemplo.
    public void ReduceLife()
    {
        if (lives > 0)
        {
            lives--;
            UpdateLifeImages();

            if (lives <= 0)
            {
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
