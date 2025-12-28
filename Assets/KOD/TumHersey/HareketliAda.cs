using UnityEngine;

public class HareketliAda : MonoBehaviour
{
    public float hareketMesafesi = 3f;   // Yukarý-aþaðý ne kadar gitsin
    public float hiz = 2f;               // Hareket hýzý

    private Vector3 baslangicPozisyonu;

    void Start()
    {
        baslangicPozisyonu = transform.position;
    }

    void Update()
    {
        float y = Mathf.PingPong(Time.time * hiz, hareketMesafesi);
        transform.position = baslangicPozisyonu + Vector3.up * y;
    }
}
