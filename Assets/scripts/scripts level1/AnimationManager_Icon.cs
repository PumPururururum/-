using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager_Icon : MonoBehaviour
{
    private ComputerScreenManager ComputerCode;
    public Animator animator;
    private bool HasGlowed;
    public void turnOnGlowManager()
    {
        if (!HasGlowed)
        {
            animator.SetBool("Glow", true);
            HasGlowed = true;
        }
        
    }

    public void turnOffGlowManager()
    {
        animator.SetBool("Glow", false);
    }

    private void Start()
    {
        ComputerCode = GameObject.FindGameObjectWithTag("Computer").GetComponent<ComputerScreenManager>();
    }
    private void Update()
    {
        if (ComputerCode.ChosenPasswordStorage)
        {
            animator.SetBool("Glow", false);
        }
    }
}
    

