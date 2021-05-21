﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnAttack : BossAttack
{
    public SpawnType spawnType;
    public enum SpawnType
    {
        SpawnRelativeToEnemy,
        SpawnAtPosition,
        SpawnAtRangeOfPositions,
        SpawnInIncrements,
        SpawnInCircle
    }

    Vector3 spawnPos = new Vector3();

    public GameObject skill;
    public bool setSpawnVectorToEnemy;
    public Vector3 spawnVector;
    public Vector3 rotation;
    public float gapDistance;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        if(setSpawnVectorToEnemy)
        {
            spawnVector = enemyPos.position;
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
    }

    protected override void UseAttack()
    {
        base.UseAttack();

        switch (spawnType)
        {
            case SpawnType.SpawnRelativeToEnemy:
                if (IsFacingLeft())
                {
                    spawnPos.Set(enemyPos.position.x - spawnVector.x, enemyPos.position.y + spawnVector.y, 0);
                }
                else
                {
                    spawnPos.Set(enemyPos.position.x + spawnVector.x, enemyPos.position.y + spawnVector.y, 0);
                }
                break;

            case SpawnType.SpawnAtPosition:
                spawnPos.Set(spawnVector.x, spawnVector.y, 0);
                break;

            case SpawnType.SpawnAtRangeOfPositions:
                spawnPos.Set(Random.Range(-spawnVector.x, spawnVector.x), Random.Range(spawnVector.y, spawnVector.z), 0);
                break;

            case SpawnType.SpawnInIncrements:
                if (IsFacingLeft())
                {
                    spawnPos.Set(spawnVector.x - (counter * gapDistance), spawnVector.y, 0);
                }
                else
                {
                    spawnPos.Set(spawnVector.x + (counter * gapDistance), spawnVector.y, 0);
                }
                break;

            case SpawnType.SpawnInCircle:
                spawnPos.Set(spawnVector.x + (gapDistance * Mathf.Cos(Mathf.PI * counter/noOfAttacks)), spawnVector.y + (gapDistance * Mathf.Sin((Mathf.PI * counter) / noOfAttacks)), 0);
                break;
        }

        Instantiate(skill, spawnPos, Quaternion.Euler(rotation));
    }
}