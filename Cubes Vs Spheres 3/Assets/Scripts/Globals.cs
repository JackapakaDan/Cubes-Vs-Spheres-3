using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals
{
    public enum Weapon
    {
        None,
        Mine,
        ThrowableGenade,
        SMG,
        Sniper,
        Shotgun,
        AR,
        Bat,
        Pistol,
        Boomerang,
        Chompers,
        RocketLauncher
    };
    public static Dictionary<int, Weapon> curWeapon = new Dictionary<int, Weapon> { { 0, Weapon.Mine} };
    public static List<Weapon> inventory = new List<Weapon> { Weapon.Mine, Weapon.None, Weapon.None, Weapon.None, Weapon.None, Weapon.None, Weapon.None, Weapon.None };
    public static bool chompersAreAttacking = false;
}

