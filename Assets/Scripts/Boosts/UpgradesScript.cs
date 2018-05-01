using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesScript : MonoBehaviour
{
    private int fullyUpgraded = 5;

    //saves
    public SaveState state;

    //sprites
    public Sprite[] purchasedUpgradesSprites;
    private Image UpgradesUI;

    // Use this for initialization
    void Start()
    {
        UpgradesUI = GameObject.Find("GumUpgrade").GetComponent<Image>();
        UpgradesUI.sprite = purchasedUpgradesSprites[SaveManager.Instance.ReturnUpgrade()[0]];
        UpgradesUI = GameObject.Find("EnergyBarUpgrade").GetComponent<Image>();
        UpgradesUI.sprite = purchasedUpgradesSprites[SaveManager.Instance.ReturnUpgrade()[1]];
        UpgradesUI = GameObject.Find("ShieldUpgrade").GetComponent<Image>();
        UpgradesUI.sprite = purchasedUpgradesSprites[SaveManager.Instance.ReturnUpgrade()[2]];
    }

    // Update is called once per frame
    void Update()
    {
        if (Shop.jumpActive)
        {
            UpgradesUI = GameObject.Find("JumpUpgrade").GetComponent<Image>();
            UpgradesUI.sprite = purchasedUpgradesSprites[SaveManager.Instance.ReturnUpgrade()[3]];
        }

        if (Shop.speedActive)
        {
            UpgradesUI = GameObject.Find("SpeedUpgrade").GetComponent<Image>();
            UpgradesUI.sprite = purchasedUpgradesSprites[SaveManager.Instance.ReturnUpgrade()[4]];
        }

        if (Shop.livesActive)
        {
            UpgradesUI = GameObject.Find("LivesUpgrade").GetComponent<Image>();
            UpgradesUI.sprite = purchasedUpgradesSprites[SaveManager.Instance.ReturnUpgrade()[5]];
        }
    }

    /// <summary>
    /// upgrade gum
    /// </summary>
    public void TaskOnGumButtonPress()
    {
        if (SaveManager.Instance.ReturnUpgrade()[0] < fullyUpgraded)
        {
            UpgradesUI = GameObject.Find("GumUpgrade").GetComponent<Image>();
            float time = SaveManager.Instance.ReturnBoostsDuration()[0] + 2;
            SaveManager.Instance.AddUpgrade(0, ++SaveManager.Instance.ReturnUpgrade()[0], time);
            UpgradesUI.sprite = purchasedUpgradesSprites[SaveManager.Instance.ReturnUpgrade()[0]];
        }
    }

    /// <summary>
    /// upgrade energy bar
    /// </summary>
    public void TaskOnEnergyBarButtonPress()
    {
        if (SaveManager.Instance.ReturnUpgrade()[1] < fullyUpgraded)
        {
            UpgradesUI = GameObject.Find("EnergyBarUpgrade").GetComponent<Image>();
            float time = SaveManager.Instance.ReturnBoostsDuration()[1] + 2;
            SaveManager.Instance.AddUpgrade(1, ++SaveManager.Instance.ReturnUpgrade()[1], time);
            UpgradesUI.sprite = purchasedUpgradesSprites[SaveManager.Instance.ReturnUpgrade()[1]];
        }
    }

    /// <summary>
    /// upgrade shield
    /// </summary>
    public void TaskOnShieldButtonPress()
    {
        if (SaveManager.Instance.ReturnUpgrade()[2] < fullyUpgraded)
        {
            UpgradesUI = GameObject.Find("ShieldUpgrade").GetComponent<Image>();
            float time = SaveManager.Instance.ReturnBoostsDuration()[2] + 2;
            SaveManager.Instance.AddUpgrade(2, ++SaveManager.Instance.ReturnUpgrade()[2], time);
            UpgradesUI.sprite = purchasedUpgradesSprites[SaveManager.Instance.ReturnUpgrade()[2]];
        }
    }

    /// <summary>
    /// upgrade jump
    /// </summary>
    public void TaskOnJumpButtonPress()
    {
        if (SaveManager.Instance.ReturnUpgrade()[3] < fullyUpgraded)
        {
            UpgradesUI = GameObject.Find("JumpUpgrade").GetComponent<Image>();
            float jump = SaveManager.Instance.ReturnCharacterStats()[0] + 10;
            SaveManager.Instance.AddUpgrade(3, ++SaveManager.Instance.ReturnUpgrade()[3], jump);
        }
    }

    /// <summary>
    /// upgrade speed
    /// </summary>
    public void TaskOnSpeedButtonPress()
    {

        if (SaveManager.Instance.ReturnUpgrade()[4] < fullyUpgraded)
        {
            UpgradesUI = GameObject.Find("SpeedUpgrade").GetComponent<Image>();
            float jump = SaveManager.Instance.ReturnCharacterStats()[1] - 0.1f;
            SaveManager.Instance.AddUpgrade(4, ++SaveManager.Instance.ReturnUpgrade()[4], jump);
        }
    }

    /// <summary>
    /// upgrades lives
    /// </summary>
    public void TaskOnLivesButtonPress()
    {
        if (SaveManager.Instance.ReturnUpgrade()[5] < fullyUpgraded)
        {
            UpgradesUI = GameObject.Find("LivesUpgrade").GetComponent<Image>();
            float lives = SaveManager.Instance.ReturnCharacterStats()[2] + 1;
            SaveManager.Instance.AddUpgrade(5, ++SaveManager.Instance.ReturnUpgrade()[5], lives);
        }
    }
}