using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance { get; private set; }

    [SerializeField] TMP_Text currencyDisplay;

    public float currency;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (Instance != this)
        {
            Destroy(Instance);
        }
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("ScoreSign");
        currencyDisplay = go.GetComponent<TMP_Text>();
    }

    #region Currency Handling
    public void IncrementCurrency(float incrementAmount)
    {
        currency += incrementAmount;
        updateCurrencyDisplay();
    }

    public void DecrementCurrency(float decrementAmount)
    {
        currency -= decrementAmount;
        updateCurrencyDisplay();
    }

    void updateCurrencyDisplay()
    {
        currencyDisplay.text = currency.ToString();
    }
    #endregion
}
