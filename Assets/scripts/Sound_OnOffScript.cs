using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_OnOffScript : MonoBehaviour
{
    public GameObject ButtonSoundOn;
    public GameObject ButtonSoundOff;
    private bool muted = false;
    void Start()
    {
        if (PlayerPrefs.HasKey("muted") == false)
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void sound()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
            ButtonSoundOn.SetActive(false);
            ButtonSoundOff.SetActive(true);

        }
        else
        {
            muted = false;
            AudioListener.pause = false;
            ButtonSoundOff.SetActive(false);
            ButtonSoundOn.SetActive(true);
        }
        Save();
    }
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
