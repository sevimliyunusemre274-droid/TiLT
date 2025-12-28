using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public LevelComplete levelComplete;

    void Start()
    {
        // Eðer inspector'dan atamadýysan otomatik bul
        if (levelComplete == null)
            levelComplete = FindObjectOfType<LevelComplete>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            levelComplete.CompleteLevel();

            // Ýstersen 2 saniye bekleyip level seçim ekranýna dön
            Invoke("GoToLevelSelect", 2f);
        }
    }

    void GoToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect"); // Scene ismini kontrol et
    }
}