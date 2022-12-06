using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public GameObject particlePrefab;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject particleObject = Instantiate(particlePrefab, this.transform.position, this.transform.rotation);
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
