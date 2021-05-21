using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : Boss
{
    public float startTimeTillIdle;
    public float startTimeTillAttack;
    public float noOfAttacks;
    float timeTillIdle;
    float timeTillAttack;
    int counter;

    public AttackType attackType;
    public enum AttackType
    {
        moveToCharacter,
        moveToRandomDestination,
        spawnSkill
    };

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        timeTillIdle = startTimeTillIdle;
        timeTillAttack = startTimeTillAttack;
        counter = 0;

        switch (attackType)
        {
            case AttackType.moveToCharacter:
                MoveToCharacterStart();
                break;

            case AttackType.moveToRandomDestination:
                MoveToRandomDestinationStart();
                break;

            case AttackType.spawnSkill:
                SpawnSkillStart();
                break;
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(startTimeTillIdle > 0)
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

        switch (attackType)
        {
            case AttackType.moveToCharacter:
                MoveToCharacterUpdate();
                break;

            case AttackType.moveToRandomDestination:
                MoveToRandomDestinationUpdate();
                break;

            case AttackType.spawnSkill:
                SpawnSkillUpdate();
                break;
        }
    }

    void MoveToCharacterStart()
    {

    }

    void MoveToRandomDestinationStart()
    {

    }

    void SpawnSkillStart()
    {

    }

    void MoveToCharacterUpdate()
    {

    }

    void MoveToRandomDestinationUpdate()
    {

    }

    void SpawnSkillUpdate()
    {

    }
}
