﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Input : MonoBehaviour
{
    [SerializeField] private Attack_Base_Animation owner;
    [SerializeField] private Movement_Base move;
    [SerializeField] private Animator animator;
    [SerializeField] private string chargeName = "ChargeTime";

    private bool attackInput = false;
    private float chargeTime = 0f;

    private void Awake()
    {
        owner = GetComponent<Attack_Base_Animation>();
    }

    private void Update()
    {
        if (Input.GetButton("Attack") && move.isGrounded)
            attackInput = true;
        else
            attackInput = false;
    }

    private void FixedUpdate()
    {
        if (attackInput && owner.isAttacking == false)
        {
            move.Move(0f, false);
            move.isActivated = false;
            chargeTime += Time.fixedDeltaTime;
            //Animation
            animator.SetFloat(chargeName, chargeTime);
        }
        else if (!attackInput && chargeTime > 0f && move.isGrounded)
        {
            Debug.Log("Activate");
            StartCoroutine(owner.Attack(chargeTime));
            chargeTime = 0f;
            animator.SetFloat(chargeName, 0f);
        }
        else
        {
            chargeTime = 0f;
            animator.SetFloat(chargeName, 0f);
        }
    }
}
