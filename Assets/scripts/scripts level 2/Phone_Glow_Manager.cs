using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone_Glow_Manager : MonoBehaviour
{
    public Animator Animator;
    public GameObject PhoneScreen;
    public GameObject ComputerScreen;
    public GameObject Joystick;
    private bool IsPhoneScreenOpen = false;
    public void TurnOffGlow()
    {
        Animator.SetBool("IsGlow", false);
    }

    public void TurnOnGlow()
    {
        Animator.SetBool("IsGlow", true);
    }

    public void PressButtonPhone()
    {
        if (!IsPhoneScreenOpen) 
        {
            PhoneScreen.SetActive(true);
            ComputerScreen.SetActive(false);
            Joystick.SetActive(false);
            IsPhoneScreenOpen = true;
        }
        else
        {
            PhoneScreen.SetActive(false);
            Joystick.SetActive(true);
            IsPhoneScreenOpen = false;
        }
    }
}
