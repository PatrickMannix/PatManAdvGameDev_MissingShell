Using UnityEngine;

public class Snake1 : Enemy
{
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction * moveSpeed * Time.deltaTime,rb. linearVelocity.y);
    }
}
