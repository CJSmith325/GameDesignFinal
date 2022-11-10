using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform player;

    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    private Transform enemyTransform;

    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        enemyTransform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("PlayerSprite") != null)
        {
            player = GameObject.Find("PlayerSprite").transform;
            Vector2 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //rb.rotation = angle;
            direction.Normalize();
            movement = direction;
            FlipCorrectly(direction);
        }
    }

    private void FixedUpdate()
    {
        if (GameObject.Find("PlayerSprite") != null)
        {
            player = GameObject.Find("PlayerSprite").transform;
            moveCharacter(movement);
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    private void FlipCorrectly(Vector2 facevector)
    {
        if (facevector.x < 0)
            enemyTransform.localScale = new Vector3(.3f, .3f, enemyTransform.localScale.z);
        else
            enemyTransform.localScale = new Vector3(-.3f, .3f, enemyTransform.localScale.z);
    }
}