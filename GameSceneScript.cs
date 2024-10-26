using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneScript : MonoBehaviour
{
    // Referenz auf den PlayerController, der den Spieler steuert
    public PlayerController player;

    // Referenz auf die Kamera, die der Szene folgt
    public Camera gameCamera;

    // Start wird einmalig beim Start des Spiels ausgefuehrt
    void Start()
    {
        // Hier kann Code eingefuegt werden, der beim Start ausgefuehrt werden soll
    }

    // Update wird einmal pro Frame aufgerufen und aktualisiert die Kamera-Position
    void Update()
    {
        // Setzt die Position der Kamera, um dem Spieler mit sanfter Uebergaengen zu folgen
        gameCamera.transform.position = new Vector3(
            // Bewegt die Kamera schrittweise auf die x-Position des Spielers zu
            Mathf.Lerp(gameCamera.transform.position.x, player.transform.position.x, 0.01f),
            
            // Uebernimmt die y-Position des Spielers direkt
            player.transform.position.y,
            
            // Bewegt die Kamera schrittweise auf eine Position hinter dem Spieler
            Mathf.Lerp(gameCamera.transform.position.z, player.transform.position.z - 15, 0.01f)
        );
    }
}
