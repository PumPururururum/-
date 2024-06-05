using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Gmail_manager : MonoBehaviour
{
    public Animator Animator;
    public void TurnOnGlow()
    {
        Animator.SetBool("Glow", true);
    }

    public void TurnOffGlow()
    {
        Animator.SetBool("Glow", false);
    }
}
