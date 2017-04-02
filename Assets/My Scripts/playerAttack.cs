using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour {

    public int attackDamage = 15;               // The amount of health taken away per attack.

    Animator anim;                              // Reference to the animator component.
    GameObject enemy;
    //PlayerHealth playerHealth;                  // Reference to the player's health.
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;                                // Timer for counting up to the next attack.

    void Awake()
    {
        // Setting up the references.
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyHealth = enemy.GetComponent<EnemyHealth>();
        anim = enemy.GetComponent<Animator>();

        //anim = GetComponent<Animator>();
    }


    void OnTriggerEnter(Collider other)
    {
        // ... the player is in range.
        Attack();
    }


    void Update()
    {

        // If the player has zero or less health...
        if (enemyHealth.currentHealth <= 0)
        {
            // ... tell the animator the player is dead.
            anim.SetTrigger("Dead");
        }
        anim.SetTrigger("PlayerOutOfRange");
    }


    void Attack()
    {
        // If the player has health to lose...
        if (enemyHealth.currentHealth > 0)
        {
            // ... damage the player.
            enemyHealth.TakeDamage(attackDamage);

        }
    }
}
