using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EnemyHealth : MonoBehaviour
{
    enemyAttackManager enemyAttackManager2;

    public int startingHealth = 100;            // The amount of health the enemy starts the game with.
    public int enemyCurrentHealth;                   // The current health the enemy has.

    public GameObject winCanvas;
    public Object sceneToLoad;
    public GameObject enemySprite;

    public string levelName;

    public Slider healthSlider;                                 // Reference to the UI's health bar.

    //Animator anim;                              // Reference to the animator.
    //AudioSource enemyAudio;                     // Reference to the audio source.

    bool isDead;                                // Whether the enemy is dead.

    void Awake()
    {
        enemyAttackManager2 = FindObjectOfType<enemyAttackManager>();

        // Setting up the references.
        //anim = GetComponent<Animator>();
        //enemyAudio = GetComponent<AudioSource>();
        GameObject.Find("BloodParticle");

        // Setting the current health when the enemy first spawns.
        enemyCurrentHealth = startingHealth;
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
        enemyCurrentHealth -= amount;


        healthSlider.value = enemyCurrentHealth;


        // If the current health is less than or equal to zero...
        if (enemyCurrentHealth <= 0)
        {
            // ... the enemy is dead.
            enemyCurrentHealth = 0;
            Death();
        }
    }

    void Death()
    {
        // The enemy is dead.
        StartCoroutine("GoBackToLevelSelectCo");
        isDead = true;
        enemyAttackManager2.enabled = false;
        Instantiate(winCanvas);


    }

    IEnumerator GoBackToLevelSelectCo()
    {

        yield return new WaitForSeconds(1f);
        enemySprite.SetActive(false);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Level Select");
    }
}