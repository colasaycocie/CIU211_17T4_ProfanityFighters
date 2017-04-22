using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject interactionCanvas;

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.gameObject.activeInHierarchy == false)
            {
                pauseMenu.SetActive(true);
                interactionCanvas.SetActive(false);

                Time.timeScale = 0;
            }

            else 
            { 
                pauseMenu.SetActive(false);
                interactionCanvas.SetActive(true);

                Time.timeScale = 1;
            }
        }
    }
}