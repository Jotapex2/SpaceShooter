using UnityEngine.SceneManagement;
using UnityEngine;

public class AsteroidCollisionTracker : MonoBehaviour
{
    public AsteroidSpawner asteroidSpawner;
    public scoreManager scoreManager; // Aseg�rate de que la variable tenga el mismo nombre (may�sculas y min�sculas) que el script ScoreManager

    private int asteroidsDestroyed = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            // Cuando una bala colisiona con el asteroide, destruye el asteroide y aumenta el contador de asteroides destruidos.
            Destroy(gameObject);
            asteroidsDestroyed++;

            if (scoreManager != null)
            {
                scoreManager.score += 10; // Suma 10 puntos por cada asteroide destruido
            }

            // Verifica si se han destruido suficientes asteroides para ganar.
            if (asteroidsDestroyed >= asteroidSpawner.asteroidsNeededToWin)
            {            
                scoreManager.Instance.SaveScore();
                // El jugador ha ganado, carga la escena de victoria.
                SceneManager.LoadScene("WinScene");
            }
        }
    }
}