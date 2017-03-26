using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightButtonScript : MonoBehaviour {

    public GameObject canvasToDisable;
    public GameObject canvasToEnable;
    public GameObject mouseOverDisable;

    public void OnClick()
    {
        canvasToDisable.SetActive(false);

        canvasToEnable.SetActive(true);

        mouseOverDisable.SetActive(false);
    }
}
