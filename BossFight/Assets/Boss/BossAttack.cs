using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : Boss
{
    public AttackType attackType;
    public enum AttackType
    {
        moveToCharacter,
        moveToRandomDestination,
        spawnSkill
    };

    public float startTimeTillIdle;
    public float startTimeTillAttack;
    public float noOfAttacks;

    [Space]
    public GameObject skill;
    public float timeBetweenAttacks;

    [Space]
    public float xRange;
    public float yMinRange;
    public float yMaxRange;

    int counter;
    float timeTillIdle;
    float timeTillAttack;

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

        if (timeTillAttack >= 0)
        {
            timeTillAttack -= Time.deltaTime;
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
        SetDestinationToPlayer(0, 0);
    }

    void MoveToRandomDestinationStart()
    {
        SetDestination(Random.Range(-xRange, xRange), Random.Range(yMinRange, yMaxRange));
    }

    void SpawnSkillStart()
    {

    }

    void MoveToCharacterUpdate()
    {
        if (timeTillAttack < 0)
        {
            MoveToDestination();
        }
    }

    void MoveToRandomDestinationUpdate()
    {
        if (timeTillAttack < 0)
        {
            MoveToDestination();
        }
    }

    void SpawnSkillUpdate()
    {
        if(timeTillAttack < 0)
        {
            if(counter < noOfAttacks)
            {
                counter++;
                Instantiate(skill, enemyPos.position, enemyPos.rotation);
                timeTillAttack = timeBetweenAttacks;
            }
        }
    }
}
