using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementAttack : BossAttack
{
    public MovementType movementType;
    public enum MovementType
    {
        MoveToPlayer,
        MoveRelativeToEnemy,
        MoveToRandomDestination
    }

    public Vector3 destinationVector;
    public float startWaitTime;
    float waitTime;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        waitTime = startWaitTime;

        switch (movementType)
        {
            case MovementType.MoveToPlayer:
                SetDestinationToPlayer(destinationVector.x, destinationVector.y);
                break;
            case MovementType.MoveRelativeToEnemy:
                SetDestinationToEnemy(enemyPos.position.x + destinationVector.x, enemyPos.position.y);
                break;
            case MovementType.MoveToRandomDestination:
                SetDestination(Random.Range(-destinationVector.x, destinationVector.x), Random.Range(destinationVector.y, destinationVector.z));
                break;
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if (timeTillAttack > 0)
        {
            timeTillAttack -= Time.deltaTime;
        }
        else
        {
            MoveToDestination();
        }

        if (IsAtDestination())
        {
            counter++;

            if (counter >= noOfAttacks)
            {
                if (waitTime > 0)
                {
                    waitTime -= Time.deltaTime;
                }
                else
                {
                    animator.Play("idle");
                }
            }
            else
            {
                timeTillAttack = timeBetweenAttacks;

                switch (movementType)
                {
                    case MovementType.MoveToPlayer:
                        animator.Play("idle");
                        break;

                    case MovementType.MoveRelativeToEnemy:
                        SetDestinationToEnemy(enemyPos.position.x + destinationVector.x, enemyPos.position.y);
                        break;

                    case MovementType.MoveToRandomDestination:
                        SetDestination(Random.Range(-destinationVector.x, destinationVector.x), Random.Range(destinationVector.y, destinationVector.z));
                        break;
                }
            }
        }
    }
}
