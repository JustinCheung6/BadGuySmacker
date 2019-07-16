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

    [Tooltip("Whether or not the character can Attack")]
    public bool isActivated = true;
    [Space(5)]
    [Header("Animations")]
    [SerializeField] private Animator animator;
    [Tooltip("Name for the trigger that activates the charging Animation")]
    [SerializeField] private string charging;
    [Tooltip("Name for the trigger that activates the Basic Attack animation")]
    [SerializeField] private string attack;

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
            damageValue = basicDamage;
        else if (chargeTime < animator.GetFloat(dullName))
            damageValue = basicDamage;
        else
            damageValue = basicDamage;

        //Play Animation
        animator.SetTrigger(attack);
        Debug.Log("Set Animation");
        //Set Attacking
        isAttacking = true;
        Debug.Log("Set Boolean");
        //Wait until the animation plays and finishes
        yield return new WaitForSeconds(0.3501f);
        Debug.Log("Animation Stopped");
        //Finish Attacking
        isAttacking = false;
        Debug.Log("The End");

        moveScript.isActivated = true;
    }
}
