using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseOverLight : MonoBehaviour {

    public GameObject mouseOverLightObject;

    public void OnMouseEnter()
    {
        mouseOverLightObject.SetActive(true);
    }

    public void OnMouseExit()
    {
        mouseOverLightObject.SetActive(false);
    }
}
