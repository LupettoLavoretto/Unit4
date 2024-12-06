using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRange = 9;
    // Start is called before the first frame update
    void Start()
    {

        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Non è private void perché ci deve comunque dare un dato, che è un Vector3. Return ci permette di avere il dato "pubblico". Return è fondamentale per restituire dati a altre funzioni (come lo usa Mattia in Ink)
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPosition = new Vector3(spawnPositionX,0,spawnPositionZ);

        return randomPosition;
    }
}
