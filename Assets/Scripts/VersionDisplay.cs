using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VersionDisplay : MonoBehaviour
{
    public string version;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform transform in transform)
        {
            if (transform.gameObject.TryGetComponent<TMP_Text>(out var text))
            {
                text.text = version;
            }
        }
    }
}
