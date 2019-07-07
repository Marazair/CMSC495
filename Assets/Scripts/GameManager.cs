using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int lives = 3;
    public bool isPlayerTurn = true;
    public Text levelText;
    public Text livesText;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        
        UpdateLevel();
        UpdateLives();

        DontDestroyOnLoad(gameObject);
    }

    public void GameOver() {
        SceneManager.LoadScene("Game Over");
    }

    public void UpdateLives() {
        livesText.text = "LIVES: " + instance.lives;
    }

    public void UpdateLevel() {
        levelText.text = "LEVEL: " + SceneManager.GetActiveScene().buildIndex;
    }

    public bool HasNextScene() {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings)
            return true;
        return false;
    }
}
