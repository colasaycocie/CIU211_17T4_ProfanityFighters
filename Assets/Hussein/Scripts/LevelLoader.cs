using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelLoader : MonoBehaviour
{
    public GameObject Controls;
    public GameObject mainButtons;

    public string selectedLevel;

    public void OnMouseDown()
    {
        if (gameObject.CompareTag("Play"))
            {
            SceneManager.LoadScene(selectedLevel);
            }

        if (gameObject.CompareTag("Controls"))
        {
            Controls.SetActive(true);
            mainButtons.SetActive(false);
        }

        if (gameObject.CompareTag("Return"))
        {
            Controls.SetActive(false);
            mainButtons.SetActive(true);
        }

        if (gameObject.CompareTag("Quit"))
        {
            Application.Quit();
        }
    }
}
