using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public Camera camara;
    public GameObject bullet;
    // Añade una referencia al Canvas que contiene las imágenes de vida.
    public GameObject lifeCanvas;

    public int lives = 3; // Cantidad de vidas del jugador
    public float invisibilityDuration = 10.0f; // Duración de la invisibilidad en segundos
    private bool isInvincible = false; // Indicador de invisibilidad

    // Punto de inicio del jugador (configúralo en el Inspector)
    public Transform startPoint;

    // Referencia al componente SpriteRenderer del jugador
    private SpriteRenderer playerRenderer;

    // Parámetros del parpadeo
    private float blinkInterval = 0.2f; // Intervalo entre parpadeos (en segundos)

    private GameManager gameManager; // Referencia al GameManager

    private void Start()
    {
        // Obtén la referencia al componente SpriteRenderer
        playerRenderer = GetComponent<SpriteRenderer>();

        // Encuentra el GameManager en la escena
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("TouchSelected");
            Touch touch = Input.GetTouch(0);
            Vector3 posicionEnPantalla = touch.position;
            Vector3 touchPosition = camara.ScreenToWorldPoint(new Vector3(posicionEnPantalla.x, posicionEnPantalla.y, 10f));
            transform.position = touchPosition;
        }
        if (Input.touchCount >= 2)
        {
            Touch toque = Input.GetTouch(1);
            if (toque.phase == TouchPhase.Began)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Asteroid") && !isInvincible)
        {
            // Pierde una vida
            lives--;
            Debug.Log("Pierdes una vida");

            // Comunica al GameManager sobre la pérdida de vida
            gameManager.ReduceLife();

            {
                // Teletransporta al jugador al punto de inicio
                TeleportToStartPosition();

                // Activa la invisibilidad durante el tiempo especificado
                StartCoroutine(ActivateInvisibility());
            }
        }
    }

    private void TeleportToStartPosition()
    {
        // Teletransporta al jugador al punto de inicio
        transform.position = startPoint.position;
    }

    private IEnumerator ActivateInvisibility()
    {
        isInvincible = true;

        // Calcula la cantidad de parpadeos
        int blinkCount = Mathf.FloorToInt(invisibilityDuration / (2 * blinkInterval));

        // Realiza el parpadeo
        for (int i = 0; i < blinkCount; i++)
        {
            // Hace que el objeto sea visible
            playerRenderer.enabled = true;

            // Espera el intervalo de parpadeo
            yield return new WaitForSeconds(blinkInterval);

            // Hace que el objeto sea invisible
            playerRenderer.enabled = false;

            // Espera el intervalo de parpadeo nuevamente
            yield return new WaitForSeconds(blinkInterval);
        }

        // Asegura que el objeto sea visible al final de la invisibilidad
        playerRenderer.enabled = true;

        isInvincible = false;
        // Restaura cualquier efecto de invisibilidad que hayas configurado.


    }
}
