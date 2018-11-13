using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour {

    MouseMove2D mouseMove;

    bool canBePlaced;
    bool isPlaced = false;

    void Start()
    {
        mouseMove = FindObjectOfType<MouseMove2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isPlaced) {
            canBePlaced = mouseMove.IsAbleToPlace();
            if (canBePlaced) {
                isPlaced = true;
                mouseMove.IsPlaced();
                FindObjectOfType<GameManagerScript>().TowerUnattached();
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
