using UnityEngine;

public static class MoveController
{
    public static void Move(Transform transform, SpriteRenderer spriteRenderer, float horizontal, float movementSpeed)
    {
        if (horizontal < -0.01)
            spriteRenderer.flipX = false;
        else if (horizontal > 0.01)
            spriteRenderer.flipX = true;

        //rb.AddForce(horizontal * Vector2.right * Time.deltaTime * speed, ForceMode2D.Impulse);
        transform.Translate(horizontal * movementSpeed * Time.deltaTime, 0, 0, transform);
    }
}