using PurpleCable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnablePool<TSpawnable> : Pool<TSpawnable>, ISpawnablePool
    where TSpawnable : Spawnable
{
    [SerializeField] TSpawnable Prefab = null;

    [Min(0)]
    [SerializeField] int _SpawnWeight = 1;
    public int SpawnWeight => _SpawnWeight;

    Spawnable ISpawnablePool.GetItem() => GetItem();

    protected override TSpawnable CreateItem()
    {
        return Instantiate(Prefab, transform);
    }
}

public interface ISpawnablePool
{
    int SpawnWeight { get; }

    Spawnable GetItem();
}
