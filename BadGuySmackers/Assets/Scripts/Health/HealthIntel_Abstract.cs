using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthIntel_Abstract : MonoBehaviour
{
    [SerializeField] protected Health owner;

    // Connect to owner if script enabled
    protected virtual void OnEnable()
    {
        if (owner != null)
        {
            owner.OnDamageTransaction += DamageTransaction;
            owner.OnDeath += Death;
        }
    }
    // Disconnect from Owner if script disabled
    protected virtual void OnDisable()
    {
        if (owner != null)
        {
            owner.OnDamageTransaction -= DamageTransaction;
            owner.OnDeath -= Death;
        }
    }

    //Specific Events that can be used for HealthIntel Scripts
    protected abstract void DamageTransaction(object sender, float damage);
    protected abstract void Death();


}
