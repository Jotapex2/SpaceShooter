using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;
    public float fireRate = 2f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public ParticleSystem explosionParticles;
    public AudioClip explosionSound;
    public float invisibilityDuration = 2.0f; // Cambiado a 2 segundos
    private bool isInvincible = true; // Inicialmente invisible

    // Referencia al componente SpriteRenderer del enemigo
    private SpriteRenderer enemyRenderer;

    // Parámetros del parpadeo
    private float blinkInterval = 0.2f; // Intervalo entre parpadeos (en segundos)

    private float nextFireTime;

    void Start()
    {
        // Inicializa el tiempo del próximo disparo
        nextFireTime = Time.time + 1f / fireRate;

        // Inicia la corrutina de invisibilidad y parpadeo
        StartCoroutine(ActivateInvisibility());
    }

    private IEnumerator ActivateInvisibility()
    {
        float startTime = Time.time;
        float endTime = startTime + invisibilityDuration;

        // Realiza el parpadeo mientras dure la invisibilidad
        while (Time.time < endTime)
        {
            enemyRenderer.enabled = !enemyRenderer.enabled; // Alterna la visibilidad
            yield return new WaitForSeconds(blinkInterval);
        }

        // Asegura que el objeto sea visible al final de la invisibilidad
        enemyRenderer.enabled = true;

        isInvincible = false;
    }

    void Update()
    {
        float horizontalMovement = Mathf.Sin(Time.time * speed);
        transform.Translate(Vector3.right * horizontalMovement * Time.deltaTime);

        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.gameObject.tag;

        if (tag == "bullet" || tag == "Player")
        {
            if (explosionSound != null)
            {
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            }

            if (explosionParticles != null)
            {
                ParticleSystem explosion = Instantiate(explosionParticles, transform.position, Quaternion.identity);
                Renderer particleRenderer = explosion.GetComponent<Renderer>();

                if (particleRenderer != null)
                {
                    particleRenderer.sortingLayerName = "Explosion";
                }
                else
                {
                    Debug.LogWarning("El objeto de partículas no tiene un componente Renderer.");
                }

                Destroy(gameObject);
            }
        }
    }
}
