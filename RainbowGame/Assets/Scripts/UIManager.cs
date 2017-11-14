using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private Text coinsText;
    private CameraFollow manager;
    private int maxCoins;

    private void Start()
    {
        coinsText = GameObject.Find("CoinsText").GetComponent<Text>();
        manager = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        maxCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    private void Update()
    {
        UpdateCoins();
    }

    private void UpdateCoins()
    {
        coinsText.text = "Coins " + manager.coins + "/" + maxCoins;
    }

    private void SetUIElementsToScreen()
    {
        //Use this function to set the size of the UI elements to fit screen.
    }
}
