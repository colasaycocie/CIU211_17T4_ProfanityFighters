using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackManager : MonoBehaviour {

    public GameObject lightAttack1;
    private GameObject instantiatedlightAttack1;
    public GameObject lightAttack2;
    private GameObject instantiatedlightAttack2;
    public GameObject lightAttack3;
    private GameObject instantiatedlightAttack3;


    public void OnClick()
    {
        if(EventSystem.current.currentSelectedGameObject.name == "LightAttackButton1")
        {
            instantiatedlightAttack1 = (GameObject)Instantiate(lightAttack1, transform.position, transform.rotation);
        }
        if (EventSystem.current.currentSelectedGameObject.name == "LightAttackButton2")
        {
            instantiatedlightAttack2 = (GameObject)Instantiate(lightAttack2, transform.position, transform.rotation);
        }
        if (EventSystem.current.currentSelectedGameObject.name == "LightAttackButton3")
        {
            instantiatedlightAttack3 = (GameObject)Instantiate(lightAttack3, transform.position, transform.rotation);
        }
    }

    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject.name == "LightAttackButton1")
        {
            Destroy(instantiatedlightAttack1.gameObject, 2f);
        }
        if (EventSystem.current.currentSelectedGameObject.name == "LightAttackButton2")
        {
            Destroy(instantiatedlightAttack2.gameObject, 2f);
        }
        if (EventSystem.current.currentSelectedGameObject.name == "LightAttackButton3")
        {
            Destroy(instantiatedlightAttack3.gameObject, 2f);
        }
    }
}
