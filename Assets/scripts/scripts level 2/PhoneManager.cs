using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneManager : MonoBehaviour
{
    public GameObject PhoneScreen;
    public GameObject WhatsAppScreen;
    public GameObject TelegramScreen;
    public GameObject WhatsAppScreenEmpty;
    public GameObject WhatsAppButton;
    public GameObject TelegramButton;

    public GameObject URLTelegrambutton;

    
    public GameObject WhatsAppURL;

    private GlowSequenceManager GlowSequenceManager;

    private void Start()
    {
        GlowSequenceManager = GameObject.FindGameObjectWithTag("Sequence").GetComponent<GlowSequenceManager>();
    }


    public void OpenTelegram()
    {
        TelegramScreen.SetActive(true);
        WhatsAppButton.SetActive(false);
        TelegramButton.SetActive(false);
        URLTelegrambutton.SetActive(true);
    }

    public void ButtonBack()
    {
        WhatsAppScreen.SetActive(false);
        TelegramScreen.SetActive(false);
        WhatsAppScreenEmpty.SetActive(false);
        WhatsAppButton.SetActive(true);
        TelegramButton.SetActive(true);
        URLTelegrambutton.SetActive(false);
        WhatsAppURL.SetActive(false);
    }

    public void OpenWhatsApp()
    {
        if (GlowSequenceManager.phishmessage_number < 4)
        {
            WhatsAppScreenEmpty.SetActive(true);
            WhatsAppButton.SetActive(false);
            TelegramButton.SetActive(false);
        }
        else
        {
            WhatsAppScreen.SetActive(true);
            WhatsAppButton.SetActive(false);
            TelegramButton.SetActive(false);
            WhatsAppURL.SetActive(true);
        }
    }

    
 
}
