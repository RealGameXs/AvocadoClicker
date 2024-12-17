using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfessorToggle : MonoBehaviour
{
    public List<GameObject> _ProfessorAssetList = new List<GameObject>();
    private bool _enabled = false;

    private void Start()
    {
        foreach (var _Asset in _ProfessorAssetList)
        {
                _Asset.SetActive(false);
        }
    }
    public void ToggleProfessor()
    {
        foreach (var _Asset in _ProfessorAssetList)
        {
            if (_enabled)
            {
                _Asset.SetActive(false);
            }
            else
            {
                _Asset.SetActive(true);
            }
        }
        _enabled = !_enabled;
    }
}
