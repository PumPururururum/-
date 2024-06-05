using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper_glowing_manager : MonoBehaviour
{
    public Animator animator;
    private bool PressedYes = false;
    private bool HasGlowed = false;
    public GameObject PopUp;
    public GameObject Button;
    private ScoreManager ScoreManager;
    private ComputerScreenManager ComputerCode;
    public GameObject PopUpAlreadyChose;
    private bool IsScript = false;

    private void Start()
    {
        ScoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
    }
    public void GetScript()
    {
        ComputerCode = GameObject.FindGameObjectWithTag("Computer").GetComponent<ComputerScreenManager>();
        IsScript = true;
    }

    private void Update()
    {
        if (HasGlowed && ComputerCode.ChosenPasswordStorage)
        {
            animator.SetBool("Glow", false);
        }
    }

    public void turnOnGlowPaper()
    {
        if (!HasGlowed && ComputerCode.PasswordEntered)
        {
            animator.SetBool("Glow", true);
            HasGlowed = true;
        }
    }

    public void turnOffGlowPaper()
    {
        animator.SetBool("Glow", false);
    }

    public void PressButtonPaper()
    {
        if (!ComputerCode.ChosenPasswordStorage) PopUp.SetActive(true);
    }

    public void PopUpYesButton()
    {
        turnOffGlowPaper();
        PopUp.SetActive(false);
        PressedYes = true;
        Button.SetActive(false);
        ComputerCode.ChosenPasswordStorage = true;
        ScoreManager.StorageScore = 1;
    }
    public void PopUpNoButton()
    {
        PopUp.SetActive(false);
    }
    public void TurnOnButtonPaper()
    {
        if (ComputerCode.PasswordEntered  && !PressedYes)  Button.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsScript)
            TurnOnButtonPaper();

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsScript)
            Button.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (IsScript) TurnOnButtonPaper();
    }

    public void PopUpAlreadyChoseExit()
    {
        PopUpAlreadyChose.SetActive(false);
    }
    public void TurnOffButtons()
    {
        if (ComputerCode.ChosenPasswordStorage)
        {
            PopUpAlreadyChose.SetActive(true);
        }
    }

}





