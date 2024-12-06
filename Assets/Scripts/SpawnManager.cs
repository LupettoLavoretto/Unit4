using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject  powerUp;
    public float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;



    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup();
    }

    // Update is called once per frame
    void Update()
    {
        //Con questa logica: prendiamo l'array della quantità di oggetti "Enemy" in scena. Quando scende a zero, avviamo uno spawnEnemyWave. Quanti Enemy fa spawnare?
        //Parte da 1 (la waveNumber iniziale) e poi incrementa ogni volta quel valore di uno.
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0)
        {
            waveNumber ++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();

        }
    }

    /// Metodi


    //Non è private void perché ci deve comunque dare un dato, che è un Vector3. Return ci permette di avere il dato "pubblico". Return è fondamentale per restituire dati a altre funzioni (come lo usa Mattia in Ink)
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPosition = new Vector3(spawnPositionX,0,spawnPositionZ);

        return randomPosition;
    }


    void SpawnEnemyWave(int enemyToSpawn)
    {
        //Questo è un famoso "for loop": inizializzo una variabile i a 0, e dico a C# di ripetere il codice fino a quando i non è minore di enemyToSpawn. A ogni ciclo aumento il valore di i di 1 (i++)
        for (int i = 0; i < enemyToSpawn; i++)
        {

        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);

        }
    }

    void SpawnPowerup()
    {
        Instantiate(powerUp, GenerateSpawnPosition(), powerUp.transform.rotation);
    }
}
