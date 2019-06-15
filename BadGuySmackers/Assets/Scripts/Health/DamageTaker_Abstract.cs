using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Damage giver scripts will use this delegate to interact with damage takers
public delegate void DamageTransaction(object sender, float damage);

public interface DamageTaker_Abstract
{
    //DamageGiver will send over damage
    void TakeDamage(object sender, float damage);

    //Event when damage happens?
    DamageTransaction OnDamageTransaction { get; set; }
}
