using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : StateMachineBehaviour
{
    [HideInInspector] protected Vector3 destination;
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

    protected void FaceLeft()
    {
        enemyPos.rotation = Quaternion.Euler(0, 90, 0);
    }

    protected void FaceRight()
    {
        enemyPos.rotation = Quaternion.Euler(0, 0, 0);

    }

    protected void FacePlayer()
    {
        if(playerPos.position.x > enemyPos.position.x)
        {
            FaceRight();
        }
        else
        {
            FaceLeft();
        }
    }

    protected void FaceDestination()
    {
        if(destination.x > enemyPos.position.x)
        {
            FaceRight();
        }
        else
        {
            FaceLeft();
        }
    }    

    protected bool IsFacingLeft()
    {
        if(enemyPos.rotation == Quaternion.Euler(0, 90, 0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
