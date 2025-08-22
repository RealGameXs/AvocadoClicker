using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CustomiserType
{
    Hats,
    Hair,
    FaceAttributes,
    FacialHair,
    BodyColor
}

[CreateAssetMenu(menuName = "Scriptable Objects/Character Item")]
public class CharacterItem : ScriptableObject
{
    public CustomiserType _customiserType;
    public string _name;
    public Sprite _image;
}
