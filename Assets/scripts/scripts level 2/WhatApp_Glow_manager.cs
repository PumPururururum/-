using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatApp_Glow_manager : MonoBehaviour
{
    public Animator Animator;
    public void TurnOffGlow()
    {
        Animator.SetBool("Glow", false);
    }

    public void TurnOnGlow()
    {
        Animator.SetBool("Glow", true);
    }
}
