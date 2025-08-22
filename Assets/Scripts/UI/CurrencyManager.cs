using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance { get; private set; }

    [SerializeField] TMP_Text currencyDisplay;

    public float currency;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

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
    private void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("ScoreSign");
        currencyDisplay = go.GetComponent<TMP_Text>();
    }

    void OnEnable()
    {
        // Subscribe to the event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene Switch");
        GameObject go = GameObject.FindGameObjectWithTag("ScoreSign");
        if (go) currencyDisplay = go.GetComponent<TMP_Text>();

        UpdateCurrencyDisplay();
    }

    #region Currency Handling
    public void IncrementCurrency(float incrementAmount)
    {
        currency += incrementAmount;
        UpdateCurrencyDisplay();
    }

    public void DecrementCurrency(float decrementAmount)
    {
        currency -= decrementAmount;
        UpdateCurrencyDisplay();
    }

    void UpdateCurrencyDisplay()
    {
        if (currencyDisplay) currencyDisplay.text = currency.ToString();
    }
    #endregion
}
