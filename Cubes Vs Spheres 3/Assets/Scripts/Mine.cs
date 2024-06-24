using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Weapon
{
    Animator animator;
    public float explosionTime;
    public AnimationClip anim;
    public GameObject topMine;
    public GameObject bottomMine;
    bool playerCanTrigger = false;
    GameObject deathRad;
    [SerializeField]
    GameObject deathRadiusPrefab;

    public override void Start()
    {
        animator = topMine.GetComponent<Animator>();
        animator.speed = 0;
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        isPlayer = true;
        durability = 1;
        range = 2;
        damage = 10;
        maxAmmo = 10;
        curAmmo = 10;
        cost = 0;
        reloadSpeed = 0;
        curEffect =  Effects.None;
        type = WeaponType.Placeable;
        StartCoroutine(WaitForDeath());
        StartCoroutine(WaitForPlayer());
    }
    IEnumerator WaitForPlayer()
    {
        yield return new WaitForSeconds(3);
        playerCanTrigger = true;
    }
    IEnumerator WaitForDeath()
    {
        while (true)
        {
            if (animator.speed == 1)
            {
                yield return new WaitForSeconds(0.1f);
                Vector3 deathRadPos = this.transform.position;
                deathRadiusPrefab.transform.localScale = new Vector3(range, 0.1f, range);
                deathRad = Instantiate(deathRadiusPrefab, deathRadPos, Quaternion.identity);
                topMine.GetComponent<Renderer>().enabled = false;
                bottomMine.GetComponent<Renderer>().enabled = false;
                yield return new WaitForSeconds(explosionTime);

                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in enemies)
                {
                    float distance = Vector3.Distance(this.transform.position, enemy.transform.position);
                    if (distance <= range)
                    {
                        //Change to remove health
                        Destroy(enemy);
                    }
                }
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                foreach (GameObject player in players)
                {
                    float distance = Vector3.Distance(this.transform.position, player.transform.position);
                    if (distance <= range)
                    {
                        //Change to remove health
                        Destroy(player);
                    }
                }
                Destroy(deathRad);
                Destroy(this.gameObject);
            }
            yield return new WaitForSeconds(1);
        }

    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy")||(collision.collider.CompareTag("Player")&&playerCanTrigger))
        {
            animator.speed = 1;
           
        }
    }
    
    
}
