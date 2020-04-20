using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] bool IsLeft = false;

    [SerializeField] float StartDelay = 0f;
    [SerializeField] float SpawnDelay = 4f;

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
        if (spawnQueue.Count == 0)
            FillSpawnQueue();

        Spawnable spawnable = SpawnablePools[spawnQueue.Dequeue()].GetItem();
        spawnable.transform.position = transform.position;
        spawnable.SetDirection(IsLeft);

        _timeLeft = Random.Range(SpawnDelay - 0.1f, SpawnDelay);
    }

    private Queue<int> spawnQueue = new Queue<int>();

    private void FillSpawnQueue()
    {
        List<int> bag = new List<int>();

        for (int i = 0; i < SpawnablePools.Length; i++)
        {
            bag.Add(i);
        }

        var rnd = new System.Random();

        bag = bag.OrderBy(x => rnd.Next()).ToList();

        for (int i = 0; i < bag.Count; i++)
        {
            spawnQueue.Enqueue(bag[i]);
        }
    }
}
