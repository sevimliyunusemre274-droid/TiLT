using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform leftPoint;
    public Transform rightPoint;

    private Rigidbody2D rb;
    private Animator anim;
    private bool movingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Patrol();
    }

    void Patrol()
    {
        float dir = movingRight ? 1 : -1;
        rb.linearVelocity = new Vector2(dir * moveSpeed, rb.linearVelocity.y);

        anim.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));

        transform.localScale = new Vector3(dir, 1, 1);

        if (movingRight && transform.position.x >= rightPoint.position.x)
            movingRight = false;
        else if (!movingRight && transform.position.x <= leftPoint.position.x)
            movingRight = true;
    }
}
