using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : Health_DamageTaker_Base
{
    [Tooltip("Maximum value character's Health can go.")]
    [SerializeField] protected float maxHealth = 100f;
    [Tooltip("Current Amount of health character has (Max value is maxHealth).")]
    [SerializeField] protected float currentHealth = 100f;
    [Tooltip("Whether or not the character can be hit.")]
    [SerializeField] protected bool isImmune = false;
    protected bool isDead = false;

    //Public variables for getting info from Health Base
    public float read_maxHealth { get { return maxHealth; } }
    public float read_currentHealth { get { return currentHealth; } }

    //Delegate for HealthIntel Scripts
    public Action OnDeath = delegate { };

    public override void TakeDamage(object sender, float damage)
    {
        //Stop function if already dead
        if (isDead || isImmune)
            return;
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            currentHealth = 0f;
            isDead = true;

            //Activate Delegate for HealthIntel scripts
            OnDeath();
        }

        //Activate Delegate for HealthIntel scripts
        OnDamageTransaction(sender, damage);
    }
}
