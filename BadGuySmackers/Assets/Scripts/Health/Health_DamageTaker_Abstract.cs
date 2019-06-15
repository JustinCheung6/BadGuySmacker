using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base for the OnDamageTransaction delegate
public delegate void DamageTransactionBase(object sender, float damage);

public interface Health_DamageTaker_Abstract
{
    //DamageGiver will send over damage
    void TakeDamage(object sender, float damage);

    //delegate that's used in HealthIntel scripts
    DamageTransactionBase OnDamageTransaction { get; set; }
}
