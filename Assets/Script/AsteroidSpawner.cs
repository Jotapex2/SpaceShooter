using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 3.0f; // Intervalo de spawn en segundos
    public int asteroidsNeededToWin = 30; // Cantidad necesaria de asteroides para ganar
    private int asteroidsSpawned = 0;

    private void Start()
    {
        // Comienza el proceso de spawn de asteroides.
        StartCoroutine(SpawnAsteroids());
    }

    IEnumerator SpawnAsteroids()
    {
        while (true) // Esto generará asteroides continuamente.
        {
            // Genera dos asteroides.
            GameObject asteroid1 = Instantiate(asteroidPrefab, spawnPoint.position, Quaternion.identity);
            GameObject asteroid2 = Instantiate(asteroidPrefab, spawnPoint.position + new Vector3(2.0f, 0.0f, 0.0f), Quaternion.identity);

            // Agrega un componente personalizado para rastrear las colisiones con las balas.
            AsteroidCollisionTracker tracker1 = asteroid1.AddComponent<AsteroidCollisionTracker>();
            AsteroidCollisionTracker tracker2 = asteroid2.AddComponent<AsteroidCollisionTracker>();

            tracker1.asteroidSpawner = this; // Asigna una referencia al spawner
            tracker2.asteroidSpawner = this; // Asigna una referencia al spawner

            asteroidsSpawned += 2; // Incrementa el contador de asteroides generados.

           /*
            if (asteroidsSpawned >= asteroidsNeededToWin)
            {
                // El jugador ha ganado, carga la escena de victoria.
                SceneManager.LoadScene("WinScene");
            */

            // Espera el intervalo de spawn.
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}