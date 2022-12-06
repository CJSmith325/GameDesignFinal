using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float attackCooldown;
    public float attackChannelMaxTime = 5f;
    public float attackChannelTime = 0f;
    public Slider channelSlider;

    public float bulletForce = 0f;
    public Vector2 fireDirection;

    public float bulletDamage = 10f;

    private float bulletLife = 5f;

    public SpriteRenderer bulletSprite;
    public float spriteChange;

    bool newPress = false;

    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))//signals the start of a channel
        {
            newPress = true;
            animator.SetBool("IsShooting", true);
            fireDirection = firePoint.up;
        }
        if (Input.GetButton("Fire1") && newPress)//building up the channel
        {
            attackChannelTime += Time.deltaTime * 5;
            if (attackChannelTime > attackChannelMaxTime)
            {
                Shoot(attackChannelTime * 2);
            }
        }
        if (Input.GetButtonUp("Fire1") && newPress)//releasing without it being full
        {
            Shoot(attackChannelTime);
        }
    }
    void Shoot(float power)
    {
        animator.SetBool("IsShooting", false);//stop the charging animation
        newPress = false;//preventing an additional chargeup after shooting

        //Shooting
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //Summon bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); //Set the bullet RB
        rb.AddForce(fireDirection * 20, ForceMode2D.Impulse); //Move the bullet in the correct direction

        //Adjusting properties of the bullets
        Bullet bulletProperties = bullet.GetComponent<Bullet>();
        bulletProperties.damage = power * 20;//Establish damage dealt to enemies based on charge
        //Change the bullets color based on charge. unfortunately does not work for unusual reasons.
        /*bulletSprite = bullet.GetComponent<SpriteRenderer>();
        spriteChange = attackChannelTime * 51;
        if (spriteChange > 255f)
            spriteChange = 255f;
        Color appliedColor = new Color(spriteChange, 255 - spriteChange, 255 - spriteChange, 255);
        bulletSprite.color = appliedColor;*/

        if(power > 7)//triggers on max charge time for the big bullet
            bullet.transform.localScale = new Vector3(.4f, .4f, 1f);
        
        attackChannelTime = 0;
        Destroy(bullet, bulletLife); //temporary infinite bullet fix
    }
}
