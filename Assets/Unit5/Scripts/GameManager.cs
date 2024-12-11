using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Elementi da spawnare")]
    public List<GameObject> targets;
    private float spawnRate = 1.0f;

    [Header("Gestione punteggio")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    private int score;
    public Button restartButton;
    [Header("UI")]
    public GameObject titleScreen;




    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        //Lo spawn si ferma se il gioco è disattivato, quindi Game Over
        while(isGameActive){
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

    public void GameOver() 
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

    }

    //Per far ripartire il gioco.
    //Nota importante: chiamiamo la funzione poi sul bottone, sotto "OnClick()"così da configurarlo
     public void RestartGame()
     {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     } 

      public void StartGame(int difficulty)
      {
        //L'ordine del codice conta: isGameActive deve essere prima della coroutine, o non parte nulla :D
        isGameActive = true;
        //Più è alto il numero con cui dividiamo lo spawnRate, più alta è la frequenza di spawning degli oggetti
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
      }
}
