using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    public int hasUnlocked1 = 1;
    // Start is called before the first frame update
    void Start()
    {
        Unlocked1();
        hasUnlocked1 = PlayerPrefs.GetInt("Skin1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Unlocked1()
    {
        if (hasUnlocked1 <= 0)
        {
            hasUnlocked1++;
            PlayerPrefs.SetInt("Skin1", hasUnlocked1);
            PlayerPrefs.GetInt("Skin1");
            Debug.Log(PlayerPrefs.GetInt("Skin1"));
        }

        else if(hasUnlocked1 >= 1)
        {
            PlayerPrefs.SetInt("Skin1", hasUnlocked1);
            PlayerPrefs.GetInt("Skin1");
            Debug.Log(PlayerPrefs.GetInt("Skin1"));
        }
    }
}
