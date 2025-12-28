using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinishManager : MonoBehaviour
{
    public static LevelFinishManager instance;
    public GameObject finishPortal; // inspector'a sürükle (baþlangýçta inactive)

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void EnableFinishPortal()
    {
        if (finishPortal != null && !finishPortal.activeSelf)
        {
            finishPortal.SetActive(true);
            Debug.Log("Finish portal aktifleþtirildi.");
            // isteðe baðlý efekt/ses => burada baþlatabilirsin
        }
    }

    // Oyuncu portala girdiðinde çaðrýlacak
    public void CompleteLevel()
    {
        Debug.Log("Level tamamlandý. Sahne deðiþtirilebilir burada.");
        // Örnek: ayný sahneyi yeniden yükle ya da sonraki sahne:
        // SceneManager.LoadScene("NextSceneName");
        // veya SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
