using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private Text coinsText;
    private CameraFollow manager;
    private int maxCoins;
    private GameObject sliderBar;
    private GameObject sliderIcon;
    public GameObject player;

    private void Start()
    {
        coinsText = GameObject.Find("CoinsText").GetComponent<Text>();
        sliderBar = GameObject.Find("HeightBar");
        sliderIcon = GameObject.Find("Slider");
        manager = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        maxCoins = GameObject.FindGameObjectsWithTag("Coin").Length; 
    }

    private void FixedUpdate()
    {
        UpdateCoins();
        SetUIElementsToScreen();
    }

    private void UpdateCoins()
    {
        coinsText.text = "Coins " + manager.coins + "/" + maxCoins;
    }

    private void SetUIElementsToScreen()
    {
        GameObject.Find("CoinsText").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width);
        GameObject.Find("CoinsText").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height);
        SliderElements();
    }
    private void SliderElements()
    {
        int sW = Screen.width;
        int sH = Screen.height;
        sliderBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width * 0.01f);
        sliderBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height * 0.8f);
        Vector2 sliderBarPosition = new Vector3(-1 * (Screen.width / 2) + (Screen.width * 0.01f), 0);
        sliderBar.GetComponent<RectTransform>().anchoredPosition = sliderBarPosition;

        float sliderBarWidth = sliderBar.GetComponent<RectTransform>().sizeDelta.x;

        sliderIcon.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, sliderBarWidth* 4);
        sliderIcon.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, sliderBarWidth* 4);

        sliderIcon.GetComponent<RectTransform>().anchoredPosition = new Vector2(sliderBarPosition.x + (sliderBarWidth*2.2f), (Screen.height * -0.4f) + SliderHeight());
    }

    private float SliderHeight()
    {
        float playerHeight = player.transform.position.y;
        float heightPercentage = playerHeight / 7f;
        if(heightPercentage > 1)
        {
            heightPercentage = 1.0f;
        }
        return (Screen.height * 0.8f) * heightPercentage;
    }
}
