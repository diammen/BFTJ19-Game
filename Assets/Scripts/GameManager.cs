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

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
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
}
