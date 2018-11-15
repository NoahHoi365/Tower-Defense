using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridAlignScript : MonoBehaviour {
    
    Vector2 topLeft;
    Tile[,] map;
    byte[,] tileMap = {
        { 0, 0, 0, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 2, 1, 1, 1, 1, 1 },
        { 0, 0, 0, 2, 1, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 1, 1, 1 },
        { 0, 0, 0, 2, 2, 2, 2, 0, 3, 3, 3, 3, 3, 0, 0, 0, 2, 1, 1, 1 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 3, 0 ,0 ,0, 3, 0, 0, 0, 0, 2, 1, 1 },
        { 3, 3, 3, 3, 3, 3, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 0, 0, 2, 1 },
        { 0, 0, 0, 0, 0, 3, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 2 },
        { 0, 0, 0, 0, 0, 3, 3, 3, 3, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 3, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 2, 1, 1, 1, 1, 1, 1, 1, 2, 0, 3, 3, 3, 3, 3, 0, 0, 0 },
        { 0, 0, 2, 1, 1, 1, 1, 1, 1, 1, 2, 0, 0, 0, 0, 0, 3, 0, 0, 0 },
    };
    Vector2 offset = new Vector2(0.27f, 0.43f);

    public GameObject sphere;
    public enum TileGenre { Valid, Water, Blocked, Path };
    public Vector2 gridSize = new Vector2();

    private void Awake()
    {
        topLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));

        map = GenerateGrid((int)gridSize.x, (int)gridSize.y);
    }

    public Tile[,] GenerateGrid(int cols, int rows)
    {
        Tile[,] map = new Tile[cols, rows];
        for(int x = 0; x < cols; x++) {
            for(int y = 0; y < rows; y++) {
                GameObject obj = Instantiate(sphere, transform);
                obj.transform.position = new Vector2((topLeft.x + x) + offset.x, (topLeft.y - y) - offset.y);
                TileGenre genre;
                switch (tileMap[y, x]) {
                    case 0: genre = TileGenre.Valid; break;
                    case 1: genre = TileGenre.Water; break;
                    case 2: genre = TileGenre.Blocked; break;
                    case 3: genre = TileGenre.Path; break;
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

    public Tile GetTile(Transform transform)
    {
        //return TileTransform(transform);
        for (int i = 0; i < map.GetLength(0); i++) {
            for (int j = 0; j < map.GetLength(1); j++) {
                Transform temp = map[i, j]._obj.transform;

                if (temp == transform) {
                    return map[i, j];
                }
            }
        }

        return null;
    }

    public void SetTile(Transform transform, TileGenre genre)
    {
        //Tile tile = TileTransform(transform);

        for (int i = 0; i < map.GetLength(0); i++) {
            for (int j = 0; j < map.GetLength(1); j++) {
                Transform temp = map[i, j]._obj.transform;

                if (temp == transform) {
                    map[i, j]._genre = genre;
                }
            }
        }

    }

    public void ResetTile(Transform transform)
    {
        for (int i = 0; i < map.GetLength(0); i++) {
            for (int j = 0; j < map.GetLength(1); j++) {
                Transform temp = map[i, j]._obj.transform;

                if (temp == transform) {
                    TileGenre genre;
                    switch (tileMap[j, i]) {
                        case 0: genre = TileGenre.Valid; break;
                        case 1: genre = TileGenre.Water; break;
                        case 2: genre = TileGenre.Blocked; break;
                        case 3: genre = TileGenre.Path; break;
                        default: genre = TileGenre.Blocked; break;
                    }
                    
                    map[i, j]._genre = genre;
                }
            }
        }
    }

    public Tile[,] GetMap()
    {
        return map;
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