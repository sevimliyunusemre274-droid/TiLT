using UnityEngine;
using TMPro;

public class UIManager1 : MonoBehaviour
{
    public static UIManager1 instance;

    [Header("UI Elements")]
    public TextMeshProUGUI diamondText; // Inspector'dan sürükle

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        UpdateDiamondUI(0, 0); // baþlangýç
    }

    // count: þu anki elmas, required: bitiþ için gerekli
    public void UpdateDiamondUI(int count, int required)
    {
        if (diamondText != null)
            diamondText.text = count + " / " + required;
    }
}
