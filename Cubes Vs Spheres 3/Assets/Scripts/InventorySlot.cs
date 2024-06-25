using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public GameObject mineImage;
    public GameObject chompersImage;
    public int slotNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.inventory[slotNumber] == Globals.Weapon.Mine)
        {
            mineImage.SetActive(true);
            chompersImage.SetActive(false);
        }
        else if (Globals.inventory[slotNumber] == Globals.Weapon.Chompers)
        {
            mineImage.SetActive(false);
            chompersImage.SetActive(true);
        }
        else
        {
            mineImage.SetActive(false);
            chompersImage.SetActive(false);
        }
    }
}
