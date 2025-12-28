using UnityEngine;
using System;   // <-- EVENT için gerekli
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int diamondCount = 0;
    public int requiredDiamonds = 10;

    // UI'ya haber verecek event
    public event Action<int> OnDiamondChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Debug.Log("GameManager AKTÝF");
    }

    public void AddDiamond()
    {
        diamondCount++;
        Debug.Log("Elmas: " + diamondCount);

        // UI'ya haber ver
        OnDiamondChanged?.Invoke(diamondCount);
    }

    public bool IsLevelCompleted()
    {
        return diamondCount >= requiredDiamonds;
    }

    public void ResetLevelData()
    {
        diamondCount = 0;

        // Reset olunca UI da güncellensin
        OnDiamondChanged?.Invoke(diamondCount);
    }

    private HashSet<string> collectedDiamonds = new HashSet<string>();

    public bool IsDiamondCollected(string id)
    {
        return collectedDiamonds.Contains(id);
    }

    public void RegisterDiamond(string id)
    {
        if (!collectedDiamonds.Contains(id))
        {
            collectedDiamonds.Add(id);
        }
    }

}
