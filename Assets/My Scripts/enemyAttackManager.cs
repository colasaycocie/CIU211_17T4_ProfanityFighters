using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyAttackManager : MonoBehaviour {

    GameObject player;
    public GameObject playerModel;
    GameObject enemyModel;
    Animator enemyAnim;
    Animator playerAnim;
    playerHealth playerHealth;                  // Reference to the player's health.
    EnemyHealth enemyHealth;
    public AttackManager attackManager;
    playerMana playerManaScript;
    enemyMana enemyManaScript;

    private int attackDamage;               // The amount of health taken away per attack.
    private int manaAdditive;
    private int manaCost;

    public static int startingEnemyMana = 50;
    public static int currentEnemyMana;
    public Slider manaSlider;
    public Slider playerManaSlider;
    public Text enemyHealthText;
    public Text enemyManaText;

    [Header("Cooldowns")]
    public static int mediumAttack1Cooldown = 4;
    public static int mediumAttack2Cooldown = 4;
    public static int mediumAttack3Cooldown = 4;
    public static int heavyAttackCooldown = 6;
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

    }

    void Start ()
    {
        canAttack = false;
        playerManaScript = FindObjectOfType<playerMana>();
        enemyModel = GameObject.FindGameObjectWithTag("EnemyModel");
        enemyAnim = enemyModel.GetComponent<Animator>();
        playerAnim = playerModel.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<playerHealth>();
        enemyHealth = FindObjectOfType<EnemyHealth>();
        enemyManaScript = FindObjectOfType<enemyMana>();
        //AttackManager = FindObjectOfType<AttackManager>();
    }

	// Update is called once per frame
	void Update ()
    {
        enemyHealthText.text = "" + enemyHealth.enemyCurrentHealth;

        //Debug.Log("RNG: " + randomNum);

        if (AttackManager.activateAttack == false)
        {
            //Debug.Log(AttackManager.activateAttack);

            StartCoroutine("ChooseAttackCo");

            if(canAttack == true)
            {

                RNG();

                if (randomNum == 1)
                {
                    AttackAnimation();

                    instantiatedlightAttack1 = (GameObject)Instantiate(lightAttack1, transform.position, transform.rotation);

                    StartCoroutine("Attack");

                    StartCoroutine("InjureCo");

                    attackDamage = 5;

                    manaAdditive = 7;

                    // After 2 seconds the text is destroyed.
                    Destroy(instantiatedlightAttack1.gameObject, 2f);
                }

                if (randomNum == 2)
                {
                    AttackAnimation();

                    StartCoroutine("Attack");

                    StartCoroutine("InjureCo");

                    attackDamage = 7;

                    manaAdditive = 10;

                    instantiatedlightAttack2 = (GameObject)Instantiate(lightAttack2, transform.position, transform.rotation);


                    // After 2 seconds the text is destroyed.
                    Destroy(instantiatedlightAttack2.gameObject, 2f);
                }

                if (randomNum == 3)
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

                if (randomNum == 4 && MA1Cooldown == false && enemyManaScript.currentEnemyMana >= 18)
                {
                    MA1Cooldown = true;

                    AttackAnimation();

                    StartCoroutine("Attack");

                    StartCoroutine("InjureCo");

                    attackDamage = 15;

                    manaAdditive = 22;

                    manaCost = 18;

                    instantiatedmediumAttack1 = (GameObject)Instantiate(mediumAttack1, transform.position, transform.rotation);

                    // After 2 seconds the text is destroyed.
                    Destroy(instantiatedmediumAttack1.gameObject, 2f);
                }
                else if(AttackManager.activateAttack == false)
                {
                    RNG();
                }

                if (randomNum == 5 && MA2Cooldown == false && enemyManaScript.currentEnemyMana >= 26)
                {
                    MA2Cooldown = true;

                    AttackAnimation();

                    StartCoroutine("Attack");

                    StartCoroutine("InjureCo");

                    attackDamage = 22;

                    manaAdditive = 33;

                    manaCost = 26;

                    instantiatedmediumAttack2 = (GameObject)Instantiate(mediumAttack2, transform.position, transform.rotation);

                    // After 2 seconds the text is destroyed.
                    Destroy(instantiatedmediumAttack2.gameObject, 2f);
                }
                else if (AttackManager.activateAttack == false)
                {
                    RNG();
                }

                if (randomNum == 6 && MA3Cooldown == false && enemyManaScript.currentEnemyMana >= 39)
                {
                    MA3Cooldown = true;

                    AttackAnimation();

                    StartCoroutine("Attack");

                    StartCoroutine("InjureCo");

                    attackDamage = 30;

                    manaAdditive = 45;

                    manaCost = 39;

                    instantiatedmediumAttack3 = (GameObject)Instantiate(mediumAttack3, transform.position, transform.rotation);

                    playerAnim.SetBool("IsGettingAttacked", true);

                    // After 2 seconds the text is destroyed.
                    Destroy(instantiatedmediumAttack3.gameObject, 2f);
                }
                else if (AttackManager.activateAttack == false)
                {
                    RNG();
                }

                if (randomNum == 7 && HACooldown == false && enemyManaScript.currentEnemyMana >= 65)
                {
                    HACooldown = true;

                    AttackAnimation();

                    StartCoroutine("Attack");

                    StartCoroutine("InjureCo");

                    attackDamage = 50;

                    manaAdditive = 70;

                    manaCost = 65;

                    instantiatedheavyAttack = (GameObject)Instantiate(heavyAttack, transform.position, transform.rotation);

                    // After 2 seconds the text is destroyed.
                    Destroy(instantiatedheavyAttack.gameObject, 2f);
                }
                else if (AttackManager.activateAttack == false)
                {
                    RNG();
                }
            }
        }
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

    void AttackAnimation()
    {
        enemyAnim.SetBool("IsAttacking", true);
    }

    IEnumerator InjureCo()
    {
        yield return new WaitForSeconds(1.3f);
        playerAnim.SetBool("IsGettingAttacked", true);
        yield return new WaitForSeconds(0.5f);
        playerAnim.SetBool("IsGettingAttacked", false);
    }

    public IEnumerator ChooseAttackCo()
    {
        yield return new WaitForSeconds(2f);
        if(enemyHealth.enemyCurrentHealth > 0)
        {
            canAttack = true;
        }
    }

    public IEnumerator Attack()
    {
        Cooldowns();

        AttackManager.activateAttack = true;

        yield return new WaitForSeconds(2f);

        enemyAnim.SetBool("IsAttacking", false);

        canAttack = false;

        if (playerHealth.playerCurrentHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage(attackDamage);
            //StopCoroutine("Attack");

        }

        if (currentEnemyMana <= 100)
        {
            enemyManaScript.ReduceMana(manaCost);
        }

        if (playerManaScript.currentplayerMana <= 100)
        {
            playerManaScript.AddMana(manaAdditive);
        }
    }

}
