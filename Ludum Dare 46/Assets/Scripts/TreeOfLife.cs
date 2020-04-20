using PurpleCable;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TreeOfLife : MonoBehaviour
{
    [SerializeField] AudioClip WaterSound = null;
    [SerializeField] AudioClip GrowSound = null;
    [SerializeField] AudioClip WitherSound = null;

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
        if (!enabled)
            return;

        WaterSound.Play();

        if (_currentHumidity < GameManager.MaxHumidity)
        {
            _currentHumidity++;

            GrowthStages[_growthStage].SetHumididy(_currentHumidity);

            return;
        }

        Grow();
    }

    public void Grow()
    {
        if (!enabled)
            return;

        GrowSound.Play();

        for (int i = 0; i < GrowthStages.Length; i++)
        {
            GrowthStages[i].gameObject.SetActive(false);
        }

        _growthStage++;

        if (_growthStage >= GrowthStages.Length)
        {
            GrowthStages.Last().gameObject.SetActive(true);

            GrowthStages.Last().SetHumididy(GameManager.MaxHumidity);

            StartCoroutine(GameManager.Win());

            enabled = false;
            return;
        }

        GrowthStages[_growthStage].gameObject.SetActive(true);

        Wither();
    }

    public void Wither()
    {
        if (!enabled)
            return;

        WitherSound.Play();

        _currentHumidity--;

        GrowthStages[_growthStage].SetHumididy(_currentHumidity);

        if (_currentHumidity < 0)
        {
            StartCoroutine(GameManager.GameOver());

            enabled = false;
            return;
        }

        _witherTimer = GameManager.WitherDelay;
    }
}
