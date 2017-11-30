using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour {

    private Button keyboard;
    private Button mouse;
    public int choice;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        keyboard = GameObject.Find("Keyboard").GetComponent<Button>();
        mouse = GameObject.Find("Mouse").GetComponent<Button>();
        keyboard.onClick.AddListener(LoadKeyboard);
        mouse.onClick.AddListener(LoadMouse);
    }

    private void LoadKeyboard()
    {
        choice = 1;
        SceneManager.LoadScene("LAmutan");
    }

    private void LoadMouse()
    {
        choice = 2;
        SceneManager.LoadScene("LAmutan");
    }

}
