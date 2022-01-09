using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonInfoSUmmerBreak : MonoBehaviour
{
    public int Price = 10;
    public TextMeshProUGUI pricetxt;

    [Header("After Click")]
    public GameObject afterPressedTXT;
    public ShopManager shopmanager;
    public ScoreController Sc;
    public GameObject NOtEnoughText;
    private int coinscollected;
    // Start is called before the first frame update
    void Start()
    {
        pricetxt.text = Price.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        coinscollected = ScoreController.Instance.TotalCOinsCollectedinlifetime;
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (coinscollected >= Price)
            {
                Press();
            }

            else
            {
                Debug.Log("DON'T HAVE ENOUGH COPINS FRICK");
                NOtEnoughText.SetActive(true);
                Invoke("noText", 2f);
            }

        }
    }

    private void noText()
    {
        NOtEnoughText.SetActive(false);
    }
    public void Press()
    {
        if (coinscollected >= Price)
        {
            Sc.sub(Price);
            shopmanager.SummerBreak();
            //End
            afterPressedTXT.SetActive(true);
            this.gameObject.SetActive(false);
        }

        else
        {
            Debug.Log("DON'T HAVE ENOUGH COPINS FRICK");
        }
    }

    void OnMouseDown()
    {
        print("Hey there buddy!");
        if (coinscollected >= Price)
        {
            Press();
        }

        else
        {
            Debug.Log("Don't have enough coins, sorry uwu");
        }
    }
}
