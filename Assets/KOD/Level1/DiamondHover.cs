using UnityEngine;

public class DiamondHover : MonoBehaviour
{
    public float floatSpeed = 2f;   // hareket hýzý
    public float floatHeight = 0.25f; // yukarý aþaðý mesafe

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = startPos + new Vector3(0f, yOffset, 0f);
    }
}
