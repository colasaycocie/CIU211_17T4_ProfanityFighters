using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject interactionCanvas;
    public GameObject attackCanvas;

    public bool inGame;

    void Start()
    {

        Time.timeScale = 1;
    }

    void Update()
    {
        attackCanvas = GameObject.FindGameObjectWithTag("AttackCanvas");

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.gameObject.activeInHierarchy == false)
            {
                pauseMenu.SetActive(true);
                interactionCanvas.SetActive(false);

                if(inGame)
                {
                    attackCanvas.SetActive(false);
                }

                Time.timeScale = 0;
            }

            else 
            { 
                pauseMenu.SetActive(false);
                interactionCanvas.SetActive(true);


                if (inGame)
                {
                    attackCanvas.SetActive(true);
                }

                Time.timeScale = 1;
            }
        }
    }
}