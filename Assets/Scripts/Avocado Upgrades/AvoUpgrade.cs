using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Avo-Upgrade")]
public class AvoUpgrade : ScriptableObject
{
    public string upgradeName;
    public int upgradeUnlockLevel;
    public int upgradeCost;
    public Sprite upgradeImage;
}
