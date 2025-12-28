using UnityEngine;

public class JumpButton : MonoBehaviour
{
    public Swordman player;

    public void Jump()
    {
        if (player == null) return;

        if (player.currentJumpCount < player.JumpCount)
        {
            if (!player.IsSit)
                player.SendMessage("prefromJump");
            else
                player.SendMessage("DownJump");
        }
    }
}
