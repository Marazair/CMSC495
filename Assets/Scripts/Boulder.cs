using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : GridMover, Obstacle
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerInteract(PlayerController player) {
        if (player.isMoving()) {
            return;
        }

        if (isMoving()) {
            return;
        }

        if (player.transform.position.x > transform.position.x) {
            AttemptMove<Obstacle>(-1, 0);
        }

        else if (player.transform.position.x < transform.position.x) {
            AttemptMove<Obstacle>(1, 0);
        }

        else if (player.transform.position.y > transform.position.y) {
            AttemptMove<Obstacle>(0, -1);
        }

        else if (player.transform.position.y < transform.position.y) {
            AttemptMove<Obstacle>(0, 1);
        }
    }

    protected override void OnCantMove<T>(T obstacle) {
        
    }
}
