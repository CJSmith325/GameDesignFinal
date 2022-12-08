using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public AudioSource enemyHit;

    public void Play()
    {
        enemyHit.Play();
    }
}
