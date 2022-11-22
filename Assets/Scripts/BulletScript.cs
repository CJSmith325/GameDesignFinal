using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float attackCooldown;
    public float attackChannelMaxTime = 10f;
    public float attackChannelTime = 0f;
    public Slider channelSlider;

    public float bulletForce = 0f;

    public float bulletDamage = 10f;

    private float bulletLife = 5f;

    bool newPress = false;
    // Update is called once per frame
    void Update()
    {
        //old shooting system
        channelSlider.value = attackChannelTime;
        /*if (Input.GetButton("Fire1"))
        {
            attackChannelTime += (Time.deltaTime * 5);
            if (attackChannelTime > attackChannelMaxTime)
            {
                //if the channel is completed, shoot, and reset the channel
                Shoot();
                attackChannelTime = 0;
            }
        }
        else
        {
            attackChannelTime = 0;
        }*/

        //new system
        if (Input.GetButtonDown("Fire1"))//signals the start of a channel
        {
            newPress = true;
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
        newPress = false;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * power * 10, ForceMode2D.Impulse);
        Bullet bulletProperties = bullet.GetComponent<Bullet>();
        bulletProperties.damage = power * 20;
        attackChannelTime = 0;
        Destroy(bullet, bulletLife); //temporary infinite bullet fix
    }
}
