using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotTower : Tower
{

    void Start()
    {
        radius = 3f;
        damage = 10f;
        canPlaceOnWater = false;
    }

    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
