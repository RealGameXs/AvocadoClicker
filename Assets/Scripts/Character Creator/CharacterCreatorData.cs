using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreatorData : MonoBehaviour
{
    [SerializeField] CustomiserType[] types;

    [SerializeField] Transform tabList;
    [SerializeField] GameObject selectionBarPrefab;

    [SerializeField] Dictionary<string, List<CharacterItem>> categories = new Dictionary<string, List<CharacterItem>>();
    List<int> currentCategoryIndex = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        types = (CustomiserType[])Enum.GetValues(typeof(CustomiserType));

        // Add a new item
        //categories["Potions"].Add("Invisibility Potion");
        // Add a new category
        //categories["Tools"] = new List<string> { "Pickaxe", "Shovel" };

        //generates selection bar content
        CharacterItem[] allCharacterItems = Resources.LoadAll<CharacterItem>("CharacterItems");
        List<CharacterItem> ItemList = new(allCharacterItems);

        //Puts the correct item in the correct list
        //Debug.Log("Loading Character Items:");
        foreach (CharacterItem Item in ItemList)
        {
            if (!categories.ContainsKey(Item._customiserType.ToString()))//if the category does not exist, make one
            {
                categories[Item._customiserType.ToString()] = new List<CharacterItem> { Item };
                //Debug.Log($"New Category! {Item._customiserType} | Added: {Item._name}");
                currentCategoryIndex.Add(0); //for each new category add a new category index
            }
            else//if the category already exists, only add Item
            {
                categories[Item._customiserType.ToString()].Add(Item);
                //Debug.Log($"Added: {Item._name} to the existing {Item._customiserType} Category");
            }
        }

        int index = 0;
        //Debug.Log("-----------");
        //Debug.Log("List of Character Item Categories:");
        foreach (var category in categories)
        {
            //Debug.Log(category.Key + " has " + category.Value.Count + " items.");

            GameObject InstantiatedGameobject = Instantiate(selectionBarPrefab, tabList);

            InstantiatedGameobject.transform.GetChild(1).GetComponent<TMP_Text>().text = category.Key;


            TMP_Text currentItemName = InstantiatedGameobject.transform.GetChild(2).GetComponent<TMP_Text>();
            if (currentItemName)
            {
                var indexCategory = categories.ElementAt(index);
                CharacterItem firstItem = indexCategory.Value[0];
                currentItemName.text = firstItem._name;
            }

            int generatedIndex = index;

            //Button btnLeft = InstantiatedGameobject.transform.GetChild(3).GetComponent<Button>();
            //Button btnRight = InstantiatedGameobject.transform.GetChild(4).GetComponent<Button>();
            InstantiatedGameobject.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(() => CharacterItemChange("Left", currentItemName, generatedIndex)); //Generates Left button properties
            InstantiatedGameobject.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(() => CharacterItemChange("Right", currentItemName, generatedIndex)); //Generates Left button properties
            index++;
        }
    }

    private void CharacterItemChange(string LeftOrRight, TMP_Text currentItemName, int index)
    {
        var currentCategory = categories.ElementAt(index);

        if (LeftOrRight == "Left")
        {
            if (currentCategoryIndex[index] == 0)
            {
                
                currentCategoryIndex[index] = currentCategory.Value.Count - 1;
            }
            else
            {
                currentCategoryIndex[index]--;
            }
        }
        else
        {
            if (currentCategoryIndex[index] == currentCategory.Value.Count - 1)
            {
                currentCategoryIndex[index] = 0;
            }
            else
            {
                currentCategoryIndex[index]++;
            }
        }

        if (currentItemName)
        {
            var indexCategory = categories.ElementAt(index);
            CharacterItem firstItem = indexCategory.Value[currentCategoryIndex[index]];
            currentItemName.text = firstItem._name;
        }
    }
}
