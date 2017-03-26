using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackCanvasScript : MonoBehaviour {

    public GameObject attackButtonCanvas;
    public GameObject moveTypeSelectionCanvas;

    public void OnClick()
    {
        attackButtonCanvas.SetActive(false);

        moveTypeSelectionCanvas.SetActive(true);
    }

}
