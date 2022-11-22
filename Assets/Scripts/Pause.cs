using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool paused = false;
    public Canvas PauseCanvas;
    //public Canvas mainCanv;
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pauseMenu();
        }
    }



    public void pauseMenu()
    {
        if (!paused)
        {

            PauseCanvas.gameObject.SetActive(true);
            //mainCanv.gameObject.SetActive(false);
            Time.timeScale = 0;

        }
        else
        {
            Time.timeScale = 1;
            PauseCanvas.gameObject.SetActive(false);
            //mainCanv.gameObject.SetActive(true);
        }

        paused = !paused;
    }


    public void exit()
    {
        Application.Quit();
    }
}