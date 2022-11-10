using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);//destroys enemy
            Destroy(gameObject); //destroys bullet
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject); //destroys bullet
        }
        
        
    }

    
}
