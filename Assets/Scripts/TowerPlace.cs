using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour {

    MouseMove2D mouseMove;

    bool canBePlaced;
    bool isPlaced = false;

    public delegate void TowerUnattached();
    public event TowerUnattached towerUnattachedEvent;

    void Start()
    {
        mouseMove = FindObjectOfType<MouseMove2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            canBePlaced = mouseMove.IsAbleToPlace();
            if (canBePlaced) {
                isPlaced = true;
                mouseMove.IsPlaced();
                if (towerUnattachedEvent != null)
                    towerUnattachedEvent();
            }
        }
    }

    public bool IsPlaced()
    {
        return isPlaced;
    }

    public void Placed(bool state)
    {
        isPlaced = state;
    }
}
