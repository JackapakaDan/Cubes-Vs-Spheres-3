using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Gun
{
    // Start is called before the first frame update
    public bool is_player;
    public override void Start()
    {
        
        base.Start();
        isPlayer = is_player;
        durability = 100;


    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

    }
}
