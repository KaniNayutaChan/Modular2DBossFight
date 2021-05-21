using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSkill : Skill
{
    public float speed;
    public float rotationSpeed;
    public float xRotation;
    public bool facePlayerOnStart;

    public ProjectileType projectileType;
    public enum ProjectileType
    {
        Linear,
        Homing
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        if (facePlayerOnStart)
        {
            transform.forward = Player.instance.transform.position - transform.position;
        }

        transform.Rotate(new Vector3(Random.Range(-xRotation, xRotation), 0, 0));
    }

    // Update is called once per frame
    public override void Update()
    {
        if (projectileType == ProjectileType.Linear)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if(projectileType == ProjectileType.Homing)
        {
            Vector3 targetDirection = Player.instance.transform.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
