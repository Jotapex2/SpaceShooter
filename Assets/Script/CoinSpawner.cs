using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 5.0f; // Intervalo de spawn en segundos
  

    private void Start()
    {
        // Comienza el proceso de spawn de monedas.
        StartCoroutine(SpawnCoins());
    }

    IEnumerator SpawnCoins()
    {
        while (true) // Esto generará monedas continuamente.
        {
            // Genera dos monedas.
            GameObject coin1 = Instantiate(coinPrefab, spawnPoint.position, Quaternion.identity);
            GameObject coin2 = Instantiate(coinPrefab, spawnPoint.position + new Vector3(2.0f, 0.0f, 0.0f), Quaternion.identity);

    
            // Espera el intervalo de spawn.
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}