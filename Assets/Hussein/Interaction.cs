using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour
{
    public GameObject interactionText;
    public Object sceneToLoad;

	void OnTriggerStay ()
    {
        if (Input.GetButtonDown("Fire1"))
        { 
                interactionText.SetActive(false);
                SceneManager.LoadScene(sceneToLoad.name);

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
