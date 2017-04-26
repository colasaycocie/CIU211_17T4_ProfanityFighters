using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject interactionCanvas;
    //public Canvas attackCanvas;
    private CanvasGroup attackCanvasObjects;

    public bool inGame;

    void Start()
    {
        //attackCanvas = FindObjectOfType<Canvas>();
        Time.timeScale = 1;


    }

    void Update()
    {
        attackCanvasObjects = FindObjectOfType<CanvasGroup>();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.gameObject.activeInHierarchy == false)
            {
                pauseMenu.SetActive(true);
                interactionCanvas.SetActive(false);

                if(inGame)
                {
                    attackCanvasObjects.interactable = false;
                }

                Time.timeScale = 0;
            }

            else 
            { 
                pauseMenu.SetActive(false);
                interactionCanvas.SetActive(true);


                if (inGame)
                {
                    attackCanvasObjects.interactable = true;
                }

                Time.timeScale = 1;
            }
        }
    }
}