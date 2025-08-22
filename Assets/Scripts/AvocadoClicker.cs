using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvocadoClicker : MonoBehaviour
{
    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => ClickEvent());
    }

    public void ClickEvent()
    {
        CurrencyManager.Instance.IncrementCurrency(1f);
    }
}
