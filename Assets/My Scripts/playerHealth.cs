using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class playerHealth : MonoBehaviour {

    public int startingHealth = 100;            // The amount of health the enemy starts the game with.
    public int playerCurrentHealth;                   // The current health the enemy has.

    public GameObject loseCanvas;
    public Object sceneToLoad;
    public GameObject playerSprite;

    public string levelName;

    public Slider healthSlider;                                 // Reference to the UI's health bar.

    Animator anim;                              // Reference to the animator.
    //AudioSource enemyAudio;                     // Reference to the audio source.

    bool isDead;                                // Whether the enemy is dead.

    void Awake()
    {
        // Setting up the references.
        anim = GetComponentInChildren<Animator>();
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

        //anim.SetBool("IsGettingAttacked", true);

        StartCoroutine("IdleCo");

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
        StartCoroutine("GoBackToLevelSelectCo");
        // The enemy is dead.
        isDead = true;
        Instantiate(loseCanvas);
        playerCurrentHealth = 0;


    }

    IEnumerator IdleCo()
    {
        yield return new WaitForSeconds(1f);
        //anim.SetBool("IsGettingAttacked", false);
    }

    IEnumerator GoBackToLevelSelectCo()
    { 

        yield return new WaitForSeconds(1f);
        playerSprite.SetActive(false);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Level Select");
    }
}
