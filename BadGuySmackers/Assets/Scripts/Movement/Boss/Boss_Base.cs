using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Boss : HealthIntel_Abstract
{
    private BossAI[] actions;

    private void Awake()
    {
        actions = (BossAI[])FindObjectsOfType(typeof(BossAI));
        StartCoroutine(BossFight());
    }

    IEnumerator BossFight()
    {
        //Get index for a random BossAI Action in the actions array
        int i = Random.Range(0, actions.Length);
        //Activate and wait for the array to finish
        yield return StartCoroutine(actions[i].Action());
        StartCoroutine(BossFight());
    }

    protected override void DamageTransaction(object sender, float damage)
    {

    }
    protected override void Death()
    {
        StopAllCoroutines();
    }
}
