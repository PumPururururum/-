using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{
    public SoundScript SoundScript;
    public GameObject DifficultyScreen;
    public GameObject BasicSelect;
    public GameObject AdvancedSelect;
    public GameObject ProfiSelect;
    public GameObject HomeScreen;

    private void Start()
    {
        SoundScript = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundScript>();
        SoundScript.StopPlaying("Theme_Level1");
        SoundScript.Play("Theme");
    }
    public void ButtonBasic()
    {
        BasicSelect.SetActive(true);
        DifficultyScreen.SetActive(false);
        SoundScript.Play("ButtonPress");
    }
   public void ButtonAdvanced()
    {
        AdvancedSelect.SetActive(true);
        DifficultyScreen.SetActive(false);
        SoundScript.Play("ButtonPress");
    }
   public void ButtonProfi()
    {
        ProfiSelect.SetActive(true);
        DifficultyScreen.SetActive(false);
        SoundScript.Play("ButtonPress");
    }
    public void ButtonHome()
    {
        HomeScreen.SetActive(true);
        SoundScript.Play("ButtonPress");
    }
    public void exitHome()
    {
        HomeScreen.SetActive(false);
        SoundScript.Play("ButtonPress");
    }
    public void ExitToTitle()
    {
        SceneManager.LoadScene("title");
        SoundScript.Play("ButtonPress");
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene("level");
        SoundScript.Play("ButtonPress");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
        SoundScript.Play("ButtonPress");
    }
}
