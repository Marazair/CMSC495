using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Yes () {
        SceneManager.LoadScene("MainMenu");
    }
    public void No () {
        Application.Quit();
    }
}
