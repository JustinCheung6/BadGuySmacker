using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Input : MonoBehaviour
{
    private Attack_Base_Animation owner;

    private bool attackInput = false;
    private float chargeTime = 0f;

    private void Awake()
    {
        owner = GetComponent<Attack_Base_Animation>();
    }

    private void Update()
    {
        if (Input.GetButton("Attack"))
            attackInput = true;
        else
            attackInput = false;
    }

    private void FixedUpdate()
    {
        if (attackInput)
        {
            chargeTime += Time.fixedDeltaTime;
        }
        else if (!attackInput && chargeTime > 0f)
        {
            StartCoroutine(owner.Attack(chargeTime));
            chargeTime = 0f;
        }
    }
}
