using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectScheme : MonoBehaviour {

    private void Awake()
    {
        if (!GameObject.Find("Settings"))
        {
            GameObject.Find("testPlayer").GetComponent<ChaseMouse>().enabled = false;
        }
        else if(GameObject.Find("Settings").GetComponent<LoadGame>().choice == 1)
        {
            GameObject.Find("testPlayer").GetComponent<ChaseMouse>().enabled = false;
        }
        else if(GameObject.Find("Settings").GetComponent<LoadGame>().choice == 2)
        {
            GameObject.Find("testPlayer").GetComponent<Movement>().enabled = false;
        }
    }


}
