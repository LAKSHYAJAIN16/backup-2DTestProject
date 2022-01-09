using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    //Text Vars(Display)
    public TextMeshProUGUI text;
    public TextMeshProUGUI Status;
    public GameObject textGO;
    public GameObject Shield;

    float currenttime = 0f;
    public float startingtime = 10f;
    public GameObject NormalImage;
    public GameObject TimerImage;
    private int canUseShield;
    private int isDoing;

    public float duration = 5f;

    public PlayerHelath Player;


    //Powerup
    public void Powered()
    {
        startingtime = 4f;
    }
    void Start()
    {
        Invoke("StartNow", 0.0001f);
    }

    void StartNow()
    {
        currenttime = startingtime;
        NormalImage.SetActive(false);
        TimerImage.SetActive(true);
        canUseShield = 0;
        isDoing = 0;
    }
    // Update is called once per frame
    void Update()
    {
        currenttime -= 1 * Time.deltaTime;
        text.text = currenttime.ToString("0");

        check();
        ShieldCheck();
    }

    void check()
    {
        if (currenttime <= 0)
        {
            if (isDoing <= 0)
            {
                currenttime = 0;
                Debug.Log("Can");
                NormalImage.SetActive(true);
                textGO.SetActive(false);
                TimerImage.SetActive(false);
                canUseShield++;
                isDoing++;
                Status.text = "READY";
                return;
            }


        }
        else if (currenttime >= 1)
        {
            Status.text = "CHARGING..";
        }

        else if (currenttime <= 0)
        {
            Status.text = "READY";
        }
    }

    void ShieldCheck()
    {
        if (canUseShield >= 1)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SetActive();
            }
        }
        else
        {
            Debug.Log("Can't use shield");
        }
    }


    void SetActive()
    {
        Shield.SetActive(true);
        Invoke("reset", duration);
        Player.enabled = false;
        Player.GetComponent<Animator>().enabled = false;
        Status.gameObject.SetActive(false);
    }
    void reset()
    {
        NormalImage.SetActive(false);
        textGO.SetActive(true);
        Status.gameObject.SetActive(true);
        TimerImage.SetActive(true);
        canUseShield--;
        Player.GetComponent<Animator>().enabled = true;
        isDoing--;
        currenttime = startingtime;
        Shield.SetActive(false);
        Player.enabled = true;
    }
    

}
