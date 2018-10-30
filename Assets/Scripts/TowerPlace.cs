using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour {

    bool canBePlaced;
    bool isPlaced = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            canBePlaced = FindObjectOfType<MouseMove2D>().IsAbleToPlace();
            if(canBePlaced) {
                isPlaced = true;
                FindObjectOfType<MouseMove2D>().IsPlaced();
            }
        }
    }
}
