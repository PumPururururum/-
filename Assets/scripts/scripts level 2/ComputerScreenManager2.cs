using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScreenManager2 : MonoBehaviour
{

    public GameObject ComputerScreen;
    public GameObject ComputerButton;
    
    
    public void ButtonExitComputer()
    {
        ComputerScreen.SetActive(false);
        ComputerButton.SetActive(true);
    }
   
    


}
