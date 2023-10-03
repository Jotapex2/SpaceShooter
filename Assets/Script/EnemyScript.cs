using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    public int health = 10;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        string name = col.gameObject.name;
        Debug.Log("Collision detected enemy: " + name);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        string name = other.gameObject.name;
        Debug.Log("Trigger with " + name);

        if (other.CompareTag("bullet")) // Verifica la etiqueta en lugar de nombre
        {
            Destroy(other.gameObject); // Destruye la bala
            health--;

            if (health <= 0)
            {
                Destroy(gameObject); // Destruye al enemigo
            }
        }
    }
}