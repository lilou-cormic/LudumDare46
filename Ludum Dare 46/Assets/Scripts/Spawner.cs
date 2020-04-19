using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] bool IsLeft = false;

    [SerializeField] float StartDelay = 0f;
    [SerializeField] float SpawnDelay = 2f;

    private ISpawnablePool[] SpawnablePools = null;

    private float _timeLeft = 0f;

    private void Awake()
    {
        List<ISpawnablePool> list = new List<ISpawnablePool>();

        foreach (var pool in GetComponentsInChildren<ISpawnablePool>())
        {
            for (int i = 0; i < pool.SpawnWeight; i++)
            {
                list.Add(pool);
            }
        }

        SpawnablePools = list.ToArray();

        InvokeRepeating("Spawn", StartDelay, SpawnDelay);
    }

    private void Spawn()
    {
        Spawnable spawnable = SpawnablePools.GetRandom().GetItem();
        spawnable.transform.position = transform.position;
        spawnable.SetDirection(IsLeft);
        _timeLeft = SpawnDelay;
    }
}
