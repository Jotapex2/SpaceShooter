using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrandAsteroidCollisionTracker : MonoBehaviour
{
    public AsteroidSpawner asteroidSpawner;
    public scoreManager scoreManager; // Aseg�rate de que la variable tenga el mismo nombre (may�sculas y min�sculas) que el script ScoreManager
    public GameObject asteroidPrefab; // Prefab del asteroide 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            // Cuando una bala colisiona con el asteroide, destruye el asteroide y aumenta el contador de asteroides destruidos.
            Destroy(gameObject);
            // Instancia dos nuevos asteroides
            for (int i = 0; i < 2; i++)
            {
                Instantiate(asteroidPrefab, transform.position, Quaternion.identity);
            }

            if (scoreManager != null)
            {
                scoreManager.score += 50; // Suma 50 puntos por cada asteroide grande destruido
            }
        }
    }
}
