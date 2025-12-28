//using UnityEngine;

//public class DiamondPickup : MonoBehaviour
//{
//    public int diamondValue = 1;
//    public GameObject pickupEffect; // istersen partikül prefab'ý sürükle
//    public AudioClip pickupSound;
//    private AudioSource audioSource;

//    private void Start()
//    {
//        audioSource = GetComponent<AudioSource>();
//        // Eðer yoksa ekleme istersen: audioSource = gameObject.AddComponent<AudioSource>();
//    }

//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            PlayerInventory inv = other.GetComponent<PlayerInventory>();
//            if (inv != null)
//            {
//                inv.AddDiamond(diamondValue);
//            }
//            else
//            {
//                // PlayerInventory yoksa direkt UI güncelle (alternatif)
//                if (UIManager1.instance != null)
//                    UIManager1.instance.UpdateDiamondUI(1, 1);
//            }

//            // efekt
//            if (pickupEffect != null)
//                Instantiate(pickupEffect, transform.position, Quaternion.identity);

//            // ses
//            if (pickupSound != null)
//            {
//                if (audioSource == null) audioSource = gameObject.AddComponent<AudioSource>();
//                audioSource.PlayOneShot(pickupSound);
//            }

//            // elmasý yok et (ses çalýyor ise Destroy'dan önce ses oynatmaya dikkat; kýsa efektler için problem olmaz)
//            Destroy(gameObject);
//        }
//    }
//}

using UnityEngine;

public class DiamondPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Elmas alýndý!");

            PlayerInventory inv = other.GetComponent<PlayerInventory>();
            if (inv != null)
            {
                inv.AddDiamond(1);
            }

            Destroy(gameObject); // ELMASI YOK EDEN SATIR
        }
    }
}
