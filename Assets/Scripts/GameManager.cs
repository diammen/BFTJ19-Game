using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public string MainScene;
    public string MainMenuScene;

    int score;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            ScoreText.text = "Score: " + score;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        var searchObject = GameObject.FindGameObjectWithTag("Score");
        if (searchObject != null)
            ScoreText = searchObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
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
