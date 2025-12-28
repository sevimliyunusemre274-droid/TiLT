using UnityEngine;
using TMPro;

public class DiamondManager : MonoBehaviour
{
    public TextMeshProUGUI diamondText;

    void Start()
    {
        diamondText.text = PlayerPrefs.GetInt("Diamonds", 0).ToString();
    }

    public static void AddDiamonds(int amount)
    {
        int diamonds = PlayerPrefs.GetInt("Diamonds", 0);
        diamonds += amount;
        PlayerPrefs.SetInt("Diamonds", diamonds);
    }
}
