using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodTower : Tower
{

    private void Awake()
    {
        towerCost = 1000;
        shootCooldown = 0.01f;
    }

    void Start()
    {
        canPlaceOnWater = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
