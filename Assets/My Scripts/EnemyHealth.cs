using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int startingHealth = 100;            // The amount of health the enemy starts the game with.
    public int currentHealth;                   // The current health the enemy has.

    //Animator anim;                              // Reference to the animator.
    //AudioSource enemyAudio;                     // Reference to the audio source.

    bool isDead;                                // Whether the enemy is dead.

    void Awake()
    {
        // Setting up the references.
        //anim = GetComponent<Animator>();
        //enemyAudio = GetComponent<AudioSource>();
        GameObject.Find("BloodParticle");

        // Setting the current health when the enemy first spawns.
        currentHealth = startingHealth;
    }

    void Update()
    {
        //Debug.Log("Enemy Health: " + currentHealth);
    }

    public void TakeDamage(int amount)
    {
        // If the enemy is dead...
        if (isDead)
            // ... no need to take damage so exit the function.
            return;

        // Play the hurt sound effect.
        //enemyAudio.Play();

        // Reduce the current health by the amount of damage sustained.
        currentHealth -= amount;

        // If the current health is less than or equal to zero...
        if (currentHealth <= 0)
        {
            // ... the enemy is dead.
            Death();
        }
    }

    void Death()
    {
        // The enemy is dead.
        isDead = true;

        Destroy(gameObject, 1.5f);
    }
}