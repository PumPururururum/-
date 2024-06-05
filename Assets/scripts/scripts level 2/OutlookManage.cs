using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OutlookManage : MonoBehaviour
{
    public GameObject OutlookScreen;
    public GameObject CompanyMessage;
    public GameObject PhishMessage;
    public GameObject EndMessage;
    public GameObject PopUp;
    public Scrollbar Scrollbar;

    private ScoreManager2 scoreManager;
    private void Start()
    {
        Scrollbar.value = 1;
        scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager2>();
    }
    public void OpenOutlook()
    {
        OutlookScreen.SetActive(true);
    }

    public void ExitOutlook()
    {
        OutlookScreen.SetActive(false);
    }

    public void CompanyMessageOpen()
    {
        CompanyMessage.SetActive(true);
        PhishMessage.SetActive(false);
        EndMessage.SetActive(false);
    }

    public void FishMessageOpen() 
    {
        CompanyMessage.SetActive(false);
        PhishMessage.SetActive(true);
        EndMessage.SetActive(false);
    }

    public void EndMessageOpen()
    {
        EndMessage.SetActive(true);
        CompanyMessage.SetActive(false);
        PhishMessage.SetActive(false);
    }

    public void OpenPopUpFish()
    {
        if (!scoreManager.ThirdMessageAnswered)
        PopUp.SetActive(true);
    }
    public void ExitPopUpFish()
    {
        PopUp.SetActive(false);
        scoreManager.ThirdMessageAnswered = true;
    }

    public void PopUpYes()
    {
        ExitPopUpFish();
        scoreManager.DiminishScore();
        scoreManager.ThirdMessageAnswered = true;
    }
}
