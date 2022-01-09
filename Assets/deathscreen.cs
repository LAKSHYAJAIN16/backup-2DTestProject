using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class deathscreen : MonoBehaviour
{
    public TextMeshProUGUI timertext;
    public TextMeshProUGUI coinText;
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void TimeOver(string valuetoDisplay)
    {
        timertext.text = "Time Survived - " + valuetoDisplay;
        Debug.Log(valuetoDisplay);
    }
    public void Coin(int coins)
    {
        coinText.text = "Coins Collected - " + coins.ToString();
    }
}
