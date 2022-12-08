using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public AudioSource enemyDeath;

    public void Play()
    {
        enemyDeath.Play();
    }
}
