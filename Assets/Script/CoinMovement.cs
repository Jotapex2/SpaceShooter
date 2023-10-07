using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinMovement : MonoBehaviour
{
    private float speed; // Velocidad de movimiento de la moneda
    private bool collected = false; // Variable para evitar la recolecci�n m�ltiple
    public AudioClip explosionSound; // Opcional: sonido de explosi�n

    public ParticleSystem explosionParticles; // Referencia al sistema de part�culas de explosi�n


    void Start()
    {
        // Genera una velocidad aleatoria entre 1 y 4 (ajusta seg�n sea necesario)
        speed = Random.Range(1f, 4f);

        // Genera una posici�n X aleatoria en la parte superior de la c�mara
        float randomX = Random.Range(Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).x, Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x);
        transform.position = new Vector3(randomX, Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).y, 0);
    }

    void Update()
    {
        // Mueve la moneda hacia abajo
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Verifica si la moneda est� fuera de la vista de la c�mara
        if (!IsVisibleFromCamera())
        {
            // Destruye la moneda
            Destroy(gameObject);
        }
    }

    bool IsVisibleFromCamera()
    {
        // Verifica si el objeto est� dentro de la vista de la c�mara
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        return GeometryUtility.TestPlanesAABB(planes, GetComponent<Renderer>().bounds);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !collected)
        {
            // Suma 10 puntos al score
            scoreManager.Instance.AddPoints(10);

            // Reproduce el sonido de explosi�n 
            if (explosionSound != null)
            {
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            }

            // Instancia el sistema de partículas de explosión
if (explosionParticles != null)
{
    ParticleSystem explosion = Instantiate(explosionParticles, transform.position, Quaternion.identity);

    // Obtén el componente Renderer del sistema de partículas
    Renderer particleRenderer = explosion.GetComponent<Renderer>();

    if (particleRenderer != null)
    {
        // Define el Sorting Layer que deseas para el sistema de partículas
        particleRenderer.sortingLayerName = "Explosion"; 
    }
    else
    {
        Debug.LogWarning("El objeto de partículas no tiene un componente Renderer.");
    }
}

            // Destruye la moneda
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        // Destruye la bala cuando sale de la vista de la c�mara
        Destroy(gameObject);
    }
}
