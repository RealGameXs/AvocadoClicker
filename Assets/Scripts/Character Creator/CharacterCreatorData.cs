using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreatorData : MonoBehaviour
{
    [SerializeField] List<CharacterItem> CharacterItems = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CharacterItem[] allCharacterItems = Resources.LoadAll<CharacterItem>("CharacterItems");
        List<CharacterItem> ItemList = new(allCharacterItems);

        foreach (CharacterItem Item in ItemList)
        {
            CharacterItems.Add(Item);
            Debug.Log(Item._customiserType);
            Debug.Log(Item._name);
            Debug.Log(Item._image);
        }
    }
}
