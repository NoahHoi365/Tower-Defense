using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridAlignScript : MonoBehaviour {
    
    Vector2 topLeft;
    Tile[,] map;
    int[,] tileMap = {
        { 0, 0, 2, 1, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 1, 2 },
        { 0, 0, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0 ,0 ,0 ,0, 0, 0, 0, 2 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 2, 1, 1, 1, 1, 1, 1, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 2, 1, 1, 1, 1, 1, 1, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0 },
    };
    float offset = 0.43f;

    public GameObject sphere;
    public enum TileGenre { Valid, Water, Blocked };

    private void Start()
    {
        topLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));

        map = GenerateGrid(18, 10);
        print(GetTile(4, 0)._genre);
    }

    public Tile[,] GenerateGrid(int cols, int rows)
    {
        Tile[,] map = new Tile[cols, rows];
        for(int x = 0; x < cols; x++) {
            for(int y = 0; y < rows; y++) {
                GameObject obj = Instantiate(sphere, transform);
                obj.transform.position = new Vector2((topLeft.x + x) + offset, (topLeft.y - y) - offset);
                TileGenre genre;
                switch (tileMap[y, x]) {
                    case 0: genre = TileGenre.Valid; break;
                    case 1: genre = TileGenre.Water; break;
                    case 2: genre = TileGenre.Blocked; break;
                    default: genre = TileGenre.Blocked; break;
                }

                map[x, y] = new Tile(obj, genre);
            }
        }

        return map;
    }

    public Tile GetTile(int row, int col)
    {
        if(row > map.GetLength(0) || col > map.GetLength(1)) {
            return null;
        }

        return map[row, col];
    }
}

public class Tile
{
    public GameObject _obj;
    public GridAlignScript.TileGenre _genre;

    public Tile(GameObject obj, GridAlignScript.TileGenre genre)
    {
        _obj = obj;
        _genre = genre;
    }
}