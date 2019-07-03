using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Input : MonoBehaviour
{
    private bool jumpInput;
    private Movement_Base owner;

    private void Awake()
    {
        owner = GetComponent<Movement_Base>();
    }

    // Read the button presses in Update so they aren't missed.
    private void Update()
    {
        jumpInput = (!jumpInput) ? Input.GetButtonDown("Jump") : false;
    }
    private void FixedUpdate()
    {
        //Get move input
        float h = Input.GetAxis("Horizontal");
        owner.Move(h, jumpInput);
        jumpInput = false;
    }
}
