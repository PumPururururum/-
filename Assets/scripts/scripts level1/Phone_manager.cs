using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Phone_manager : MonoBehaviour
{
    private ComputerScreenManager ComputerCode;
    private DialogManager DialogManager;
    public Animator animator;
    public GameObject Button;

    //public TMP_Text textPhone;

    private bool IsScript = false;
    public void GetScript()
    {
        ComputerCode = GameObject.FindGameObjectWithTag("Computer").GetComponent<ComputerScreenManager>();
        DialogManager = GameObject.FindGameObjectWithTag("Dialog").GetComponent<DialogManager>();
         IsScript = true;
    }

    private void Update()
    {
        if (IsScript == true && !DialogManager.IsDialog)
        {
            TurnOnGlowPhone();
            
        }
    }

    public void TurnOnGlowPhone()
    {
        if (ComputerCode.ChosenPasswordStorage)
        {
            animator.SetBool("Glow", true);
        }
    }
    public void TurnOffGlowPhone()
    {
        animator.SetBool("Glow", false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsScript && ComputerCode.ChosenPasswordStorage && !DialogManager.IsDialog) Button.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsScript && ComputerCode.ChosenPasswordStorage && !DialogManager.IsDialog) Button.SetActive(false);
    }
}
