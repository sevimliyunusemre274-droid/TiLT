using UnityEngine;
using TMPro;

public class DiamondUI : MonoBehaviour
{
    public TMP_Text diamondText;

    private void Start()
    {
        // Ýlk deðeri yaz
        diamondText.text = GameManager.Instance.diamondCount.ToString();

        // Event'e abone ol
        GameManager.Instance.OnDiamondChanged += UpdateUI;
    }

    private void UpdateUI(int newAmount)
    {
        diamondText.text = (newAmount.ToString());
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnDiamondChanged -= UpdateUI;
    }
}
