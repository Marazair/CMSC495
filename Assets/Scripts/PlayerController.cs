using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GridMover
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        int horizontal = 0;
        int vertical = 0;

        horizontal = (int) Input.GetAxisRaw("Horizontal");
        vertical = (int) Input.GetAxisRaw("Vertical");
        
        if (horizontal != 0)
            vertical = 0;

        if (horizontal != 0 || vertical != 0)
            AttemptMove<CaveWall> (horizontal, vertical);
        
    }

    protected override void AttemptMove <T> (int xDir, int yDir) 
    {
        base.AttemptMove <T> (xDir, yDir);
    }

    protected override void OnCantMove<T>(T component) 
    {
        
    }

    private void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    private void LoseLife()
    {
        GameManager.instance.lives--;
    }
}
