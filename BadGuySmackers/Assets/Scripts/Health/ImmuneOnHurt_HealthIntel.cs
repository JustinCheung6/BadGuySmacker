using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImmuneOnHurt_HealthIntel : HealthIntel_Abstract
{
    [Tooltip("Time character is intargetable")]
    [SerializeField] private float hurtTime = 1f;
    [SerializeField] private Anima2D.SpriteMeshInstance[] spriteRenderers;

    protected override void DamageTransaction(object sender, float damage)
    {
        StartCoroutine(Hurt());
    }
    protected override void Death()
    {
    }

    private IEnumerator Hurt()
    {
        //Set character invulnerable to further damage
        owner.isImmune = true;

        //Fade all the sprites 
        foreach (Anima2D.SpriteMeshInstance sprite in spriteRenderers)
        {
            sprite.color = new Color(1f, 1f, 1f, 0.5f);
        }

        yield return new WaitForSeconds(hurtTime);

        //Undo everything done previously
        owner.isImmune = false;

        foreach (Anima2D.SpriteMeshInstance sprite in spriteRenderers)
        {
            sprite.color = new Color(1f, 1f, 1f, 1f);
        }

    }
}
