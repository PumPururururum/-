using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class ComputerScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ComputerScreen;
    public GameObject ComputerButton;
    public GameObject InstructionScreen;
    public GameObject BloknotScreen;
    public GameObject AccountScreen;
    public GameObject ManagerScreen;

    public GameObject EnterPasswordWindow;
    public GameObject InstructionPasswordWindow;

    public GameObject InitialPassManagerWindow;
    public GameObject AddPasswordWindow;
    public GameObject PopUpWindow;
    

    public GameObject SecQuestManagerInfo;
    public GameObject AddPasswordButton;
    public GameObject SecQuestButton;
    public Button AddPassword;

    public TMP_Text EmailText;


    public TMP_Text SecQuestNametext;
    public TMP_Text SecQuestEmailtext;
    public TMP_Text SecQuestPasswrdtext;
    public TMP_Text SecQuestButtonName;

    public InputFieldPassword InputFieldPassword;

    public TMP_InputField BloknotInput;
    public GameObject PopUpBloknot;
    public bool PasswordEntered = false;


    public bool ChosenPasswordStorage = false;
    public GameObject PopUpAlreadyChose;
    private ScoreManager ScoreManager;
    public void Start()
    {
        EmailText.text = PlayerPrefs.GetString("PlayerName") + "@secquest.ru";
        InputFieldPassword = GameObject.FindGameObjectWithTag("InputFielf").GetComponent<InputFieldPassword>();
        ScoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
    }

    


    //ќсновные кнопки иконок и выход
    public void ButtonExitComputer()
    {
        ComputerScreen.SetActive(false);
        ComputerButton.SetActive(true);
    }
    public void ButtonInstruction()
    {
        InstructionScreen.SetActive(true);
    }
    public void ButtonInstructionExit()
    {
        InstructionScreen.SetActive(false);
    }
    public void ButtonBloknot()
    {
        if (!ChosenPasswordStorage)
        {
            if (PasswordEntered)
            {
                PopUpBloknot.SetActive(true);
            }
            else { BloknotScreen.SetActive(true); }
        }
        
    }
    public void ButtonBloknotExit()
    {
        BloknotScreen.SetActive(false);
    }
    public void ButtonAccount()
    {
        AccountScreen.SetActive(true);
    }
    public void ButtonAccountExit()
    {
        AccountScreen.SetActive(false);
    }
    public void ButtonPassManager()
    {
        if (!ChosenPasswordStorage) ManagerScreen.SetActive(true);
    }
    public void ButtonManagerExit()
    {
        ManagerScreen.SetActive(false);
    }



    //  нопки окна аккаунта
    public void ButtonNext1()
    {
        EnterPasswordWindow.SetActive(false);
        InstructionPasswordWindow.SetActive(true);
        PasswordEntered = true;
    }
    public void ButtonBack1()
    {
        EnterPasswordWindow.SetActive(true);
        InstructionPasswordWindow.SetActive(false);
    }

    //  нопки окна менеджера паролей
    public void ButtonAddPassword()
    {
       if (PasswordEntered) { PopUpWindow.SetActive(true);}
    }
    public void ButtonYesManager()
    {
        SecQuestEmailtext.text = PlayerPrefs.GetString("PlayerName") + "@secquest.ru";
        SecQuestPasswrdtext.text = PlayerPrefs.GetString("PlayerPassword");
        SecQuestButton.SetActive(true);
        
        PopUpWindow.SetActive(false);
        AddPassword.interactable = false;
        ChosenPasswordStorage = true;
        ScoreManager.StorageScore = 3;

    }
    public void ButtonNoManager()
    {
        PopUpWindow.SetActive(false);
        
    }
    public void ButtonSecQuest()
    {
        AddPasswordButton.SetActive(false);
        SecQuestManagerInfo.SetActive(true);

    }
    public void PopUpWindowExit()
    {
        PopUpWindow.SetActive(false);
        AddPassword.interactable = false;
    }

    //  нопки уведомлени€ блокнота
    public void ButtonYesBloknot()
    {
        BloknotInput.text = PlayerPrefs.GetString("PlayerPassword");
        BloknotScreen.SetActive(true);
        BloknotInput.interactable = false;
        PopUpBloknot.SetActive(false);
        ChosenPasswordStorage = true;
        ScoreManager.StorageScore = 1;
    }
    public void ButtonNoBloknot()
    {
        PopUpBloknot.SetActive(false);
    }

   // ”ведомление, что уже выбрали место хранени€ парол€
    public void PopUpAlreadyChoseExit()
    {
        PopUpAlreadyChose.SetActive(false);
    }
    public void TurnOffButtons()
    {
        if (ChosenPasswordStorage)
        {
            PopUpAlreadyChose.SetActive(true);
        }
    }
}
