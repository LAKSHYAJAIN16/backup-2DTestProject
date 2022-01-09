using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int coinscollected;
    public TextMeshProUGUI balance;

    public xHealth healthx;
    public LifeSave ls;
    public SummerBreak SUmmerBreak;
    public longboi longboi;

    public GameObject Shop;
    public GameObject Endless;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinscollected = ScoreController.Instance.TotalCOinsCollectedinlifetime;
        balance.text = coinscollected.ToString();
    }

    //Medkit(DoubleHealth)
    public void MedKit()
    {
        healthx.enabled = true;
    }
    //Totem(CheatsDeath)
    public void Totem()
    {
        ls.enabled = true;
    }

    //SummerBreak(Decreases Rate)
    public void SummerBreak()
    {
        SUmmerBreak.enabled = true;
    }

    //UI Functions
    public void ToGame()
    {
        Shop.SetActive(false);
        Endless.SetActive(true);
    }

    //LongBoi(Increases Shield duration)
    public void LongBoi()
    {
        longboi.enabled = true;
    }
}
