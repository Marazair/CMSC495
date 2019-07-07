using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private Text lives;
    private Text level;

    public static UI instance = null;
    
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Text[] textObjects = GetComponentsInChildren<Text>();
        level = textObjects[0];
        lives = textObjects[1];
        UpdateLives();
        UpdateLevel();

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives() {
        lives.text = "LIVES: " + GameManager.instance.lives;
    }

    public void UpdateLevel() {
        level.text = "LEVEL: " + GameManager.instance.currentScene;
    }
}
