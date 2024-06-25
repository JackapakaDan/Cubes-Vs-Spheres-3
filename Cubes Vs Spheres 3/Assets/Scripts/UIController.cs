using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject curWeapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (Globals.curWeapon.First().Key)
        {
            case 0:
                curWeapon.transform.position = new Vector3(400f, transform.position.y, transform.position.z);
                break;
            case 1:
                curWeapon.transform.position = new Vector3(540f, transform.position.y, transform.position.z);
                break;
            case 2:
                curWeapon.transform.position = new Vector3(680f, transform.position.y, transform.position.z);
                break;
            case 3:
                curWeapon.transform.position = new Vector3(820f, transform.position.y, transform.position.z);
                break;
            case 4:
                curWeapon.transform.position = new Vector3(960f, transform.position.y, transform.position.z);
                break;
            case 5:
                curWeapon.transform.position = new Vector3(1100f, transform.position.y, transform.position.z);
                break;
            case 6:
                curWeapon.transform.position = new Vector3(1240f, transform.position.y, transform.position.z);
                break;
            case 7:
                curWeapon.transform.position = new Vector3(1380f, transform.position.y, transform.position.z);
                break;

        }


    }
}
