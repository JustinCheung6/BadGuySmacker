using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Boss_Base : HealthIntel_Abstract
{
    [Header("Boss Scripts")]
    public int totalActions;
    public BossAI_Slam slamScript; //Index 1


    private void Awake()
    {
        StartCoroutine(BossFight());
    }
    
    IEnumerator BossFight()
    {
        //Get index for a random BossAI Action in the actions array
        int i = Random.Range(1, totalActions);
        //Activate and wait for the array to finish
        if(i == 1)
            yield return StartCoroutine(slamScript.Action());
        //Restart
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
