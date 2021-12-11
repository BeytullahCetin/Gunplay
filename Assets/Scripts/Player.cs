using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] Slider healthBar;
    bool isDead;

    void Start() {
        isDead = false;
    }
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        healthBar.value = health;
        if (health < 0)
            Die();
    }

    void Die()
    {
        isDead = true;
        FindObjectOfType<GameManager>().GameOver();
    }
}
