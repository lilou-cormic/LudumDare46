using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TreeOfLife : MonoBehaviour
{
    private int _growthStage = 0;

    private int _currentHumidity = 1;

    private float _witherTimer = 0f;

    private GrowthStage[] GrowthStages = null;

    private void Awake()
    {
        GrowthStages = GetComponentsInChildren<GrowthStage>(includeInactive: true);

        GrowthStages[0].gameObject.SetActive(true);

        for (int i = 1; i < GrowthStages.Length; i++)
        {
            GrowthStages[i].gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        _witherTimer = GameManager.WitherDelay;

        GrowthStages[_growthStage].SetHumididy(_currentHumidity);
    }

    private void Update()
    {
        _witherTimer -= Time.deltaTime;

        if (_witherTimer <= 0)
        {
            Wither();
            return;
        }
    }

    public void Water()
    {
        if (_currentHumidity < GameManager.MaxHumidity)
        {
            _currentHumidity++;
            return;
        }

        Grow();
    }

    public void Grow()
    {
        GrowthStages[_growthStage++].gameObject.SetActive(false);
        GrowthStages[_growthStage].gameObject.SetActive(true);

        if (_growthStage >= GrowthStages.Length - 1)
        {
            GrowthStages.Last().gameObject.SetActive(true);

            StartCoroutine(GameManager.Win());

            enabled = false;
            return;
        }

        Wither();
    }

    public void Wither()
    {
        _currentHumidity--;

        if (_currentHumidity <= 0)
        {
            StartCoroutine(GameManager.GameOver());

            enabled = false;
            return;
        }

        GrowthStages[_growthStage].SetHumididy(_currentHumidity);

        _witherTimer = GameManager.WitherDelay;
    }
}
