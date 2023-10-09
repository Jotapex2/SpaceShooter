﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f; // Velocidad de movimiento del enemigo
    public float fireRate = 2f; // Tasa de disparo (disparos por segundo)
    public GameObject bulletPrefab; // Prefab de la bala
    public Transform firePoint; // Punto de disparo de las balas
    public ParticleSystem explosionParticles; // Referencia al sistema de part�culas de explosi�n
    public AudioClip explosionSound; // Opcional: sonido de explosi�n

    private float nextFireTime;

    void Start()
    {
        // Inicializa el tiempo del próximo disparo
        nextFireTime = Time.time + 1f / fireRate;
    }

    void Update()
    {
        // Mueve el enemigo de izquierda a derecha dentro de la cámara
        float horizontalMovement = Mathf.Sin(Time.time * speed);
        transform.Translate(Vector3.right * horizontalMovement * Time.deltaTime);

        // Comprueba si es hora de disparar
        if (Time.time >= nextFireTime)
        {
            Shoot(); // Dispara
            nextFireTime = Time.time + 1f / fireRate; // Actualiza el tiempo del próximo disparo
        }
    }

    void Shoot()
    {
        // Crea una instancia de la bala en el punto de disparo
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    // Método llamado cuando el enemigo colisiona con otro objeto
    void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.gameObject.tag;

        if (tag == "bullet" || tag == "Player")
        {
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
                // Destruye el asteroide
                Destroy(gameObject);
            }
        }
    }
    }
