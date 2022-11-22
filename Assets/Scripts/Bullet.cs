using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth targetHealth = collision.gameObject.GetComponent<EnemyHealth>();
            targetHealth.EHealth -= damage;
            if (targetHealth.EHealth <= 0)
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject); //destroys bullet
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject); //destroys bullet
        }
        
        
    }

    
}
