using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals
{
    public enum EnemyType
    {
        Ranged,
        Malee
    };
    public enum Effects
    {
        None,
        Freeze,
        Stun,
        Fire,
        Explode,
        Impulse,
        Poison,
        Spiky
    };
    public enum SpawnerTypes
    {
        Enemy,
        Furnature
    }
    public enum WeaponType
    {
        Ranged,
        Malee,
        Placeable,
        Projectile
    };
    public enum Weapon
    {
        None,
        Mine,
        Revolver,
        Pistol,
        ThrowableGenade,
        SMG,
        Sniper,
        Shotgun,
        AR,
        Bat,
        Boomerang,
        Chompers,
        RocketLauncher
    };
    public static Dictionary<int, Weapon> curWeapon = new() { { 0, Weapon.Mine} };
    public static List<Weapon> inventory = new() { Weapon.Mine, Weapon.None, Weapon.None, Weapon.None, Weapon.None, Weapon.None, Weapon.None, Weapon.None };
    public static bool chompersAreAttacking = false;
    public static KeyCode attackKey;
    public static KeyCode forwardKey;
    public static KeyCode backwardKey;
    public static KeyCode leftKey;
    public static KeyCode rightKey;
    public static KeyCode jumpKey;
    public static KeyCode changeHandKey;
}

