using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class QuizManager : MonoBehaviour
{
    
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject quizPanel;
    public GameObject goPanel;

    public GameObject retryButton;
    public GameObject continueButton;
    public GameObject passedText;
    public GameObject failedText;

    public TMP_Text questionTxt;

    public int scoreCount = 0;
    public int trigger_counter = 0;
    private int totalQuestions;

    private void Start()
    {
        goPanel.SetActive(false);

        totalQuestions = QnA.Count;
        trigger_counter++;
        
        if (trigger_counter != 1)
        {
            QnA.RemoveAt(currentQuestion);
        }

        generateQuestion();


        //For testing purposes
       // scoreCount = 1;
      //  totalQuestions = 2;
      //  gameOver();
    }

    public void gameOver()
    {
        if (scoreCount == totalQuestions)
        {
            passedText.SetActive(true);
            continueButton.SetActive(true);
        }
        else
        {
            failedText.SetActive(true);
            retryButton.SetActive(true);
        }

        quizPanel.SetActive(false);
        goPanel.SetActive(true);

    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void continueToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void correct()
    {
        scoreCount += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void setAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].answers[i];

            if(QnA[currentQuestion].correctAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {

        if (QnA.Count > 0)
        {
            currentQuestion = UnityEngine.Random.Range(0, QnA.Count);

            questionTxt.text = QnA[currentQuestion].question;
            setAnswers();
        }
        else
        {
            Debug.Log("Out of questions");
            gameOver();
        }



    }

}
