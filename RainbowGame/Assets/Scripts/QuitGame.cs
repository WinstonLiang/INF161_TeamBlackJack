﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {

    private void Update()
    {
        if(Input.GetButton("Quit"))
        {
            Application.Quit();
        }
    }


}
