using UnityEngine;

public class Diamond : MonoBehaviour
{
    [Header("Unique ID (Inspector'dan gir)")]
    public string diamondID;

    private void Start()
    {
        // Eðer bu elmas daha önce toplandýysa, sahnede görünmesin
        if (GameManager.Instance.IsDiamondCollected(diamondID))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        // Elmasý kaydet
        GameManager.Instance.RegisterDiamond(diamondID);
        GameManager.Instance.AddDiamond();

        Destroy(gameObject);
    }
}
