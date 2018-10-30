using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    protected float radius;
    protected float damage;
    protected bool canPlaceOnWater = false;
    protected bool isPlaced = false;

    public void Shoot() { }
    public void Turn() { }
    public bool IsAbleToPlaceOnWater() { return canPlaceOnWater;  }
}
