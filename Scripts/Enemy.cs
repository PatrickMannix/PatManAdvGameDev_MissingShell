Using UnityEngine;

public class Enemy : MonoBehavior
{
    public float moveSpeed;
    public int hp;
    [HideInInspector]public float direction;
    
    protected Rigidbody2D rb;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2d>();
    }

    protected virtual void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction * moveSpeed * Time.deltaTime,rb. linearVelocity.y);
    }

    protected virtual public void OnCollisionEnter2d(Collision2D collision)
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
}
