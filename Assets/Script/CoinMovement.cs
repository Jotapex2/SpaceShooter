using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinMovement : MonoBehaviour
{
    private float speed; // Velocidad de movimiento de la moneda
    private bool collected = false; // Variable para evitar la recolección múltiple
    public AudioClip explosionSound; // Opcional: sonido de explosión


    void Start()
    {
        // Genera una velocidad aleatoria entre 1 y 4 (ajusta según sea necesario)
        speed = Random.Range(1f, 4f);

        // Genera una posición X aleatoria en la parte superior de la cámara
        float randomX = Random.Range(Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).x, Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x);
        transform.position = new Vector3(randomX, Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).y, 0);
    }

    void Update()
    {
        // Mueve la moneda hacia abajo
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Verifica si la moneda está fuera de la vista de la cámara
        if (!IsVisibleFromCamera())
        {
            // Destruye la moneda
            Destroy(gameObject);
        }
    }

    bool IsVisibleFromCamera()
    {
        // Verifica si el objeto está dentro de la vista de la cámara
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        return GeometryUtility.TestPlanesAABB(planes, GetComponent<Renderer>().bounds);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !collected)
        {
            // Suma 10 puntos al score
            scoreManager.Instance.AddPoints(10);

            // Reproduce el sonido de explosión 
            if (explosionSound != null)
            {
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            }

            // Destruye la moneda
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        // Destruye la bala cuando sale de la vista de la cámara
        Destroy(gameObject);
    }
}
