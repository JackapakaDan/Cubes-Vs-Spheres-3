using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    protected GameObject player;
    protected GameObject[] bandages;
    protected GameObject[] water;
    protected GameObject[] antidote;
    protected int rangeToMaybeSpawnWeapon;
    protected int rangeToSpawnWeapon;
    public float speed;
    protected Rigidbody rb;
    protected bool canMove = true;
    protected bool flattened = false;
    protected bool onFire = false;
    protected bool poisoned = false;
    protected bool bleeding = false;
    protected int level;
    protected bool stunned = false;
    [SerializeField]
    GameObject inactiveWeapon;
   
    public Globals.EnemyType type;
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public virtual void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bandages = GameObject.FindGameObjectsWithTag("Bandages");
        water = GameObject.FindGameObjectsWithTag("Water");
        antidote = GameObject.FindGameObjectsWithTag("Antidote");
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if(player != null && canMove && !stunned && (!bleeding || bandages == null||(onFire && water == null)) && (!poisoned || antidote == null) && (!onFire || water == null))
        {
            MoveTo(player);
        }
        if(bandages != null && canMove && !stunned && bleeding && !onFire && (!poisoned || antidote == null))
        {
            MoveTo(bandages[0]);
        }
        if (water != null && canMove && !stunned && onFire)
        {
            MoveTo(water[0]);
        }
        if (antidote != null && canMove && !stunned && (!onFire || water == null) && poisoned)
        {
            MoveTo(antidote[0]);
        }
    }

    public virtual void MoveTo(GameObject target)
    {
        transform.LookAt(target.transform.position);
        Vector3 pos = target.transform.position;
        if (transform.position != pos)
        {
            Vector3 q = Vector3.MoveTowards(transform.position, pos, speed);
            rb.MovePosition(q);
        }
    }
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player")&&(type != Globals.EnemyType.Malee || !Globals.curWeapon.ContainsValue(Globals.Weapon.Chompers)||Globals.chompersAreAttacking == false))
        {

            Destroy(collision.collider.gameObject);
        }

    }
    public void OnDestroy()
    {
        int rand = Random.Range(0, rangeToMaybeSpawnWeapon);
        if (rand < rangeToSpawnWeapon)
        {

            Vector3 weaponPos = transform.position;
            Instantiate(inactiveWeapon, weaponPos, Quaternion.identity);
        }
    }
}
