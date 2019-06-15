using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : DamageTaker_Base
{
    protected float maxHealth = 100f;
    protected float currentHealth = 100f;

    protected bool isDead = false;

    //Find Event
    public Action OnDeath = delegate { };

    public override void TakeDamage(object sender, float damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if ((currentHealth <= 0f && !isDead) || (isDead && currentHealth != 0))
        {
            currentHealth = 0f;
            isDead = true;

            OnDeath();
        }

        OnDamageTransaction(sender, damage);
    }

    //Public functions for getting info from Health Base
    public float GetMaxHealth { get { return maxHealth; } }
    public float GetCurrentHealth { get { return currentHealth; } }
}
