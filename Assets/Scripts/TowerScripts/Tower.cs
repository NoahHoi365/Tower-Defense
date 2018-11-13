using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    protected float radius;
    protected float damage;
    protected bool canPlaceOnWater = true;
    protected bool isPlaced;

    public void Shoot() { }
    public void Turn() { }
    public bool IsAbleToPlaceOnWater() { return canPlaceOnWater;  }
}
