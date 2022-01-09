using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    //Assignables
    public TextMeshProUGUI CoinText;
    public TextMeshProUGUI totalText;
    public deathscreen ds;

    //Variables
    public int CoinsCollected;
    public int TotalCOinsCollectedinlifetime;

    public static ScoreController Instance { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        TotalCOinsCollectedinlifetime = PlayerPrefs.GetInt("TotalCoins");
        Debug.Log(TotalCOinsCollectedinlifetime);
        totalText.text = PlayerPrefs.GetInt("TotalCoins").ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Add()
    {
        CoinsCollected++;
        TotalCOinsCollectedinlifetime++;
        PlayerPrefs.SetInt("TotalCoins", TotalCOinsCollectedinlifetime);
        PlayerPrefs.GetInt("TotalCoins");
        CoinText.text = CoinsCollected.ToString();
        totalText.text = PlayerPrefs.GetInt("TotalCoins").ToString();
    }

    public void DED()
    {
        ds.Coin(CoinsCollected);
        Debug.Log("Called");
    }

    public void sub(int Amtobesubbed)
    {
        //THESE TWO LINES TOOK ME LIKE 2 WEEKS TO DO IN SPACE WHAM WTF
        TotalCOinsCollectedinlifetime -= Amtobesubbed;
        PlayerPrefs.SetInt("TotalCoins", TotalCOinsCollectedinlifetime);
        
    }
}
