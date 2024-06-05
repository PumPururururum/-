using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Outlook_Manager : MonoBehaviour
{
    public Animator Animator;
    void Start()
    {
        Animator.SetBool("Glow", true);
    }

    public void TurnOffGlow()
    {
        Animator.SetBool("Glow", false);
    }

    public void TurnOnGlow()
    {
        Animator.SetBool("Glow", true);
    }
}
