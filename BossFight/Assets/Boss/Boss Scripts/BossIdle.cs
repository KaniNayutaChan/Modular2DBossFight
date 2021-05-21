using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdle : Boss
{
    public MovementType movementType;
    public enum MovementType
    {
        MoveToPlayer,
        MoveToRandomDestination,
        StayStill
    }

    public Vector3 destinationVector;

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

        switch (movementType)
        {
            case MovementType.MoveToPlayer:
                SetDestinationToPlayer(0, 0);
                FacePlayer();
                break;

            case MovementType.MoveToRandomDestination:
                SetDestination(Random.Range(-destinationVector.x, destinationVector.x), Random.Range(destinationVector.y, destinationVector.z));
                FaceDestination();
                break;

            case MovementType.StayStill:
                SetDestinationToEnemy(0, 0);
                FacePlayer();
                break;
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(movementType == MovementType.MoveToPlayer)
        {
            SetDestinationToPlayer(0, 0);
            FacePlayer();
        }

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
