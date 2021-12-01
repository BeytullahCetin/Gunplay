using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Movement : MonoBehaviour
{
    [SerializeField] MobSettings mobSetting;
    Rigidbody mobRb;
    Transform target;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        mobRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movement = (target.position - transform.position).normalized;
    }

    void FixedUpdate()
    {
        mobRb.velocity = movement/5 * mobSetting.Speed;
    }
}
