using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 18;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = 6;
    public int pointValue;
    public ParticleSystem explosionParticle;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        //Per chiamare il game manager
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        targetRb.AddTorque(RandomTorque(), RandomTorque(),RandomTorque(),ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Se clicco il tasto destro del mouse, ho bisogno che venga distrutto l'oggetto che tocco.
    private void OnMouseDown()
    {
        Destroy(gameObject);
        //Così chiamo e aggiorno il punteggio dal game manager script
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
    }

    //Se l'oggetto tocca "Sensor", viene distrutto.
    private void OnTriggerEnter (Collider other)
    {
        Destroy(gameObject);
    }


    //Moltiplica un valore già esistente per i due estremi del Random.Range
    Vector3 RandomForce(){
        return Vector3.up * Random.Range(minSpeed,maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque,maxTorque);
    }

    //Qui utilizziamo "new" perché creiamo un nuovo valore (rispetto a RandomForce dove moltiplichiamo un valore già esistente, il Vector3.up)
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), -ySpawnPos);
    }

}
