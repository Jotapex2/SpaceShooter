using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadingSceneController : MonoBehaviour

{
    public Slider progressBar;  // Referencia al componente Slider (Barra de progreso)

    public void Start()
    {
        StartLoading();
    }

    // M�todo para iniciar la carga de la escena
    public void LoadScene(string GameScene)
    {
        StartCoroutine(LoadSceneAsync(GameScene));
    }

    // Cambi� el nombre del m�todo de Start() a StartLoading()
    public void StartLoading()
    {
        StartCoroutine(LoadSceneAsync("GameScene")); // Reemplaza "NombreDeTuEscena" con el nombre real de la escena.
    }

    private IEnumerator LoadSceneAsync(string GameScene)
    {
        // Inicia la carga de la escena de manera as�ncrona
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(GameScene);

        // Evita que la escena se active autom�ticamente al terminar la carga
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            // Actualiza la barra de progreso
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            progressBar.value = progress;

            // Checa si la escena ha terminado de cargar (el valor de progress llega hasta 0.9)
            if (asyncOperation.progress >= 0.9f)
            {
                // Activa la escena cuando est� lista
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
