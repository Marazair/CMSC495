using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveWall : MonoBehaviour, Obstacle {
    
    public void OnPlayerInteract(PlayerController player) {
        if (player.isMoving()) {
            return;
        }
    }
}
