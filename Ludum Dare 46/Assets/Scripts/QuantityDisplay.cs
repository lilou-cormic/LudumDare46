using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantityDisplay : MonoBehaviour
{
    [SerializeField] OnOffIndicator OnOffIndicatorPrefab = null;

    [SerializeField] bool IsRightToLeft = false;

    private OnOffIndicator[] Indicators;

    public void SetMaxQuantity(int maxQuantity)
    {
        int direction = (IsRightToLeft ? -1 : 1);

        List<OnOffIndicator> list = new List<OnOffIndicator>();

        for (int i = 0; i < maxQuantity; i++)
        {
            var indicator = Instantiate(OnOffIndicatorPrefab, transform);
            indicator.transform.localPosition = new Vector3(i * direction, 0);

            list.Add(indicator);
        }

        Indicators = list.ToArray();
    }

    public void SetQuantity(int quantity)
    {
        for (int i = 0; i < Indicators.Length; i++)
        {
            Indicators[i].SetState(i < quantity);
        }
    }
}
