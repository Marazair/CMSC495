using System.Collections;
using UnityEngine;

public class respawn : MonoBehaviour
{
      
    public Transform Player;
    public Transform respawnPoint;

    void OnTriggerEnter2D(Collider2D other)
    {
        Player.transform.position = respawnPoint.transform.position;
    }    
}
