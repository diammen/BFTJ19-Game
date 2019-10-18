using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public string MainScene;
    public string MainMenu;

    static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GoToMainScene()
    {
        SceneManager.LoadScene(MainScene);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(MainMenu);
    }
}
