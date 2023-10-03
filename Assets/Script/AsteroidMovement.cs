using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public ParticleSystem explosionParticles; // Referencia al sistema de partículas de explosión
    public AudioClip explosionSound; // Opcional: sonido de explosión

    private float speed; // Velocidad de descenso del asteroide

    void Start()
    {
        // Genera una velocidad aleatoria entre 1 y 4
        speed = Random.Range(1f, 4f);

        // Genera una posición X aleatoria en la parte superior de la cámara
        float randomX = Random.Range(Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).x, Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x);
        transform.position = new Vector3(randomX, Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).y, 0);
    }

    void Update()
    {
        // Desciende el asteroide
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Verifica si el asteroide está fuera de la vista de la cámara
        if (!IsVisibleFromCamera())
        {
            // Destruye el asteroide
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
        string tag = other.gameObject.tag;

        if (tag == "bullet" || tag == "Player")
        {
            // Reproduce el sonido de explosión 
            if (explosionSound != null)
            {
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            }

            // Instancia el sistema de partículas de explosión
            if (explosionParticles != null)
            {
                Instantiate(explosionParticles, transform.position, Quaternion.identity);
            }

            // Destruye el asteroide
            Destroy(gameObject);
        }
    }
}