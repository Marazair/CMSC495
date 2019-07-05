using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Block block;
    public Sprite position2;

    public void Activate() {
        block.Open();
        GetComponent<SpriteRenderer>().sprite = position2;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            Activate();
        }
    }
}
