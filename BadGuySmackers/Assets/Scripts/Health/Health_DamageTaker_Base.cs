using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health_DamageTaker_Base : MonoBehaviour, Health_DamageTaker_Abstract
{
    //Hide the field used by this property?
    private DamageTransactionBase _onDamageTransaction = delegate { };
    public DamageTransactionBase OnDamageTransaction
    {
        get { return _onDamageTransaction; }
        set { _onDamageTransaction = value; }
    }

    //Abstract declaration of functions from interface?
    public abstract void TakeDamage(object sender, float damage);
}
