using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GmailManager : MonoBehaviour
{
    public GameObject PhishMessage;
    public GameObject Message;
    public GameObject GmailScreen;

    public GameObject PopUpPhish;
    public GameObject PopUp;

    private ScoreManager2 scoreManager;
    private void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager2>();
    }
    public void OpenGmail()
    {
        GmailScreen.SetActive(true);
    }

    public void CloseGmail()
    {
        GmailScreen?.SetActive(false);
    }

    public void OpenPhish()
    {
        PhishMessage.SetActive(true);
        Message.SetActive(false);
    }

    public void OpenNoPhish()
    {
        PhishMessage.SetActive(false);
        Message.SetActive(true);
    }

    public void OpenPopUpPhish()
    {
        if (!scoreManager.FirstMessageAnswered)
        PopUpPhish.SetActive(true);
    }
    public void ClosePopUpPhish()
    {
        PopUpPhish.SetActive(false);
        
    }

    public void PopUpYes()
    {
        PopUpPhish.SetActive(false);
        scoreManager.DiminishScore();
        scoreManager.FirstMessageAnswered = true;
    }

    public void PopUpNo()
    {
        PopUpPhish.SetActive(false);
        scoreManager.FirstMessageAnswered = true;
    }

    public void OpenPopUp() 
    {
        if (!scoreManager.FifthMessageAnswered)
        PopUp.SetActive(true);
    }
    public void ClosePopUp()
    {
        PopUp.SetActive(false);
        scoreManager.DiminishScoreNoPhish();
        scoreManager.FifthMessageAnswered = true;
    }
    public void PopUpNoFishYes()
    {
        PopUp.SetActive(false);
        scoreManager.FifthMessageAnswered = true;


    }

}
