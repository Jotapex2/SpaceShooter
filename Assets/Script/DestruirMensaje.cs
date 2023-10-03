using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirMensaje : MonoBehaviour
{
    public GameObject androidSpawnPointPrefab; // Arrastra el Prefab androidSpawnPoint aquí en el Inspector
    public scoreManager scoreManager;

    private void OnBecameInvisible()
    {
        // Spawnea el Prefab androidSpawnPoint en la posición (0, 4, 0)
        Instantiate(androidSpawnPointPrefab, new Vector3(0f, 4f, 0f), Quaternion.identity);

        // Destruye este objeto (el objeto actual al que se adjunta este script)
        Destroy(gameObject);
    }
    public void Start()
    {
        scoreManager.score = 0;
    }
}