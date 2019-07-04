using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anubis : MonoBehaviour{


    public float timeBtwShots;

    public float startTimeBtwShots = 2;

    public Projectile projectile;

    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timeBtwShots <=0 )
        {
            Projectile clone = Instantiate(projectile, transform.position, Quaternion.identity);
            clone.player = player;
            timeBtwShots = startTimeBtwShots;
        }
        else {
            timeBtwShots -= Time.deltaTime;

        }
    }
}
