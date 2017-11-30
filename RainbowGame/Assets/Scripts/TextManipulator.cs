using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManipulator : MonoBehaviour
{

    private GameObject textObject;
    private bool rotateLeft;
    private bool increase;
    private float timePassed;
    private Vector3 origin;

    private void Start()
    {
        textObject = GameObject.Find("Text");
        rotateLeft = true;
        increase = true;
        timePassed = 0;
        origin = textObject.transform.position;
    }

    private void Update()
    {
        Rotate();
        CircleAround();
        ChangeSize();
        timePassed += Time.deltaTime;
        Time.timeScale = 1;
    }

    private void Rotate()
    {
        float z = textObject.transform.rotation.eulerAngles.z;
        if (z >= 345 && z < 346)
        {
            rotateLeft = false;
        }
        else if (z >= 14 && z < 15)
        {
            rotateLeft = true;
        }

        if (rotateLeft)
        {
            Vector3 temp = textObject.transform.rotation.eulerAngles;
            temp -= new Vector3(0, 0, Time.deltaTime * 30);
            textObject.transform.rotation = Quaternion.Euler(temp);
        }
        else
        {
            Vector3 temp = textObject.transform.rotation.eulerAngles;
            temp += new Vector3(0, 0, Time.deltaTime * 30);
            textObject.transform.rotation = Quaternion.Euler(temp);
        }
    }

    private void CircleAround()
    {
        float x = Mathf.Cos(timePassed * 10) * 30;
        float y = Mathf.Sin(timePassed * 10) * 30;
        textObject.transform.position = origin + new Vector3(x, y, 0);
    }

    private void ChangeSize()
    {
        if(increase && textObject.GetComponent<Text>().fontSize < 150)
        {
            textObject.GetComponent<Text>().fontSize += 2;
        }
        else if(!increase && textObject.GetComponent<Text>().fontSize > 50)
        {
            textObject.GetComponent<Text>().fontSize -= 2;
        }

        if(textObject.GetComponent<Text>().fontSize >= 150)
        {
            increase = false;
        }
        if (textObject.GetComponent<Text>().fontSize <= 50)
        {
            increase = true;
        }
    }
}