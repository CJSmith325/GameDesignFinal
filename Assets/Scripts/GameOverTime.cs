using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverTime : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI highScoreTimerText;
    void CheckScore()
    {
        if (PlayerHealth.hourStore > PlayerPrefs.GetInt("HighScoreHour", 0)) 
        {
            PlayerPrefs.SetInt("HighScoreHour", PlayerHealth.hourStore);
            PlayerPrefs.SetInt("HighScoreMin", PlayerHealth.minuteStore);
            PlayerPrefs.SetInt("HighScoreSec", PlayerHealth.secondStore);
        }
        if (PlayerHealth.hourStore < PlayerPrefs.GetInt("HighScoreHour", 0))
        {
            
        }
        if (PlayerHealth.hourStore == PlayerPrefs.GetInt("HighScoreHour", 0))
        {
            if (PlayerHealth.minuteStore > PlayerPrefs.GetInt("HighScoreMin", 0))
            {
                PlayerPrefs.SetInt("HighScoreSec", PlayerHealth.secondStore);
                PlayerPrefs.SetInt("HighScoreMin", PlayerHealth.minuteStore);
            }
            if (PlayerHealth.minuteStore == PlayerPrefs.GetInt("HighScoreMin", 0))
            {
                if (PlayerHealth.secondStore > PlayerPrefs.GetInt("HighScoreSec", 0))
                {
                    PlayerPrefs.SetInt("HighScoreSec", PlayerHealth.secondStore);
                }
            }
        }
    }

    private void Start()
    {
        timerText.text = (int)PlayerHealth.hourStore + "h:" + (int)PlayerHealth.minuteStore + "m:" + (int)PlayerHealth.secondStore + "s";

        CheckScore();
        highScoreTimerText.text = PlayerPrefs.GetInt("HighScoreHour", 0) + "h:" +  PlayerPrefs.GetInt("HighScoreMin", 0) + "m:" + PlayerPrefs.GetInt("HighScoreSec", 0) + "s";
    }
}
