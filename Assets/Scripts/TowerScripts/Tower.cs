using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour {

    protected bool canPlaceOnWater = true;
    protected bool isPlaced;
    protected int towerCost;
    protected float shootCooldown;
    protected bool ableToShoot = true;
    public float damage;
    public float radius;
    public GameObject bulletPrefab;

    protected Transform target = null;


    protected void Update()
    {
        if (ableToShoot && GetComponent<TowerPlace>().IsPlaced())
            StartCoroutine(Shoot());

        if (target != null)
            Turn();
    }

    public void ShootLogic() {
        target = GetClosestTarget(transform.position);
        if (target != null) {
            GameObject bullet = Instantiate(bulletPrefab, transform);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.Move(GetDirectionToTarget(target));
            bulletScript.SetDamage(damage);
        }
    }

    public void Turn() {
        Vector3 vectorToTarget = target.position - transform.position;
        float angle = 180 + (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg);
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5f);
    }
    public bool IsAbleToPlaceOnWater() { return canPlaceOnWater;  }
    public int GetTowerCost() { return towerCost; }

    Transform GetClosestTarget(Vector3 currentPosition)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;

        GameObject[] targets = GetTargets(transform.position, radius);
        Transform[] transforms = new Transform[targets.Length];

        for (int i = 0; i < targets.Length; i++) {
            transforms[i] = targets[i].transform;
        }

        foreach (Transform potentialTarget in transforms) {
            if (potentialTarget.GetComponent<Tower>()|| potentialTarget.name == "Bullet(Clone)") {}
            else {
                Vector3 directionToTarget = potentialTarget.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr) {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialTarget;
                }
            }
        }
        
        return bestTarget;
    }

    Vector3 GetDirectionToTarget(Transform target)
    {
        Vector3 magnitude = target.position - transform.position;
        Vector3 direction = magnitude.normalized;

        return direction;
    }

    public IEnumerator Shoot()
    {
        ShootLogic();
        ableToShoot = false;
        yield return new WaitForSeconds(shootCooldown);
        ableToShoot = true;
    }
    
    GameObject[] GetTargets(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        GameObject[] targets = new GameObject[hitColliders.Length];
        for(int i = 0; i < hitColliders.Length; i++) {
            targets[i] = hitColliders[i].gameObject;
        }
        return targets;
    }
}
