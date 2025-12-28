using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapDestroyer : MonoBehaviour
{
    public Tilemap tilemap;
    public Vector3Int[] tilesToBreak;
    private TileBase[] savedTiles;

    private void Start()
    {
        savedTiles = new TileBase[tilesToBreak.Length];

        for (int i = 0; i < tilesToBreak.Length; i++)
        {
            savedTiles[i] = tilemap.GetTile(tilesToBreak[i]);

            Debug.Log("START Tile [" + tilesToBreak[i] + "] = " +
                      (savedTiles[i] == null ? "YOK" : "VAR"));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGER ENTER: " + collision.name);

        if (collision.CompareTag("Player"))
        {
            foreach (var pos in tilesToBreak)
            {
                Debug.Log("SÝLME DENEMESÝ: " + pos);
                tilemap.SetTile(pos, null);
            }
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("TRIGGER EXIT: " + collision.name);

        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < tilesToBreak.Length; i++)
            {
                Debug.Log("GERÝ YÜKLEME: " + tilesToBreak[i]);
                tilemap.SetTile(tilesToBreak[i], savedTiles[i]);
            }
        }
    }
}
