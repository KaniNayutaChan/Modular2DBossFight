using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectileSkill : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        transform.forward = Player.instance.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
