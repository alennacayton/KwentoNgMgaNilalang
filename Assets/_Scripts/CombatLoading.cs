using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatLoading : MonoBehaviour
{
    public void ProceedtoLevelTwo()
    {
        SceneManager.LoadScene("AreaTwo");
    }

    public void ProceedtoLevelThree()
    {
        SceneManager.LoadScene("AreaThree");
    }

    public void ProceedtoLevelFour()
    {
        SceneManager.LoadScene("AreaFour");
    }

    public void FinishGame()
    {
        SceneManager.LoadScene(0);
    }
}
