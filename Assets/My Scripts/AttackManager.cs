using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AttackManager : MonoBehaviour {

    private int attackDamage;               // The amount of health taken away per attack.
    private int manaAdditive;
    private int manaCost;

    public Slider manaSlider;
    public Slider enemyManaSlider;
    public Text playerHealthText;
    public Text playerManaText;

    [Header("Cooldowns")]
    public static int mediumAttack1Cooldown = 4;
    public static int mediumAttack2Cooldown = 4;
    public static int mediumAttack3Cooldown = 4;
    public static int heavyAttackCooldown = 6;
    private static bool MA1Cooldown;
    private static bool MA2Cooldown;
    private static bool MA3Cooldown;
    private static bool HACooldown;
    public Text MA1CooldownText;
    public GameObject MA1CooldownButton;
    public Text MA2CooldownText;
    public GameObject MA2CooldownButton;
    public Text MA3CooldownText;
    public GameObject MA3CooldownButton;
    public Text HACooldownText;
    public GameObject HACooldownButton;

    Animator playerAnim;                              // Reference to the animator component.
    Animator enemyAnim;
    GameObject enemyModel;
    public GameObject playerModel;
    GameObject enemy;
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    playerHealth playerHealth;
    playerMana playerManaScript;
    enemyMana enemyManaScript;

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
        enemyManaScript = FindObjectOfType<enemyMana>();
        playerManaScript = FindObjectOfType<playerMana>();
        // Setting up the references.
        enemyAttackManager = FindObjectOfType<enemyAttackManager>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        playerHealth = FindObjectOfType<playerHealth>();
        enemyHealth = enemy.GetComponent<EnemyHealth>();
        playerAnim = playerModel.GetComponent<Animator>();
        enemyModel = GameObject.FindGameObjectWithTag("EnemyModel");
        enemyAnim = enemyModel.GetComponent<Animator>();
    }

    public void OnClick()
    {
        // When clicking a certain button, a text is instantiated.

        if(activateAttack == true && enemyAttackManager.canAttack == false)
        {

            //Debug.Log("" + activateAttack);

            if (EventSystem.current.currentSelectedGameObject.name == "LightAttackButton1")
            {
                AttackAnimation();

                StartCoroutine("Attack");

                StartCoroutine("InjureCo");

                attackDamage = 5;

                manaAdditive = 7;

                //activateAttack = false;

                instantiatedlightAttack1 = (GameObject)Instantiate(lightAttack1, transform.position, transform.rotation);

                // After 2 seconds the text is destroyed.
                Destroy(instantiatedlightAttack1.gameObject, 2f);
                
            }

            if (EventSystem.current.currentSelectedGameObject.name == "LightAttackButton2")
            {
                AttackAnimation();

                StartCoroutine("Attack");

                StartCoroutine("InjureCo");

                attackDamage = 7;

                manaAdditive = 10;

                //activateAttack = false;

                instantiatedlightAttack2 = (GameObject)Instantiate(lightAttack2, transform.position, transform.rotation);

                // After 2 seconds the text is destroyed.
                Destroy(instantiatedlightAttack2.gameObject, 2f);

            }

            if (EventSystem.current.currentSelectedGameObject.name == "LightAttackButton3")
            {
                AttackAnimation();

                StartCoroutine("Attack");

                StartCoroutine("InjureCo");

                attackDamage = 10;

                manaAdditive = 15;

                instantiatedlightAttack3 = (GameObject)Instantiate(lightAttack3, transform.position, transform.rotation);

                // After 2 seconds the text is destroyed.
                Destroy(instantiatedlightAttack3.gameObject, 2f);

            }

            if (EventSystem.current.currentSelectedGameObject.name == "MediumAttackButton1" && MA1Cooldown == false && playerManaScript.currentplayerMana >= 18)
            {
                AttackAnimation();

                MA1Cooldown = true;

                StartCoroutine("Attack");

                StartCoroutine("InjureCo");

                attackDamage = 15;

                manaAdditive = 22;

                manaCost = 18;

                instantiatedmediumAttack1 = (GameObject)Instantiate(mediumAttack1, transform.position, transform.rotation);



               // After 2 seconds the text is destroyed.
               Destroy(instantiatedmediumAttack1.gameObject, 2f);

            }

            if (EventSystem.current.currentSelectedGameObject.name == "MediumAttackButton2" && MA2Cooldown == false && playerManaScript.currentplayerMana >= 26)
            {
                AttackAnimation();

                MA2Cooldown = true;

                StartCoroutine("Attack");

                StartCoroutine("InjureCo");

                attackDamage = 22;

                manaAdditive = 33;

                manaCost = 26;

                instantiatedmediumAttack2 = (GameObject)Instantiate(mediumAttack2, transform.position, transform.rotation);

                // After 2 seconds the text is destroyed.
                Destroy(instantiatedmediumAttack2.gameObject, 2f);

            }

            if (EventSystem.current.currentSelectedGameObject.name == "MediumAttackButton3" && MA3Cooldown == false && playerManaScript.currentplayerMana >= 39)
            {
                AttackAnimation();

                MA3Cooldown = true;

                StartCoroutine("Attack");

                StartCoroutine("InjureCo");

                attackDamage = 30;

                manaAdditive = 45;

                manaCost = 39;

                instantiatedmediumAttack3 = (GameObject)Instantiate(mediumAttack3, transform.position, transform.rotation);

                // After 2 seconds the text is destroyed.
                Destroy(instantiatedmediumAttack3.gameObject, 2f);
                
            }

            if (EventSystem.current.currentSelectedGameObject.name == "HeavyAttackButton" && HACooldown == false && playerManaScript.currentplayerMana >= 65)
            {
                AttackAnimation();

                HACooldown = true;

                StartCoroutine("Attack");

                StartCoroutine("InjureCo");

                attackDamage = 50;

                manaAdditive = 70;

                manaCost = 65;

                instantiatedheavyAttack = (GameObject)Instantiate(heavyAttack, transform.position, transform.rotation);

                // After 2 seconds the text is destroyed.
                Destroy(instantiatedheavyAttack.gameObject, 2f);
                
            }
        }
    }

    void Update()
    {

        playerHealthText.text = "" + playerHealth.playerCurrentHealth;

        if (enemyHealth.enemyCurrentHealth <= 0)
        {

            // ... the enemy is dead.
            enemyHealth.enemyCurrentHealth = 0;
            
        }
        //playerManaText.text = "" + currentplayerMana;

        //Debug.Log(mediumAttack1Cooldown);
        //Debug.Log("" + activateAttack);
    }

    void AttackAnimation()
    {
        playerAnim.SetBool("IsAttacking", true);
    }

    void Cooldowns()
    {
        if (MA1Cooldown == true)
        {
            MA1CooldownButton.SetActive(true);
            mediumAttack1Cooldown -= 1;

            MA1CooldownText.text = "" + mediumAttack1Cooldown;

            if (mediumAttack1Cooldown <= 0)
            {

                MA1Cooldown = false;
                mediumAttack1Cooldown = 4;
                MA1CooldownText.text = "" + mediumAttack1Cooldown;
                MA1CooldownButton.SetActive(false);
            }
        }

        if (MA2Cooldown == true)
        {
            MA2CooldownButton.SetActive(true);
            mediumAttack2Cooldown -= 1;

            MA2CooldownText.text = "" + mediumAttack2Cooldown;

            if (mediumAttack2Cooldown <= 0)
            {

                MA2Cooldown = false;
                mediumAttack2Cooldown = 4;
                MA2CooldownText.text = "" + mediumAttack2Cooldown;
                MA2CooldownButton.SetActive(false);
            }
        }

        if (MA3Cooldown == true)
        {
            MA3CooldownButton.SetActive(true);
            mediumAttack3Cooldown -= 1;

            MA3CooldownText.text = "" + mediumAttack3Cooldown;

            if (mediumAttack3Cooldown <= 0)
            {

                MA3Cooldown = false;
                mediumAttack3Cooldown = 4;
                MA3CooldownText.text = "" + mediumAttack3Cooldown;
                MA3CooldownButton.SetActive(false);
            }
        }

        if (HACooldown == true)
        {

            HACooldownButton.SetActive(true);
            heavyAttackCooldown -= 1;

            HACooldownText.text = "" + heavyAttackCooldown;

            if (heavyAttackCooldown <= 0)
            {

                HACooldown = false;
                heavyAttackCooldown = 6;
                HACooldownText.text = "" + heavyAttackCooldown;
                HACooldownButton.SetActive(true);
            }
        }
    }


    IEnumerator InjureCo()
    {
        yield return new WaitForSeconds(1.3f);
        enemyAnim.SetBool("IsGettingAttacked", true);
        yield return new WaitForSeconds(0.5f);
        enemyAnim.SetBool("IsGettingAttacked", false);
    }

    public IEnumerator Attack()
    {
        Cooldowns();
        activateAttack = false;
        yield return new WaitForSeconds(2f);

        playerAnim.SetBool("IsAttacking", false);

        if (enemyHealth.enemyCurrentHealth > 0)
        {
            // ... damage the player.
            enemyHealth.TakeDamage(attackDamage);
            //Debug.Log("Enemy Health: " + enemyHealth.enemyCurrentHealth);
        }

        if(playerManaScript.currentplayerMana <= 100)
        {
            playerManaScript.ReduceMana(manaCost);
        }

        if(enemyAttackManager.currentEnemyMana <= 100)
        {
            enemyManaScript.AddMana(manaAdditive);
        }
    }
}
