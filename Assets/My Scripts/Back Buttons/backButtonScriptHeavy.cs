﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backButtonScriptHeavy : MonoBehaviour {

    public GameObject canvasToDisable;
    public GameObject canvasToEnable;

    public void OnClick()
    {
        canvasToDisable.SetActive(false);

        canvasToEnable.SetActive(true);
    }
}
