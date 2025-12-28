using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapCoordinateDebugger : MonoBehaviour
{
    [Header("References")]
    public Tilemap tilemap;                 // sahnedeki Tilemap referansý
    public Camera targetCamera;             // null ise Camera.main kullanýlýr

    [Header("Optional UI")]
    public TMP_Text uiText;                 // ekranda göstermek istersen (TextMeshPro). Opsiyonel.
    public GameObject markerPrefab;         // hücre merkezinde göstermek istersen (opsiyonel)

    private GameObject spawnedMarker;

    void Reset()
    {
        // Kolaylýk: otomatik atama denemesi
        if (targetCamera == null) targetCamera = Camera.main;
    }

    void Update()
    {
        if (tilemap == null) return;
        if (targetCamera == null) targetCamera = Camera.main;

        // Sol fare týklamasý ile hücreyi al ve göster
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPos = targetCamera.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0f;
            Vector3Int cellPos = tilemap.WorldToCell(worldPos);
            TileBase tile = tilemap.GetTile(cellPos);

            string tileInfo = $"Cell: {cellPos}  |  HasTile: {(tile != null ? "EVET" : "HAYIR")}";
            Debug.Log(tileInfo);

            if (uiText != null)
                uiText.text = tileInfo;

            if (markerPrefab != null)
            {
                Vector3 cellCenter = tilemap.GetCellCenterWorld(cellPos);
                if (spawnedMarker == null)
                    spawnedMarker = Instantiate(markerPrefab, cellCenter, Quaternion.identity);
                else
                    spawnedMarker.transform.position = cellCenter;
            }
        }

        // Ýsteðe baðlý: sað týklamayla marker'ý temizle
        if (Input.GetMouseButtonDown(1) && spawnedMarker != null)
        {
            Destroy(spawnedMarker);
            spawnedMarker = null;
            if (uiText != null) uiText.text = "";
        }
    }
}
