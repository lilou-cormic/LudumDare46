using PurpleCable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private static Player _instance;

    private Rigidbody2D rb;

    private WaterTank waterTank;

    [SerializeField] Animator Animator = null;

    [SerializeField] SpriteRenderer SpriteRenderer = null;

    [SerializeField] AudioClip JumpSound = null;

    [SerializeField] GameObject WaterProjectile = null;

    public float MovementSpeed = 3;
    public float JumpForce = 400;

    private void Awake()
    {
        _instance = this;

        rb = GetComponent<Rigidbody2D>();

        waterTank = GetComponent<WaterTank>();

        waterTank.WaterLevelChanged += Player_WaterLevelChanged;
    }

    private void Start()
    {
        //HACK
        GameManager.IsDone = false;
        ScoreManager.ResetScore();
    }

    private void OnDestroy()
    {
        waterTank.WaterLevelChanged -= Player_WaterLevelChanged;
    }

    private void Update()
    {
        if (GetY() < -10)
        {
            StartCoroutine(GameManager.GameOver());
            enabled = false;
        }

        float horizontal = Input.GetAxis("Horizontal");

        MoveController.Move(transform, horizontal, MovementSpeed);

        if (Animator.isActiveAndEnabled)
            Animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (Input.GetButtonDown("Jump"))
            Jump();

        if (Animator.isActiveAndEnabled)
        {
            if (Mathf.Abs(rb.velocity.y) <= 0.01)
                Animator.SetBool("IsJumping", false);
        }
    }

    private void Jump()
    {
        if (rb.velocity.y != 0)
            return;

        JumpSound.Play();

        if (Animator.isActiveAndEnabled)
            Animator.SetBool("IsJumping", true);

        rb.AddForce(Vector2.up * Time.deltaTime * JumpForce, ForceMode2D.Impulse);
    }

    public static void SetPosition(Vector3 value)
    {
        _instance.transform.position = value;
    }

    public static bool IsGoingUp()
    {
        return _instance.rb.velocity.y > 0.01;
    }

    public static float GetY()
    {
        return _instance.transform.position.y;
    }

    private void Player_WaterLevelChanged(int waterLevel)
    {
        WaterProjectile.SetActive(waterLevel > 0);
    }
}
