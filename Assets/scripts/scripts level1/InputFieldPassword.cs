using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class InputFieldPassword : MonoBehaviour
{
    public TMP_InputField InputPassword1;
    public TMP_InputField InputPassword2;
    public TMP_InputField InputEmail;
    public Button ButtonNext;
    public GameObject PasswordDontMatchText;
    public GameObject EmailDontMatch;


    public TMP_InputField ManagerInputEmail;
    public TMP_InputField ManagerInputPassword;
    public TMP_InputField ManagerInputName;
    public Button ButtonAddPassword;

    public string ManagerName;
    public string ManagerPassword;
    public string ManagerEmail;


    public void Start()
    {
        ManagerName = ManagerInputName.text;
    }

    public void InputFieldEmail()
    {
        string name = PlayerPrefs.GetString("PlayerName");

        if (InputEmail.text == (name + "@secquest.ru"))
        {
            ButtonNext.interactable = true;
            EmailDontMatch.SetActive(false);
        }
        else
        {
            ButtonNext.interactable = false;
            EmailDontMatch.SetActive(true);
        }
    }
    public void InpField1EndEdit()
    {
        if (InputPassword1.text == InputPassword2.text)
        {
            ButtonNext.interactable = true;
            PasswordDontMatchText.SetActive(false);
            PlayerPrefs.SetString("PlayerPassword", InputPassword1.text);
        }
        else
        {
            ButtonNext.interactable = false;
            PasswordDontMatchText.SetActive(true);
        }
    }
    public void InpField2EndEdit()
    {
        if (InputPassword1.text == InputPassword2.text)
        {
            ButtonNext.interactable = true;
            PasswordDontMatchText.SetActive(false);
            PlayerPrefs.SetString("PlayerPassword", InputPassword2.text);
        }
        else
        {
            ButtonNext.interactable = false;
            PasswordDontMatchText.SetActive(true);
        }
    }
    public void InpFieldManagerName()
    {
        if (ManagerInputName == null)
        {
            ButtonAddPassword.interactable = false;
        }
        else
        {
            ButtonAddPassword.interactable = true;
            ManagerName = ManagerInputName.text;
        }
    }
    public void InpFieldManagerPassword()
    {

        if (ManagerInputPassword == null)
        {
            ButtonAddPassword.interactable = false;
        }
        else
        {
            ButtonAddPassword.interactable = true;
            ManagerPassword = ManagerInputPassword.text;
        }
    }
    public void InpFieldManagerEmail()
    {

        if (ManagerInputEmail == null)
        {
            ButtonAddPassword.interactable = false;
        }
        else
        {
            ButtonAddPassword.interactable = true;
            ManagerEmail = ManagerInputEmail.text;
        }
    }

}
