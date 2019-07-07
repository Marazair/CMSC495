using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int lives = 3;
    public int maxLives = 5;
    public int currentScene = 0;
    public bool isPlayerTurn = true;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        
        currentScene = SceneManager.GetActiveScene().buildIndex;
        DontDestroyOnLoad(gameObject);
    }

    public void EndGame(string scene) {
        Destroy(UI.instance.gameObject);
        SceneManager.LoadScene(scene);
        Destroy(this.gameObject);
    }

    public void LoadNextLevel() {
        if (instance.HasNextScene()) {
            currentScene = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(currentScene);

            if(lives < maxLives) 
                instance.lives++;

            UI.instance.UpdateLives();
            UI.instance.UpdateLevel();
        }
        else {
            EndGame("Credits");
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
            UI.instance.UpdateLives();
        }
        else
            GameManager.instance.EndGame("Game Over");
    }

    private bool HasNextScene() {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings)
            return true;
        return false;
    }
}
