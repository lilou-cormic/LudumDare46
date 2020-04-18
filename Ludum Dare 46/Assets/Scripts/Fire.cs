using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Spawnable
{
    protected override void OnPickup(Collider2D collision)
    {
        collision.GetComponent<Tree>()?.Wither();
    }
}
