using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public int currentLevel = 1;

    public void CompleteLevel()
    {
        // Mevcut unlocked level'ý al
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        // Eðer bu level zaten açýksa ve bir sonraki level daha yüksekse, güncelle
        if (currentLevel >= unlockedLevel)
        {
            PlayerPrefs.SetInt("UnlockedLevel", currentLevel + 1);
            PlayerPrefs.Save();

            Debug.Log("Level " + (currentLevel + 1) + " açýldý!");
        }
    }
}