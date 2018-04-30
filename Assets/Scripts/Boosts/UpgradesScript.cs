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

    //0 - gum, 1 - energy barr, 2 - shield, 3 - jump, 4 - speed, 5 - lives
    private int[] upgradesCount = new int[6];

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
        //upgrade gum
        Shop.gumButton.onClick.RemoveAllListeners();
        Shop.gumButton.onClick.AddListener(TaskOnGumButtonPress);

        //upgrade energy bar
        Shop.energyBarButton.onClick.RemoveAllListeners();
        Shop.energyBarButton.onClick.AddListener(TaskOnEnergyBarButtonPress);

        //upgrade shield
        Shop.shieldButton.onClick.RemoveAllListeners();
        Shop.shieldButton.onClick.AddListener(TaskOnShieldButtonPress);
    }

    /// <summary>
    /// upgrade gum
    /// </summary>
    void TaskOnGumButtonPress()
    {
        if (upgradesCount[0] < fullyUpgraded)
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
    void TaskOnEnergyBarButtonPress()
    {
        if (upgradesCount[1] < fullyUpgraded)
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
    void TaskOnShieldButtonPress()
    {
        if (upgradesCount[2] < fullyUpgraded)
        {
            UpgradesUI = GameObject.Find("ShieldUpgrade").GetComponent<Image>();
            float time = SaveManager.Instance.ReturnBoostsDuration()[2] + 2;
            SaveManager.Instance.AddUpgrade(2, ++SaveManager.Instance.ReturnUpgrade()[2], time);
            UpgradesUI.sprite = purchasedUpgradesSprites[SaveManager.Instance.ReturnUpgrade()[2]];
        }
    }
}