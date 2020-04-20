using PurpleCable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Spawnable : Item, IPoolable
{
    private Rigidbody2D rb = null;

    [SerializeField] SpriteRenderer SpriteRenderer = null;

    private int direction = 1;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected Spawnable()
        : base()
    { }


    private void Update()
    {
        if (IsTaken)
            return;

        MoveController.Move(transform, direction, GameManager.SpawnableSpeed);
    }

    protected override bool CanPickup(Collider2D collision)
    {
        return !collision.gameObject.CompareTag("Level");
    }

    protected override void OnPickup(Collider2D collision)
    {
        rb.velocity = Vector3.zero;
    }

    public void UTurn()
    {
        direction *= -1;
    }

    public void SetDirection(bool isLeft)
    {
        direction = (isLeft ? -1 : 1);
    }

    #region IPoolable

    public bool IsInUse { get; private set; } = true;

    public void SetAsAvailable()
    {
        IsInUse = false;
        gameObject.SetActive(false);
        Reset();
    }

    public void SetAsInUse()
    {
        IsInUse = true;
        gameObject.SetActive(true);
    }

    #endregion
}
