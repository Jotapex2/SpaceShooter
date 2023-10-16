using UnityEngine.SceneManagement;
using UnityEngine;

public class AsteroidCollisionTracker : MonoBehaviour
{
    public AsteroidSpawner asteroidSpawner;
    public scoreManager scoreManager; 

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
                scoreManager.score += 20; // Suma 20 puntos por cada asteroide destruido
            }
        }
    }
}