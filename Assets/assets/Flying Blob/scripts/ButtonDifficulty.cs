using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonDifficulty : MonoBehaviour
{
    // Start is called before the first frame update
    public void easyGame()
    {
        SceneManager.LoadScene("game easy");
    }

    public void hardGame()
    {
        SceneManager.LoadScene("game hard");
    }
}
