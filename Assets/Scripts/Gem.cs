using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{

    private GameObject specialWall;

    private static int gemsCollected = 0;
    // Start is called before the    first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            gemsCollected = gemsCollected + 1;
          
        }
        if (gemsCollected == 3)
        {
            specialWall = GameObject.FindGameObjectWithTag("SpecialWall");
            Destroy(specialWall);

        }

    }

    public static void ResetGems() {
        gemsCollected = 0;
    }
}
