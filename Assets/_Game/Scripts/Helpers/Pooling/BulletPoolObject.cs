using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolObject : PoolObject
{
    public Rigidbody rb;

    public override void OnCreated()
    {
        OnDeactivate();
    }

    public override void OnDeactivate()
    {
        gameObject.SetActive(false);
    }

    public override void OnSpawn()
    {
        gameObject.SetActive(true);
    }
}
