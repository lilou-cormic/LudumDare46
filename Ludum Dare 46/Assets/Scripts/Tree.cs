using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private int _growthStage = 0;

    private int _currentWaterLevel = 0;

    private int _currentHumidity = 2;

    private float _witherTimer = 0f;

    private void Start()
    {
        _witherTimer = GameManager.WitherDelay;
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

        _currentWaterLevel++;

        if (_currentWaterLevel >= GameManager.WaterNeededToGrow)
            Grow();
    }

    public void Grow()
    {
        _growthStage++;

        if (_growthStage >= GameManager.GrowthStageCount)
        {
            GameManager.Instance.Win();
            return;
        }

        _currentWaterLevel = 0;
    }

    public void Wither()
    {
        _currentHumidity--;

        if (_currentHumidity <= 0)
        {
            GameManager.Instance.GameOver();
            return;
        }

        _witherTimer = GameManager.WitherDelay;
    }
}
