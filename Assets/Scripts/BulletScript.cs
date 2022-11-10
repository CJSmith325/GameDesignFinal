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

    public float bulletForce = 20f;

    public float bulletDamage = 10f;
    // Update is called once per frame
    void Update()
    {
        channelSlider.value = attackChannelTime;
        if (Input.GetButton("Fire1"))
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
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
