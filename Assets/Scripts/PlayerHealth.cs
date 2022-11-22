using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // couroutine duration timer
    private float iFrameDuration = 3f;
    // timer to hard code a stop to enemy attacks, not working at all
    private float enemyAtkTimer = 3f;
    // gets sprite renderer of playersprite
    private SpriteRenderer playerSprite;
    // comparison variable to detect enemy damage
    private float playerHealthCompare = 3f;
    // static float variable for player health
    public static float playerHealth = 3;
    // text component for health
    public Text currentHealth;
    // number of times to flash in invulnerabilty coroutine
    private float numberFlashes = 3f;

    public static float secondStore;
    public static float minuteStore;
    public static float hourStore;
    private void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
    }

    private IEnumerator Invulnerability ()
    {
        Physics2D.IgnoreLayerCollision(4, 2, true);
        for (int i = 0; i < numberFlashes; i++)
        {
            playerSprite.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFrameDuration / (numberFlashes *2));
            playerSprite.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numberFlashes * 2));

        }
        Physics2D.IgnoreLayerCollision(4, 2, true);
    }

    private void Update()
    {
        if (playerHealthCompare > playerHealth)
        {
            StartCoroutine(Invulnerability());
            playerHealthCompare = playerHealth;
            
        }

        if (playerHealth <= 0)
        {
            secondStore = GameTimer.secondsCount;
            minuteStore = GameTimer.minuteCount;
            hourStore = GameTimer.hourCount;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        currentHealth.text = playerHealth.ToString();

        enemyAtkTimer -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (enemyAtkTimer <= 0)
        {
            if (collision.gameObject.CompareTag("Enemy") == true)
            {
                playerHealth -= 1;
                enemyAtkTimer = 3;
            }
        }
    }
}


