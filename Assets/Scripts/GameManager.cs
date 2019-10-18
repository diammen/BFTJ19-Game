using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public string MainScene;
    public string MainMenuScene;

    FadeTransition fade;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnLevelLoaded()
    {
        
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
        SceneManager.LoadScene(MainMenuScene);
    }
}
