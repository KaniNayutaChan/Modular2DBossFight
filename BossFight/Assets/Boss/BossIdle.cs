using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdle : Boss
{
    int attackToUse;
    public float minTimeTillAttack;
    public float maxTimeTillAttack;
    float timeTillAttack;
    public string[] attackList;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        timeTillAttack = Random.Range(minTimeTillAttack, maxTimeTillAttack);
        attackToUse = Random.Range(0, attackList.Length);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SetDestinationToPlayer(0, 0);
        MoveToDestination();

        if (timeTillAttack > 0)
        {
            timeTillAttack -= Time.deltaTime;
        }
        else
        {
            animator.Play(attackList[attackToUse]);
        }
    }
}
