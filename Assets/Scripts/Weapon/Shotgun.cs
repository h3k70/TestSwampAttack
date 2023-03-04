using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    protected int Spread = 10;

    public override void Shoot()
    {
        CreateBullet();
        CreateBullet();
        CreateBullet();
    }

    private void CreateBullet()
    {
        Bullet bullet = Instantiate(Bullet, _shootPoint.position, Bullet.transform.rotation);
        bullet.transform.Rotate(0, 0, Random.Range(-Spread, Spread + 1));
    }
}
