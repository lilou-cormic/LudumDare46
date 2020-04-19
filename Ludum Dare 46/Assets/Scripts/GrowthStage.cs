using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthStage : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] SpriteRenderers = null;

    internal void SetHumididy(int currentHumidity)
    {
        for (int i = 0; i < SpriteRenderers.Length; i++)
        {
            SpriteRenderers[i].gameObject.SetActive(false);
        }

        SpriteRenderers[currentHumidity - 1].gameObject.SetActive(true);
    }
}
