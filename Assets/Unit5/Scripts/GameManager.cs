using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Elementi da spawnare")]
    public List<GameObject> targets;
    private float spawnRate = 1.0f;

    [Header("Gestione punteggio")]
    public TextMeshProUGUI scoreText;
    private int score;




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while(true){
            //Qui diciamo di attendere per il tempo indicato da SpawnRate
            yield return new WaitForSeconds(spawnRate);
            //Qui chiamiamo un index che prende un valore random tra 0 e la quantità massima di elementi nella nostra lista.
            //"Count" sta alle liste come "Length" sta agli array
            int index = Random.Range(0,targets.Count);
            //Qui gli diciamo di instanziare l'oggetto con il valore di indice che abbiamo randomizzato.
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd; 
        scoreText.text = "Score: " + score;

    }
}
