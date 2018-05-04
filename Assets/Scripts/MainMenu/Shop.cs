using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    //saves
    private Text candyCount;

    //popups
    private Image jumpUpgradePopup;
    private Image speedUpgradePopup;
    private Image livesUpgradePopup;
    private Image gumUpgradePopup;
    private Image energyBarUpgradePopup;
    private Image shieldUpgradePopup;

    //boosts buttons
    private Button gumUpgrade;
    private Button energyBarUpgrade;
    private Button shieldUpgrade;
    private Button jumpUpgrade;
    private Button speedUpgrade;
    private Button livesUpgrade;

    public static bool gumActive;
    public static bool energyBarActive;
    public static bool shieldActive;
    public static bool jumpActive;
    public static bool speedActive;
    public static bool livesActive;


    // Use this for initialization
    void Start () {

        gumActive = true;
        energyBarActive = true;
        shieldActive = true;
        jumpActive = false;
        speedActive = false;
        livesActive = false;

        candyCount = GameObject.Find("ShopCandy").GetComponentInChildren<Text>();


        //get popups
        jumpUpgradePopup = GameObject.Find("JumpUpgradePopup").GetComponent<Image>();
        jumpUpgradePopup.gameObject.SetActive(false);
        speedUpgradePopup = GameObject.Find("SpeedUpgradePopup").GetComponent<Image>();
        speedUpgradePopup.gameObject.SetActive(false);
        livesUpgradePopup = GameObject.Find("LivesUpgradePopup").GetComponent<Image>();
        livesUpgradePopup.gameObject.SetActive(false);
        gumUpgradePopup = GameObject.Find("GumUpgradePopup").GetComponent<Image>();
        energyBarUpgradePopup = GameObject.Find("EnergyBarUpgradePopup").GetComponent<Image>();
        shieldUpgradePopup = GameObject.Find("ShieldUpgradePopup").GetComponent<Image>();

        //get /boosts buttons
        jumpUpgrade = GameObject.Find("JumpBoost").GetComponent<Button>();
        speedUpgrade = GameObject.Find("SpeedBoost").GetComponent<Button>();
        livesUpgrade = GameObject.Find("LivesBoost").GetComponent<Button>();
        gumUpgrade = GameObject.Find("GumBoost").GetComponent<Button>();
        energyBarUpgrade = GameObject.Find("EnergyBarBoost").GetComponent<Button>();
        shieldUpgrade = GameObject.Find("ShieldBoost").GetComponent<Button>();
}
	
	// Update is called once per frame
	void Update () {
        candyCount.text = SaveManager.Instance.ReturnCandy().ToString();


        //opens jump popup
        jumpUpgrade.onClick.RemoveAllListeners();
        jumpUpgrade.onClick.AddListener(TaskOnJumpPress);
        //opens speed popup
        speedUpgrade.onClick.RemoveAllListeners();
        speedUpgrade.onClick.AddListener(TaskOnSpeedPress);
        //opens lives popup
        livesUpgrade.onClick.RemoveAllListeners();
        livesUpgrade.onClick.AddListener(TaskOnLivesPress);
        //opens gum popup
        gumUpgrade.onClick.RemoveAllListeners();
        gumUpgrade.onClick.AddListener(TaskOnGumPress);
        //opens energy bar popup
        energyBarUpgrade.onClick.RemoveAllListeners();
        energyBarUpgrade.onClick.AddListener(TaskOnEnergyBarPress);
        //opens shield popup
        shieldUpgrade.onClick.RemoveAllListeners();
        shieldUpgrade.onClick.AddListener(TaskOnShieldPress);

    }

    /// <summary>
    /// gum popup
    /// </summary>
    void TaskOnGumPress()
    {
        gumUpgradePopup.gameObject.SetActive(true);
        jumpUpgradePopup.gameObject.SetActive(false);
        jumpActive = false;
        gumActive = true;
    }

    /// <summary>
    /// energy bar popup
    /// </summary>
    void TaskOnEnergyBarPress()
    {
        energyBarUpgradePopup.gameObject.SetActive(true);
        speedUpgradePopup.gameObject.SetActive(false);
        speedActive = false;
        energyBarActive = true;
    }

    /// <summary>
    /// shield popup
    /// </summary>
    void TaskOnShieldPress()
    {
        shieldUpgradePopup.gameObject.SetActive(true);
        livesUpgradePopup.gameObject.SetActive(false);
        livesActive = false;
        shieldActive = true;
    }

    /// <summary>
    /// opens jump popup
    /// </summary>
    void TaskOnJumpPress()
    {
        jumpUpgradePopup.gameObject.SetActive(true);
        gumUpgradePopup.gameObject.SetActive(false);
        jumpActive = true;
        gumActive = false;
    }

    /// <summary>
    /// speed popup
    /// </summary>
    void TaskOnSpeedPress()
    {
        speedUpgradePopup.gameObject.SetActive(true);
        energyBarUpgradePopup.gameObject.SetActive(false);
        speedActive = true;
        energyBarActive = false;
    }

    /// <summary>
    /// lives popup
    /// </summary>
    void TaskOnLivesPress()
    {
        livesUpgradePopup.gameObject.SetActive(true);
        shieldUpgradePopup.gameObject.SetActive(false);
        livesActive = true;
        shieldActive = false;
    }
}
