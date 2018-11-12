using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour {

    MouseMove2D mouseMove;

    bool canBePlaced;
    bool isPlaced = false;
    ScriptableObject a;

    void Start()
    {
        mouseMove = FindObjectOfType<MouseMove2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            canBePlaced = mouseMove;
            if (canBePlaced) {
                isPlaced = true;
                mouseMove.IsPlaced();
            }
        }
    }
}
