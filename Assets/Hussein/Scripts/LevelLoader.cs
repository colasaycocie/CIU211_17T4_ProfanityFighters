using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelLoader : MonoBehaviour
{
    public GameObject Controls;
    public GameObject mainButtons;
    public GameObject mainSpeechBubbles;
    public GameObject controlsSpeechBubbles;

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

            // disables main speech bubbles
            mainSpeechBubbles.SetActive(false);
            // activates controls speech bubbles
            controlsSpeechBubbles.SetActive(true);
        }

        if (gameObject.CompareTag("Return"))
        {
            Controls.SetActive(false);
            mainButtons.SetActive(true);

            // acitvates main speech bubbles
            mainSpeechBubbles.SetActive(true);
            // disables controls speech bubbles
            controlsSpeechBubbles.SetActive(false);
        }

        if (gameObject.CompareTag("Quit"))
        {
            Application.Quit();
        }
    }
}
