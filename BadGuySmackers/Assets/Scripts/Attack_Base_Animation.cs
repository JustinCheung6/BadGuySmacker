using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Base_Animation : DamageGiver
{
    [SerializeField] private float basicDamage = 100f;
    [SerializeField] private float charge1Damage = 125f;
    [SerializeField] private float charge2Damage = 150f;
    [SerializeField] private float charge3Damage = 200f;
    [SerializeField] private float dullDamage = 50f;
    [SerializeField] private string charge1Name = "ChargeTime1";
    [SerializeField] private string charge2Name = "ChargeTime2";
    [SerializeField] private string charge3Name = "ChargeTime3";
    [SerializeField] private string dullName = "DullTime";
    [SerializeField] private string attackName = "attack";

    [Tooltip("Whether or not the character can Attack")]
    public bool isActivated = true;
    [Space(5)]
    [Header("Animations")]
    [SerializeField] private Animator animator;
    [Tooltip("Time attack animation takes to finish")]
    [SerializeField] private float attackDuration = 1.3501f;

    private bool isAttacking = false; //Whether or not the character is already attacking
    private bool isCharging = true;

    [SerializeField] private Movement_Base moveScript;

    public IEnumerator Attack(float chargeTime)
    {
        if (!isActivated || isAttacking || !isCharging)
            yield break;
        //Stop Movement
        moveScript.Move(0f, false);
        moveScript.isActivated = false;

        //Set Damage
        if (chargeTime < animator.GetFloat(charge1Name))
            damageValue = basicDamage;
        else if (chargeTime < animator.GetFloat(charge2Name))
            damageValue = charge1Damage;
        else if (chargeTime < animator.GetFloat(charge3Name))
            damageValue = charge2Damage;
        else if (chargeTime < animator.GetFloat(dullName))
            damageValue = charge3Damage;
        else
            damageValue = dullDamage;
        //Set Attacking
        isAttacking = true;
        if(!(chargeTime > animator.GetFloat(dullName)))
            animator.SetTrigger(attackName);
        //Wait until the animation plays and finishes
        yield return new WaitForSeconds(attackDuration);
        //Finish Attacking
        isAttacking = false;
        moveScript.isActivated = true;
    }
}
