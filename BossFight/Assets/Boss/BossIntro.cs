using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIntro : Boss
{
    public float startTimeTillIdle;
    float timeTillIdle;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        timeTillIdle = startTimeTillIdle;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(timeTillIdle > 0)
        {
            timeTillIdle -= Time.deltaTime;
        }
        else
        {
            animator.Play("idle");
        }
    }
}
