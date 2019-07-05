using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour, Obstacle
{
    public Vector2 openDirection;

    private bool open = false;

    public void Open() {
        if (open == false) {
            transform.Translate(openDirection);
            open = true;
        }
    }

    public void OnPlayerInteract(PlayerController player) {

    }
}
