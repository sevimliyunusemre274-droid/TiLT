using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    // Bu script merdiven objesine eklenecek
    // Sadece trigger görevi görür, özel bir kod gerektirmez

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.isNearLadder = true;
                player.currentLadder = this.gameObject;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.isNearLadder = false;
                player.currentLadder = null;

                // Merdivenden çýkýnca normal moda dön
                if (player.isClimbing)
                {
                    player.ExitLadder();
                    player.m_rigidbody.gravityScale = 3; // Gravity'yi kesin aç
                }
            }
        }
    }
}