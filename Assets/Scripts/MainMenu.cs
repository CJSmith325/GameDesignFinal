using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource menuSound;
    IEnumerator AudioWaiterMain()
    {
        menuSound.Play();
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator AudioWaiterInstructions()
    {
        menuSound.Play();
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("Instructions");
    }

    IEnumerator AudioWaiterStart()
    {
        menuSound.Play();
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("SampleScene");
    }

    IEnumerator AudioWaiterExit()
    {
        menuSound.Play();
        yield return new WaitForSeconds(0.4f);
        Application.Quit();
    }

    public void onStartPress()
    {
        StartCoroutine(AudioWaiterStart());
        
    }

    public void onExitPress()
    {
        StartCoroutine(AudioWaiterExit());
    }

    public void onInstructionsPress()
    {
        StartCoroutine(AudioWaiterInstructions());
    }

    public void onMenuPress()
    {
        StartCoroutine(AudioWaiterMain());
    }
}
