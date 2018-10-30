using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove2D : MonoBehaviour {

    private Vector3 mousePosition, lastMousePosition;
    private Tile[,] map;
    private List<Transform> gridPositions = new List<Transform>();

    void Start()
    {
        map = FindObjectOfType<GridAlignScript>().GetMap();
        for (int i = 0; i < map.GetLength(0); i++) {
            for (int j = 0; j < map.GetLength(1); j++) {
                gridPositions.Add(map[i, j]._obj.transform);
            }
        }
    }

    void Update () {
        mousePosition = Input.mousePosition;

        if (mousePosition != lastMousePosition) {
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Transform target = GetClosedGridPosition(mousePosition);
            transform.position = new Vector3(target.position.x, target.position.y, -4);
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
}
