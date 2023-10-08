using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletMovement1 : MonoBehaviour
{
    // Se llama cuando la bala colisiona con otro objeto
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si la colisi�n es con un asteroide
        if (collision.CompareTag("Player"))
        {
            // Destruye la bala
            Destroy(gameObject);
        }
    }
    void Update()
    {
        // Mueve la bala hacia abajo
        transform.Translate(Vector2.down * Time.deltaTime * 10f);
    }
    // Se llama cuando el objeto se hace invisible para la c�mara
    private void OnBecameInvisible()
    {
        // Destruye la bala cuando sale de la vista de la c�mara
        Destroy(gameObject);
    }
}