using UnityEngine;

public class PortalActivator : MonoBehaviour
{
    public GameObject finishPortal;

    private void Start()
    {
        // Portal baþta kapalý
        finishPortal.SetActive(false);

        // Elmas eventine abone ol
        GameManager.Instance.OnDiamondChanged += CheckDiamonds;

        // Sahne yeniden açýlýrsa kontrol et
        CheckDiamonds(GameManager.Instance.diamondCount);
    }

    private void CheckDiamonds(int currentAmount)
    {
        if (currentAmount >= GameManager.Instance.requiredDiamonds)
        {
            finishPortal.SetActive(true);
            Debug.Log("Portal açýldý!");
        }
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnDiamondChanged -= CheckDiamonds;
    }
}
