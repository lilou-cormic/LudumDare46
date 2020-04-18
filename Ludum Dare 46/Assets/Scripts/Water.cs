using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PurpleCable;

public class Water : Spawnable
{
    protected override void OnPickup(Collider2D collision)
    {
        collision.GetComponent<WaterTank>()?.Fill();

        collision.GetComponent<Tree>()?.Water();
    }
}
