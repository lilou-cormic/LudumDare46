using PurpleCable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Spawnable
{
    protected override void OnPickup(Collider2D collision)
    {
        if (GameManager.IsDone)
            return;

        base.OnPickup(collision);

        var tree = collision.GetComponentInParent<TreeOfLife>();
        if (tree != null)
        {
            if (ScoreManager.Score > 50)
                ScoreManager.AddPoints(-50);
            else
                ScoreManager.SetPoints(0);

            tree.Wither();
        }

        var waterTank = collision.GetComponentInParent<WaterTank>();
        if (waterTank != null)
        {
            ScoreManager.AddPoints(100);

            waterTank.Use();
        }
    }
}
