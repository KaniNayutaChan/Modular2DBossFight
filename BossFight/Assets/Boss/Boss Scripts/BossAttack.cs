using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : Boss
{
    public float startTimeTillIdle;
    public float startTimeTillAttack;
    public float noOfAttacks;
    public float timeBetweenAttacks;

    protected int counter;
    float timeTillIdle;
    float timeTillAttack;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        timeTillIdle = startTimeTillIdle;
        timeTillAttack = startTimeTillAttack;
        counter = 0;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (startTimeTillIdle > 0)
        {
            if (timeTillIdle > 0)
            {
                timeTillIdle -= Time.deltaTime;
            }
            else
            {
                animator.Play("idle");
            }
        }

        if (timeTillAttack > 0)
        {
            timeTillAttack -= Time.deltaTime;
        }
        else if (counter < noOfAttacks)
        {
            timeTillAttack = timeBetweenAttacks;
            UseAttack();
            counter++;
        }
    }   

    protected virtual void UseAttack()
    {

    }
}
