using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGiver : MonoBehaviour
{
    [Tooltip("Amount of damage this collider does.")]
    [SerializeField] protected float damageValue = 25f;

    [Tooltip("Whether or not character can do damage")]
    public bool activated = true;

    private void OnTriggerStay2D(Collider2D col)
    {
        //Check if collided object can take damage
        Health_DamageTaker_Abstract taker = col.gameObject.GetComponent<Health_DamageTaker_Abstract>();
        if(taker != null)
        {
            //Apply damage to the character
            taker.TakeDamage(this, damageValue);
        }
    }
}
