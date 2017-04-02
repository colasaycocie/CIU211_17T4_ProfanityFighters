using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackManager : MonoBehaviour {

    private int attackDamage;               // The amount of health taken away per attack.

    Animator anim;                              // Reference to the animator component.
    GameObject enemy;
    //PlayerHealth playerHealth;                  // Reference to the player's health.
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.

    public GameObject lightAttack1;
    public GameObject lightAttack2;
    public GameObject lightAttack3;

    private GameObject instantiatedlightAttack1;
    private GameObject instantiatedlightAttack2;
    private GameObject instantiatedlightAttack3;
    static bool activateAttack = true;


    void Start()
    {
        // Setting up the references.
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyHealth = enemy.GetComponent<EnemyHealth>();
    }

    public void OnClick()
    {
        // When clicking a certain button, a text is instantiated.
        if(EventSystem.current.currentSelectedGameObject.name == "LightAttackButton1")
        {

            if (activateAttack == true)
            {

                StartCoroutine("Attack");

                attackDamage = 5;

                instantiatedlightAttack1 = (GameObject)Instantiate(lightAttack1, transform.position, transform.rotation);

                // After 2 seconds the text is destroyed.
                Destroy(instantiatedlightAttack1.gameObject, 2f);
            }

        }

        if (EventSystem.current.currentSelectedGameObject.name == "LightAttackButton2")
        {


            if (activateAttack == true)
            {
                StartCoroutine("Attack");

                attackDamage = 10;


                instantiatedlightAttack2 = (GameObject)Instantiate(lightAttack2, transform.position, transform.rotation);
            }


            // After 2 seconds the text is destroyed.
            Destroy(instantiatedlightAttack2.gameObject, 2f);
        }

        if (EventSystem.current.currentSelectedGameObject.name == "LightAttackButton3")
        {

            if (activateAttack == true)
            {
                StartCoroutine("Attack");

                activateAttack = false;

                attackDamage = 15;

                instantiatedlightAttack3 = (GameObject)Instantiate(lightAttack3, transform.position, transform.rotation);

                // After 2 seconds the text is destroyed.
                Destroy(instantiatedlightAttack3.gameObject, 2f);
            }

        }
    }

    void Update()
    {
        //Debug.Log("" + activateAttack);
    }

    public IEnumerator Attack()
    {

        activateAttack = false;
        yield return new WaitForSeconds(1.7f);
        activateAttack = true;

        if (enemyHealth.currentHealth > 0)
        {
            // ... damage the player.
            enemyHealth.TakeDamage(attackDamage);
            Debug.Log("Enemy Health: " + enemyHealth.currentHealth);
        }


    }
}
