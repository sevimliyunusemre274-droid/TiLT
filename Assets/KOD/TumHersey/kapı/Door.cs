using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string sceneName;
    public GameObject enterButton;   // UI Button
    public GameObject infoText;      // "Kapýya Gir" / "Enter" yazýsý

    private bool playerInside;

    void Start()
    {
        enterButton.SetActive(false);
        infoText.SetActive(false);
    }

    // UI Button burayý çaðýracak
    public void EnterDoor()
    {
        if (playerInside)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            enterButton.SetActive(true);
            infoText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            enterButton.SetActive(false);
            infoText.SetActive(false);
        }
    }
}
