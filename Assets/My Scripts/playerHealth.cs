using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerHealth : MonoBehaviour {

    public int startingHealth = 100;            // The amount of health the enemy starts the game with.
    public int playerCurrentHealth;                   // The current health the enemy has.

    public Slider healthSlider;                                 // Reference to the UI's health bar.

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
        playerCurrentHealth = startingHealth;
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
        playerCurrentHealth -= amount;

        healthSlider.value = playerCurrentHealth;

        // If the current health is less than or equal to zero...
        if (playerCurrentHealth <= 0)
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
