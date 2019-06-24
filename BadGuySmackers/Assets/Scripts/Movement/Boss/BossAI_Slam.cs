using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI_Slam : Movement_Base, BossAI
{
    [Space(10)]
    [Header("Boss Slam")]
    [Tooltip("Delay that happens before the attack")]
    [SerializeField] private float Startdelay;
    [Tooltip("Delay that happens after the attack")]
    [SerializeField] private float Enddelay;

    [SerializeField] private Transform playerXYZ;

    public IEnumerator Action()
    {
        yield return new WaitForSeconds(Startdelay);

        //Find player
        float playerX = playerXYZ.position.x;
        //Check where is player
        float h = 0;
        if (this.transform.position.x > playerX)
            h = -1;
        else if (this.transform.position.x < playerX)
            h = 1;
        //Jump into the air
        Move(h, true);

        //Move to player while in air (Player is to the left
        while(h == -1 && this.transform.position.x > playerX && !isGrounded)
            Move(h, false);
        while (h == 1 && this.transform.position.x < playerX && !isGrounded)
            Move(h, false);
        
        //Wait Until Boss hits the ground before finishing
        yield return new WaitUntil(() => isGrounded);
        yield return new WaitForSeconds(Enddelay);
    }
}
