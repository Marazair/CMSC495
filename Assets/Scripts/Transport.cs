using System.Collections;
using UnityEngine;

public class Transport : MonoBehaviour {
        
    public Transform teleportTarget;
    public GameObject Player;

    void OnTriggerEnter2D(Collider2D other)
    {    
        Player.transform.position = teleportTarget.transform.position;
    }
}
