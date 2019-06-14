    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Input : MonoBehaviour
{
    private bool jumpInput;
    private MovementBase Base;

    private void Awake()
    {
        Base = GetComponent<MovementBase>();
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
        Base.Move(h, jumpInput);
        jumpInput = false;
    }
}
