using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Base_Animation : MonoBehaviour
{
    [Tooltip("Time it takes for attakck to be charged once")]
    [SerializeField] private float firstThreshhold = 1f;
    [Tooltip("Whether or not the character can Attack")]
    public bool isActivated = true;
    [Space(5)]
    [Header("Animations")]
    [SerializeField] private Animator animator;
    [Tooltip("Name for the trigger that activates the charging Animation")]
    [SerializeField] private string charging;
    [Tooltip("Name for the trigger that activates the Basic Attack animation")]
    [SerializeField] private string basicAttack;

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

        if (chargeTime > firstThreshhold) //CHANGE THIS
        {
            //Play Animation
            animator.SetTrigger(basicAttack);
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
        }
        else
        {
            //Play Animation
            animator.SetTrigger(basicAttack);
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
        }

        moveScript.isActivated = true;
    }
}
