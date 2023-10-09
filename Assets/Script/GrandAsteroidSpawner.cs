using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandAsteroidSpawner : MonoBehaviour
{
    public GameObject GrandasteroidPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 3.0f; // Intervalo de spawn en segundos


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
            GameObject Grandasteroid1 = Instantiate(GrandasteroidPrefab, spawnPoint.position, Quaternion.identity);

            // Agrega un componente personalizado para rastrear las colisiones con las balas.
            AsteroidCollisionTracker tracker1 = Grandasteroid1.AddComponent<AsteroidCollisionTracker>();

            //tracker1.GrandasteroidSpawner = this; // Asigna una referencia al spawner
            // Espera el intervalo de spawn.
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
