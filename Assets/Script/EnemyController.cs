using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f; // Velocidad de movimiento del enemigo
    public float fireRate = 2f; // Tasa de disparo (disparos por segundo)
    public GameObject bulletPrefab; // Prefab de la bala
    public Transform firePoint; // Punto de disparo de las balas

    private float nextFireTime;

    void Start()
    {
        // Inicializa el tiempo del pr�ximo disparo
        nextFireTime = Time.time + 1f / fireRate;
    }

    void Update()
    {
        // Mueve el enemigo de izquierda a derecha dentro de la c�mara
        float horizontalMovement = Mathf.Sin(Time.time * speed);
        transform.Translate(Vector3.right * horizontalMovement * Time.deltaTime);

        // Comprueba si es hora de disparar
        if (Time.time >= nextFireTime)
        {
            Shoot(); // Dispara
            nextFireTime = Time.time + 1f / fireRate; // Actualiza el tiempo del pr�ximo disparo
        }
    }

    void Shoot()
    {
        // Crea una instancia de la bala en el punto de disparo
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
