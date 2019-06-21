using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveWall : Obstacle {
    
    public override void OnPlayerInteract(PlayerController player) {
        base.OnPlayerInteract(player);
        player.LoseLife();
    }
}
