using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(!GameManager.instance.isPlayerTurn)
            return;

        int horizontal = 0;
        int vertical = 0;

        horizontal = (int) Input.GetAxisRaw("Horizontal");
        vertical = (int) Input.GetAxisRaw("Vertical");
        
        if (horizontal != 0)
            vertical = 0;

        if (horizontal != 0 || vertical != 0)
            AttemptMove<Obstacle> (horizontal, vertical);
        
    }

    protected override void AttemptMove <T> (int xDir, int yDir) 
    {
        if (isMoving())
            return;
        base.AttemptMove <T> (xDir, yDir);
    }

    protected override void OnCantMove<T>(T obstacle) 
    {
        obstacle.OnPlayerInteract(this);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Exit") {
            Scene currentScene = SceneManager.GetActiveScene();
            if (GameManager.instance.HasNextScene()) {
                GameManager.instance.lives++;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
                SceneManager.LoadScene("Credits");
        }

        if (other.tag == "Projectile") {
            LoseLife();
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoseLife()
    {
        GameManager.instance.lives--;
        if(GameManager.instance.lives > 0) {
            Gem.ResetGems();
            Restart();
        }
        else
            GameManager.instance.GameOver();
    }
}
