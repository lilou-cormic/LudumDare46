using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTank : MonoBehaviour
{
    [SerializeField] QuantityDisplay WaterTankDisplay = null;

    private int _waterLevel;

    public event Action<int> WaterLevelChanged;

    private void Start()
    {
        WaterTankDisplay.SetMaxQuantity(GameManager.WaterTankCapacity);

        Fill();
    }

    public bool Use()
    {
        if (_waterLevel == 0)
            return false;

        _waterLevel--;
        OnWaterLevelChanged();

        return true;
    }

    public void Fill()
    {
        if (_waterLevel == GameManager.WaterTankCapacity)
            return;

        _waterLevel++;
        OnWaterLevelChanged();
    }

    private void OnWaterLevelChanged()
    {
        WaterTankDisplay.SetQuantity(_waterLevel);
        WaterLevelChanged?.Invoke(_waterLevel);
    }
}
