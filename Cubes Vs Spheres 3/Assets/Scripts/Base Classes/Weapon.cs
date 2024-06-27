using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    protected float range;
    protected int durability;
    protected int damage;
    protected int curAmmo;
    protected int maxAmmo;
    protected int reloadSpeed;
    protected int cost;
    protected bool isPlayer;
    protected bool effectDuration;
    protected bool isAttacking = false;
    
    protected Globals.Effects curEffect;

    
    public Globals.WeaponType type;
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(durability == 0)
        {
            Destroy(gameObject);
        }
        if(Input.GetKey(Globals.attackKey))
        {
            isAttacking = true;
        }
    }
    public virtual bool CanAttack()
    {
        if(type == Globals.WeaponType.Ranged|| type == Globals.WeaponType.Placeable)
        {
            return (0 < curAmmo);
        }
        return true;
    }
    public virtual void GetMoreAmmo(int amount)
    {
        if(amount+curAmmo >= maxAmmo)
        {
            curAmmo = maxAmmo;
        }
        else
        {
            curAmmo += amount;
        }
    }
}
