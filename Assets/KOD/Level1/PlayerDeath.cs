using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            HealthSystem hs = FindObjectOfType<HealthSystem>();
            if (hs != null)
                hs.TakeDamage();
        }
    }
}
