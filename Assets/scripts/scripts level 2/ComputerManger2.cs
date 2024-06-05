using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerManger2 : MonoBehaviour
{
    public GameObject ComputerButton;
    public Animator Animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ComputerButton.SetActive(true);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ComputerButton.SetActive(false);
    }

    public void TurnOffGlow()
    {
        Animator.SetBool("IsGlow", false);
    }

    public void TurnOnGlow()
    {
        Animator.SetBool("IsGlow", true);
    }
}
