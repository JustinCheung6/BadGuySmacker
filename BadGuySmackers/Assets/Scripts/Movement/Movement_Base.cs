using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Base : MonoBehaviour  
{
    [Tooltip("How fast player's velocity increases")]
    [SerializeField] private float speed = 1f;
    [Tooltip("Max value player's velocity can move")]
    [SerializeField] private float maxSpeed = 5f;
    [Tooltip("Force added when player jumps")]
    [SerializeField] private float jumpForce = 500f;
    [Tooltip("Gravity multiplier when character jumps (1 = normal, must be greater than 0)")]
    [SerializeField] private float gravityMultiplier = 2f;
    [Tooltip("Gravity multiplier when character falls (1 = normal, must be greater than 0)")]
    [SerializeField] private float fallMultiplier = 5f;
    [Tooltip("Decides if character can move in air")]
    [SerializeField] private bool airControl = true;
    [Tooltip("Decides what physic layers are considered floor")]
    [SerializeField] private LayerMask floorMask;

    private Transform xyz;
    private Rigidbody2D rb2d;
    protected bool isGrounded = false; //Is character on the floor
    const float groundcheckDist = 0.2f; //Distance for checking if there is floor (Circle cast)

    public bool isActivated = true; //If player allowed to move
    public bool isLocked = false; //If player's velocity is locked

    private void Awake()
    {
        xyz = this.transform;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Check if there are colliders with groundMask specified layer, and set bool true if there is
        Collider2D[] cols = Physics2D.OverlapCircleAll(xyz.position, groundcheckDist, floorMask);
        isGrounded = (cols.Length > 0) ? true : false;
        //Check if player is in air, gravitymultiplier is greater than 1, and velocity is positive
        if (!isGrounded && fallMultiplier >= 0f && rb2d.velocity.y > 0)
            rb2d.AddForce(Physics2D.gravity * (gravityMultiplier - 1f));
        //Check if player is in air, fallmultiplier is greater than 1, and velocity is negative
        else if (!isGrounded && fallMultiplier >= 0f && rb2d.velocity.y < 0)
            rb2d.AddForce(Physics2D.gravity * (fallMultiplier - 1f));

    }

    public void Move(float move, bool jump)
    {
        //Stop function if character is disactivated
        if (!isActivated)
            return;
        //Check if character is on the ground or if they can move in the air
        if (isGrounded || airControl)
        {
            //Stop movement if character is moving and there is no input
            if ((Mathf.Abs(move) < 0.1f) && (Mathf.Abs(rb2d.velocity.x) > 0f))
                rb2d.velocity -= new Vector2(rb2d.velocity.x, 0f);
            //Move character if there is input
            else
                rb2d.velocity += new Vector2(move * speed, 0f);
        }
        //Lock the velocity to the maxspeed
        rb2d.velocity = new Vector2(Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed), rb2d.velocity.y);

        //Check if the character is on the ground and can jump
        if(isGrounded && jump)
        {
            //Set character to not on ground and add jumpforce
            isGrounded = false;
            rb2d.AddForce(new Vector2(0f, jumpForce));
        }
    }
}
