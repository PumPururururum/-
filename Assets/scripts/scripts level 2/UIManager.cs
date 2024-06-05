using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager2 : MonoBehaviour
{
    public GameObject ComputerScreen;
    public SoundScript SoundScript;
    public GameObject PauseScreen;
    public GameObject Joystick;

    public GameObject GoodOffer;
    public GameObject BadOffer;

    private ScoreManager2 scoreManager;


    public GameObject grid;
    public GameObject collider1;
    public GameObject collider2;

    public bool FlyingBlob = false;
    private void Start()
    {
        SoundScript = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundScript>();
        scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager2>();
        SoundScript.StopPlaying("Theme");
        SoundScript.Play("Theme_Level1");
    }
    public void OpenComputerScreen()
    {
        ComputerScreen.SetActive(true);
    }
    public void CloseComputerScreen()
    {
        ComputerScreen.SetActive(false);
    }

    public void ButtonPause()
    {
        PauseScreen.SetActive(true);
        Time.timeScale = 0;
        SoundScript.Play("ButtonPress");
    }
    public void exitPause()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1;
        SoundScript.Play("ButtonPress");
    }
    public void ExitToTitle()
    {
        SceneManager.LoadScene("title");
        Time.timeScale = 1;
        SoundScript.Play("ButtonPress");
    }

    public void Replay()
    {
        SceneManager.LoadScene("Level 2");
            SoundScript.Play("ButtonPress");
    }

    public void Next()
    {
        SceneManager.LoadScene("LevelSelect");
        SoundScript.Play("ButtonPress");
    }

    public void PlaySoundButton()
    {
        SoundScript.Play("ButtonPress");
    }

    public void PlaySoundClick()
    {
        SoundScript.Play("MouseClick");
    }

    public void TurnOnJoystick()
    {
        Joystick.SetActive(true);
    }
    public void TurnOffJoystick()
    {
        Joystick.SetActive(false);
    }

    public void OpenGoodOffer()
    {
        if(!scoreManager.SecondMessageAnswered)
        GoodOffer.SetActive(true);
    }

    public void CloseGoodOffer()
    {
        GoodOffer.SetActive(false);
        scoreManager.AddScore();
        scoreManager.SecondMessageAnswered = true;
    }

    public void OpenBadOffer()
    {
       if (!scoreManager.ForthMessageAnswered)
            BadOffer.SetActive(true);
    }

    public void CloseBadOffer()
    {
        BadOffer.SetActive(false);
        scoreManager.ForthMessageAnswered = true;
    }

    public void  BadOfferYes() 
    {
        BadOffer.SetActive(false);
        scoreManager.DiminishScore();
        scoreManager.ForthMessageAnswered = true;
    }

    public void ButtonBlob()
    {
        SceneManager.LoadScene("game hard", LoadSceneMode.Additive);
        FlyingBlob = true;
        
    } 

    
}
