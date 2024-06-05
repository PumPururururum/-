using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public GameObject grid;
    public GameObject collider1;
    public GameObject collider2;
    public UIManager2 UIManager;
    public BoxCollider2D PlayerCollider;


    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public AudioSource meow;
    public Text highscoreText;
    [ContextMenu("Increase Score")]
    private void Start()
    {
        grid = GameObject.FindGameObjectWithTag("grid");
        collider1 = GameObject.FindGameObjectWithTag("collider1");
        collider2 = GameObject.FindGameObjectWithTag("collider2");
        UIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager2>();
        PlayerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();

        grid.SetActive(false);
        collider1.SetActive(false);
        collider2.SetActive(false);
        PlayerCollider.enabled = false;
        UIManager.FlyingBlob = true;
    }
    public void addScore(int scoreToAdd) 
    { 
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        meow.Play();
    }

    public void restartGame()
    {
        UIManager.FlyingBlob = false;
        grid.SetActive(true);
        collider1.SetActive(true);
        collider2.SetActive(true);
        SceneManager.UnloadSceneAsync("game hard");
        SceneManager.LoadScene("game hard", LoadSceneMode.Additive);
        
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
    public void closeGame()
    {
        SceneManager.UnloadSceneAsync("game hard");
        UIManager.FlyingBlob = false;
        grid.SetActive(true);
        collider1.SetActive(true);
        collider2.SetActive(true);
        PlayerCollider.enabled = true;
    }
    public void Gotomenu()
    {
        SceneManager.LoadScene("Title Screen");
    }
    public void highscore()
    {
        int highscore = PlayerPrefs.GetInt("highscore");
        highscoreText.text = PlayerPrefs.GetInt("highscore").ToString();
        if (playerScore > highscore)
        {
            highscore = playerScore;
            PlayerPrefs.SetInt("highscore", highscore);
            highscoreText.text = PlayerPrefs.GetInt("highscore").ToString();
        }
    }
}



    
