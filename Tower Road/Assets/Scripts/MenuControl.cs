using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject pauseButtonObj, resumeButtonObj,pauseScreen;

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            pauseButtonObj.SetActive(true);
            resumeButtonObj.SetActive(false);
            pauseScreen.SetActive(false);
        }     
    }

    public void startButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if(Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
    }

    public void menuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void pauseButton()
    {
        pauseScreen.SetActive(true);
        pauseButtonObj.SetActive(false);
        resumeButtonObj.SetActive(true);
        Time.timeScale = 0f;
    }

    public void resumeButton()
    {
        pauseButtonObj.SetActive(true);
        pauseScreen.SetActive(false);
        resumeButtonObj.SetActive(false);
        Time.timeScale = 1f;
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
