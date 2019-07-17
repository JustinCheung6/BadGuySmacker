using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnDeath_HealthIntel : HealthIntel_Abstract
{
    protected override void DamageTransaction(object sender, float damage)
    {

    }
    protected override void Death()
    {
        Destroy(gameObject);
    }
}
