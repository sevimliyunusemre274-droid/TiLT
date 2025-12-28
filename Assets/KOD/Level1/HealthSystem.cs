using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public Image[] hearts; // Heart1, Heart2, Heart3
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameObject gameOverPanel;

    private Vector3 respawnPosition;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHearts();

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
            respawnPosition = player.transform.position;
    }

    public void TakeDamage()
    {
        currentHealth--;
        UpdateHearts();

        if (currentHealth <= 0)
        {
            GameOver();
        }
        else
        {
            Respawn();
        }
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = i < currentHealth ? fullHeart : emptyHeart;
        }
    }

    private void Respawn()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = respawnPosition;
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.linearVelocity = Vector2.zero;
        }
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // Oyunu durdur
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
