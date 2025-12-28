using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    public bool IsSit = false;
    public int currentJumpCount = 0;
    public bool isGrounded = false;
    public bool OnceJumpRayCheck = false;
    public bool Is_DownJump_GroundCheck = false;

    [Header("[Ladder System]")]
    public bool isNearLadder = false; // Merdiven yakınında mı?
    public bool isClimbing = false; // Merdivende tırmanıyor mu?
    public GameObject currentLadder = null; // Hangi merdiven
    public float climbSpeed = 4f; // Tırmanma hızı

    protected float m_MoveX;
    protected float m_MoveY; // Merdiven için Y hareketi
    public Rigidbody2D m_rigidbody;
    protected CapsuleCollider2D m_CapsulleCollider;
    protected Animator m_Anim;

    [Header("[Setting]")]
    public float MoveSpeed = 6;
    public int JumpCount = 2;
    public float jumpForce = 15f;

    protected void AnimUpdate()
    {
        if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                m_Anim.Play("Attack");
            }
            else
            {
                if (m_MoveX == 0)
                {
                    if (!OnceJumpRayCheck)
                        m_Anim.Play("Idle");
                }
                else
                {
                    m_Anim.Play("Run");
                }
            }
        }
    }

    protected void Flip(float dir)
    {
        if (dir > 0)
            transform.localScale = new Vector3(-1, 1, 1); // SAĞ
        else if (dir < 0)
            transform.localScale = new Vector3(1, 1, 1);  // SOL
    }



    protected void prefromJump()
    {
        m_Anim.Play("Jump");
        m_rigidbody.linearVelocity = new Vector2(m_rigidbody.linearVelocity.x, 0);
        m_rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        OnceJumpRayCheck = true;
        isGrounded = false;
        currentJumpCount++;
    }

    protected void DownJump()
    {
        if (!isGrounded) return;

        if (!Is_DownJump_GroundCheck)
        {
            m_Anim.Play("Jump");
            m_rigidbody.AddForce(-Vector2.up * 10);
            isGrounded = false;
            m_CapsulleCollider.enabled = false;
            StartCoroutine(GroundCapsulleColliderTimmerFuc());
        }
    }

    IEnumerator GroundCapsulleColliderTimmerFuc()
    {
        yield return new WaitForSeconds(0.3f);
        m_CapsulleCollider.enabled = true;
    }

    // Merdiven sistemi metodları
    public void EnterLadder()
    {
        isClimbing = true;
        m_rigidbody.gravityScale = 0; // Yerçekimini kapat
        m_rigidbody.linearVelocity = Vector2.zero; // Hareketi durdur
        currentJumpCount = 0; // Zıplama sayacını sıfırla
    }

    public void ExitLadder()
    {
        isClimbing = false;
        m_rigidbody.gravityScale = 3; // Yerçekimini aç (3 veya istediğiniz değer)
        m_rigidbody.linearVelocity = Vector2.zero; // Velocity'yi sıfırla
    }

    protected void ClimbLadder()
    {
        if (!isClimbing) return;

        float moveY = Input.GetAxis("Vertical"); // W/S veya Yukarı/Aşağı ok tuşları

        // Merdivende yukarı/aşağı hareket
        if (moveY != 0)
        {
            transform.Translate(Vector2.up * moveY * climbSpeed * Time.deltaTime);
            m_Anim.Play("Jump"); // Veya "Climb" animasyonu varsa onu kullan
        }
        else
        {
            m_Anim.Play("Idle"); // Durduğunda Idle animasyonu
        }

        // Merdivenden çıkmak için Space tuşu
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExitLadder();
            prefromJump(); // Zıpla
        }
    }

    // Zemin kontrol sistemi
    Vector2 RayDir = Vector2.down;
    float PretmpY;
    float GroundCheckUpdateTic = 0;
    float GroundCheckUpdateTime = 0.01f;

    protected void GroundCheckUpdate()
    {
        if (!OnceJumpRayCheck) return;

        GroundCheckUpdateTic += Time.deltaTime;
        if (GroundCheckUpdateTic > GroundCheckUpdateTime)
        {
            GroundCheckUpdateTic = 0;

            if (PretmpY == 0)
            {
                PretmpY = transform.position.y;
                return;
            }

            float reY = transform.position.y - PretmpY;

            if (reY <= 0)
            {
                if (isGrounded)
                {
                    LandingEvent();
                }
            }

            PretmpY = transform.position.y;
        }
    }

    protected abstract void LandingEvent();
}