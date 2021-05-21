using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BT
{
  public class WorldGrid : MonoBehaviour
  {
    public GameObject tilePrefab;

    [Header("Settings")]
    public int width = 10;
    public int height = 10;
    public int depth = 10;

    [Range(0, 5)]
    public float spacing = .155f;

    public Tile[,,] tiles;

    Vector3 offset = new Vector3(.5f, .5f, .5f);

    private void Start()
    {
      GenerateTiles();
    }

    void GenerateTiles()
    {
      print("Generating...");

      float offsetValue = tilePrefab.transform.localScale.x / 4;
      offset = new Vector3(offsetValue, offsetValue, offsetValue);

      tiles = new Tile[width, height, depth];

      Vector3 halfSize = new Vector3(width * 0.5f, height * 0.5f, depth * 0.5f);

      for (int x = 0; x < width; x++)
      {
        for (int y = 0; y < height; y++)
        {
          for (int z = 0; z < depth; z++)
          {
            Vector3 pos = new Vector3(x - halfSize.x, y - halfSize.y, z - halfSize.z);

            pos += offset;

            pos *= spacing;

            Tile tile = SpawnTile(pos);
          }
        }
      }
    }

    Tile SpawnTile(Vector3 pos)
    {
      print("Spawning...");

      GameObject newTile = Instantiate(tilePrefab, transform.position, transform.rotation);

      newTile.transform.position = pos;

      Vector3 localPos = newTile.transform.localPosition;

      newTile.transform.SetParent(transform);
      newTile.transform.localPosition = localPos;

      Tile currentTile = newTile.GetComponent<Tile>();

      return currentTile;
    }
  } 
}
