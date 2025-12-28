using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Diamond Settings")]
    public int diamondCount = 0;
    public int diamondsToFinish = 5; // inspector'dan ayarlanabilir

    private void Start()
    {
        // Baþlangýçta UI'yý güncelle
        if (UIManager1.instance != null)
            UIManager1.instance.UpdateDiamondUI(diamondCount, diamondsToFinish);
    }

    // DiamondPickup tarafýndan çaðrýlacak
    public void AddDiamond(int amount = 1)
    {
        diamondCount += amount;

        if (UIManager1.instance != null)
            UIManager1.instance.UpdateDiamondUI(diamondCount, diamondsToFinish);

        // Gerekli adede ulaþtý mý?
        if (diamondCount >= diamondsToFinish)
        {
            if (LevelFinishManager.instance != null)
                LevelFinishManager.instance.EnableFinishPortal();
        }
    }
}
