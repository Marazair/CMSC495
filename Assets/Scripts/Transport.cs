using System.Collections;
using UnityEngine;

public class Transport : MonoBehaviour {
        
    public Transform teleportTarget;
    public PlayerController player;

    void OnTriggerEnter2D(Collider2D other)
    {   
        player.InterruptMove();
        player.transform.position = teleportTarget.transform.position;
    }
}
