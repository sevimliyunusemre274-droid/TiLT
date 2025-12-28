using UnityEngine;

public class FinishPortalTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        // Opsiyonel: sadece portal açýk ise tamamla. (Portal aktif edilince zaten açýk olacaktýr)
        if (LevelFinishManager.instance != null)
        {
            LevelFinishManager.instance.CompleteLevel();
        }
        LevelCompleteUI.instance.ShowLevelComplete();
    }
}
