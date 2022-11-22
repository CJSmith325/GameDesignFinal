using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void onStartPress()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void onExitPress()
    {
        Application.Quit();
    }

    public void onInstructionsPress()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void onMenuPress()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
