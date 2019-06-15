using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGiver : MonoBehaviour
{
    [SerializeField] protected float damageValue = 25f;

    private void OnCollisionEnter2D(Collision2D col)
    {
        //Check if collided object can take damage
        DamageTaker_Abstract taker = col.gameObject.GetComponent<DamageTaker_Abstract>();
        if(taker != null)
        {
            //Apply damage to the character
            taker.TakeDamage(this, damageValue);
        }
    }
}
