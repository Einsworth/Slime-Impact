using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject WinPanel;

    //Main Menu
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    //Stage1
    public void GoToStage1()
    {
        SceneManager.LoadScene("Stage1");
        MenuPanel.SetActive(false);
        WinPanel.SetActive(false);
        ScoreCounter.scoreValue = 0;
        HPCounter.HPValue = 3;
        TimeCounter.TimeLeft = 200;
    }

    //Stage2
    public void GoToStage2()
    {
        SceneManager.LoadScene("Stage2");
        MenuPanel.SetActive(false);
        WinPanel.SetActive(false);
        ScoreCounter.scoreValue = 0;
        HPCounter.HPValue = 3;
        TimeCounter.TimeLeft = 300;
    }

    //Stage2
    public void GoToStage3()
    {
        SceneManager.LoadScene("Stage3");
        MenuPanel.SetActive(false);
        WinPanel.SetActive(false);
        ScoreCounter.scoreValue = 0;
        HPCounter.HPValue = 3;
        TimeCounter.TimeLeft = 400;
    }
}
