using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseOverHeavy : MonoBehaviour {

    public GameObject mouseOverHeavyObject;

    public void OnMouseEnter()
    {
        mouseOverHeavyObject.SetActive(true);
    }

    public void OnMouseExit()
    {
        mouseOverHeavyObject.SetActive(false);
    }
}
