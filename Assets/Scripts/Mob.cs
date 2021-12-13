using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Mob : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] MobSettings mobSetting;
    [SerializeField] int lookRotationDamping;
    [SerializeField] Slider healthBar;
    Vector3 distance;
    float health;
    bool isDead;
    bool attacking;
    [SerializeField] float attackDistance;  
    [SerializeField] float destroyDelay = 3.5f;

    [Header("Effects")]
    [SerializeField] GameObject[] bloodEffects;
    AudioSource hitSound;

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
        hitSound = GetComponent<AudioSource>();
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
        hitSound.PlayDelayed(0.1f);
        CreateBloodEffect(point, rotation);
        health -= dmg;
        healthBar.value = health;
        if (health < 0 && !isDead)
            Die();
    }

    void CreateBloodEffect(Vector3 point, Quaternion rotation)
    {
        GameObject blood = Instantiate(bloodEffects[Random.Range(0, bloodEffects.Length)], point, rotation);
        Destroy(blood, 2f);

    }

    void Die()
    {
        string dieTrig = "die" + Random.Range(0, 2).ToString();
        Debug.Log(dieTrig);
        zombieAnim.SetTrigger(dieTrig);
        Destroy(gameObject, destroyDelay);
        isDead = true;
        FindObjectOfType<GameManager>().AddScore(10);
        healthBar.gameObject.SetActive(false);
    }
}
