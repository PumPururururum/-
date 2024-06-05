using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager2 : MonoBehaviour
{

   
    public int score;
    public int scorePhish;
    public int scoreNoPhish;

    public bool FirstMessageAnswered = false;
    public bool SecondMessageAnswered = false;
    public bool ThirdMessageAnswered = false;
    public bool ForthMessageAnswered = false;
    public bool FifthMessageAnswered = false;
    private void Start()
    {
        scorePhish = 3;
        scoreNoPhish = 1;
    }
    public void DiminishScore()
    {
        scorePhish--;
    }
    public void DiminishScoreNoPhish()
    {
        scoreNoPhish--;
    }

    public void AddScore()
    {
        scoreNoPhish++;
    }

    public void GlobalScore()
    {
        score = scorePhish + scoreNoPhish;
    }
}
