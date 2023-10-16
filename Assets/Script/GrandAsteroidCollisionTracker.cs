using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrandAsteroidCollisionTracker : MonoBehaviour
{
    public AsteroidSpawner asteroidSpawner;
    public scoreManager scoreManager; 
    public GameObject asteroidPrefab; // Prefab del asteroide 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            // Cuando una bala colisiona con el asteroide, destruye el asteroide y aumenta el contador de asteroides destruidos.
            Destroy(gameObject);
            // Instancia de un nuevo asteroide
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
