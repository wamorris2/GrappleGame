using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private BoxCollider2D checkGrounded;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float movingX;
    [SerializeField] private bool jumped;
    [SerializeField] private bool grounded;
    [SerializeField] private Grappler grappler;
    [SerializeField] private float speed;
    public bool pulling;
    public float slowedX;
    public bool grappling;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            if(grounded)
                jumped = true;
        }

        movingX = Input.GetAxisRaw("Horizontal");
    }

    // FixedUpdate is called once every physics update
    private void FixedUpdate()
    {
        Collider2D[] collisions = new Collider2D[2];
        int numOfCollisions = checkGrounded.OverlapCollider(new ContactFilter2D(), collisions);
        if (numOfCollisions > 1)
            grounded = true;
        else
            grounded = false;
        if (grounded && jumped)
        {
            rigidBody.AddForce(Vector2.up * 7, ForceMode2D.Impulse);
            jumped = false;
        }
        if (!grappler.isGrappling())
            rigidBody.velocity = new Vector2(movingX * speed, rigidBody.velocity.y);


    }

    public void Propel(Vector2 direction)
    {
        rigidBody.AddForce(direction * 10, ForceMode2D.Impulse);
    }
}
