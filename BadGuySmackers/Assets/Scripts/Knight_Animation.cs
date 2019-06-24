﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Base : MonoBehaviour
{
    [SerializeField] private string Running = "Moving";
    [SerializeField] private string Direction = "FacingRight";

    private Animator anim;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //Direction
        if (Input.GetAxis("Horizontal") > 0f && Mathf.Abs(rb2d.velocity.x) > 0.1f)
            anim.SetBool(Direction, true);
        else if (Input.GetAxis("Horizontal") < 0f && Mathf.Abs(rb2d.velocity.x) > 0.1f)
            anim.SetBool(Direction, false);
        //Moving
        if (Mathf.Abs(rb2d.velocity.x) > 0.1f)
            anim.SetBool(Running, true);
        else
            anim.SetBool(Running, false);
    }

    private void FixedUpdate()
    {
    }
}
