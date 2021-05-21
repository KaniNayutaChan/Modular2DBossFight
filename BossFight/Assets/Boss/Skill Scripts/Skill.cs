using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [HideInInspector] public Transform owner;
    public float timeTillDestroy;

    // Start is called before the first frame update
    public virtual void Start()
    {
        if (timeTillDestroy > 0)
        {
            Destroy(gameObject, timeTillDestroy);
        }
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }
}
