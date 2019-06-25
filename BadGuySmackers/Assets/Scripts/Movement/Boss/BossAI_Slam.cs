using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI_Slam : Movement_Base, BossAI
{
    
    [Header("Boss Slam")]
    [Tooltip("Delay that happens before the attack.")]
    [SerializeField] private float Startdelay;
    [Tooltip("Delay that happens after the attack.")]
    [SerializeField] private float Enddelay;
    [Space(5)]
    [SerializeField] private Transform playerXYZ;

    [SerializeField] private float h = 0;
    [SerializeField] private float playerX = 0;

    public IEnumerator Action()
    {
        yield return new WaitForSeconds(Startdelay);
        //Get Player Position
        playerX = playerXYZ.position.x;

        if (xyz.position.x > playerX)
            h = -1;
        else if (xyz.position.x < playerX)
            h = 1;

        //Jump into the air
        Move(h * speed, true);
        
        yield return new WaitForSeconds(0.1f);
        //Wait Until Boss hits the ground before finishing or if Boss passes player
        yield return new WaitUntil(() => isGrounded || (h == -1 && xyz.position.x < playerX) || h == 1 && xyz.position.x > playerX);
        //Stop Movement
        Move(0f, false);
        //Wait Unit Boss hits the ground if it hadn't yet
        if(!isGrounded)
            yield return new WaitUntil(() => isGrounded);

        yield return new WaitForSeconds(Enddelay);
    }
}
