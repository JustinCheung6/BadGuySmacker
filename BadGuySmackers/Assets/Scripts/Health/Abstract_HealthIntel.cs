using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Abstract_HealthIntel : MonoBehaviour
{
    protected Health owner;

    protected virtual void Awake()
    {
        if (owner == null)
            owner = GetComponent<Health>();
    }
    protected virtual void OnEnable()
    {
        if (owner != null)
        {
            owner.OnDamageTransaction += DamageTransaction;
            owner.OnDeath += Death;
        }
    }
    protected virtual void OnDisable()
    {
        if (owner != null)
        {
            owner.OnDamageTransaction -= DamageTransaction;
            owner.OnDeath -= Death;
        }
    }
    protected abstract void DamageTransaction(object sender, float damage);
    protected abstract void Death();

}
