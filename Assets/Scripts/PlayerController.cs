using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public bool hasPowerUp = false;
    public float powerUpStrength = 15f;
    public GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //In questo modo il "davanti" non è quello dell'oggetto player, ma sempre quello della camera
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        powerupIndicator.transform.position = transform.position;

    }

    //Metodo utile in generale per i collider
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            //questo è il metodo che abbiamo incontrato anche nel tutorial ink per attivare/disattivare il box di testo.
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            //La Coroutine mi permette di avviare questo benedetto countdown
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        //questo blocchetto mi permette di avere una gestione del tempo separata da Update, che è l'altro contatore temporale del codice.
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    //Metodo utile se vuoi lavorare con la fisica del gioco
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {

            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);

            Debug.Log("Collided with:" + collision.gameObject.name + "with power up set to " + hasPowerUp);
        }
    }



}
