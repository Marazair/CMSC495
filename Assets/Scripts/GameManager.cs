using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int lives = 3;
    public bool isPlayerTurn = true;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }

    private void GameOver() {
        enabled = false;
    }

    public bool HasNextScene() {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCount)
            return true;
        return false;
    }
}
