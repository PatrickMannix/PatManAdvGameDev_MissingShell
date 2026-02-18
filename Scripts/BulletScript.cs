Using UnityEngine;

public class BulletScript : MonoBehavior
{
    [HideInInspector]public float speed;
    [HideInInspector]public Vector2 direction;
    private Rigidbody2D rb;

    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction * speed * Time.deltaTime, rb.linearVelocity.y);
    }

    public void OnCollisionEnter2d(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){ return; }
        
        Destroy(gameObject);
    }
}
