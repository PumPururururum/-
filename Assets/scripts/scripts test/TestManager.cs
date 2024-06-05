using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class TestManager : MonoBehaviour
{

    public SoundScript SoundScript;

    public questions[] questions;
    private static List<questions> unansweredQuestions;
    private questions currentQuestion;
    //private 

    [SerializeField]
    private TMP_Text questionText;

    [SerializeField]
    private float timeBetweenQuestions = 1f;

    [SerializeField] private TMP_Text answerText1;
    [SerializeField] private TMP_Text answerText2;
    [SerializeField] private TMP_Text answerText3;
    [SerializeField] private TMP_Text answerText4;
    [SerializeField] private TMP_Text answerTextBig1;
    [SerializeField] private TMP_Text answerTextBig2;
    [SerializeField] private TMP_Text answerTextBig3;
    [SerializeField] private TMP_Text answeredQuestions;
    [SerializeField] private TMP_Text difficultyLevel;

    public GameObject answerButton1;
    public GameObject answerButton2;
    public GameObject answerButton3;
    public GameObject answerButton4;
    public GameObject answerButtonBig1;
    public GameObject answerButtonBig2;
    public GameObject answerButtonBig3;
    public GameObject EndTestScreen;
    public GameObject TestScreen;

    static int AnsweredRightNumber = 0;
    static int questionsAnswered = 0;
    private void Start()
    {
        SoundScript = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundScript>();
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<questions>();
        }


        answerButtonBig1.SetActive(false);
        answerButtonBig2.SetActive(false);
        answerButton1.SetActive(false);
        answerButton2.SetActive(false);
        answerButton3.SetActive(false);
        answerButton4.SetActive(false);

        SetCurrentQuestion();
    }
    void SetCurrentQuestion()
    {
        int RandomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[RandomQuestionIndex];
        
        if (currentQuestion.answer.Capacity == 3)
        {
            answerButtonBig1.SetActive(true);
            answerButtonBig2.SetActive(true);
            answerButtonBig3.SetActive(true);
            answerTextBig1.text = currentQuestion.answer[0];
            answerTextBig2.text = currentQuestion.answer[1];
            answerTextBig3.text = currentQuestion.answer[2];
        }
        else 
        {
            answerButton1.SetActive(true);
            answerButton2.SetActive(true);
            answerButton3.SetActive(true);
            answerButton4.SetActive(true);
            answerText1.text = currentQuestion.answer[0];
            answerText2.text = currentQuestion.answer[1];
            answerText3.text = currentQuestion.answer[2];
            answerText4.text = currentQuestion.answer[3];
        }

        questionText.text = currentQuestion.question;
    }

    IEnumerator transitionToNextQuestion()
    {
        if (questionsAnswered == questions.Length-1)
        {
            yield return new WaitForSeconds(timeBetweenQuestions);
            EndTest();
        }
        else
        {
            questionsAnswered++;
            unansweredQuestions.Remove(currentQuestion);
            yield return new WaitForSeconds(timeBetweenQuestions);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }

    public void ButtonPress()
    {
        SoundScript.Play("ButtonPress");
        int buttonID = 0;
        if (EventSystem.current.currentSelectedGameObject.name == "ButtonAnswer")
        {
            buttonID = 1;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "ButtonAnswer 2")
        {
            buttonID = 2;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "ButtonAnswer 3")
        {
            buttonID = 3;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "ButtonAnswer 4")
        {
            buttonID = 4;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "ButtonAnswerBig")
        {
            buttonID = 1;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "ButtonAnswerBig2")
        {
            buttonID = 2;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "ButtonAnswerBig3")
        {
            buttonID = 3;
        }
        if (currentQuestion.corAnswer == buttonID)
        {
            Debug.Log("CORREXT!");
            AnsweredRightNumber++;
        }
        else
        {
            Debug.Log("NOOOOOOO!");
        }
       
        StartCoroutine(transitionToNextQuestion());
    }
    public void ButtonContinue()
    {
        SoundScript.Play("ButtonPress");
        SceneManager.LoadScene("LevelSelect");

    }
    public void EndTest()
    {
        EndTestScreen.SetActive(true);
        TestScreen.SetActive(false);
        answeredQuestions.text = AnsweredRightNumber.ToString();
        PlayerPrefs.SetInt("TestPassed", 10);
        if (AnsweredRightNumber <= 5)
        {
            difficultyLevel.text = "Базовый";
            PlayerPrefs.SetString("PlayerLevel", "Базовый");
        }
        else if (AnsweredRightNumber <= 10)
        {
            difficultyLevel.text = "Продвинутый";
            PlayerPrefs.SetString("PlayerLevel", "Продвинутый");
        }
        else 
        {
            difficultyLevel.text = "Профессионал";
            PlayerPrefs.SetString("PlayerLevel", "Профессионал");
        }


    }
}

