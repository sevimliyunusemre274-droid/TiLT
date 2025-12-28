using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f;        // Platformun hýzý
    public float moveDistance = 3f; // Saða-sola gideceði mesafe

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newX = Mathf.Sin(Time.time * speed) * moveDistance;
        transform.position = startPos + new Vector3(newX, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
