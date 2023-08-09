using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class LaserRevolverBehaviour : ProjectileBehaviour
{
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position += Direction * (projectileSpeed * Time.deltaTime);
    }
}
