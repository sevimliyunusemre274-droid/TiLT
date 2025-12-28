using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteUI : MonoBehaviour
{
    public static LevelCompleteUI instance;

    public GameObject levelCompletePanel;

    private void Awake()
    {
        instance = this;
    }

    public void ShowLevelComplete()
    {
        levelCompletePanel.SetActive(true);
        Time.timeScale = 0f; // oyunu durdur
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelectSahnesi");
    }
}
