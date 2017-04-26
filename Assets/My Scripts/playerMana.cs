using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMana : MonoBehaviour {

    public int startingPlayerMana = 50;
    public int currentplayerMana;

    public Text playerManaText;

    public Slider manaSlider;
    public Slider enemyManaSlider;

    // Use this for initialization
    void Start ()
    {
        currentplayerMana = startingPlayerMana;
    }
	
	// Update is called once per frame
	void Update ()
    {
        playerManaText.text = "" + currentplayerMana;

        if (currentplayerMana > 100)
        {
            currentplayerMana = 100;
        }

        if (currentplayerMana < 0)
        {
            currentplayerMana = 0;
        }
    }

    public void AddMana(int amount)
    {
        // Reduce the current health by the amount of damage sustained.
        currentplayerMana += amount;

        manaSlider.value = currentplayerMana;
    }

    public void ReduceMana(int amount)
    {
        // Reduce the current health by the amount of damage sustained.
        currentplayerMana -= amount;

        manaSlider.value = currentplayerMana;
    }
}
