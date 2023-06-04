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

    public TMP_Text questionTxt;
    public Text scoreTxt;

    int totalQuestions = 0;
    public int scoreCount;
    public string score;

    private void start()
    {
        totalQuestions = QnA.Count;
        goPanel.SetActive(false);
        generateQuestion();
    }

    public void gameOver()
    {
        quizPanel.SetActive(false);
        goPanel.SetActive(true);
        //scoreTxt.txt = (scoreCount.ToString()) + "/" + (totalQuestions.ToString());
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].answers[i];

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
