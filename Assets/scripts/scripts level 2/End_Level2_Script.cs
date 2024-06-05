using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class End_Level2_Script : MonoBehaviour
{
    private ScoreManager2 ScoreManager;
    public GameObject EndScreen;
    public TMP_Text ScoreText;
    public TMP_Text TipsText;

    
    [TextArea(3, 10)]
    public string MaxPointsText;
    [TextArea(3, 10)]
    public string TipText;
    [TextArea(3, 10)]
    public string TipFish;
    [TextArea(3, 10)]
    public string TipNoFish;
    private void Start()
    {
        ScoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager2>();
        ScoreManager.GlobalScore();
        ScoreText.text = ScoreManager.score.ToString();
        if (ScoreManager.score == 5)
        {
            TipsText.text = MaxPointsText;
        }
        else
        {
            TipsText.text = TipText;
            if (ScoreManager.scorePhish < 3)
            {
                TipsText.text += TipFish;
            }
            if (ScoreManager.scoreNoPhish < 2)
            {
                TipsText.text += TipNoFish;
            }
        }
    }
   
}
