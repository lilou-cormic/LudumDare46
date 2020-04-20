using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GrowthStage : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] SpriteRenderers = null;

    internal void SetHumididy(int currentHumidity)
    {
        if (currentHumidity >= 0)
        {
            for (int i = 0; i < SpriteRenderers.Length; i++)
            {
                SpriteRenderers[i].gameObject.SetActive(false);
            }

            SpriteRenderers.ElementAtOrDefault(currentHumidity)?.gameObject.SetActive(true);
        }

        gameObject.StartAnimations();
    }
}
