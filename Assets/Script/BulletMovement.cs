using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletMovement : MonoBehaviour
{
    // Se llama cuando la bala colisiona con otro objeto
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si la colisión es con un asteroide
        if (collision.CompareTag("Asteroid"))
        {
            // Destruye la bala
            Destroy(gameObject);

            // Suma 10 puntos al puntaje
            scoreManager scoreManager = FindObjectOfType<scoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddPoints(10);
            }
        }
    }
    void Update()
    {
        transform.Translate(new Vector2(0.0f, 1.0f) * Time.deltaTime * 10f);
    }
    // Se llama cuando el objeto se hace invisible para la cámara
    private void OnBecameInvisible()
    {
        // Destruye la bala cuando sale de la vista de la cámara
        Destroy(gameObject);
    }
}