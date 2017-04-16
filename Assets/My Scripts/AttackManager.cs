using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackManager : MonoBehaviour {

    private int attackDamage;               // The amount of health taken away per attack.

    [Header("Cooldowns")]
    public float mediumAttack1Cooldown = Mathf.Clamp (3f,0f,3f);
    public float mediumAttack2Cooldown = 4f;
    public float mediumAttack3Cooldown = 5f;
    private bool MA1Cooldown;

    Animator anim;                              // Reference to the animator component.
    GameObject enemy;
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    public enemyAttackManager enemyAttackManager;

    [Header("Attack Prefabs")]
    public GameObject lightAttack1;
    public GameObject lightAttack2;
    public GameObject lightAttack3;
    public GameObject mediumAttack1;
    public GameObject mediumAttack2;
    public GameObject mediumAttack3;
    public GameObject heavyAttack;

    private GameObject instantiatedlightAttack1;
    private GameObject instantiatedlightAttack2;
    private GameObject instantiatedlightAttack3;
    private GameObject instantiatedmediumAttack1;
    private GameObject instantiatedmediumAttack2;
    private GameObject instantiatedmediumAttack3;
    private GameObject instantiatedheavyAttack;

    static public bool activateAttack = true;

    void Start()
    {
        // Setting up the references.
        enemyAttackManager = FindObjectOfType<enemyAttackManager>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyHealth = enemy.GetComponent<EnemyHealth>();
    }

    public void OnClick()
    {
        // When clicking a certain button, a text is instantiated.

        if(activateAttack == true && enemyAttackManager.canAttack == false)
        {
            //Debug.Log("" + activateAttack);

            if (EventSystem.current.currentSelectedGameObject.name == "LightAttackButton1")
            {

               StartCoroutine("Attack");

               attackDamage = 5;

               //activateAttack = false;

               instantiatedlightAttack1 = (GameObject)Instantiate(lightAttack1, transform.position, transform.rotation);

               // After 2 seconds the text is destroyed.
               Destroy(instantiatedlightAttack1.gameObject, 2f);
                

            }

            if (EventSystem.current.currentSelectedGameObject.name == "LightAttackButton2")
            {

               StartCoroutine("Attack");

               attackDamage = 10;

               //activateAttack = false;

               instantiatedlightAttack2 = (GameObject)Instantiate(lightAttack2, transform.position, transform.rotation);

               // After 2 seconds the text is destroyed.
               Destroy(instantiatedlightAttack2.gameObject, 2f);

            }

            if (EventSystem.current.currentSelectedGameObject.name == "LightAttackButton3")
            {

               StartCoroutine("Attack");

               //activateAttack = false;

               attackDamage = 15;

               instantiatedlightAttack3 = (GameObject)Instantiate(lightAttack3, transform.position, transform.rotation);

               // After 2 seconds the text is destroyed.
               Destroy(instantiatedlightAttack3.gameObject, 2f);

            }

            if (EventSystem.current.currentSelectedGameObject.name == "MediumAttackButton1")
            {

               StartCoroutine("Attack");

               //activateAttack = false;

               attackDamage = 15;

               instantiatedmediumAttack1 = (GameObject)Instantiate(mediumAttack1, transform.position, transform.rotation);

                MA1Cooldown = true;

               // After 2 seconds the text is destroyed.
               Destroy(instantiatedmediumAttack1.gameObject, 2f);

            }

            if (EventSystem.current.currentSelectedGameObject.name == "MediumAttackButton2")
            {
    
               StartCoroutine("Attack");

               //activateAttack = false;

               attackDamage = 15;

               instantiatedmediumAttack2 = (GameObject)Instantiate(mediumAttack2, transform.position, transform.rotation);

               // After 2 seconds the text is destroyed.
               Destroy(instantiatedmediumAttack2.gameObject, 2f);

            }

            if (EventSystem.current.currentSelectedGameObject.name == "MediumAttackButton3")
            {

               StartCoroutine("Attack");

               //activateAttack = false;

               attackDamage = 15;

               instantiatedmediumAttack3 = (GameObject)Instantiate(mediumAttack3, transform.position, transform.rotation);

               // After 2 seconds the text is destroyed.
               Destroy(instantiatedmediumAttack3.gameObject, 2f);
                
            }

            if (EventSystem.current.currentSelectedGameObject.name == "HeavyAttackButton")
            {

               StartCoroutine("Attack");

               //activateAttack = false;

               attackDamage = 15;

               instantiatedheavyAttack = (GameObject)Instantiate(heavyAttack, transform.position, transform.rotation);

               // After 2 seconds the text is destroyed.
               Destroy(instantiatedheavyAttack.gameObject, 2f);
                
            }
        }
    }

    void Update()
    {
        //Debug.Log(mediumAttack1Cooldown);

        if(MA1Cooldown == true)
        {
            mediumAttack1Cooldown -= Time.deltaTime;

            if(mediumAttack1Cooldown == 0)
            {
                MA1Cooldown = false;
            }

            //if()
        }

        //Debug.Log("" + activateAttack);
    }

    public IEnumerator Attack()
    {
        activateAttack = false;
        yield return new WaitForSeconds(2f);

        //activateAttack = true;

        if (enemyHealth.enemyCurrentHealth > 0)
        {
            // ... damage the player.
            enemyHealth.TakeDamage(attackDamage);
            Debug.Log("Enemy Health: " + enemyHealth.enemyCurrentHealth);
        }
    }
}
