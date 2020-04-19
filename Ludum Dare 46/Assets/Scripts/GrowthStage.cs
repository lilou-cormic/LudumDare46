using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthStage : MonoBehaviour
{
    [SerializeField] SpriteRenderer SpriteRenderer = null;

    internal void SetHumididy(int currentHumidity)
    {
        switch (currentHumidity)
        {
            case 0:
                SpriteRenderer.color = Color.red;
                break;

            case 1:
                SpriteRenderer.color = Color.gray;
                break;

            case 2:
            default:
                SpriteRenderer.color = Color.white;
                break;
        }
    }
}
