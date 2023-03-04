using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot()
    {
        Instantiate(Bullet, _shootPoint.position, Bullet.transform.rotation);
    }
}
