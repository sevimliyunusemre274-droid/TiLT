using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public int levelIndex;       // Level numarasý (1,2,3...)
    public GameObject lockIcon;  // Kilit ikonunu atayýn
    public Button button;        // Buton component

    void Start()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        if (levelIndex <= unlockedLevel)
        {
            lockIcon.SetActive(false);
            button.interactable = true;
        }
        else
        {
            lockIcon.SetActive(true);
            button.interactable = false;
        }

        button.onClick.AddListener(OpenLevel);
    }

    void OpenLevel()
    {
        SceneManager.LoadScene("Level" + levelIndex);
    }
}
