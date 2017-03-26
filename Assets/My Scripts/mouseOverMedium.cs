using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseOverMedium : MonoBehaviour {

    public GameObject mouseOverMediumObject;

    public void OnMouseEnter()
    {
        mouseOverMediumObject.SetActive(true);
    }

    public void OnMouseExit()
    {
        mouseOverMediumObject.SetActive(false);
    }
}
