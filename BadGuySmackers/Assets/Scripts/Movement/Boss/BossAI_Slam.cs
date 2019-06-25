using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI_Slam : Movement_Base, BossAI
{
    
    [Header("Boss Slam")]
    [Tooltip("Delay that happens before the attack")]
    [SerializeField] private float Startdelay;
    [Tooltip("Delay that happens after the attack")]
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
        //Check where is player
        
        if (this.transform.position.x > playerX)
            h = -1;
        else if (this.transform.position.x < playerX)
            h = 1;
        //Jump into the air
        Move(h, true);
        //Wait Until Boss hits the ground before finishing
        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => isGrounded);
        //Stop Movement
        Move(0f, false);
        yield return new WaitForSeconds(Enddelay);
    }

    void FixedUpdate()
    {
        base.FixedUpdate();

        if (!isGrounded)
        {
            if (h == -1 && this.transform.position.x > playerX)
                Move(h, false);
            else if (h == -1 && this.transform.position.x < playerX)
                Move(0f, false);

            if (h == 1 && this.transform.position.x < playerX)
                Move(h, false);
            else if (h == 1 && this.transform.position.x > playerX)
                Move(0f, false);
        }
        
    }
}
