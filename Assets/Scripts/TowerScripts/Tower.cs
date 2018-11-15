using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour {

    protected float radius;
    protected float damage;
    protected bool canPlaceOnWater = true;
    protected bool isPlaced;
    public int towerCost;

    public void Shoot() { }
    public void Turn() { }
    public bool IsAbleToPlaceOnWater() { return canPlaceOnWater;  }
    public int GetTowerCost() { return towerCost; }
}
