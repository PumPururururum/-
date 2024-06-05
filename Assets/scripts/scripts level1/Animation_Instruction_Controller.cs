using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Instruction_Controller : MonoBehaviour
{

    public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        Animator.SetBool("Glow", true);
    }

    public void ButtonPressInstruction()
    {
        Animator.SetBool("Glow", false);
    }
}
