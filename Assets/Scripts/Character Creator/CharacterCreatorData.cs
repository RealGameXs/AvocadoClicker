using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterCreatorData : MonoBehaviour
{
    public static CharacterCreatorData Instance { get; private set; }

    [Tooltip("Hat, Hair, FaceAttributes, FacialHair, BodyColor")]
    [SerializeField] List<Image> avocadoPreviewParts = new();

    [SerializeField] GameObject creationPanel;
    [SerializeField] Transform tabList;
    [SerializeField] GameObject selectionBarPrefab;

    [SerializeField] Dictionary<string, List<CharacterItem>> categories = new();
    private List<int> currentCategoryIndex = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    #region OnSceneSwitch
    void OnEnable()
    {
        // Subscribe to the event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ApplySkinToAvocado();
    }
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        creationPanel.SetActive(false);//hides menu if it is still open

        CustomiserType[] types = (CustomiserType[])Enum.GetValues(typeof(CustomiserType));

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

                SetSkin(index);
                ApplySkinToAvocado();
            }

            int generatedIndex = index;

            //Button btnLeft = InstantiatedGameobject.transform.GetChild(3).GetComponent<Button>();
            //Button btnRight = InstantiatedGameobject.transform.GetChild(4).GetComponent<Button>();
            InstantiatedGameobject.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(() => CharacterItemChange("Left", currentItemName, generatedIndex)); //Generates Left button properties
            InstantiatedGameobject.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(() => CharacterItemChange("Right", currentItemName, generatedIndex)); //Generates Left button properties
            index++;
        }
    }

    void CharacterItemChange(string LeftOrRight, TMP_Text currentItemName, int index)
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

            SetSkin(index);
        }
    }

    void SetSkin(int index)
    {
        var indexCategory = categories.ElementAt(index);
        CharacterItem firstItem = indexCategory.Value[currentCategoryIndex[index]];

        switch (firstItem._customiserType)
        {
            case CustomiserType.Hats:
                avocadoPreviewParts[0].sprite = firstItem._image;
                break;
            case CustomiserType.Hair:
                avocadoPreviewParts[1].sprite = firstItem._image;
                break;
            case CustomiserType.FaceAttributes:
                avocadoPreviewParts[2].sprite = firstItem._image;
                break;
            case CustomiserType.FacialHair:
                avocadoPreviewParts[3].sprite = firstItem._image;
                break;
            case CustomiserType.BodyColor:
                avocadoPreviewParts[4].sprite = firstItem._image;
                break;
        }
    }

    bool open = false;
    public void ToggleSkinMenu()
    {
        open = !open;
        creationPanel.SetActive(open);
    }

    public void ApplySkinToAvocado()
    {
        GameObject avocado = GameObject.FindGameObjectWithTag("Avocado");

        avocado.GetComponent<Image>().sprite = avocadoPreviewParts[4].sprite; //bodycolor
        avocado.transform.GetChild(0).GetComponent<Image>().sprite = avocadoPreviewParts[0].sprite;
    }
}
