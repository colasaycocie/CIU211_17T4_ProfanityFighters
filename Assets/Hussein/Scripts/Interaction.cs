using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour
{
    public GameObject interactionText;
    public Object sceneToLoad;
    public string levelName;

	void OnTriggerStay ()
    {
        if (Input.GetButtonDown("Interact"))
        { 
                interactionText.SetActive(false);
                SceneManager.LoadScene(levelName);

        }
    }

	void OnTriggerEnter (Collider other)
    {
        interactionText.SetActive(true);
        Debug.Log("activated");
    }

    void OnTriggerExit(Collider other)
    {
        interactionText.SetActive(false);
    }
}
