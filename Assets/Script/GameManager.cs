using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image[] lifeImages; // Asigna las im�genes de vida desde el Inspector.
    private int lives = 3; // Cantidad de vidas del jugador (puedes cambiar esto seg�n tu juego).

    // A�ade una referencia al Canvas que contiene las im�genes de vida.
    public GameObject lifeCanvas;
  

    private void Start()
    {
        // Puedes encontrar el Canvas por su nombre o etiqueta, dependiendo de tu configuraci�n.
        lifeCanvas = GameObject.Find("LifeCanvas");

        // Luego, puedes obtener las im�genes de vida desde el Canvas.
        lifeImages = lifeCanvas.GetComponentsInChildren<Image>();
    }

    // M�todo para actualizar las im�genes de vida en el Canvas.
    void UpdateLifeImages()
    {
        for (int i = 0; i < lifeImages.Length; i++)
        {
            // Activa o desactiva las im�genes de vida seg�n la cantidad actual de vidas.
            lifeImages[i].gameObject.SetActive(i < lives);
        }
    }

    // M�todo para reducir una vida cuando el jugador colisiona con un enemigo, por ejemplo.
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

    // M�todo para aumentar una vida cuando el jugador recoge un power-up, por ejemplo.
    public void IncreaseLife()
    {
        if (lives < lifeImages.Length)
        {
            lives++;
            UpdateLifeImages();
        }
    }

 
}
