using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleLogicScript : MonoBehaviour
{
    public GameObject aboutScreen;
    public GameObject testScreen;
    public GameObject NameScreen;

    public TMP_InputField NameInput;
    public Button ButtonNext;
    private string PlayerName;

    public SoundScript SoundScript;

    public void Start()
    {
       // PlayerPrefs.SetString("PlayerName", "");
       SoundScript = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundScript>();
        SoundScript.StopPlaying("Theme_Level1");
        SoundScript.Play("Theme");
    }

    public void InputNameEnd()
    {
        if (NameInput != null)
        {
            ButtonNext.interactable = true;
            PlayerName = NameInput.text;
        }
        else
        {
            ButtonNext.interactable = false;
        }
    }
    public void playGame()
    {
        if (PlayerPrefs.GetString("PlayerName") == "")
        {
           
            NameScreen.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("TestPassed") == 0)
        {
            testScreen.SetActive(true);
            //Debug.Log(PlayerPrefs.GetString("PlayerName"));
        }
        else if (PlayerPrefs.GetInt("TestPassed") != 0)
        {
            SceneManager.LoadScene("LevelSelect");
        }
        SoundScript.Play("ButtonPress");
    }
    public void ContinueNameButton()
    {
        PlayerPrefs.SetString("PlayerName", PlayerName);
        testScreen.SetActive(true);
        NameScreen.SetActive(false);
        SoundScript.Play("ButtonPress");

    }
    public void aboutGame()
    {
        aboutScreen.SetActive(true);
        SoundScript.Play("ButtonPress");
    }

    public void exitAbout() 
    {
        aboutScreen.SetActive(false);
        SoundScript.Play("ButtonPress");
    }
    public void exitTest()
    {
        testScreen.SetActive(false);
        SoundScript.Play("ButtonPress");
    }

    public void exitName()
    {
        NameScreen.SetActive(false);
        SoundScript.Play("ButtonPress");
    }
    public void startTest()
    {
        SceneManager.LoadScene("Test");
        SoundScript.Play("ButtonPress");
    }
    public void startnoTest()
    {
        SceneManager.LoadScene("LevelSelect");
        SoundScript.Play("ButtonPress");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (aboutScreen == true))
        {
            aboutScreen.SetActive(false);
            
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
