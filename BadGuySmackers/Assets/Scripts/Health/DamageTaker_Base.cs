using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageTaker_Base : MonoBehaviour, DamageTaker_Abstract
{
    //Hide the field used by this property?
    private DamageTransaction _onDamageTransaction = delegate { };
    public DamageTransaction OnDamageTransaction
    {
        get { return _onDamageTransaction; }
        set { _onDamageTransaction = value; }
    }

    //Abstract declaration of functions from interface?
    public abstract void TakeDamage(object sender, float damage);
}
