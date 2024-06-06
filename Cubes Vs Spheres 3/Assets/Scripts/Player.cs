using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public KeyCode jumpKey;
    public KeyCode forwardKey;
    public KeyCode backwardKey;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public GameObject face;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(leftKey))
        {
            rb.AddForce(-transform.right*speed);
            face.transform.rotation = Quaternion.Euler(90, 90, 0);
        }
        if (Input.GetKey(rightKey))
        {
            rb.AddForce(transform.right * speed);
            face.transform.rotation = Quaternion.Euler(90, 270, 0);
        }
        if (Input.GetKey(jumpKey))
        {
            rb.AddForce(transform.up * speed);
        }
        if (Input.GetKey(forwardKey))
        {
            rb.AddForce(transform.forward * speed);
            face.transform.rotation = Quaternion.Euler(90, 180, 0);
        }
        if (Input.GetKey(backwardKey))
        {
            rb.AddForce(-transform.forward * speed);
            face.transform.rotation = Quaternion.Euler(90, 0, 0);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Furnature"))
        {
            Destroy(collision.collider.gameObject);
        }
    }

}
