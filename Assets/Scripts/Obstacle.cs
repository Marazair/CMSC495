using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    public virtual void OnPlayerInteract(PlayerController player) {
        if(player.isMoving()) 
            return;
    }
}
