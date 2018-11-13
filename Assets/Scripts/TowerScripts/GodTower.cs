using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodTower : Tower
{

    private void Awake()
    {
        towerCost = -1;
    }

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
