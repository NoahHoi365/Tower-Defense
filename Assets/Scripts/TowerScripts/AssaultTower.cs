using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultTower : Tower
{

    private void Awake()
    {
        towerCost = 100;
        shootCooldown = 0.3f;
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
