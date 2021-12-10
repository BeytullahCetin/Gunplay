using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] MobSettings mobSetting;
    [SerializeField] int lookRotationDamping;
    float health;

    [Header("Effects")]
    [SerializeField] GameObject[] bloodEffects;

    [Header("Movement")]
    Transform target;
    Vector3 movement;
    Rigidbody mobRb;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        mobRb = GetComponent<Rigidbody>();

        health = mobSetting.Health;
    }

    void Update()
    {
        movement = (target.position - transform.position).normalized;
        movement.y = 0;
        Quaternion rotation = Quaternion.LookRotation(movement);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * lookRotationDamping);
    }

    void FixedUpdate()
    {
        mobRb.velocity = movement / 5 * mobSetting.Speed;
    }

    public void TakeDamage(Vector3 point, Quaternion rotation, float dmg)
    {
        CreateBloodEffect(point, rotation);
        health -= dmg;
        if (health < 0)
            Die();
    }

    void CreateBloodEffect(Vector3 point, Quaternion rotation)
    {
        GameObject blood = Instantiate(bloodEffects[Random.Range(0, bloodEffects.Length)], point, rotation);
        Destroy(blood, 2f);

    }

    void Die()
    {
        Destroy(gameObject);
    }
}
