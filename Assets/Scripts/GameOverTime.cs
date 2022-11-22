using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverTime : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private void Start()
    {
        timerText.text = (int)PlayerHealth.hourStore + "h:" + (int)PlayerHealth.minuteStore + "m:" + (int)PlayerHealth.secondStore + "s";
    }
}
