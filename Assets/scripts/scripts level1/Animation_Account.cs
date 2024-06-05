using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Account : MonoBehaviour
{
    public Animator animator;
    private bool HasGlowed;
    public void turnOnGlowAccount()
    {
        if (!HasGlowed)
        {
            animator.SetBool("Glow", true);
            HasGlowed = true;
        }
    }

    public void turnOffGlowAccount()
    {
        animator.SetBool("Glow", false);
    }
}
