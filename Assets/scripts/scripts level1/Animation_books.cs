using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Animation_books : MonoBehaviour
{
    public Animator animator;
    private bool PressedYes;
    private bool HasGlowed = false;
    private ComputerScreenManager ComputerCode;
    private ScoreManager ScoreManager;
    public GameObject PopUp;
    public GameObject Button;



    private void Start()
    {
        ScoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
    }
    public void GetScript()
    {

        ComputerCode = GameObject.FindGameObjectWithTag("Computer").GetComponent<ComputerScreenManager>();
    }

    private void Update()
    {
        if (HasGlowed && ComputerCode.ChosenPasswordStorage)
        {
            animator.SetBool("Glow", false);
        }
    }

    public void turnOnGlowBooks()
    {
        if (!HasGlowed && ComputerCode.PasswordEntered)
        {
            animator.SetBool("Glow", true);
            HasGlowed = true;
        }
    }

    public void turnOffGlowBooks()
    {
        animator.SetBool("Glow", false);
    }

    public void PressButtonBooks()
    {
        if (!ComputerCode.ChosenPasswordStorage) PopUp.SetActive(true);
    }

    public void PopUpYesButton()
    {
        turnOffGlowBooks();
        PopUp.SetActive(false);
        PressedYes = true;
        Button.SetActive(false);
        ComputerCode.ChosenPasswordStorage = true;
        ScoreManager.StorageScore = 2;
    }
    public void PopUpNoButton()
    {
        PopUp.SetActive(false);
    }
    public void TurnOnButtonBooks()
    {
        if (ComputerCode.PasswordEntered && !PressedYes) Button.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TurnOnButtonBooks();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Button.SetActive(false);
    }

}

