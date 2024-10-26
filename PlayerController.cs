using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Die Sprungkraft des Spielers
    public float jumpForce = 300;
    
    // Die Bewegungskraft des Spielers
    public float moveForce = 250;

    // Variable, um zu ueberpruefen, ob der Spieler springen kann
    private bool canJump = false;

    // Variable, um zu ueberpruefen, ob der Spieler die Ebene gewechselt hat
    private bool hasSwitchedLayers = false;

    // Start wird einmalig beim Start des Spiels ausgefuehrt
    void Start()
    {
        // Hier kann Code eingefuegt werden, der beim Start ausgefuehrt werden soll
    }

    // FixedUpdate wird in regelmaessigen Abstaenden ausgefuehrt und ist gut fuer Physik-Berechnungen
    void FixedUpdate()
    {
        // Wenn die Taste "A" gedrueckt wird, bewegt sich der Spieler nach links
        if (Input.GetKey("a"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(
                -moveForce * Time.deltaTime,          // Setzt die Geschwindigkeit nach links
                GetComponent<Rigidbody>().velocity.y,  // Behaelt die y-Geschwindigkeit bei
                GetComponent<Rigidbody>().velocity.z   // Behaelt die z-Geschwindigkeit bei
            );
        }

        // Wenn die Taste "D" gedrueckt wird, bewegt sich der Spieler nach rechts
        if (Input.GetKey("d"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(
                moveForce * Time.deltaTime,           // Setzt die Geschwindigkeit nach rechts
                GetComponent<Rigidbody>().velocity.y, // Behaelt die y-Geschwindigkeit bei
                GetComponent<Rigidbody>().velocity.z  // Behaelt die z-Geschwindigkeit bei
            );
        }
    }

    // Update wird einmal pro Frame aufgerufen
    private void Update()
    {
        // Wenn "W" gedrueckt wird und der Spieler springen kann, fuehrt er einen Sprung aus
        if (Input.GetKeyDown("w") && canJump)
        {
            canJump = false; // Verhindert weiteres Springen, bis er den Boden beruehrt
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
        }

        // Wenn die Leertaste gedrueckt wird, wechselt der Spieler die Ebene
        if (Input.GetKey("space"))
        {
            // Prueft, ob der Spieler die Ebene gewechselt hat und aendert die Position
            if (hasSwitchedLayers)
            {
                this.transform.position = new Vector3(
                    this.transform.position.x,
                    this.transform.position.y,
                    0 // Setzt die Z-Position zurueck auf 0
                );
            }
            else
            {
                this.transform.position = new Vector3(
                    this.transform.position.x,
                    this.transform.position.y,
                    10 // Setzt die Z-Position auf 10 fuer die andere Ebene
                );
            }
            
            hasSwitchedLayers = !hasSwitchedLayers; // Wechselt den Zustand der Ebene
        }
    }

    // Diese Methode wird ausgefuehrt, wenn der Spieler auf ein Objekt trifft
    private void OnCollisionEnter(Collision collision)
    {
        canJump = true; // Erlaubt dem Spieler nach der Landung wieder zu springen
    }
}
