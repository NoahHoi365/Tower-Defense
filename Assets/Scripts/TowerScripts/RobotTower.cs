using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotTower : Tower
{

    private void Awake()
    {
        towerCost = 320;
        shootCooldown = 1f;
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
