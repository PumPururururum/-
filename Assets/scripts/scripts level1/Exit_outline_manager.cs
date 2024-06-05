using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_outline_manager : MonoBehaviour
{
    public Animator animator;
    private bool HasGlowed;
    public void turnOnGlowExit()
    {
        if (!HasGlowed)
        {
            animator.SetBool("Glow", true);
            HasGlowed = true;
        }
    }

    public void turnOffGlowExit()
    {
        animator.SetBool("Glow", false);
    }
}
