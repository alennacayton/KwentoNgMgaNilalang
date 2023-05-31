using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;
    
    public GameObject quizPanel;
    public GameObject goPanel;

    public Text questionTxt;

    private void start()
    {
        goPanel.SetActive(false);
        generateQuestion();
    }

    public void correct()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public gameOver()
    {
        quizPanel.setActive(false);
        goPanel.SetActive(true);
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex)
    }
    void setAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswersScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].answers[i];

            if(QnA[currentQuestion].correctAnswer == i+1)
            {
                options[i].GetComponent<AnswersScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if(QnA.Count > 0)
        {
        currentQuestion = Random.Range(0, QnA.Count);

        questionTxt.text = QnA[currentQuestion].question;
        setAnswers();
        }
        else
        {
            Debug.Log("Out of questions")
            gameOver();
        }

    }

}
