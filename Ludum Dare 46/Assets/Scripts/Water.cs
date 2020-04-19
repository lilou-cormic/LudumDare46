using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PurpleCable;

public class Water : Spawnable
{ 
    protected override void OnPickup(Collider2D collision)
    {
        base.OnPickup(collision);

        collision.GetComponent<WaterTank>()?.Fill();

        collision.GetComponentInParent<TreeOfLife>()?.Water();
    }
}
