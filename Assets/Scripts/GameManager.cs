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

        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartTransition(string newTargetScene)
    {
        if (!fade.isFading)
        {
            fade.DoFade(true);
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
