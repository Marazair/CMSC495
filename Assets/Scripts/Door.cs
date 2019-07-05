using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Obstacle
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerInteract(PlayerController player) {
        player.hasKey = false;
        
        for (int i = 0; i < player.transform.childCount; i++) {
            Transform child = player.transform.GetChild(i);

            if (child.gameObject.tag == "Key") {
                Destroy(child.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
