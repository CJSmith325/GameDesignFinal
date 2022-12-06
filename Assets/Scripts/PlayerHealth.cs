using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // public shake ienumerator object
    public CameraShake cameraShake;
    // couroutine duration timer
    private float iFrameDuration = 1f;
    // gets sprite renderer of playersprite
    private SpriteRenderer playerSprite;
    // static float variable for player health
    public int playerHealth = 3;
    public int playerMaxHealth = 3;
    // text component for health
    public Text healthText;
    // number of times to flash in invulnerabilty coroutine
    private int numberFlashes = 1;

    public ParticleSystem particleSysFast;
    public ParticleSystem particleSysSlow;

    public static float secondStore;
    public static float minuteStore;
    public static float hourStore;
    private void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
    }
    private void Awake()
    {
        playerHealth = 3;
    }
    private IEnumerator Invulnerability ()
    {
        Physics2D.IgnoreLayerCollision(9, 7, true);
        for (int i = 0; i < numberFlashes; i++)
        {
            playerSprite.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFrameDuration / (numberFlashes *2));
            playerSprite.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numberFlashes * 2));

        }
        Physics2D.IgnoreLayerCollision(9, 7, false);
    }
    private void Update()
    {
        healthText.text = playerHealth.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //enemy collision
        if (collision.gameObject.CompareTag("Enemy") == true)
        {
            StartCoroutine(cameraShake.Shake(1f, 0.1f));
            playerHealth -= 1;
            if (playerHealth <= 0)
            {
                secondStore = GameTimer.secondsCount;
                minuteStore = GameTimer.minuteCount;
                hourStore = GameTimer.hourCount;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            StartCoroutine(Invulnerability());
        }
        //Repair kit collision
        if (collision.gameObject.CompareTag("Repair"))
        {
            if (playerHealth < playerMaxHealth)
                playerHealth += 1;
            Destroy(collision.gameObject);
        }
        //Checks health to decide on particle system state
        if (playerHealth == 3)
        {
            //stops particle system from playing
            particleSysFast.Stop();
            particleSysSlow.Stop();
        }
        else if (playerHealth == 2)
        {
            //makes particle system play
            particleSysSlow.Play();
            particleSysFast.Stop();
        }
        else if (playerHealth == 1)
        {
            //makes fast particle system play
            particleSysSlow.Stop();
            particleSysFast.Play();
        }

    }
}


