using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PurpleCable;

public class GameManager : Singleton<GameManager>
{
    public static int WaterTankCapacity { get; private set; }
    public static int WaterNeededToGrow { get; private set; }
    public static int GrowthStageCount { get; private set; }
    public static float WitherDelay { get; private set; }
    public static int MaxHumidity { get; private set; }

    private void Awake()
    {
        WaterTankCapacity = PlayerPrefs.GetInt("WaterTankCapacity", 3);
        WaterNeededToGrow = PlayerPrefs.GetInt("WaterNeededToGrow", 3);
        GrowthStageCount = PlayerPrefs.GetInt("GrowthStageCount", 3);
        WitherDelay = PlayerPrefs.GetFloat("WitherDelay", 10f);
        MaxHumidity = PlayerPrefs.GetInt("MaxHumidity", 3);
    }

    protected override void Start()
    {
        base.Start();

        ScoreManager.ResetScore();
    }

    public void Win()
    {
        ScoreManager.SetHighScore();

        StartCoroutine(MainMenu.GoToScene("Win"));
    }

    public void GameOver()
    {
        ScoreManager.SetHighScore();

        StartCoroutine(MainMenu.GoToScene("GameOver"));
    }
}
