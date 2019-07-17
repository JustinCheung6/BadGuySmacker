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

    [Space(5)]
    [Header("Animations")]
    [SerializeField] private Animator animator;
    [Tooltip("Time attack animation takes to finish")]
    [SerializeField] private float attackDuration = 1.3501f;

    public bool isAttacking = false; //Whether or not the character is already attacking

    [SerializeField] private Movement_Base moveScript;
    [SerializeField] private BoxCollider2D boxCollider;

    public IEnumerator Attack(float chargeTime)
    {
        Debug.Log("Started");
        if (isAttacking)
            yield break;

        Debug.Log("1st Barrier");
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
        boxCollider.enabled = true;
        if(chargeTime < animator.GetFloat(dullName))
        {
            animator.SetTrigger(attackName);
        }
        //Wait until the animation plays and finishes
        yield return new WaitForSeconds(attackDuration);
        //Finish Attacking
        Debug.Log("No more hit");
        isAttacking = false;
        boxCollider.enabled = false;
        moveScript.isActivated = true;
    }
}
