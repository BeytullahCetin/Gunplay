using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float health = 100;
    bool isDead;

    void Start() {
        isDead = false;
    }
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health < 0)
            Die();
    }

    void Die()
    {
        isDead = true;
        FindObjectOfType<GameManager>().GameOver();
    }
}
