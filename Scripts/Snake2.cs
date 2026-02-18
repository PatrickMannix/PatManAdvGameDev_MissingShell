Using UnityEngine;

public class Snake2 : Enemy
{
    public float range = 5;

    public LayerMask playerLayer;
    
    private void Update()
    {
        if (PlayerDetected())
        {
            moveSpeed = 0;
            Debug.Log("Player Detected");
        }

        Debug.DrawRay(transform.position, new Vector3(direction, 0,0) * range. Color.red);
    }
    public void OnCollisionEnter2d(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            direction *= -1;
        }
    }
    
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction * moveSpeed * Time.deltaTime,rb. linearVelocity.y);
    }

    private bool PlayerDetected()
    {
        Vector2 dir = new Vector2(direction, 0);
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.positon, direction, range, playerLayer);
        
        return hit;
    }
}
