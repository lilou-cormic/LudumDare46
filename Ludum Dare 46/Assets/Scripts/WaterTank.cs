using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTank : MonoBehaviour
{
    private int _waterLevel;

    public event Action<int> WaterLevelChanged;

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
        WaterLevelChanged?.Invoke(_waterLevel);
    }
}
