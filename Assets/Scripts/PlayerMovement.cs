using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public Rigidbody2D rb;

    public Vector2 movement;
    public GameObject cameraObject;
    public Camera cam;
    public Vector2 mousePos;

    public static PlayerMovement instance;

    private void Start()
    {
        instance = this;
    }

    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            rb.velocity = movement * speed;
            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            cameraObject.transform.position = new Vector3(rb.position.x, rb.position.y, cameraObject.transform.position.z);
            rb.rotation = angle;
        }
    }
}
