using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperTower : Tower
{

    private void Awake()
    {
        towerCost = 150;
        shootCooldown = 3f;
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
