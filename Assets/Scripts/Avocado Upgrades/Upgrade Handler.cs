using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeHandler : MonoBehaviour
{
    //creates a list of AvoUpgrades that will be showed in-game
    //the player can buy an upgrade

    [SerializeField] GameObject upgradePrefab;
    [SerializeField] Transform upgradelist;

    private void Start()
    {
        AvoUpgrade[] allAvoUpgrades = Resources.LoadAll<AvoUpgrade>("Upgrades");
        List<AvoUpgrade> upgradeList = new(allAvoUpgrades);

        //Puts the correct item in the correct list
        //Debug.Log("Loading Character Items:");
        foreach (AvoUpgrade upgrade in upgradeList)
        {
            GameObject instantiatedObj = Instantiate(upgradePrefab, upgradelist);

            instantiatedObj.GetComponent<Button>().onClick.AddListener(() => BuyUpgrade());

            instantiatedObj.transform.GetChild(1).GetComponent<TMP_Text>().text = upgrade.upgradeName;
            instantiatedObj.transform.GetChild(2).GetComponent<TMP_Text>().text = $"Costs: {upgrade.upgradeCost} Avocado";
        }
    }

    void BuyUpgrade()
    {
        Debug.Log("me is getting the buys :)");
    }
}
