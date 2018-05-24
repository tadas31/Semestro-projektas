using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesScript : MonoBehaviour
{
    private int fullyUpgraded = 5;
    private int maxLives = 3;

    //saves
    public SaveState state;

    //sprites
    public Sprite[] purchasedUpgradesSprites;
    public Sprite[] heartUpdateSprites;
    private Image UpgradesUI;

    //prices
    private Text priceText;
    int price;


    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Shop.gumActive)
        {
            UpgradesUI = GameObject.Find("GumUpgrade").GetComponent<Image>();
            UpgradesUI.sprite = purchasedUpgradesSprites[SaveManager.Instance.ReturnUpgrade()[0]];

            priceText = GameObject.Find("GumPrice").GetComponent<Text>();
            if (SaveManager.Instance.ReturnUpgrade()[0] < fullyUpgraded)
                priceText.text = ((SaveManager.Instance.ReturnUpgrade()[0] + 1) * 20).ToString();
            else
                priceText.text = "Max";
           
        }

        if (Shop.energyBarActive)
        {
            UpgradesUI = GameObject.Find("EnergyBarUpgrade").GetComponent<Image>();
            UpgradesUI.sprite = purchasedUpgradesSprites[SaveManager.Instance.ReturnUpgrade()[1]];

            priceText = GameObject.Find("EnergyBarPrice").GetComponent<Text>();
            if (SaveManager.Instance.ReturnUpgrade()[1] < fullyUpgraded)
                priceText.text = ((SaveManager.Instance.ReturnUpgrade()[1] + 1) * 20).ToString();
            else
                priceText.text = "Max";
        }

        if (Shop.shieldActive)
        {
            UpgradesUI = GameObject.Find("ShieldUpgrade").GetComponent<Image>();
            UpgradesUI.sprite = purchasedUpgradesSprites[SaveManager.Instance.ReturnUpgrade()[2]];

            priceText = GameObject.Find("ShieldPrice").GetComponent<Text>();
            if (SaveManager.Instance.ReturnUpgrade()[2] < fullyUpgraded)
                priceText.text = ((SaveManager.Instance.ReturnUpgrade()[2] + 1) * 20).ToString();
            else
                priceText.text = "Max";
        }

        if (Shop.jumpActive)
        {
            UpgradesUI = GameObject.Find("JumpUpgrade").GetComponent<Image>();
            UpgradesUI.sprite = purchasedUpgradesSprites[SaveManager.Instance.ReturnUpgrade()[3]];

            priceText = GameObject.Find("JumpPrice").GetComponent<Text>();
            if (SaveManager.Instance.ReturnUpgrade()[3] < fullyUpgraded)
                priceText.text = ((SaveManager.Instance.ReturnUpgrade()[3] + 1) * 20).ToString();
            else
                priceText.text = "Max";
        }

        if (Shop.speedActive)
        {
            UpgradesUI = GameObject.Find("SpeedUpgrade").GetComponent<Image>();
            UpgradesUI.sprite = purchasedUpgradesSprites[SaveManager.Instance.ReturnUpgrade()[4]];

            priceText = GameObject.Find("SpeedPrice").GetComponent<Text>();
            if (SaveManager.Instance.ReturnUpgrade()[4] < fullyUpgraded)
                priceText.text = ((SaveManager.Instance.ReturnUpgrade()[4] + 1) * 20).ToString();
            else
                priceText.text = "Max";
        }

        if (Shop.livesActive)
        {
            UpgradesUI = GameObject.Find("LivesUpgrade").GetComponent<Image>();
            UpgradesUI.sprite = heartUpdateSprites[SaveManager.Instance.ReturnUpgrade()[5]];

            priceText = GameObject.Find("LivesPrice").GetComponent<Text>();
            if (SaveManager.Instance.ReturnUpgrade()[5] < maxLives)
                priceText.text = ((SaveManager.Instance.ReturnUpgrade()[5] + 1) * 50).ToString();
            else
                priceText.text = "Max";
        }
    }

    /// <summary>
    /// upgrade gum
    /// </summary>
    public void TaskOnGumButtonPress()
    {
        int price = (SaveManager.Instance.ReturnUpgrade()[0] + 1) * 20;
        if (SaveManager.Instance.ReturnUpgrade()[0] < fullyUpgraded && SaveManager.Instance.ReturnCandy() >= price)
        {
            UpgradesUI = GameObject.Find("GumUpgrade").GetComponent<Image>();
            float time = SaveManager.Instance.ReturnBoostsDuration()[0] + 2;
            SaveManager.Instance.AddUpgrade(0, ++SaveManager.Instance.ReturnUpgrade()[0], time);
            SaveManager.Instance.AddCandy(-price);
        }
    }

    /// <summary>
    /// upgrade energy bar
    /// </summary>
    public void TaskOnEnergyBarButtonPress()
    {
        int price = (SaveManager.Instance.ReturnUpgrade()[1] + 1) * 20;
        if (SaveManager.Instance.ReturnUpgrade()[1] < fullyUpgraded && SaveManager.Instance.ReturnCandy() >= price)
        {
            UpgradesUI = GameObject.Find("EnergyBarUpgrade").GetComponent<Image>();
            float time = SaveManager.Instance.ReturnBoostsDuration()[1] + 2;
            SaveManager.Instance.AddUpgrade(1, ++SaveManager.Instance.ReturnUpgrade()[1], time);
            SaveManager.Instance.AddCandy(-price);
        }
    }

    /// <summary>
    /// upgrade shield
    /// </summary>
    public void TaskOnShieldButtonPress()
    {
        int price = (SaveManager.Instance.ReturnUpgrade()[2] + 1) * 20;
        if (SaveManager.Instance.ReturnUpgrade()[2] < fullyUpgraded && SaveManager.Instance.ReturnCandy() >= price) 
        {
            UpgradesUI = GameObject.Find("ShieldUpgrade").GetComponent<Image>();
            float time = SaveManager.Instance.ReturnBoostsDuration()[2] + 2;
            SaveManager.Instance.AddUpgrade(2, ++SaveManager.Instance.ReturnUpgrade()[2], time);
            SaveManager.Instance.AddCandy(-price);
        }
    }

    /// <summary>
    /// upgrade jump
    /// </summary>
    public void TaskOnJumpButtonPress()
    {
        int price = (SaveManager.Instance.ReturnUpgrade()[3] + 1) * 20;
        if (SaveManager.Instance.ReturnUpgrade()[3] < fullyUpgraded && SaveManager.Instance.ReturnCandy() >= price)
        {
            UpgradesUI = GameObject.Find("JumpUpgrade").GetComponent<Image>();
            float jump = SaveManager.Instance.ReturnCharacterStats()[0] + 50;
            SaveManager.Instance.AddUpgrade(3, ++SaveManager.Instance.ReturnUpgrade()[3], jump);
            SaveManager.Instance.AddCandy(-price);
        }
    }

    /// <summary>
    /// upgrade speed
    /// </summary>
    public void TaskOnSpeedButtonPress()
    {

        int price = (SaveManager.Instance.ReturnUpgrade()[4] + 1) * 20;
        if (SaveManager.Instance.ReturnUpgrade()[4] < fullyUpgraded && SaveManager.Instance.ReturnCandy() >= price)
        {
            UpgradesUI = GameObject.Find("SpeedUpgrade").GetComponent<Image>();
            float speed = SaveManager.Instance.ReturnCharacterStats()[1] - 0.2f;
            float maxSpeed = SaveManager.Instance.ReturnCharacterStats()[3] + 0.5f;
            SaveManager.Instance.AddUpgrade(4, ++SaveManager.Instance.ReturnUpgrade()[4], speed);
            SaveManager.Instance.ChangeMaxSpeed(maxSpeed);
            SaveManager.Instance.AddCandy(-price);
        }
    }

    /// <summary>
    /// upgrades lives
    /// </summary>
    public void TaskOnLivesButtonPress()
    {
        int price = (SaveManager.Instance.ReturnUpgrade()[5] + 1) * 50;
        if (SaveManager.Instance.ReturnUpgrade()[5] < maxLives && SaveManager.Instance.ReturnCandy() >= price)
        {
            UpgradesUI = GameObject.Find("LivesUpgrade").GetComponent<Image>();
            float lives = SaveManager.Instance.ReturnCharacterStats()[2] + 1;
            SaveManager.Instance.AddUpgrade(5, ++SaveManager.Instance.ReturnUpgrade()[5], lives);
            SaveManager.Instance.AddCandy(-price);
        }
    }
}