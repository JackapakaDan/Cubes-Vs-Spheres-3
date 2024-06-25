using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    int mineAmmo = 10;
    public float speed;
    public KeyCode jumpKey;
    public KeyCode forwardKey;
    public KeyCode backwardKey;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public GameObject face;
    public GameObject chompers;
    public KeyCode changeHandKey;

    [SerializeField]
    GameObject minePrefab;
    public KeyCode attackKey;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        chompers.SetActive(false);
        //StartCoroutine(WaitForChangeHand());
    }
    /*
    IEnumerator WaitForChangeHand()
    {
        while(true)
        {
            if (Input.GetKey(changeHandKey))
            {
                Debug.Log(Globals.curWeapon.Values.First());
                if (Globals.curWeapon.ContainsKey(Globals.inventory.Count - 1))
                {
                    Globals.curWeapon = new Dictionary<int, Globals.Weapon> { { 0, Globals.inventory[0] } };
                }
                else
                {
                    Globals.curWeapon = new Dictionary<int, Globals.Weapon> { { Globals.curWeapon.Keys.First() + 1, Globals.inventory[Globals.curWeapon.Keys.First() + 1] } };
                }

            }
            yield return new WaitForSeconds(1);
        }
    }
    */
    // Update is called once per frame
    private void Update()
    {

        if (Input.GetKeyUp(changeHandKey))
        {

            if (Globals.curWeapon.ContainsKey(Globals.inventory.Count - 1))
            {
                Globals.curWeapon = new Dictionary<int, Globals.Weapon> { { 0, Globals.inventory[0] } };
            }
            else
            {
                Globals.curWeapon = new Dictionary<int, Globals.Weapon> { { Globals.curWeapon.Keys.First() + 1, Globals.inventory[Globals.curWeapon.Keys.First() + 1] } };
            }
            Debug.Log(Globals.curWeapon.Values.First());
        }

        chompers.SetActive(Globals.curWeapon.ContainsValue(Globals.Weapon.Chompers));
        this.GetComponent<PlayerChompers>().enabled = Globals.curWeapon.ContainsValue(Globals.Weapon.Chompers);
        face.SetActive(!Globals.curWeapon.ContainsValue(Globals.Weapon.Chompers));
        if (Globals.curWeapon.ContainsValue(Globals.Weapon.Mine) && mineAmmo > 0 && Input.GetKeyDown(attackKey))
        {
            mineAmmo--;
            Vector3 mine_position = transform.position;
            Instantiate(minePrefab, mine_position, Quaternion.identity);
        }
        
    }
        void FixedUpdate()
    {
        
        if (Input.GetKey(leftKey))
        {
            rb.AddForce(-transform.right*speed);
            if(!Globals.curWeapon.ContainsValue(Globals.Weapon.Chompers))
            {
                face.transform.rotation = Quaternion.Euler(90, 90, 0);
            }
            else
            {
                chompers.transform.rotation = Quaternion.Euler(90, 90, 0);
            }
        }
        if (Input.GetKey(rightKey))
        {
            rb.AddForce(transform.right * speed);
            if (!Globals.curWeapon.ContainsValue(Globals.Weapon.Chompers))
            {
                face.transform.rotation = Quaternion.Euler(90, 270, 0);
            }
            else
            {
                chompers.transform.rotation = Quaternion.Euler(90, 270, 0);
            }
        }
        if (Input.GetKey(jumpKey))
        {
            rb.AddForce(transform.up * speed);
        }
        if (Input.GetKey(forwardKey))
        {
            rb.AddForce(transform.forward * speed);
            if (!Globals.curWeapon.ContainsValue(Globals.Weapon.Chompers))
            {
                face.transform.rotation = Quaternion.Euler(90, 180, 0);
            }
            else
            {
                chompers.transform.rotation = Quaternion.Euler(90, 180, 0);
            }
        }
        if (Input.GetKey(backwardKey))
        {
            rb.AddForce(-transform.forward * speed);
            if (!Globals.curWeapon.ContainsValue(Globals.Weapon.Chompers))
            {
                face.transform.rotation = Quaternion.Euler(90, 0, 0);
            }
            else
            {
                chompers.transform.rotation = Quaternion.Euler(90, 0, 0);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Furnature"))
        {
            Destroy(collision.collider.gameObject);
        }
        if(collision.collider.CompareTag("Chompers"))
        {
            if(Globals.inventory.Contains(Globals.Weapon.None))
            {
                Destroy(collision.collider.gameObject);
                for(int i = 0;i<Globals.inventory.Count;i++)
                {
                    if (Globals.inventory[i]==Globals.Weapon.None)
                    {
                        Globals.inventory[i] = Globals.Weapon.Chompers;
                        break;
                    }
                }

            }

        }
    }

}
