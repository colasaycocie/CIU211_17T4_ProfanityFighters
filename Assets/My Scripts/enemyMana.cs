using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyMana : MonoBehaviour {

    public int startingEnemyMana = 50;
    public int currentEnemyMana;
    public Slider manaSlider;
    public Slider playerManaSlider;
    public Text enemyManaText;

    // Use this for initialization
    void Start ()
    {
        currentEnemyMana = startingEnemyMana;
    }
	
	// Update is called once per frame
	void Update ()
    {
        enemyManaText.text = "" + currentEnemyMana;

        if (currentEnemyMana > 100)
        {
            currentEnemyMana = 100;
        }

        if (currentEnemyMana < 0)
        {
            currentEnemyMana = 0;
        }
    }

    public void AddMana(int amount)
    {
        // Reduce the current health by the amount of damage sustained.
        currentEnemyMana += amount;

        manaSlider.value = currentEnemyMana;

    }

    public void ReduceMana(int amount)
    {
        // Reduce the current health by the amount of damage sustained.
        currentEnemyMana -= amount;

        manaSlider.value = currentEnemyMana;
    }
}
