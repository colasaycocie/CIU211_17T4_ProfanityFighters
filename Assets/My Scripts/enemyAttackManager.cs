using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyAttackManager : MonoBehaviour {

    GameObject player;
    playerHealth playerHealth;                  // Reference to the player's health.
    EnemyHealth enemyHealth;
    public AttackManager attackManager;

    private int attackDamage;               // The amount of health taken away per attack.
    private int manaAdditive;
    private int manaCost;

    public int startingEnemyMana = 50;
    public static int currentEnemyMana;
    public Slider manaSlider;
    public Slider playerManaSlider;
    public Text enemyHealthText;
    public Text enemyManaText;

    [Header("Cooldowns")]
    public static int mediumAttack1Cooldown = 3;
    public static int mediumAttack2Cooldown = 3;
    public static int mediumAttack3Cooldown = 3;
    public static int heavyAttackCooldown = 5;
    private static bool MA1Cooldown;
    private static bool MA2Cooldown;
    private static bool MA3Cooldown;
    private static bool HACooldown;

    public GameObject MA1CooldownButton;
    public GameObject MA2CooldownButton;
    public GameObject MA3CooldownButton;
    public GameObject HACooldownButton;

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

    [HideInInspector]
    public bool canAttack;

    static int randomNum;

    // Use this for initialization
    void Awake()
    {
        currentEnemyMana = startingEnemyMana;

    }

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<playerHealth>();
        enemyHealth = FindObjectOfType<EnemyHealth>();


        //AttackManager = FindObjectOfType<AttackManager>();
    }

	// Update is called once per frame
	void Update ()
    {
        enemyHealthText.text = "" + enemyHealth.enemyCurrentHealth;
        enemyManaText.text = "" + currentEnemyMana;

        if (currentEnemyMana > 100)
        {
            currentEnemyMana = 100;
        }

        if (currentEnemyMana < 0)
        {
            currentEnemyMana = 0;
        }

        //Debug.Log(randomNum);

        if (AttackManager.activateAttack == false)
        {
            //Debug.Log(AttackManager.activateAttack);


            StartCoroutine("ChooseAttackCo");

            if(canAttack == true)
            {
                RNG();

                if (randomNum == 1)
                {

                    instantiatedlightAttack1 = (GameObject)Instantiate(lightAttack1, transform.position, transform.rotation);

                    StartCoroutine("Attack");

                    attackDamage = 5;

                    manaAdditive = 10;

                    // After 2 seconds the text is destroyed.
                    Destroy(instantiatedlightAttack1.gameObject, 2f);
                }
                else
                {

                }

                if (randomNum == 2)
                {
                    StartCoroutine("Attack");

                    attackDamage = 7;

                    manaAdditive = 14;

                    instantiatedlightAttack2 = (GameObject)Instantiate(lightAttack2, transform.position, transform.rotation);


                    // After 2 seconds the text is destroyed.
                    Destroy(instantiatedlightAttack2.gameObject, 2f);
                }
                else
                {

                }

                if (randomNum == 3)
                {
                    StartCoroutine("Attack");

                    attackDamage = 10;

                    manaAdditive = 20;

                    instantiatedlightAttack3 = (GameObject)Instantiate(lightAttack3, transform.position, transform.rotation);

                    // After 2 seconds the text is destroyed.
                    Destroy(instantiatedlightAttack3.gameObject, 2f);
                }
                else
                {

                }

                if (randomNum == 4 && MA1Cooldown == false && currentEnemyMana >= 18)
                {
                    MA1Cooldown = true;

                    StartCoroutine("Attack");

                    attackDamage = 15;

                    manaAdditive = 22;

                    manaCost = 18;

                    instantiatedmediumAttack1 = (GameObject)Instantiate(mediumAttack1, transform.position, transform.rotation);

                    // After 2 seconds the text is destroyed.
                    Destroy(instantiatedmediumAttack1.gameObject, 2f);
                }
                else
                {
                    RNG();
                }

                if (randomNum == 5 && MA2Cooldown == false && currentEnemyMana >= 26)
                {
                    MA2Cooldown = true;

                    StartCoroutine("Attack");

                    attackDamage = 22;

                    manaAdditive = 33;

                    manaCost = 26;

                    instantiatedmediumAttack2 = (GameObject)Instantiate(mediumAttack2, transform.position, transform.rotation);

                    // After 2 seconds the text is destroyed.
                    Destroy(instantiatedmediumAttack2.gameObject, 2f);
                }
                else
                {
                    RNG();
                }

                if (randomNum == 6 && MA3Cooldown == false && currentEnemyMana >= 39)
                {
                    MA3Cooldown = true;

                    StartCoroutine("Attack");

                    attackDamage = 30;

                    manaAdditive = 45;

                    manaCost = 39;

                    instantiatedmediumAttack3 = (GameObject)Instantiate(mediumAttack3, transform.position, transform.rotation);

                    // After 2 seconds the text is destroyed.
                    Destroy(instantiatedmediumAttack3.gameObject, 2f);
                }
                else
                {
                    RNG();
                }

                if (randomNum == 7 && HACooldown == false && currentEnemyMana >= 65)
                {
                    HACooldown = true;

                    StartCoroutine("Attack");

                    attackDamage = 50;

                    manaAdditive = 70;

                    manaCost = 65;

                    instantiatedheavyAttack = (GameObject)Instantiate(heavyAttack, transform.position, transform.rotation);

                    // After 2 seconds the text is destroyed.
                    Destroy(instantiatedheavyAttack.gameObject, 2f);
                }
                else
                {
                    RNG();
                }
            }
        }
	}

    public void AddMana(int amount)
    {
        // If the enemy is dead...
        //if (isDead)
        // ... no need to take damage so exit the function.
        //return;

        // Reduce the current health by the amount of damage sustained.
        currentEnemyMana += amount;

        manaSlider.value = currentEnemyMana;

    }

    public void ReduceMana(int amount)
    {
        // If the enemy is dead...
        //if (isDead)
        // ... no need to take damage so exit the function.
        //return;

        // Reduce the current health by the amount of damage sustained.
        currentEnemyMana -= amount;

        manaSlider.value = currentEnemyMana;
    }

    void RNG()
    {
        randomNum = Random.Range(1, 7);
    }

    void Cooldowns()
    {
        if (MA1Cooldown == true)
        {

            mediumAttack1Cooldown -= 1;

            if (mediumAttack1Cooldown <= 0)
            {

                MA1Cooldown = false;
                mediumAttack1Cooldown = 3;

            }
        }

        if (MA2Cooldown == true)
        {

            mediumAttack2Cooldown -= 1;

            if (mediumAttack2Cooldown <= 0)
            {

                MA2Cooldown = false;
                mediumAttack2Cooldown = 2;

            }
        }

        if (MA3Cooldown == true)
        {

            mediumAttack3Cooldown -= 1;

            if (mediumAttack3Cooldown <= 0)
            {

                MA3Cooldown = false;
                mediumAttack3Cooldown = 2;

            }
        }

        if (HACooldown == true)
        {

            heavyAttackCooldown -= 1;

            if (heavyAttackCooldown <= 0)
            {

                HACooldown = false;
                heavyAttackCooldown = 5;

            }
        }
    }

    public IEnumerator ChooseAttackCo()
    {
        yield return new WaitForSeconds(2f);
        canAttack = true;

    }

    public IEnumerator Attack()
    {
        Cooldowns();

        AttackManager.activateAttack = true;
        yield return new WaitForSeconds(2f);
        canAttack = false;

        if (playerHealth.playerCurrentHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage(attackDamage);
            Debug.Log("Player Health: " + playerHealth.playerCurrentHealth);
            //StopCoroutine("Attack");

        }

        if (currentEnemyMana <= 100)
        {
            ReduceMana(manaCost);
        }

        if (AttackManager.currentplayerMana <= 100)
        {
            attackManager.AddMana(manaAdditive);
        }
    }

}
