using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PurpleCable;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] AudioClip WinSound = null;
    [SerializeField] AudioClip GameOverSound = null;

    public static int WaterTankCapacity { get; private set; }

    public static float WitherDelay { get; private set; }
    public static int MaxHumidity { get; private set; }

    public static float SpawnableSpeed { get; private set; }

    private void Awake()
    {
        WaterTankCapacity = PlayerPrefs.GetInt("WaterTankCapacity", 3);
        WitherDelay = PlayerPrefs.GetFloat("WitherDelay", 10f);
        MaxHumidity = PlayerPrefs.GetInt("MaxHumidity", 2);
        SpawnableSpeed = PlayerPrefs.GetFloat("SpawnableSpeed", 2.5f);
    }

    protected override void Start()
    {
        base.Start();

        ScoreManager.ResetScore();
    }

    public static IEnumerator Win()
    {
        ScoreManager.SetHighScore();

        Instance.WinSound.Play();

        yield return new WaitForSeconds(2f);

        yield return MainMenu.GoToScene("Win");
    }

    public static IEnumerator GameOver()
    {
        ScoreManager.SetHighScore();

        Instance.GameOverSound.Play();

        yield return new WaitForSeconds(1f);

        yield return MainMenu.GoToScene("GameOver");
    }
}
