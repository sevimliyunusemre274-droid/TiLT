using UnityEngine;

public class Swordman : PlayerController
{
    private void Start()
    {
        m_CapsulleCollider = GetComponent<CapsuleCollider2D>();
        m_Anim = transform.Find("model").GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isClimbing)
        {
            ClimbLadder();
            return;
        }

        checkInput();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") ||
            collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
            currentJumpCount = 0;
            OnceJumpRayCheck = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") ||
            collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = false;
        }
    }

    public void checkInput()
    {
        // INPUT
        if (JoystickMove.Instance != null)
            m_MoveX = JoystickMove.Instance.Horizontal;
        else
            m_MoveX = Input.GetAxis("Horizontal");

        // ANİMASYON
        if (Mathf.Abs(m_MoveX) < 0.01f)
        {
            if (isGrounded && !OnceJumpRayCheck)
                m_Anim.Play("Idle");
        }
        else
        {
            m_Anim.Play("Run");
        }

        // HAREKET (Rigidbody)
        m_rigidbody.linearVelocity = new Vector2(
            m_MoveX * MoveSpeed,
            m_rigidbody.linearVelocity.y
        );

        // YÖN
        if (Mathf.Abs(m_MoveX) > 0.01f)
            Flip(m_MoveX);

        // ZIPLAMA
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentJumpCount < JumpCount)
                prefromJump();
        }
    }


    protected override void LandingEvent()
    {
        currentJumpCount = 0;
        isGrounded = true;
        OnceJumpRayCheck = false;
        m_Anim.Play("Idle");
    }
}
