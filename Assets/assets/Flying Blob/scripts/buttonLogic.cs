using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonLogic : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Difficulty");
    }

    public void closeGame()
    {
        Application.Quit();
    }
}
