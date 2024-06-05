using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Playables;

public class DialogManager : MonoBehaviour
{
    private Queue<string> sentences;
    public TMP_Text PhoneText;
    public GameObject PhoneTextScreen;
    public GameObject TextContinue;
    private bool IsChoice = false;
    public bool IsDialog = false;

    public GameObject ButtonYes;
    public GameObject ButtonNo;
    public GameObject ButtonPhone;
    public GameObject JoyPad;

    private bool Answer;
    public PlayableDirector TimelineYes;
    public PlayableDirector TimelineNo;
    
    void Start()
    {
        sentences = new Queue<string>();

        
    }

    private void Update()
    {
        if (typeSentence == null && !IsChoice && IsDialog)
        {
            if (Input.GetMouseButtonDown(0) == true)
            {
                TextContinue.SetActive(false);
                DisplayNextSentence();
            }
        }

    }
    public void StartDialog( Dialog dialog)
    {
        sentences.Clear();
        PhoneTextScreen.SetActive(true);
        ButtonPhone.SetActive(false);
        JoyPad.SetActive(false);
        IsDialog = true;

        foreach ( string sentence in dialog.sentences )
        {
            sentences.Enqueue( sentence );
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        
        if (sentences.Count == 0)
        {
           
                EndDialog();
                return;
            
        }
        if (sentences.Count == 4)
        {
            ButtonYes.SetActive(true);
            ButtonNo.SetActive(true);
            IsChoice = true;
        }

        string sentence = sentences.Dequeue();
        
        StopAllCoroutines();
        typeSentence = StartCoroutine(TypeSentence(sentence));
        
    }
    private Coroutine typeSentence;
    IEnumerator TypeSentence (string sentence)
    {
        PhoneText.text = "";
        foreach (char letter in sentence.ToCharArray() ) 
        {
            PhoneText.text += letter;
            yield  return new WaitForSeconds(0.05f); ;
        }
        if (IsChoice) TextContinue.SetActive(false);
        else TextContinue.SetActive(true);

        typeSentence = null;
    }

    public void EndDialog() 
    {
        PhoneTextScreen.SetActive(false);
       // IsDialog = false;
        if (Answer)
        {
            
            TimelineYes.Play();
        }
        else
        {
            
            TimelineNo.Play();
        }
        
    }

    public void ButtonYesPress()
    {
        ButtonYes.SetActive(false);
        ButtonNo.SetActive(false);
        TextContinue.SetActive(true);
        IsChoice = false;
        Answer = true;
    }

    public void ButtonNoPress()
    {
        ButtonYes.SetActive(false);
        ButtonNo.SetActive(false);
        Answer = false;
        EndDialog();
    }


}
