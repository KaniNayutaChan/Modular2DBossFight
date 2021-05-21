using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : StateMachineBehaviour
{
    [HideInInspector] protected Vector3 destination;
    [HideInInspector] protected Vector3 spawnPos;
    [HideInInspector] protected Transform playerPos;
    [HideInInspector] protected Transform enemyPos;
    public float speed;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = Player.instance.transform;
        enemyPos = animator.transform;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    protected void SetDestinationToPlayer(float x, float y)
    {
        destination.Set(playerPos.transform.position.x + x, playerPos.transform.position.y + y, 0);
    }

    protected void SetDestination(float x, float y)
    {
        destination.Set(x, y, 0);
    }

    protected void MoveToDestination()
    {
        enemyPos.position = Vector3.MoveTowards(enemyPos.position, destination, speed * Time.deltaTime);
    }
}
