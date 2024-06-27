using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    protected int fireRate;
    [SerializeField]
    GameObject bullet;
   
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        StartCoroutine(WaitForBullet());

    }
    protected IEnumerator WaitForBullet()
    {
       while (true)
        {
            if(isPlayer)
            {
                if(Input.GetKey(Globals.attackKey)&& curAmmo>0)
                {
                    durability--;
                    Instantiate(bullet);
                }
            }
            else
            {
                Instantiate(bullet);
            }

            yield return new WaitForSeconds(fireRate);
        }
    }
    // Update is called once per frame
    public override void Update()
    {
        base.Update();

    }
}
