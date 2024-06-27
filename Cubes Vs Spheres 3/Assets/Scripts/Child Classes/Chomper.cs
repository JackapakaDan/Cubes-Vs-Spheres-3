using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomper : Enemy
{
    public override void Start()
    {
        base.Start();
        rangeToMaybeSpawnWeapon = 100;
        rangeToSpawnWeapon = 10;
    }

}
