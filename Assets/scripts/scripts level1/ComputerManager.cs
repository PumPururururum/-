using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerManager : MonoBehaviour
{

    public Animator animator;
    public GameObject ComputerScreen;
    public GameObject ComputerButton;
    private ComputerScreenManager ComputerCode;
    private bool IsScript = false;

    private void Update()
    {
        if (IsScript && ComputerCode.ChosenPasswordStorage)
        {
            TurnOffButtonComputer();
        }
    }
    
    public void GetScript()
    {
        ComputerCode = GameObject.FindGameObjectWithTag("Computer").GetComponent<ComputerScreenManager>();
        IsScript = true;
    }
    public void PulseAnimation()
    {
        animator.SetBool("IsGlow",true);
    }

    public void ComputerPress()
    {
        animator.SetBool("IsGlow", false);
        ComputerScreen.SetActive(true);
        ComputerButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       ComputerButton.SetActive(true);
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ComputerButton.SetActive(false);
    }
    public void TurnOffButtonComputer()
    {
        ComputerButton.SetActive(false);
    }

    
}
