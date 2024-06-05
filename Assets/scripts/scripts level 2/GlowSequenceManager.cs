using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlowSequenceManager : MonoBehaviour
{
    private Animation_Gmail_manager AnimationGmail;
    private Animation_Outlook_Manager AnimationOutlook;
    private Phone_Glow_Manager AnimationPhone;
    private WhatApp_Glow_manager AnimationWhatApp;
    private Telegram_Glow_manager AnimationTelegram;
    private ComputerManger2 AnimationComputer;

    private bool GotScripts = false;

    public SoundScript SoundScript;

    public int phishmessage_number = 0;
    private bool IsCoroutineRunning = false;

    public GameObject MailGmail;
    public GameObject MailGmailButton;

    public GameObject MailGmailPhish;
    public GameObject MailGmailPhishButton;
    private bool ButtonMailPressedOnce = false;

    public GameObject MailOutlookPhish;
    public GameObject MailOutlookPhishButton;
    public GameObject MailOutlookEndButton;
    public GameObject MailOutlookEnd;
    private bool MessageOpenedOutlook = false;
    private bool MessageOpenedOutlookEnd = false;
    private bool MessageOpenedGmail = false;
    public Button PhoneButton;
    public Image PhoneButtonImage;

    public GameObject EndScreen;
    public void GetScripts1()
    {
        AnimationGmail = GameObject.FindGameObjectWithTag("GmailIcon").GetComponent<Animation_Gmail_manager>();
        AnimationOutlook = GameObject.FindGameObjectWithTag("OutlookIcon").GetComponent<Animation_Outlook_Manager>();
        AnimationPhone = GameObject.FindGameObjectWithTag("PhoneIcon").GetComponent<Phone_Glow_Manager>();
        PhoneButtonImage = GameObject.FindGameObjectWithTag("PhoneIcon").GetComponent<Image>();
        AnimationComputer = GameObject.FindGameObjectWithTag("ComputerButton").GetComponent<ComputerManger2>(); 
        SoundScript = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundScript>();
    }

    public void GetScripts2()
    {
        if (!GotScripts)
        {
            AnimationWhatApp = GameObject.FindGameObjectWithTag("WhatsAppIcon").GetComponent<WhatApp_Glow_manager>();
            AnimationTelegram = GameObject.FindGameObjectWithTag("TelegramIcon").GetComponent<Telegram_Glow_manager>();
            if (phishmessage_number == 2) AnimationTelegram.TurnOnGlow();
            GotScripts = true;
        }
    }

    void Update()
    {
        if (phishmessage_number == 1 && !ButtonMailPressedOnce) //Google phish
        {
            AnimationGmail.TurnOnGlow();
            AnimationOutlook.TurnOffGlow();
            MailGmailPhish.SetActive(true);
            MailGmailPhishButton.SetActive(true);
            AnimationComputer.TurnOnGlow();
        }
        if (phishmessage_number == 2)  //Phone not fish
        {
            AnimationGmail.TurnOffGlow();
            AnimationOutlook.TurnOffGlow();
            AnimationComputer.TurnOffGlow();
            AnimationPhone.TurnOnGlow();

            PhoneButton.interactable = true;
            Color c = PhoneButtonImage.color;
            c.a = 1f;
            PhoneButtonImage.color = c;
        }
        if (phishmessage_number == 3) //security quest phish
        {
            AnimationGmail.TurnOffGlow();
            AnimationOutlook.TurnOnGlow();
            AnimationPhone.TurnOffGlow();
            AnimationComputer.TurnOnGlow();
            if (!MessageOpenedOutlook)
            {
                MailOutlookPhish.SetActive(true);
                MessageOpenedOutlook = true;
            }
            MailOutlookPhishButton.SetActive(true);
        }
        if (phishmessage_number == 4) //Phone phish
        {
            AnimationGmail.TurnOffGlow();
            AnimationOutlook.TurnOffGlow();
            AnimationComputer.TurnOffGlow();
            AnimationPhone.TurnOnGlow();
            AnimationWhatApp.TurnOnGlow();
        }
        if (phishmessage_number == 5) //Gmail no phish
        {
            AnimationGmail.TurnOnGlow();
            AnimationOutlook.TurnOffGlow();
            AnimationPhone.TurnOffGlow();
            AnimationComputer.TurnOnGlow();
            if (!MessageOpenedGmail)
            {
                MailGmail.SetActive(true);
                MessageOpenedGmail = true;
            }
            
            MailGmailButton.SetActive(true);
        }

        if (phishmessage_number == 6) //End email
        {
            AnimationGmail.TurnOffGlow();
            AnimationOutlook.TurnOnGlow();
            AnimationPhone.TurnOffGlow();
            AnimationComputer.TurnOnGlow();
            MailOutlookEndButton.SetActive(true);
            if (!MessageOpenedOutlookEnd)
            {
                MailOutlookEnd.SetActive(true);
                MessageOpenedOutlookEnd = true;
            }
        }
        if (phishmessage_number == 7)
        {
            EndScreen.SetActive(true);
            AnimationGmail.TurnOffGlow();
            AnimationOutlook.TurnOffGlow();
            AnimationComputer.TurnOffGlow();
            AnimationPhone.TurnOffGlow();
        }

    }

    public void PressedMailButtonDuring1message()
    {
        if (phishmessage_number == 1) ButtonMailPressedOnce = true;
    }

    IEnumerator SendMessageCoroutine()
    {
        IsCoroutineRunning = true;
        yield return new WaitForSeconds(15);
        phishmessage_number++;
        SoundScript.Play("Notification");
        IsCoroutineRunning = false;

    }

    public void SendMessage()
    {
        if (IsCoroutineRunning == false) StartCoroutine(SendMessageCoroutine());
        
    }


    public void SendFirstPhishMessage()
    {
        if (phishmessage_number == 0 && !IsCoroutineRunning)
        {
            StartCoroutine(SendMessageCoroutine());
            
        }
    }

    public void SendSecondPhishMessage()
    {
        if (phishmessage_number == 1 && !IsCoroutineRunning)
        {
            StartCoroutine(SendMessageCoroutine());
            
        }
    }
    public void SendThirdPhishMessage()
    {
        if (phishmessage_number == 2 && !IsCoroutineRunning)
        {
            StartCoroutine(SendMessageCoroutine());

        }
    }
    public void SendFourthPhishMessage()
    {
        if (phishmessage_number == 3 && !IsCoroutineRunning)
        {
            StartCoroutine(SendMessageCoroutine());
        }
    }
    public void SendFifthPhishMessage() 
    {
        if (phishmessage_number == 4 && !IsCoroutineRunning)
        {
            StartCoroutine(SendMessageCoroutine());
        }
    }

    public void SentLastMessage()
    {
        if (phishmessage_number == 5 && !IsCoroutineRunning)
        {
            StartCoroutine(SendMessageCoroutine());
        }
    }

    public void OpenEndScreen()
    {
        if (phishmessage_number == 6 && !IsCoroutineRunning)
        {
            StartCoroutine(SendMessageCoroutine());
        }
    }

}
