using System.Collections.Generic;
using UnityEngine;

public class MouseMove2D : MonoBehaviour {

    Vector3 mousePosition, lastMousePosition;
    Tile[,] map;
    List<Transform> gridPositions = new List<Transform>();
    Transform target;

    SpriteRenderer[] spriteRenderers;
    SpriteRenderer overlay;
    GridAlignScript gridAlignScript;

    bool canBePlaceOnWater = false;
    bool canBePlaced, isPlaced;
    bool towerAttached;

    void Start()
    {
        FindObjectOfType<GameManagerScript>().TowerAttached();

        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        overlay = spriteRenderers[1];
        gridAlignScript = FindObjectOfType<GridAlignScript>();

        map = gridAlignScript.GetMap();
        for (int i = 0; i < map.GetLength(0); i++) {
            for (int j = 0; j < map.GetLength(1); j++) {
                gridPositions.Add(map[i, j]._obj.transform);
            }
        }
    }

    void Update ()
    {
        towerAttached = FindObjectOfType<GameManagerScript>().HasTowerAttached();
        mousePosition = Input.mousePosition;

        canBePlaceOnWater = FindObjectOfType<Tower>().IsAbleToPlaceOnWater();

        if (mousePosition != lastMousePosition && !isPlaced) {
            Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePosition);

            target = GetClosedGridPosition(mousePositionWorld);
            transform.position = new Vector3(target.position.x, target.position.y, -4);
            
            GridAlignScript.TileGenre currentTileGenre = gridAlignScript.GetTile(target)._genre;

            if (currentTileGenre == GridAlignScript.TileGenre.Blocked || currentTileGenre == GridAlignScript.TileGenre.Path) {
                if (currentTileGenre == GridAlignScript.TileGenre.Water && !canBePlaceOnWater) {
                    overlay.color = new Color(255, 0, 0, 0.3f);
                    canBePlaced = false;
                }
                overlay.color = new Color(255, 0, 0, 0.3f);
                canBePlaced = false;
            } else if(currentTileGenre == GridAlignScript.TileGenre.Valid && !canBePlaceOnWater) {
                overlay.color = new Color(0, 255, 0, 0.3f);
                canBePlaced = true;
            } else if(currentTileGenre == GridAlignScript.TileGenre.Water && canBePlaceOnWater) {
                overlay.color = new Color(0, 255, 0, 0.3f);
                canBePlaced = true;
            }
        }

        if(isPlaced) {
            overlay.color = new Color(0, 0, 0, 0);
        }

        if(Input.GetKeyDown(KeyCode.A)) {
            UnPlace();
        }

        lastMousePosition = mousePosition;
	}

    Transform GetClosedGridPosition(Vector3 currentPosition)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        foreach (Transform potentialTarget in gridPositions) {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr) {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        
        return bestTarget;
    }

    public bool IsAbleToPlace()
    {
        return canBePlaced;
    }

    public void IsPlaced()
    {
        isPlaced = true;
        gridAlignScript.SetTile(target, GridAlignScript.TileGenre.Blocked);
    }
    
    public void UnPlace()
    {
        if (!towerAttached) {
            isPlaced = false;
            gridAlignScript.ResetTile(target);
            overlay.color = new Color(0, 255, 0, 0.3f);
        }
    }
}
