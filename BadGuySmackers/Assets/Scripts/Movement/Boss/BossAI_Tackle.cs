using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI_Tackle : Movement_Base, BossAI
{
    [Header("Boss Tackle")]
    [Tooltip("Delay that happens before the attack.")]
    [SerializeField] private float Startdelay;
    [Tooltip("Delay that happens after the attack.")]
    [SerializeField] private float Enddelay;
    [Tooltip("Whether or not the boss jumps during the tackle.")]
    [SerializeField] private bool jump = false;
    [SerializeField] private float tackleDistance = 0f;
    [Space(5)]
    [SerializeField] private Transform playerXYZ;

    private float endingX;
    private float h;

    public IEnumerator Action()
    {
        yield return new WaitForSeconds(Startdelay);

        h = (xyz.position.x > playerXYZ.position.x) ? -1 : 1;
        endingX = (h == -1) ? xyz.position.x - tackleDistance : xyz.position.x + tackleDistance;

        //Jump into the air if needed
        if (jump)
            Move(h * speed, true);
        else
            Move(h * speed, false);
        //Wait Until Boss moves desired distance
        if (h == -1)
            yield return new WaitUntil(() => xyz.position.x <= endingX);
        else
            yield return new WaitUntil(() => xyz.position.x >= endingX);
        Move(0f, false);
        Debug.Log("End");

        yield return new WaitForSeconds(Enddelay);
    }
}
