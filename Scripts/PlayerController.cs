Using UnityEngine;

public class PlayerController : MonoBehavior
{
    [Header("Movement")]
    public float movementSpeed = 160;
    public float jumpSpeed = 6;

    public KeyCode jumpKey;

    public float xMove;

    private Rigidbody2D rb;

    private bool jumpFlag;
    public LayerMask groundLayer;

    private float facingDirection;

    
    [Header("Melee")]
    public GameObject meleeAttackObj;
    public float meleeDirection;
    private float timeElaspedSinceMelee = 0;
    private bool meleeTriggered = false;

    private float attackPointX = 0.7;

    [Header("Melee")]
    public GameObject Prefab;
    public float bulletSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingDirection = 1;
    }

    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");

        if (xMove != 0)
        {
            facingDirection = xMove;
        }
        if (Input.GetKeyDown(jumpKey) && IsGround())
        {
            jumpFlag = true;
        }

        if (GetMouseButtonDown(0) && !meleeTriggered)
        {
            MeleeAttack();
        }

        if (GetMouseButtonDown(1))
        {
            rangedAttack();
        }

        MeleeAttackTimer();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(xMove * movementSpeed * Time.deltaTime, rb.linearVelocity.y);

        if (jumpFlag)
        {
            rb.linearVelocityY = jumpSpeed;
            jumpFlag = false;
        }
    }

    private void MeleeAttack()
    {
        meleeTriggered = true;
        meleeAttackObj.SetActive(true);
        meleeAttackObj.localPosition = new Vector3(facingDirection * attackPointX, meleeAttackObj.localPosition.y, 0);
    }

    private void rangedAttack()
    {
        Vector3 pos = new Vector3(transform.position.x + attackPointX * facingDirection, transform.position.y, 0);
        gameObject bullet = instantiate(bulletPrefab, pos, Quaterion.identity);
        bullet.GetComponent<BulletScript>().direction = facingDirection;
        bullet.GetComponent<BulletScript>().speed = bulletSpeed;
    }

    private void MeleeAttackTimer()
    {
        if (meleeTriggered)
        {
            if (timeElaspedSinceMelee < meleeDirection)
            {
                timeElaspedSinceMelee += time.deltaTime;
            }
            else
            {
                meleeAttackObj.gameObject.SetActive(false);
                timeElaspedSinceMelee = 0;
                meleeTriggered = false;
            }
        }
    }

    private bool IsGround()
    {
        float radius = GetComponent<Coillder2D>().bounds.extents.x;
        float distance = GetComponent<Coillder2D>().bounds.extents.y;
        return Physics2D.CircleCast(transform.position, radius, Vector2.down, distance, groundLayer);
    }
}
