using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Vector3 direction;
    float speed = 20f;
    float damage;

    float lifetime = 6f;

    private void Update()
    {
        Vector3 moveAmount = direction * speed * Time.deltaTime;

        transform.position += moveAmount;

        Destroy(gameObject, lifetime);
    }

    public void Move(Vector3 dir)
    {
        direction = dir;
    }

    public void SetDamage(float dmg)
    {
        damage = dmg;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy") {
            GameObject enemy = other.gameObject;

            enemy.GetComponent<Enemy>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
