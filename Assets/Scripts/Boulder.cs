using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Boulder : GridMover, Obstacle
{
    private bool canMove = true;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerInteract(PlayerController player) {
        if (player.IsMoving() || IsMoving()) {
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

    protected override void AttemptMove<T>(int xDir, int yDir) {
        if (!canMove)
            return;
        base.AttemptMove<T>(xDir, yDir);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Hole") {
            objectCollider.enabled = false;
            other.enabled = false;
            GetComponent<SpriteRenderer>().sortingOrder--;
        }
        if (other.tag == "Spike") {
            if (spriteRenderer.bounds.size.magnitude > other.GetComponent<SpriteRenderer>().bounds.size.magnitude) {
                Destroy(other.gameObject);
            }
            else {
                InterruptMove();
                canMove = false;
            }
        }
    }
}
