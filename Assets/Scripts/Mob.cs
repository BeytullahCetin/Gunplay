using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] MobSettings mobSetting;
    [SerializeField] int lookRotationDamping;
    Vector3 distance;
    float health;
    bool isDead;
    bool attacking;
    [SerializeField] float attackDistance;  
    [SerializeField] float destroyDelay = 3.5f;

    [Header("Effects")]
    [SerializeField] GameObject[] bloodEffects;

    [Header("Movement")]
    Vector3 movement;

    [Header("Dependencies")]
    Animator zombieAnim;
    Transform target;
    Rigidbody mobRb;
    Player player;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        mobRb = GetComponent<Rigidbody>();
        zombieAnim = GetComponent<Animator>();
        health = mobSetting.Health;
        isDead = false;
        attacking = false;
        player = target.gameObject.GetComponent<Player>();
    }

    void Update()
    {
        if (!isDead)
        {

            distance = (target.position - transform.position);
            movement = distance.normalized;
            Quaternion rotation = Quaternion.LookRotation(movement);
            rotation.eulerAngles = new Vector3(0, rotation.eulerAngles.y, rotation.eulerAngles.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * lookRotationDamping);

            if(distance.magnitude < attackDistance){
                zombieAnim.SetTrigger("attack");
                if(!attacking)
                    StartCoroutine(DealDamage(mobSetting.DamageDeal));
            }
        }
    }

    IEnumerator DealDamage(int damage){
        while(!isDead){
            attacking = true;
            yield return new WaitForSeconds(2f);
            player.TakeDamage(damage);
        }
        attacking = false;
    }

    void FixedUpdate()
    {
        if (!isDead)
        {
            Vector3 vel = mobRb.velocity;
            vel.x = movement.x / 5 * mobSetting.Speed;
            vel.z = movement.z / 5 * mobSetting.Speed;
            mobRb.velocity = vel;
        }
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
        zombieAnim.SetTrigger("die" + Random.Range(0, 2));
        Destroy(gameObject, destroyDelay);
        isDead = true;
        FindObjectOfType<GameManager>().AddScore(10);
    }
}
