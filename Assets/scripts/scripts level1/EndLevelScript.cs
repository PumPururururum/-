using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndLevelScript : MonoBehaviour


{
    private ScoreManager ScoreManager;
    public GameObject EndScreen;
    public TMP_Text ScoreText;
    public TMP_Text TipsText;
    [TextArea(3, 10)]
    public string MaxPointsText;
    [TextArea(3, 10)]
    public string TipText;
    [TextArea(3, 10)]
    public string TipPassword;
    [TextArea(3, 10)]
    public string TipStorage;
    [TextArea(3, 10)]
    public string TipPhone;
    private void Start()
    {
        ScoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
        ScoreManager.EndScore();
        ScoreText.text = ScoreManager.GlobalScore.ToString();
        if (ScoreManager.GlobalScore == 9)
        {
            TipsText.text = MaxPointsText;
        }
        else
        {
            TipsText.text = TipText;
            if (ScoreManager.PassScore < 5)
            {
                TipsText.text += TipPassword;
            }
            if (ScoreManager.StorageScore < 3)
            {
                TipsText.text += TipStorage;
            }
            if(ScoreManager.PhoneScore == 0)
            {
                TipsText.text += TipPhone;
            }
        }
    }
    public void TurnOnEndScreen()
    {
        EndScreen.SetActive(true);
    }
}
