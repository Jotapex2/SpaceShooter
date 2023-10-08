using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoASpawn : MonoBehaviour
{
    public GameObject EnemyAPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 5.0f; // Intervalo de spawn en segundos

    private void Start()
    {
        // Comienza el proceso de spawn de enemigos.
        StartCoroutine(SpawnEnemyA());
    }

    IEnumerator SpawnEnemyA()
    {
        while (true) // Esto generará enemigos continuamente.
        {
            // Genera un enemigo en la posición del spawnPoint.
            GameObject enemy = Instantiate(EnemyAPrefab, spawnPoint.position, Quaternion.identity);

            // Espera el intervalo de spawn.
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
