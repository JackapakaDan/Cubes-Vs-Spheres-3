using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerChompers : Weapon
{
    public GameObject bottomTeeth;
    Animator anim;
    bool isPlaying = false;
    BoxCollider col;
    public override void Start()
    {
        range = 1.5f;
        col = GetComponent<BoxCollider>();
        col.size = new Vector3(range, range, range);
        durability = 10;
        damage = 20;
        isPlayer = true;
        anim = bottomTeeth.GetComponent<Animator>();
        anim.speed = 0;
        StartCoroutine(WaitForEndAnimation());
    }
    IEnumerator WaitForEndAnimation()
    {
        while (true)
        {
            if (anim != null && Globals.chompersAreAttacking && !isPlaying)
            {
                isPlaying = true;
                anim.speed = 1;
                yield return new WaitForSeconds(1f);
                anim.speed = 0;
                isPlaying = false;
                Globals.chompersAreAttacking = false;
                //anim.Play("Player Chompers Animation", 0, 0.25f);

            }
            anim.speed = 0;
            yield return new WaitForEndOfFrame();
        }
    }
    public override void Update()
    {
        base.Update();
        if(Input.GetKey(attackKey) && Globals.curWeapon.ContainsValue(Globals.Weapon.Chompers))
        {
            Globals.chompersAreAttacking = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Enemy")&&Globals.chompersAreAttacking)
        {
            Destroy(collision.gameObject);
            durability -= 1;
        }
    }
}
