using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttackManager : MonoBehaviour {

    GameObject player;
    playerHealth playerHealth;                  // Reference to the player's health.
    public AttackManager attackManager;

    private int attackDamage;               // The amount of health taken away per attack.

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

    int randomNum;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<playerHealth>();
        //AttackManager = FindObjectOfType<AttackManager>();
    }
	
    void LateUpdate()
    {

    }

	// Update is called once per frame
	void Update ()
    {

        //Debug.Log(randomNum);

		if(AttackManager.activateAttack == false)
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

                    //AttackManager.activateAttack = true;


                    //canAttack = false;

                    // After 2 seconds the text is destroyed.
                    Destroy(instantiatedlightAttack1.gameObject, 2f);
                }
                else
                {

                }

                if (randomNum == 2)
                {
                    StartCoroutine("Attack");

                    attackDamage = 5;

                    //AttackManager.activateAttack = true;

                    instantiatedlightAttack2 = (GameObject)Instantiate(lightAttack2, transform.position, transform.rotation);

                    //canAttack = false;

                    // After 2 seconds the text is destroyed.
                    Destroy(instantiatedlightAttack2.gameObject, 2f);
                }
                else
                {

                }

                if (randomNum == 3)
                {
                    StartCoroutine("Attack");

                    attackDamage = 5;

                    //AttackManager.activateAttack = true;

                    instantiatedlightAttack3 = (GameObject)Instantiate(lightAttack3, transform.position, transform.rotation);

                    //canAttack = false;

                    // After 2 seconds the text is destroyed.
                    Destroy(instantiatedlightAttack3.gameObject, 2f);
                }
                else
                {

                }

                if (randomNum == 4)
                {
                    StartCoroutine("Attack");

                    attackDamage = 5;

                    //AttackManager.activateAttack = true;

                    instantiatedmediumAttack1 = (GameObject)Instantiate(mediumAttack1, transform.position, transform.rotation);

                    //canAttack = false;

                    // After 2 seconds the text is destroyed.
                    Destroy(instantiatedmediumAttack1.gameObject, 2f);
                }
                else
                {

                }

                if (randomNum == 5)
                {
                    StartCoroutine("Attack");

                    attackDamage = 5;

                    //AttackManager.activateAttack = true;

                    instantiatedmediumAttack2 = (GameObject)Instantiate(mediumAttack2, transform.position, transform.rotation);



                    // After 2 seconds the text is destroyed.
                    Destroy(instantiatedmediumAttack2.gameObject, 2f);
                }
                else
                {

                }

                if (randomNum == 6)
                {
                    StartCoroutine("Attack");

                    attackDamage = 5;

                    //AttackManager.activateAttack = true;

                    instantiatedmediumAttack3 = (GameObject)Instantiate(mediumAttack3, transform.position, transform.rotation);

                    //canAttack = false;

                    // After 2 seconds the text is destroyed.
                    Destroy(instantiatedmediumAttack3.gameObject, 2f);
                }
                else
                {

                }

                if (randomNum == 7)
                {
                    StartCoroutine("Attack");

                    attackDamage = 5;

                    //AttackManager.activateAttack = true;

                    instantiatedheavyAttack = (GameObject)Instantiate(heavyAttack, transform.position, transform.rotation);

                    //canAttack = false;

                    // After 2 seconds the text is destroyed.
                    Destroy(instantiatedheavyAttack.gameObject, 2f);
                }
                else
                {

                }
            }
        }
	}

    void RNG()
    {
        randomNum = Random.Range(1, 7);
    }

    public IEnumerator ChooseAttackCo()
    {
        yield return new WaitForSeconds(2f);
        canAttack = true;

    }

    public IEnumerator Attack()
    {
        AttackManager.activateAttack = true;
        yield return new WaitForSeconds(2f);
        canAttack = false;

        if (playerHealth.playerCurrentHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage(attackDamage);
            Debug.Log("Player Health: " + playerHealth.playerCurrentHealth);
            StopCoroutine("Attack");
        }
    }

}
