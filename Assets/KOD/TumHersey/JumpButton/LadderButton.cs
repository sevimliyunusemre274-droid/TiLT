using UnityEngine;
using UnityEngine.EventSystems;

public class LadderButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Swordman player;
    private bool isHolding = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (player == null) return;

        // Tek týk ? merdivene gir
        if (player.isNearLadder && !player.isClimbing)
        {
            player.EnterLadder();
        }

        // Basýlý tut ? týrman
        isHolding = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
    }

    private void Update()
    {
        if (!isHolding) return;
        if (!player.isClimbing) return;

        // Yukarý doðru týrman
        player.transform.Translate(Vector2.up * player.climbSpeed * Time.deltaTime);
    }
}
