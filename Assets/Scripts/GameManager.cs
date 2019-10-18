using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public FadeTransition fade;
    public string MainScene;
    public string MainMenuScene;

    bool fading;
    string TargetScene;

    delegate void SceneMethod();
    SceneMethod methodToCall;

    static GameManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        fade = GameObject.FindGameObjectWithTag("Fade").GetComponent<FadeTransition>();
        SceneManager.sceneLoaded += OnLevelLoaded;

        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        var searchObject = GameObject.FindGameObjectWithTag("Fade").GetComponent<FadeTransition>();
        if (searchObject != null)
            fade = searchObject.GetComponent<FadeTransition>();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartTransition(string newTargetScene)
    {
        if (!fade.isFading)
        {
            fade.DoFade();
            fade.onFadeCompleted.AddListener(GoToScene);
            TargetScene = newTargetScene;
        }
    }

    public void GoToScene()
    {
        SceneManager.LoadScene(TargetScene);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(MainMenuScene);
    }
}
