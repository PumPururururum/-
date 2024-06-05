using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMAnager : MonoBehaviour { 

    public GameObject PauseScreen;
    public GameObject Joystick;
    public SoundScript SoundScript;

    private void Start()
    {
        SoundScript = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundScript>();
        SoundScript.StopPlaying("Theme");
        SoundScript.Play("Theme_Level1");
        
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
    public void EnableJoystick()
    {
        Joystick.SetActive(true);
    }

    public void Replay()
    {
        SceneManager.LoadScene("level");
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
    public void MouseClickSound() {
        SoundScript.Play("MouseClick");
    }
}
